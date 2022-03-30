using System;
using System.Collections.Generic;
using System.Linq;
using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Enums;
using QWERTY.Shared.Helpers;
using static QWERTY.Shared.Enums.БуквенныеКодыТиповЗаявок;

namespace QWERTY.Shared.Models._Создатель
{
    public partial class Создатель<T> where T : ДанныеИзФормы
    {
        /// <summary>
        /// Создание заявки определенного типа
        /// </summary>
        /// <param name="буквКодТипаЗаявки"></param>
        /// <param name="requestParams"></param>
        /// <param name="родительскаяЗаявка"></param>
        /// <returns>Созданная заявка</returns>
        /// <exception cref="ArgumentNullException">Бросает исключение, если не верные входные данные</exception>
        /// <exception cref="Exception">Бросат исключение, если заявка не создана</exception>
        public REQUEST СоздатьЗаявкуПоИмениТипа
        (
            string буквКодТипаЗаявки,
            RequestParams requestParams,
            REQUEST? родительскаяЗаявка
        )
        {
            if (буквКодТипаЗаявки == null) throw new ArgumentNullException(nameof(буквКодТипаЗаявки));
            if (requestParams == null) throw new ArgumentNullException(nameof(requestParams));

            try
            {
                
                var идТипаЗаявки = (
                        CommonService.ПолучитьТипЗаявкиПоИмениТипа(буквКодТипаЗаявки)
                        ?? throw new ArgumentNullException(
                            $"CommonService.ПолучитьТипЗаявкиПоИмениТипа(\"{буквКодТипаЗаявки}\")?.id"))
                    .id;
                
                var идПользователяПолучателяУслуги =
                    requestParams.recipient_login != null
                        ? CommonService.ПолучитьПользователяПоЛогину(requestParams!.recipient_login)!.id
                        : ПользовательСервиса?.id ?? throw new ArgumentNullException(nameof(ПользовательСервиса.id));
                
                if (requestParams.request_state_id == null) throw new ArgumentNullException(nameof(requestParams.request_state_id));
                var идТекущегоСтатусаЗаявки = CommonService
                    .ПолучитьСтатусЗаявкиПоИд((int) requestParams.request_state_id)?
                    .id;

                var регистрационныйНомер = requestParams.reg_number ?? Guid.NewGuid().ToString();
                
                var заявка = CommonService?.Создать(
                    new REQUEST
                    {
                        id_request_type = идТипаЗаявки,
                        date_1 = requestParams.create_date_time ?? DateTime.Now,
                        date_2 = requestParams.end_date_time ?? null,
                        id_user_1 = ПользовательСервиса!.id,
                        id_user_2 = идПользователяПолучателяУслуги,
                        id_request_state = (int) идТекущегоСтатусаЗаявки,
                        // todo: документ догружается позже
                        id_doc = null, 
                        reg_num = регистрационныйНомер,
                        parent = родительскаяЗаявка?.id,
                        id = 0,
                    });
                
                CommonService?.Коммитнуть(typeof(REQUEST));

                if (заявка == null || заявка?.id < 1) throw new Exception($"{буквКодТипаЗаявки} не создана");
            
                Log.Info($"Заявка типа [{буквКодТипаЗаявки}] с id={заявка!.id} успешно создана");
                return заявка;
            }
            catch (Exception e)
            {
                Ошибка = e;
                throw;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="идЗаявка"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public List<REQUEST> ОткатитьВсеСозданныеЗаявки(int? идЗаявка)
        {
            var requests = new List<REQUEST>();
            try
            {
                if (идЗаявка == null || идЗаявка < 1) throw new ArgumentOutOfRangeException(nameof(идЗаявка));
                
                var родительскаяЗаявка = CommonService.ПолучитьЗаявкуПоИд((int) идЗаявка) 
                                         ?? throw new ArgumentNullException
                                             (nameof(ОткатитьВсеСозданныеЗаявки)+" | родительскаяЗаявка не найдена");
                
                requests.Add(родительскаяЗаявка);
                
                Log.Warn($"Начинается ROLLBACK подчиненных заявок для заявки с id={идЗаявка}");
                
                // получаем все подчиненные заявки
                var подчиненныеЗаявки = 
                    CommonService.ПолучитьЗаявкиИзПредставления(r => r.parent == родительскаяЗаявка.id);
                
                foreach (var r in подчиненныеЗаявки)
                {
                    var получитьЗаявкуПоИд = 
                        CommonService.ПолучитьЗаявкуПоИд(r.id_request)
                        ?? throw new ArgumentNullException($"CommonService.ПолучитьЗаявкуПоИд({r.id_request})");
                    
                    requests.Add(получитьЗаявкуПоИд);
                    
                    СменитьСтатусЗаявки(
                        получитьЗаявкуПоИд,
                        БуквенныеКодыСтатусовЗаявок.ROLLBACKED);
                }
                
                СменитьСтатусЗаявки(родительскаяЗаявка, БуквенныеКодыСтатусовЗаявок.ROLLBACKED);
                
                Log.Warn($"ROLLBACK для заявки id={идЗаявка} завершен");
                
            }
            catch (Exception e)
            {
                Ошибка = e;
                throw;
            }

            return requests;
        }


        public REQUEST СменитьСтатусЗаявки(REQUEST? request, string буквенныйКодСтатусаЗаявки)
        {
            try
            {
                if (request is null) throw new ArgumentNullException(
                    $"Имя параметра: {nameof(request)}, имя метода: {nameof(СменитьСтатусЗаявки)}");
                
                var старыйСтатусЗаявки = CommonService.ПолучитьСтатусЗаявкиПоИд(request.id_request_state);
                    
                request.date_2 = DateTime.Now;
                request.id_request_state =
                    CommonService.ПолучитьСтатусЗаявкиПоКоду(буквенныйКодСтатусаЗаявки).id;
                    
                CommonService.Обновить(request);
                CommonService.Коммитнуть(typeof(REQUEST));   
                
                Log.Warn($"Заявка id={request.id} сменила статус с [{старыйСтатусЗаявки?.code}] на [{буквенныйКодСтатусаЗаявки}]");
                
            }
            catch (Exception e)
            {
                Ошибка = e;
                throw;
            }

            return request;
        }

        public void ИсполнитьЗаявкуСоОпределеннымСтатусом(REQUEST? request, int идНовогоСтатусаЗаявки)
        {
            List<REQUEST> requests = new List<REQUEST>();
            
            try
            {
                if (request is null) throw new ArgumentNullException(
                    $"Имя параметра: {nameof(request)}, имя метода: {nameof(СменитьСтатусЗаявки)}");

                
                
                /*var кодТипаЗаявки = CommonService
                                        .ПолучитьТипЗаявкиПоИд(request.ид_типа_заявки)?
                                        .code
                                    ?? throw new ArgumentNullException(nameof(идНовогоСтатусаЗаявки));*/
                
                var новыйКодСтатусаЗаявки = CommonService
                    .ПолучитьСтатусЗаявкиПоИд(идНовогоСтатусаЗаявки)
                    ?.code ?? "<код не известен>";
                
                var дочерниеЗаявки = (
                        CommonService.ПолучитьДочерниеЗаявки(request.id)
                        ?? Array.Empty<REQUEST>()
                    ).ToList();

                foreach (var дочЗаявка in дочерниеЗаявки)
                {
                    СменитьСтатусЗаявки(дочЗаявка, новыйКодСтатусаЗаявки);
                    requests.Add(дочЗаявка);
                }
                
                СменитьСтатусЗаявки(request, новыйКодСтатусаЗаявки);
                requests.Add(request);
                
                Result = JsonHelper.СоздатьJsonМодель(
                    new
                    {
                        _requests = requests?.ConvertAll(m 
                            => new
                            {
                                _request = new
                                {
                                    m.id,
                                    date_1 = m.date_1,
                                    date_2 = m.date_2,
                                    id_request_state = m.id_request_state
                                }   
                            } 
                        ),
                    },
                    Ошибка,
                    $"Статус заявки id={request.id} и её дочерних заявок успешно изменен"
                );
            }
            catch (Exception e)
            {
                Ошибка = e;
                throw;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="doc"></param>
        public void ДобавитьДокументВоЗаявку(REQUEST request, DOC? doc)
        {
            try
            {
                if (request is null) throw new ArgumentNullException(
                    $"Имя параметра: {nameof(request)}, имя метода: {nameof(ДобавитьДокументВоЗаявку)}");
                
                if (doc is null || doc.id < 1) throw new ArgumentNullException(
                    $"Имя параметра: {nameof(doc)}, имя метода: {nameof(ДобавитьДокументВоЗаявку)}");

                request.id_doc = doc.id;
                
                CommonService.Обновить(request);
                CommonService.Коммитнуть(typeof(REQUEST));
                Log.Info($"Документ с id={doc.id} привязан к заявке с id={request.id}]");
            }
            catch (Exception e)
            {
                Ошибка = e;
                throw;
            }
        }
    }
}