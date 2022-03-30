using System;
using System.Diagnostics;
using DBPSA.Shared.Db.Entities;
using DBPSA.Shared.Db.Entities.Таблицы;
using DBPSA.Shared.Db.Services;
using DBPSA.Shared.Extensions;
using log4net;
using static DBPSA.Shared.Models.JsonModel.Codes;

namespace DBPSA.Shared.Models
{
    public class Создать_Логин : Создатель<ДанныеИзФормы_СозданияЛогина_модель?>
    {
        private readonly Создать_Заявку _созданнаяЗаявка;
        private LOGIN? логин;

        public Создать_Логин
        (
            ICommonService commonService,
            ILog log,
            string? логинПользователяСервиса,
            ДанныеИзФормы_СозданияЛогина_модель? модель,
            Создать_Заявку созданнаяЗаявка
        ) 
            : base (commonService: commonService, log: log, логинПользователяСервиса: логинПользователяСервиса, модель: модель)
        {
            try
            {
                if (Ошибка != null) return;
                логин = СоздатьЛогинБД();
            }
            catch (Exception e)
            {
                СохранитьОшибкуJsonModelResult(e: e, откуда: nameof(Создать_Логин));
            }
            finally
            {
                ВернутьРезультатJsonModel(сообщениеВоСлучаеУспеха: $"Логин [{логин?.name}] успешно создан");
            }
        }
        
        public override object ПолучитьJsonМодель =>
            СоздатьJsonМодель(объект: new
            {
                RequestId = _созданнаяЗаявка.Заявка?.id,
                Login = логин?.id
            });
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="модель"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public LOGIN? СоздатьЛогинБД<T>(T модель) where T : ДанныеИзФормы_СозданияЛогина_модель
        {
            var логин = CommonService?.Создать(
                entity: new LOGIN
            {
                name = модель.login_name!,
                email = модель.email!,
                id_user = (int) модель.id_user!,
                id_domen = (int) модель.id_domen,
                id_request_0 = null,
                id_request_1 = null,
                id_request_2 = null,
            });
                    
            CommonService?.Коммитнуть(type: typeof(LOGIN));
            if (логин == null || логин.id == 0) throw new Exception(message: "Логин не создан");
            return логин;
        }

        private LOGIN? СоздатьЛогинБД()
        {
            var логин = CommonService?.Создать(
                entity: new LOGIN
                {
                    name = Модель.login_name!,
                    email = Модель.email!,
                    id_user = (int) Модель.id_user,
                    id_domen = (int) Модель.id_domen,
                    id_request_0 = null,
                    id_request_1 = null,
                    id_request_2 = null,
                });
                    
            CommonService?.Коммитнуть(type: typeof(LOGIN));
            if (логин == null || логин.id == 0)
            {
                Log.Error(message: "Логин не создан");
                throw new Exception(message: "Логин не создан");
            } 
                
            return логин;
        }

        public LOGIN? ПолучитьЛогин() => логин;
    }
}

