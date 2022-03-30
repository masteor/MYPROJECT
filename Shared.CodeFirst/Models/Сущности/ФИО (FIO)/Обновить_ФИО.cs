using System;
using System.Diagnostics;
using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Db.Services;
using QWERTY.Shared.Extensions;
using static QWERTY.Shared.Models.JsonModel.Codes;

namespace QWERTY.Shared.Models.Сущности
{
    public class Обновить_ФИО
    {
        public Exception Exception;
        private JsonModel.Result _result;
        
        private REQUEST _request;
        private FIO _fio;

        public Обновить_ФИО(ДанныеИзФормы_ОбновленияФИО_модель модель, ICommonService commonService, EMPLOYEE пользовательСервиса)
        {
            if (пользовательСервиса.IsNull() || модель == null || commonService == null) { throw new ArgumentNullException(); }

            try
            {
                //------------------------------------------------------------------------------------------------------
                // Создаем заявку на обновление ФИО, её привяжем ко всем создаваемым и обновляемым объектам
                //------------------------------------------------------------------------------------------------------
                var заявка = commonService.Создать(new REQUEST
                {
                    // todo: переделать все вызовы метода ПолучитьТипЗаявкиПоИмениТипа, должна передаваться не строка, совпадающая с текстом из базы данных, а строковая константа, которую можно было бы поменять
                    
                    id_request_type = commonService.ПолучитьТипЗаявкиПоИмениТипа("Заявка на обновление ФИО").id,
                    date_1 = DateTime.Now,
                    date_2 = DateTime.Now,
                    id_user_1 = пользовательСервиса.id,
                    id_user_2 = пользовательСервиса.id,
                    id_request_state = commonService.ПолучитьСтатусЗаявкиПоИмени	("Закрыта").id,
                    id_doc = null,
                    reg_num = 1234567890.ToString()
                });
                
                commonService.Коммитнуть(typeof(REQUEST));
                
                if (заявка == null || заявка.id == 0) throw new Exception("Заявка на создание ФИО не создана");
                _request = заявка;
                
                var существующее_фио = commonService.ПолучитьФИО(r => r.id == модель.id_fio);
                
                //------------------------------------------------------------------------------------------------------
                // создаем для существующего старого ФИО другую запись в таблице 
                //----------------------------------------------------------------------------------------------------
                var копия_существующего_фио = commonService.Создать(new FIO 
                {
                    id_user = существующее_фио.id_user, 
                    family = существующее_фио.family,
                    name = существующее_фио.name,
                    patronymic = существующее_фио.patronymic,
                    ид_заявки_на_создание = существующее_фио.ид_заявки_на_создание,
                    ид_заявки_на_удаление = заявка.id,
                    id_new = существующее_фио.id
                });
                
                commonService.Коммитнуть(typeof(FIO));
                if (копия_существующего_фио == null || копия_существующего_фио.id == 0) throw new Exception("Копия существующего ФИО не создано");
                
                //------------------------------------------------------------------------------------------------------
                // обновляем старое ФИО по первоначальному месту его нахождения в таблице
                //----------------------------------------------------------------------------------------------------
                существующее_фио.family = модель.family;
                существующее_фио.name = модель.name;
                существующее_фио.patronymic = модель.patronymic;
                существующее_фио.id_new = null;
                существующее_фио.ид_заявки_на_создание = заявка.id;
                существующее_фио.ид_заявки_на_удаление = null;
                
                commonService.Обновить(существующее_фио);
                commonService.Коммитнуть(typeof(FIO));
                if (существующее_фио.id == 0) throw new Exception("ФИО не обновлено");
                _fio = существующее_фио;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                _result = new JsonModel.Result
                {
                    code = (int) error_500,
                    msg = "Ошибка. " + e.Message
                };
                Exception = e;
                return;
            }
            
            _result = new JsonModel.Result
            {
                code = (int) success,
                msg = $"ФИО [{_fio.ПолучитьКороткоеФИО}] успешно обновлено"
            };
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public object ПолучитьJsonМодель()
        {
            var jsonModel = new {
                Model = new {
                    requestId = _request.id,
                    fioId = _fio.id 
                },
                Result = _result
            };
            return jsonModel;
        }
    }
}