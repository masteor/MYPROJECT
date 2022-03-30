using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using QWERTY.Shared.Db.Entities.Представления;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Shared.Db.Services
{
    public partial interface ICommonService // IREQUEST_Service
    {
        #region REQUEST
        //--------------------------------------------------------------------------------------------------------------
        REQUEST? ПолучитьЗаявкуПоРегНомеру(string регНомер);
        REQUEST? ПолучитьЗаявкуПоИд(int идЗаявки);
        IEnumerable<VIEW_REPORT_ALL_REQUESTS>? ПолучитьЗаявкиИзПредставления
            (Expression<Func<VIEW_REPORT_ALL_REQUESTS, bool>> exp);

        /// <summary>
        /// Отфильтровать заявки отправленные каким-то пользователем, либо предназначенные для этого пользователя
        /// </summary>
        /// <param name="id_user"></param>
        /// <returns></returns>
        Expression<Func<VIEW_REPORT_ALL_REQUESTS, bool>> ГлавныеЗаявки(int? id_user);

        //--------------------------------------------------------------------------------------------------------------
        #endregion


        #region REQUEST_TYPE
        //--------------------------------------------------------------------------------------------------------------
        REQUEST_TYPE? ПолучитьТипЗаявкиПоИмениТипа(string имяТипаЗаявки);
        REQUEST_TYPE? ПолучитьТипЗаявкиПоИд(int id);
        string? ПолучитьИмяШаблонаЗаявки(string буквенныйКодТипаЗаявки);
        //--------------------------------------------------------------------------------------------------------------
        #endregion


        #region REQUEST_STATE
        //--------------------------------------------------------------------------------------------------------------
        IEnumerable<REQUEST_STATE>? ВсеСтатусыЗаявок();
        REQUEST_STATE? ПолучитьСтатусЗаявкиПоИд(int ид);
        REQUEST_STATE ПолучитьСтатусЗаявкиПоКоду(string code);
        REQUEST_STATE ПолучитьСтатусЗаявкиПоИмени(string имяСтатуса);

        //--------------------------------------------------------------------------------------------------------------

        #endregion


        IEnumerable<REQUEST>? ПолучитьДочерниеЗаявки(int requestId);
    }
    public partial class Common_Service // REQUEST_Service : IREQUEST_Service
    {
        public IEnumerable<VIEW_REPORT_ALL_REQUESTS>? ПолучитьЗаявкиИзПредставления
        (Expression<Func<VIEW_REPORT_ALL_REQUESTS, bool>> exp) => 
            _viewReportAllRequestsRepository?.GetMany(exp);

        public Expression<Func<VIEW_REPORT_ALL_REQUESTS, bool>> ГлавныеЗаявки(int? id_user) 
            =>
            r
                => r.parent == null
                   &&
                   (id_user == null
                    || r.id_user_sender == id_user
                    || r.id_user_recipient == id_user
                   );

        public REQUEST_TYPE ПолучитьТипЗаявкиПоИмениТипа(string имяТипаЗаявки)
        {
            try
            {
                return _requestTypeRepository?.Найти(r =>
                    string.Equals(r.code, имяТипаЗаявки, StringComparison.OrdinalIgnoreCase))
                    
                       ?? throw new Exception($"тип заявки [{имяТипаЗаявки}] не найден в БД");
            }
            catch (Exception e)
            {
                throw new Exception($"{nameof(ПолучитьТипЗаявкиПоИмениТипа)} {e}");
            }
        }

        public REQUEST_TYPE? ПолучитьТипЗаявкиПоИд(int id) 
            => 
                _requestTypeRepository?.Найти(r => r.id == id);

        public string? ПолучитьИмяШаблонаЗаявки(string буквенныйКодТипаЗаявки) 
            =>
            _requestTypeRepository?.Найти(r => 
                    string.Equals(
                        r.code,
                        буквенныйКодТипаЗаявки,
                        StringComparison.OrdinalIgnoreCase)
                    ).templateName;

        public REQUEST_STATE ПолучитьСтатусЗаявкиПоИмени(string? имяСтатуса) 
            =>
            _requestStateRepository?.Найти(r =>
                string.Equals(r.name, имяСтатуса, StringComparison.OrdinalIgnoreCase))
            ?? 
            throw new InvalidOperationException($"{nameof(ПолучитьСтатусЗаявкиПоИмени)}: имя статуса заявки не найдено [{имяСтатуса}]");

        public IEnumerable<REQUEST>? ПолучитьДочерниеЗаявки(int requestId) 
            => 
                _requestRepository?.GetMany(r => r.parent == requestId);

        public REQUEST? ПолучитьЗаявкуПоИд(int идЗаявки) => _requestRepository?.Найти(r => r.id == идЗаявки);

        public REQUEST_STATE ПолучитьСтатусЗаявкиПоКоду(string code) =>
            _requestStateRepository?
                .Найти(r => string.Equals(r.code, code, StringComparison.OrdinalIgnoreCase))
            ??
            throw new InvalidOperationException(
                $"{nameof(ПолучитьСтатусЗаявкиПоКоду)}: код статуса заявки не найден [{code}]");

        public REQUEST? ПолучитьЗаявкуПоРегНомеру(string регНомер) =>
            _requestRepository?.Найти(r =>
                string.Equals(r.reg_num, регНомер, StringComparison.OrdinalIgnoreCase));

        public IEnumerable<REQUEST_STATE>? ВсеСтатусыЗаявок() => _requestStateRepository?.GetAll().ToList();

        public REQUEST_STATE? ПолучитьСтатусЗаявкиПоИд(int ид) => _requestStateRepository?.Найти(r => r.id == ид);
    }
}
