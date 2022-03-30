using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using QWERTY.Shared.Db.Entities;
using QWERTY.Shared.Db.Entities.Представления;
using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Db.Repositories;
using QWERTY.Shared.Db.Запросы;
using QWERTY.Shared.Enums;
using QWERTY.Shared.Extensions;
using QWERTY.Shared.Extensions.Entity;

namespace QWERTY.Shared.Db.Services
{
    public partial interface ICommonService // IRESOURCE_Service
    {
        #region AC_FRAGMENT
        //--------------------------------------------------------------------------------------------------------------
        IEnumerable<AC_FRAGMENT>? GetAC_FRAGMENT();
        IEnumerable<AC_FRAGMENT>? ПолучитьФрагменты(Expression<Func<AC_FRAGMENT, bool>> @where);
        AC_FRAGMENT? ПолучитьФрагмент(Func<AC_FRAGMENT, bool> func);
        List<AC_FRAGMENT> ПолучитьВсеФрагменты();
        //--------------------------------------------------------------------------------------------------------------
        #endregion


        #region SERVICE // Сервисы
        //--------------------------------------------------------------------------------------------------------------
        SERVICE? ПолучитьСервисПоПолномуСетевомуИмени(string полноеСетевоеИмя);
        List<SERVICE>? ПолучитьВсеСервисы();
        List<SERVICE>? ПолучитьВсеСервисыПоТипуСервиса(int идТипаСервиса);
        //--------------------------------------------------------------------------------------------------------------
        #endregion
        

        #region OBJECT_TYPE // Типы объектов
        //--------------------------------------------------------------------------------------------------------------
        List<OBJECT_TYPE> ПолучитьВсеТипыОбъектов();
        List<OBJECT_TYPE> ПолучитьПодчиненныеТипыОбъектов(int типСервиса);
/*
        List<OBJECT> ПолучитьВсеОбъектыИзТаблицы_RIGHT();
*/
        OBJECT_TYPE? ПолучитьТипОбъекта(string имяТипаОбъекта);
        OBJECT_TYPE? ПолучитьТипОбъекта(Func<OBJECT_TYPE, bool> @where);
        OBJECT_TYPE? ПолучитьГлавныйОбъектИзТиповОбъектов(int типСервиса);
        IEnumerable<OBJECT_TYPE>? ПолучитьТипыОбъектов(Expression<Func<OBJECT_TYPE, bool>> @where);
        IEnumerable<OBJECT_TYPE>? ПолучитьТипыОбъектов(int идТипаСервиса);
        //--------------------------------------------------------------------------------------------------------------
        #endregion
        

        #region SECRET_TYPE // Типы секретности
        //--------------------------------------------------------------------------------------------------------------
        IEnumerable<SECRET_TYPE>? ПолучитьВсеТипыСекретностиРесурсов();
        //--------------------------------------------------------------------------------------------------------------
        #endregion
        

        #region SERVICE_TYPE // Типы сервисов
        //--------------------------------------------------------------------------------------------------------------
        IEnumerable<SERVICE_TYPE>? ПолучитьТипыСервисов(Expression<Func<SERVICE_TYPE, bool>> @where);
        List<SERVICE_TYPE> ПолучитьВсеТипыСервисов();
        SERVICE_TYPE? ПолучитьТипСервиса(string названиеСлужбы);
        //--------------------------------------------------------------------------------------------------------------
        #endregion
        

        #region OBJECT
        //--------------------------------------------------------------------------------------------------------------
        OBJECT? ПолучитьОбъектРесурса(Func<OBJECT, bool> func);
        IEnumerable<OBJECT>? ПолучитьВсеОбъекты();
        //--------------------------------------------------------------------------------------------------------------
        #endregion


        #region RESOURCE / РЕСУРСЫ
        //--------------------------------------------------------------------------------------------------------------
        IEnumerable<RESOURCE>? ПолучитьВсеРесурсы();
        IEnumerable<RESOURCE>? ПолучитьВсеРесурсы(Expression<Func<RESOURCE, bool>> @where);
        RESOURCE? ПолучитьРесурсПоИд(int идРесурса);
        
        /*List<RESOURCE> ПолучитьСуществующиеРесурсы(DateTime? data);*/
        /*IEnumerable<VIEW_RESOURCE_EXT> ПолучитьРесурсыДляФормы(Expression<Func<VIEW_RESOURCE_EXT, bool>> @where);*/

        #region VIEW_RESOURCES_BY_OT_ST

        public IEnumerable<VIEW_RESOURCES_BY_OT_ST>? ПолучитьРесурсыДляФормыСоУсловием
            (Expression<Func<VIEW_RESOURCES_BY_OT_ST, bool>> @where);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="where">строка в формате "WHERE условие"</param>
        /// <param name="data"></param>
        /// <returns></returns>
        IEnumerable<VIEW_RESOURCES_BY_OT_ST>? ПолучитьСуществующиеРесурсыДляФормыСоУсловием
            (Expression<Func<VIEW_RESOURCES_BY_OT_ST, bool>> @where, DateTime? data);
        
        IEnumerable<VIEW_RESOURCES_BY_OT_ST>? ПолучитьРесурсыДляФормыНаЭтапеРегистрация();

        Expression<Func<VIEW_RESOURCES_BY_OT_ST, bool>> Expression_OT_ST(int? serviceTypeId, int? objectTypeId);

        /*List<T> ФильтрТолькоДляПривилегированныйОтветственныйВладелец<T>(
            List<T> list,
            string? логин,
            bool isPrivileged) where T : ILOGIN_RESPONSIBLE_OWNER;*/

        /// <summary>
        /// фильтруем запрос в зависимости от привилегированности пользователя 
        /// либо если он является ответственным или владельцем
        /// </summary>
        /// <param name="list"></param>
        /// <param name="employeeId"></param>
        /// <param name="isPrivileged"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        List<T> ФильтрТолькоДляПривилегированныйОтветственныйВладелец<T>(
            List<T> list,
            int employeeId,
            bool isPrivileged
        ) where T : IEMPLOYEE_RESPONSIBLE_OWNER;

        #endregion

        public List<T> ФильтрТолькоДляПривилегированныйИлиПолучательУслуги<T>
            (List<T> list, int employeeId, bool isPrivileged) where T : IEMPLOYEE_SENDER_RECIPIENT;

        public bool МожноОтдатьТолькоДляПривилегОтветствВладелец<T>
            (T t, int? employeeId, bool isPrivileged) where T : IEMPLOYEE_RESPONSIBLE_OWNER;

        public bool МожноОтдатьТолькоДляПривилегИлиПолучатель<T>
            (T t, int? employeeId, bool isPrivileged) where T : IEMPLOYEE_SENDER_RECIPIENT;
        
        /*public bool МожноОтдатьТолькоДляПривилегИлиПолучатель<T>
            (T t, int? employeeId, bool isPrivileged);*/
        
        
        IEnumerable<VIEW_REPORT_ALL_RESOURCES>? ПолучитьРесурсыИзПредставления(
            Expression<Func<VIEW_REPORT_ALL_RESOURCES, bool>> @where);
        
        VIEW_REPORT_ALL_RESOURCES? ПолучитьРесурсИзПредставления(Func<VIEW_REPORT_ALL_RESOURCES, bool> @where);
        
        IEnumerable<VIEW_REPORT_ALL_RESOURCES>? ПолучитьВсе_Или_СуществующиеНаДату_Ресурсы(DateTime? data);
        
        /*IEnumerable<VIEW_REPORT_ALL_RESOURCES_FROM_PRD>? ПолучитьСуществующиеРесурсыИзPrd(DateTime? data);*/

        
        // Predicate<VIEW_REPORT_ALL_RESOURCES>? ФильтрПользЯвлсяОтветственным(string? login);

        bool СуществуетЛиИмяСуществующегоРесурса(DateTime? dateTime, string name);

        //--------------------------------------------------------------------------------------------------------------
        #endregion

        #region VIEW_REPORT_RESOURCES_WHERE_AM_I

        
            
        
        
        IEnumerable<VIEW_REPORT_RESOURCES_WHERE_AM_I>?
            ПолучитьРесурсыИзПредставленияГдеПользовательЯвляется
            (Expression<Func<VIEW_REPORT_RESOURCES_WHERE_AM_I, bool>> @where);

        IEnumerable<VIEW_REPORT_RESOURCES_WHERE_AM_I>?
            ПолучитьРесурсыИзПредставленияГдеПользовательЯвляетсяОтветственным(int? идПользователя);
        
        IEnumerable<VIEW_REPORT_RESOURCES_WHERE_AM_I>?
            ПолучитьРесурсыИзПредстГдеПользтельЯвлсяВладельцем(int? идПользователя);

        #endregion


        #region PROFILE / ПРОФИЛИ
        //--------------------------------------------------------------------------------------------------------------
        bool СуществуетЛиИмяПрофиляВСуществующихПрофилях(DateTime? dateTime, string name);

        PROFILE? ПолучитьПрофиль(Func<PROFILE, bool> func);

        IEnumerable<PROFILE>? ПолучитьПрофили(Expression<Func<PROFILE, bool>> expression);

        List<PROFILE> ПолучитьСуществующиеПрофили(DateTime? data);
        IEnumerable<VIEW_PROFILE>? ПолучитьСуществующиеНаДатуПрофилиИзПредставления(
            Expression<Func<VIEW_PROFILE, bool>> exp, DateTime? data);
        
        VIEW_REPORT_ALL_PROFILES? ПолучитьПрофильИзПредставления
            (Func<VIEW_REPORT_ALL_PROFILES, bool> exp);
        
        IEnumerable<VIEW_REPORT_ALL_PROFILES>? ПолучитьПрофилиИзПредставления
            (Expression<Func<VIEW_REPORT_ALL_PROFILES, bool>> exp);
        
        IEnumerable<VIEW_REPORT_ALL_PROFILES>? ПолучитьПрофилиИзПредставления
            (int id_user_recipient, string description);
        
        IEnumerable<VIEW_REPORT_ALL_PROFILES>? ПолучитьВсеПрофилиИзПредставления(string description);
        //--------------------------------------------------------------------------------------------------------------
        #endregion


        #region RIGHT
        //--------------------------------------------------------------------------------------------------------------
        IEnumerable<RIGHT>? ПолучитьПравоОбъектаПрофиля(Expression<Func<RIGHT, bool>> @where);
/*
        List<PROFILE> ПолучитьПрофилиПривязанныеКОбъекту(int идОбъекта);
*/
        //--------------------------------------------------------------------------------------------------------------
        #endregion


        #region VIEW_PROFILE_OBJECT_RIGHT
        IEnumerable<VIEW_PROFILE_OBJECT_RIGHT>? ПолучитьПрофилиПривязанныеКоРесурсу
            (int? идОбъектаРесурса);
        
        IEnumerable<VIEW_PROFILE_OBJECT_RIGHT>? ПолучитьРесурсПривязанныйКоПрофилю
            (int? идПрофиля);
        
        IEnumerable<VIEW_PROFILE_OBJECT_RIGHT>? ПолучитьДанныеИзПредставления_VIEW_PROFILE_OBJECT_RIGHT
            (Expression<Func<VIEW_PROFILE_OBJECT_RIGHT, bool>> exp);
        #endregion


        #region RIGHT_OBJECT_TYPE
        //--------------------------------------------------------------------------------------------------------------
        IEnumerable<RIGHT_OBJECT_TYPE>? ГруппыПравТипаОбъекта(int идТипаОбъекта);
        //--------------------------------------------------------------------------------------------------------------
        #endregion


        #region RIGHT_DESCR
        //--------------------------------------------------------------------------------------------------------------
/*
        List<RIGHT_DESCR> ГруппыПрав(int идТипаОбъекта);
*/
        RIGHT_DESCR? ПолучитьОписаниеПрава(Func<RIGHT_DESCR, bool> func);
        IEnumerable<RIGHT_DESCR>? ГруппыПрав(Expression<Func<RIGHT_DESCR, bool>> @where);
        /*IEnumerable<VIEW_RIGHT_DESCR>? ПолучитьГруппыПравНаОбъектыРесурсов(
            Expression<Func<VIEW_RIGHT_DESCR, bool>> @where);*/
        
        IEnumerable<VIEW_RIGHT_DESCR>? ПолучитьГруппыПравНаОбъектыРесурсов();
        //--------------------------------------------------------------------------------------------------------------
        #endregion
        

        #region MEMBER
        //--------------------------------------------------------------------------------------------------------------
        IEnumerable<MEMBER>? ПолучитьСубъектовИзПрофиля(Expression<Func<MEMBER, bool>> @where);
        IEnumerable<VIEW_MEMBER_USER>? ПолучитьСубъектовИзПрофиляИзПредставления
            (Expression<Func<VIEW_MEMBER_USER, bool>> @where);
        
        IEnumerable<VIEW_MEMBER_ORG>? ПолучитьОргСтруктурыИзПрофиляИзПредставления
            (Expression<Func<VIEW_MEMBER_ORG, bool>> @where);
        
        List<MEMBER> ПолучитьВсехСубъектовПрофилей();
        List<MEMBER> ПолучитьВсеПрофилиУКоторыхЕстьСубъекты();

        MEMBER? ПолучитьДоступСубъекта(Func<MEMBER, bool> func);
        //--------------------------------------------------------------------------------------------------------------
        #endregion


        #region VIEW_OBJECT_USER_RIGHTS_DISTINCTED
        //--------------------------------------------------------------------------------------------------------------
        IEnumerable<VIEW_OBJECT_USER_RIGHTS_DISTINCTED> ПолучитьДопущенныхКОбъектуРесурса(Expression<Func<VIEW_OBJECT_USER_RIGHTS_DISTINCTED, bool>> where);
/*
        List<RESOURCE> ПолучитьВсеРесурсыИмеющихСубъектовДоступа();
*/
        List<VIEW_OBJECT_USER_RIGHTS_DISTINCTED> ПолучитьДопущенныхКОбъектуРесурса(int идОбъекта);
        // List<VIEW_OBJECT_USER_RIGHTS_DISTINCTED> ПолучитьРесурсыИСубьектовДоступа(DateTime? data = null);
        List<RESOURCE> ПолучитьРесурсыСДопускамиИзПредставления(DateTime? запарситьДату);
        List<VIEW_OBJECT_USER_RIGHTS_DISTINCTED> ПолучитьДопущенныхКРесурсу(int идРесурса);
        //--------------------------------------------------------------------------------------------------------------
        #endregion


        #region VIEW_REPORT_RSD

        IEnumerable<VIEW_REPORT_RSD>? ПолучитьРесурсыИСубьектовДоступа(Expression<Func<VIEW_REPORT_RSD, bool>> @where);
        IEnumerable<VIEW_REPORT_RSD>? ПолучитьСуществующиеРесурсыИСубьектовДоступа(DateTime? dateTime);
        
        /*IEnumerable<VIEW_REPORT_RSD_FROM_PRD>? ПолучитьРесурсыИСубьектовДоступаИзPrd(
            Expression<Func<VIEW_REPORT_RSD_FROM_PRD, bool>> @where);*/
        
        /*IEnumerable<VIEW_REPORT_RSD_FROM_PRD>? ПолучитьСуществующиеРесурсыИСубьектовДоступаИзPrd(DateTime? dateTime);*/

        #endregion


        #region VIEW_RESOURCE_USER_RIGHT
        //--------------------------------------------------------------------------------------------------------------
        IEnumerable<VIEW_RESOURCE_USER_RIGHT>? ПолучитьРесурсыСДопусками(
            Expression<Func<VIEW_RESOURCE_USER_RIGHT, bool>> @where);
        //--------------------------------------------------------------------------------------------------------------
        #endregion

        List<SERVICE>? ПолучитьСервисыПоТипуФрагмента(int идФрагмента);

        IEnumerable<SERVICE>? ПолучитьСервисы(Expression<Func<SERVICE, bool>> func);

        #region RESOURCE_MEMBER
        RESOURCE_MEMBER? ПолучитьСубъектаРесурсаЗЛИВС(Func<RESOURCE_MEMBER, bool> func);
        #endregion

        #region VIEW_RESOURCE_MEMBER_EMPLOYEE
        IEnumerable<VIEW_RESOURCE_MEMBER_EMPLOYEE>? ПолучитьСотрудниковДопущенныхКоРесурсуЗЛИВС
            (Expression<Func<VIEW_RESOURCE_MEMBER_EMPLOYEE, bool>> @where);
        #endregion

        #region VIEW_RESOURCE_MEMBER_ORG
        IEnumerable<VIEW_RESOURCE_MEMBER_ORG>? ПолучитьОргДопущенныеКоРесурсуЗЛИВС
            (Expression<Func<VIEW_RESOURCE_MEMBER_ORG, bool>> @where);
        #endregion

        
    }
    
    public partial class Common_Service // RESOURCE_Service : IRESOURCE_Service
    {
        public IEnumerable<AC_FRAGMENT>? GetAC_FRAGMENT()
        {
            return _acFragmentRepository?.GetMany(r => true);
        }

        public AC_FRAGMENT? ПолучитьФрагмент(Func<AC_FRAGMENT, bool> func) 
            => 
                _acFragmentRepository?.Найти(func);

        public List<AC_FRAGMENT> ПолучитьВсеФрагменты() => (ПолучитьФрагменты(fragment => true) ?? Array.Empty<AC_FRAGMENT>()).ToList();

        public SERVICE? ПолучитьСервисПоПолномуСетевомуИмени(string полноеСетевоеИмя) =>
            _serviceRepository?.Найти(r =>
                string.Equals(r.net_name, полноеСетевоеИмя, StringComparison.OrdinalIgnoreCase));

        public List<SERVICE>? ПолучитьВсеСервисы() => _serviceRepository?.GetAll().ToList();
        public IEnumerable<OBJECT_TYPE>? ПолучитьТипыОбъектов(int идТипаСервиса) => 
            ПолучитьТипыОбъектов(r => r.id_service_type == идТипаСервиса);

        List<OBJECT_TYPE> ICommonService.ПолучитьВсеТипыОбъектов() 
            => 
                (ПолучитьТипыОбъектов(r => true) ?? Array.Empty<OBJECT_TYPE>()).ToList();

        public IEnumerable<SECRET_TYPE>? ПолучитьВсеТипыСекретностиРесурсов() => 
            _secretTypeRepository?.GetMany(r=> true).ToList();
        
        public IEnumerable<SERVICE_TYPE>? ПолучитьТипыСервисов(Expression<Func<SERVICE_TYPE, bool>> @where) => _serviceTypeRepository?.GetMany(where);
        public List<SERVICE_TYPE> ПолучитьВсеТипыСервисов() => (ПолучитьТипыСервисов(r => true) ?? Array.Empty<SERVICE_TYPE>()).ToList();

        public SERVICE_TYPE? ПолучитьТипСервиса(string названиеСлужбы) =>
            _serviceTypeRepository?.Найти(r =>
                string.Equals(r.название, названиеСлужбы, StringComparison.OrdinalIgnoreCase));

        public List<SERVICE>? ПолучитьВсеСервисыПоТипуСервиса(int идТипаСервиса) => 
            _serviceRepository?.GetMany(r => r.id_service_type == идТипаСервиса).ToList();

        public OBJECT_TYPE? ПолучитьТипОбъекта(string имяТипаОбъекта) => 
            _objectTypeRepository?.Найти(r => string.Equals(r.name, имяТипаОбъекта, StringComparison.OrdinalIgnoreCase));

        public OBJECT_TYPE? ПолучитьТипОбъекта(Func<OBJECT_TYPE, bool> @where) => _objectTypeRepository?.Найти(where);

        /*public IEnumerable<VIEW_RESOURCE_EXT> ПолучитьРесурсыДляФормы(Expression<Func<VIEW_RESOURCE_EXT, bool>> @where) => 
            _viewResourceExtRepository.GetMany(@where);*/

        /// <summary>
        /// 
        /// </summary>
        /// <param name="where">строку надо писать в ключевым словом WHERE в начале, потом выражение, пример: "WHERE TRUE" или "WHERE id = 1" и т.д.</param>
        /// <returns></returns>
        public IEnumerable<VIEW_RESOURCES_BY_OT_ST>? ПолучитьРесурсыДляФормыСоУсловием
            (Expression<Func<VIEW_RESOURCES_BY_OT_ST, bool>> where)
        {
            /*var query =  _viewResourcesByOtStRepository?.GetContext().ViewResourcesByOtSt.SqlQuery(
                Запрос.ViewResourcesByOtSt.Select + " " + @where
            );
            return query;*/

            return _viewResourcesByOtStRepository?.GetMany(where);
        }

        public IEnumerable<VIEW_RESOURCES_BY_OT_ST>? ПолучитьСуществующиеРесурсыДляФормыСоУсловием
            (Expression<Func<VIEW_RESOURCES_BY_OT_ST, bool>> @where, DateTime? data) 
            =>
            _linqHelpers?.СуществуетНаДату(ПолучитьРесурсыДляФормыСоУсловием(@where), data);

        public IEnumerable<VIEW_RESOURCES_BY_OT_ST>? ПолучитьРесурсыДляФормыНаЭтапеРегистрация()
            =>
                ПолучитьРесурсыДляФормыСоУсловием(r => 
                    r.create_date_1 != null 
                    && 
                    r.create_request_state == (int?) ИдСтатусаЗаявки.Зарегистрирована);

        public Expression<Func<VIEW_RESOURCES_BY_OT_ST, bool>> Expression_OT_ST(int? serviceTypeId, int? objectTypeId)
        {
            var isServiceTypeIdIsNullOrZero = serviceTypeId.IsNullZeroOrLess();
            var isObjectTypeIdIsNullOrZero = objectTypeId.IsNullZeroOrLess();

            Expression<Func<VIEW_RESOURCES_BY_OT_ST, bool>> query = r =>
                (r.id_service_type == serviceTypeId || isServiceTypeIdIsNullOrZero)
                && (r.id_object_type == objectTypeId || isObjectTypeIdIsNullOrZero);
            return query;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeId"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private Predicate<T> ФильтрПользЯвлсяОтветствЛибоВладельц<T>(int? employeeId) where T : IEMPLOYEE_RESPONSIBLE_OWNER 
            => v => 
                Equals(v.id_user_owner, employeeId) || Equals(v.id_user_responsible, employeeId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <param name="employeeId"></param>
        /// <param name="isPrivileged"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public List<T> ФильтрТолькоДляПривилегированныйОтветственныйВладелец<T>
            (List<T> list, int employeeId, bool isPrivileged) where T : IEMPLOYEE_RESPONSIBLE_OWNER 
            =>
                isPrivileged
                    ? list // привилегированные пользователи получают весь список, без фильтров
                    : list.FindAll(ФильтрПользЯвлсяОтветствЛибоВладельц<T>(employeeId));
        
        
        public List<T> ФильтрТолькоДляПривилегированныйИлиПолучательУслуги<T>
            (List<T> list, int employeeId, bool isPrivileged) where T : IEMPLOYEE_SENDER_RECIPIENT 
            =>
                isPrivileged
                    ? list // привилегированные пользователи получают весь список, без фильтров
                    : list.FindAll(ФильтрПользЯвлсяПолучУслуги<T>(employeeId));
        
        private Predicate<T> ФильтрПользЯвлсяПолучУслуги<T>(int? employeeId) where T : IEMPLOYEE_SENDER_RECIPIENT 
            => v => 
                Equals(v.id_user_recipient, employeeId);
        
        
        public bool МожноОтдатьТолькоДляПривилегОтветствВладелец<T>
            (T t, int? employeeId, bool isPrivileged) where T : IEMPLOYEE_RESPONSIBLE_OWNER 
            =>
            isPrivileged || Equals(t.id_user_owner, employeeId) || Equals(t.id_user_responsible, employeeId);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <param name="employeeId"></param>
        /// <param name="isPrivileged"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public bool МожноОтдатьТолькоДляПривилегИлиПолучатель<T>
            (T t, int? employeeId, bool isPrivileged) where T : IEMPLOYEE_SENDER_RECIPIENT 
            =>
                isPrivileged || Equals(t.id_user_recipient, employeeId);

        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IEnumerable<VIEW_REPORT_ALL_RESOURCES>? ПолучитьРесурсыИзПредставления
            (Expression<Func<VIEW_REPORT_ALL_RESOURCES, bool>> @where) 
            => 
            _viewReportAllResourcesRepository?.GetMany(where);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public VIEW_REPORT_ALL_RESOURCES? ПолучитьРесурсИзПредставления
            (Func<VIEW_REPORT_ALL_RESOURCES, bool> @where) 
            => 
                _viewReportAllResourcesRepository?.Найти(@where);

        // todo: не оптимальный метод, сначала делается запрос всех данных из таблицы, а потом сортируется
        // а хочется сразу запросить данные с универсальным фильтром НаДату, который обслуживает разные типы
        public IEnumerable<VIEW_REPORT_ALL_RESOURCES>? ПолучитьВсе_Или_СуществующиеНаДату_Ресурсы(DateTime? data) 
            => 
                _linqHelpers?.СуществуетНаДату
                (ПолучитьРесурсыИзПредставления(r => true), 
                    data);

        /*public IEnumerable<VIEW_REPORT_ALL_RESOURCES_FROM_PRD>? ПолучитьСуществующиеРесурсыИзPrd(DateTime? data = null)
        {
            try
            {
                var all = _viewReportAllResourcesFromPrdRepository?.GetAll().ToList();
                return _linqHelpers?.СуществуетНаДату(all, data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("", e);
            }
        }*/


        public bool СуществуетЛиИмяСуществующегоРесурса(DateTime? dateTime, string name)
        {
            throw new NotImplementedException();
            /*return ПолучитьСуществующиеРесурсы(dateTime).Exists(r =>
                string.Equals(r.resource_name, name, StringComparison.OrdinalIgnoreCase));*/
        }

        public IEnumerable<VIEW_REPORT_RESOURCES_WHERE_AM_I>?
            ПолучитьРесурсыИзПредставленияГдеПользовательЯвляется
            (Expression<Func<VIEW_REPORT_RESOURCES_WHERE_AM_I, bool>> @where) 
            =>
            _viewReportResourcesWhereAmIRepository?.GetMany(@where);

        public IEnumerable<VIEW_REPORT_RESOURCES_WHERE_AM_I>?
            ПолучитьРесурсыИзПредставленияГдеПользовательЯвляетсяОтветственным(int? идПользователя) 
            =>
            _viewReportResourcesWhereAmIRepository?
                .GetContext()
                .ViewReportResourcesWhereAmI
                .SqlQuery($"select * from {ИмяТаблицы.VIEW_REPORT_RESOURCES_WHERE_AM_I} " +
                          $"where {nameof(VIEW_REPORT_RESOURCES_WHERE_AM_I.id_user_responsible).ToUpper()}" +
                          $"='{идПользователя}'");

        public IEnumerable<VIEW_REPORT_RESOURCES_WHERE_AM_I>? ПолучитьРесурсыИзПредстГдеПользтельЯвлсяВладельцем(
            int? идПользователя) 
            =>
            _viewReportResourcesWhereAmIRepository?
                .GetContext()
                .ViewReportResourcesWhereAmI
                .SqlQuery($"select * from {ИмяТаблицы.VIEW_REPORT_RESOURCES_WHERE_AM_I} " +
                          $"where {nameof(VIEW_REPORT_RESOURCES_WHERE_AM_I.id_user_owner).ToUpper()}" +
                          $"='{идПользователя}'");

        public bool СуществуетЛиИмяПрофиляВСуществующихПрофилях(DateTime? dateTime, string name) => 
            ПолучитьСуществующиеПрофили(dateTime).Exists(r => string.Equals(r.name, name, StringComparison.OrdinalIgnoreCase));

        public PROFILE? ПолучитьПрофиль(Func<PROFILE, bool> func) => _profileRepository?.Найти(func);
        
        public IEnumerable<PROFILE>? ПолучитьПрофили(Expression<Func<PROFILE, bool>> expression) => 
            _profileRepository?.GetMany(expression);

        public List<PROFILE> ПолучитьСуществующиеПрофили(DateTime? data)
        {
            throw new NotImplementedException();
            // return НаДату(ПолучитьПрофили(r => r.ид_заявки_на_создание != 0 && r.ид_заявки_на_удаление == null), data);
        }

        public IEnumerable<VIEW_PROFILE>? ПолучитьСуществующиеНаДатуПрофилиИзПредставления(
            Expression<Func<VIEW_PROFILE, bool>> exp, DateTime? data) 
            => 
                _linqHelpers?.СуществуетНаДату
                (_viewProfileRepository?.GetMany(exp), data);

        public VIEW_REPORT_ALL_PROFILES? ПолучитьПрофильИзПредставления
            (Func<VIEW_REPORT_ALL_PROFILES, bool> func) 
            =>
            _viewReportAllProfilesRepository?.Найти(func);

        public IEnumerable<VIEW_REPORT_ALL_PROFILES>? 
            ПолучитьПрофилиИзПредставления(Expression<Func<VIEW_REPORT_ALL_PROFILES, bool>> exp) 
            =>
            _viewReportAllProfilesRepository?.GetMany(exp);

        public IEnumerable<VIEW_REPORT_ALL_PROFILES>? ПолучитьПрофилиИзПредставления(int id_user_recipient, string description) 
            =>
            _viewReportAllProfilesRepository?.GetContext()
                .ViewReportAllProfiles
                .SqlQuery(
                    $"select * from {ИмяТаблицы.VIEW_REPORT_ALL_PROFILES} as V " +
                    $"where {nameof(VIEW_REPORT_ALL_PROFILES.description).ToUpper()}='{description}' " +
                    $"AND {nameof(VIEW_REPORT_ALL_PROFILES.id_user_recipient).ToUpper()}={id_user_recipient}"
                );

        public IEnumerable<VIEW_REPORT_ALL_PROFILES>? ПолучитьВсеПрофилиИзПредставления(string description)
        {
            var sql = 
                $"select * from {ИмяТаблицы.VIEW_REPORT_ALL_PROFILES} " +
                $"where {nameof(VIEW_REPORT_ALL_PROFILES.description).ToUpper()}='{description}' ";
            
            return _viewReportAllProfilesRepository?.GetContext()
                .ViewReportAllProfiles
                .SqlQuery(sql);
        }

        /*
        public List<PROFILE> ПолучитьПрофилиПривязанныеКОбъекту(int идОбъекта) 
            => 
            (ПолучитьПравоОбъектаПрофиля(r => r.id_object == идОбъекта) 
                ?? 
             Array.Empty<RIGHT>())
            .Select(r => r.PROFILE).ToList();
*/

        public IEnumerable<VIEW_PROFILE_OBJECT_RIGHT>? ПолучитьПрофилиПривязанныеКоРесурсу
            (int? идОбъектаРесурса) 
            =>
            _viewProfileObjectRightRepository?
                .GetContext()
                .ViewProfileObjectRights
                    .SqlQuery($"select * from {ИмяТаблицы.VIEW_PROFILE_OBJECT_RIGHT} as V " +
                              $"where {nameof(VIEW_PROFILE_OBJECT_RIGHT.description).ToUpper()}='{Право.НаРесурс}' " +
                              $"AND {nameof(VIEW_PROFILE_OBJECT_RIGHT.id_object).ToUpper()}={идОбъектаРесурса}");

        /// <summary>
        /// Если профиль известен - возвращает привязанные ресурсы, если нет - тогда возвращает все ресурсы
        /// </summary>
        /// <param name="идПрофиля"></param>
        /// <returns></returns>
        public IEnumerable<VIEW_PROFILE_OBJECT_RIGHT>? ПолучитьРесурсПривязанныйКоПрофилю(int? идПрофиля)
        {
            string query;
            if (идПрофиля == null)
            {
                query = $"select * from {ИмяТаблицы.VIEW_PROFILE_OBJECT_RIGHT} as V " +
                        $"where {nameof(VIEW_PROFILE_OBJECT_RIGHT.description).ToUpper()}='{Право.НаРесурс}'";
            }
            else
            {
                query = $"select * from {ИмяТаблицы.VIEW_PROFILE_OBJECT_RIGHT} as V " +
                        $"where {nameof(VIEW_PROFILE_OBJECT_RIGHT.description).ToUpper()}='{Право.НаРесурс}' " +
                        $"AND {nameof(VIEW_PROFILE_OBJECT_RIGHT.id_profile).ToUpper()}={идПрофиля}";
            }

            return _viewProfileObjectRightRepository?
                .GetContext()
                .ViewProfileObjectRights
                .SqlQuery(query);
        }

        public IEnumerable<VIEW_PROFILE_OBJECT_RIGHT>? ПолучитьДанныеИзПредставления_VIEW_PROFILE_OBJECT_RIGHT
            (Expression<Func<VIEW_PROFILE_OBJECT_RIGHT, bool>> exp) 
            => 
                _viewProfileObjectRightRepository?.GetMany(exp);
        

        public IEnumerable<RIGHT_OBJECT_TYPE>? ГруппыПравТипаОбъекта(int идТипаОбъекта) => 
            _rightObjectTypeRepository?.GetMany(r => r.id_object_type == идТипаОбъекта);

/*
        public List<RIGHT_DESCR> ГруппыПрав(int идТипаОбъекта) 
            => 
            (ГруппыПравТипаОбъекта(идТипаОбъекта) 
             ?? 
             Array.Empty<RIGHT_OBJECT_TYPE>()
             )
            .Select(r=> r.ГРУППА_ПРАВ)
            .ToList();
*/

        public RIGHT_DESCR? ПолучитьОписаниеПрава(Func<RIGHT_DESCR, bool> func) 
            => 
                _rightDescriptionRepository?.Найти(func);

        public IEnumerable<RIGHT_DESCR>? ГруппыПрав(Expression<Func<RIGHT_DESCR, bool>> @where) 
            => 
            _rightDescriptionRepository?.GetMany(where);

        public IEnumerable<VIEW_RIGHT_DESCR>? ПолучитьГруппыПравНаОбъектыРесурсов(Expression<Func<VIEW_RIGHT_DESCR, bool>> @where) 
            => 
                _viewRightDescrRepository?.GetMany(@where);

        public IEnumerable<VIEW_RIGHT_DESCR>? ПолучитьГруппыПравНаОбъектыРесурсов() 
            =>
            _viewRightDescrRepository?
                .GetContext()
                .ViewRightDescrs
                .SqlQuery($"select * from {ИмяТаблицы.VIEW_RIGHT_DESCR}");

        public IEnumerable<OBJECT_TYPE>? ПолучитьТипыОбъектов(Expression<Func<OBJECT_TYPE, bool>> @where) => 
            _objectTypeRepository?.GetMany(where);

        public OBJECT_TYPE? ПолучитьГлавныйОбъектИзТиповОбъектов(int типСервиса) =>
            _objectTypeRepository?.Найти(r =>
                r.id_service_type == типСервиса && r.main_object != null && r.main_object != 0);

        public List<OBJECT_TYPE> ПолучитьПодчиненныеТипыОбъектов(int типСервиса) => 
            (ПолучитьТипыОбъектов(r => 
                r.id_service_type == типСервиса && (r.main_object == null || r.main_object == 0)) ?? Array.Empty<OBJECT_TYPE>()).ToList();

/*
        public List<OBJECT> ПолучитьВсеОбъектыИзТаблицы_RIGHT() 
            => 
            (ПолучитьПравоОбъектаПрофиля(right => true) 
                ?? 
            Array.Empty<RIGHT>())
            .ПолучитьОбъекты()
            .ToList();
*/

        public IEnumerable<RESOURCE>? ПолучитьВсеРесурсы() => _resourceRepository?.GetAll();
        public IEnumerable<RESOURCE>? ПолучитьВсеРесурсы(Expression<Func<RESOURCE, bool>> @where) => _resourceRepository?.GetMany(where);

        public RESOURCE? ПолучитьРесурсПоИд(int идРесурса) => _resourceRepository?.GetById(идРесурса);
        
        

        public OBJECT? ПолучитьОбъектРесурса(Func<OBJECT, bool> func) => _objectRepository?.Найти(func);
        public IEnumerable<OBJECT>? ПолучитьВсеОбъекты() => _objectRepository?.GetAll();
        public IEnumerable<RIGHT>? ПолучитьПравоОбъектаПрофиля(Expression<Func<RIGHT, bool>> @where) => _rightRepository?.GetMany(where);
        
        public IEnumerable<MEMBER>? ПолучитьСубъектовИзПрофиля(Expression<Func<MEMBER, bool>> @where) 
            => 
                _memberRepository?.GetMany(where);

        public IEnumerable<VIEW_MEMBER_USER>? ПолучитьСубъектовИзПрофиляИзПредставления(Expression<Func<VIEW_MEMBER_USER, bool>> @where) 
            => 
                _viewMemberUserRepository?.GetMany(@where);

        public IEnumerable<VIEW_MEMBER_ORG>? ПолучитьОргСтруктурыИзПрофиляИзПредставления(Expression<Func<VIEW_MEMBER_ORG, bool>> @where) 
            => 
                _viewMemberOrgRepository?.GetMany(@where);

        public List<MEMBER> ПолучитьВсехСубъектовПрофилей() => (ПолучитьСубъектовИзПрофиля(member => true) ?? Array.Empty<MEMBER>()).ToList();

        public List<MEMBER> ПолучитьВсеПрофилиУКоторыхЕстьСубъекты() =>
            new List<MEMBER>(ПолучитьВсехСубъектовПрофилей().RemoveAll(r => r.id_user == null && r.id_org == null));

        public MEMBER? ПолучитьДоступСубъекта(Func<MEMBER, bool> func) 
            => _memberRepository?.Найти(func);

        public MEMBER ПредоставитьСубъектуДоступКПрофилю(MEMBER субъект) => Создать(субъект);
        
        public IEnumerable<VIEW_REPORT_RSD>? ПолучитьРесурсыИСубьектовДоступа(
            Expression<Func<VIEW_REPORT_RSD, bool>> @where) => 
            _viewReportRsdRepository?.GetMany(@where);

        public IEnumerable<VIEW_REPORT_RSD>? ПолучитьСуществующиеРесурсыИСубьектовДоступа(DateTime? dateTime) => 
            _linqHelpers?.СуществуетНаДату
                (ПолучитьРесурсыИСубьектовДоступа
                (r => true), dateTime);

        /*public IEnumerable<VIEW_REPORT_RSD_FROM_PRD>? ПолучитьРесурсыИСубьектовДоступаИзPrd(
            Expression<Func<VIEW_REPORT_RSD_FROM_PRD, bool>> @where)
        {
            var tmp = _viewReportRsdFromPrdRepository?.GetMany(@where);
            return tmp;
        }*/

        /*public IEnumerable<VIEW_REPORT_RSD_FROM_PRD>? ПолучитьСуществующиеРесурсыИСубьектовДоступаИзPrd(DateTime? dateTime) => _linqHelpers?.СуществуетНаДату
            (ПолучитьРесурсыИСубьектовДоступаИзPrd
            (r => true), dateTime);*/

        public IEnumerable<VIEW_OBJECT_USER_RIGHTS_DISTINCTED> ПолучитьДопущенныхКОбъектуРесурса(
            Expression<Func<VIEW_OBJECT_USER_RIGHTS_DISTINCTED, bool>> where)
        {
            throw new NotImplementedException();
            return _viewObjectUserRightsDistinctedRepository.GetMany(@where);
        }

/*
        public List<RESOURCE> ПолучитьВсеРесурсыИмеющихСубъектовДоступа() =>
            ПолучитьДопущенныхКОбъектуРесурса(r => 
                    true)
                .Select(r => r.РЕСУРС).ToList();
*/

        public List<VIEW_OBJECT_USER_RIGHTS_DISTINCTED> ПолучитьДопущенныхКОбъектуРесурса(int идОбъекта) =>
            ПолучитьДопущенныхКОбъектуРесурса(r=> r.id_object == идОбъекта
                                                          && (r.id_login != 0 || r.id_org != 0)).ToList();

        public List<RESOURCE> ПолучитьРесурсыСДопускамиИзПредставления(DateTime? запарситьДату) => 
            (ПолучитьРесурсыСДопусками(r=> r.id_resource != null) ?? Array.Empty<VIEW_RESOURCE_USER_RIGHT>())
                .Select(r=> r.РЕСУРС).ToList();

        public List<VIEW_OBJECT_USER_RIGHTS_DISTINCTED> ПолучитьДопущенныхКРесурсу(int идРесурса)
        {
            throw new NotImplementedException();
            var ресурс = ПолучитьРесурсПоИд(идРесурса);
            var идОбъекта = ресурс.id_object;
            if (идОбъекта.IsNull()) throw new Exception($"Ошибка. У ресурса с ид={идРесурса} нет объекта с ид={идОбъекта}");
            var допущенныхКОбъектуРесурса = ПолучитьДопущенныхКОбъектуРесурса(идОбъекта);
            return допущенныхКОбъектуРесурса;
        }

        public IEnumerable<VIEW_RESOURCE_USER_RIGHT>? ПолучитьРесурсыСДопусками(
            Expression<Func<VIEW_RESOURCE_USER_RIGHT, bool>> @where) => 
            _viewResourceUserRightRepository?.GetMany(where);

        public List<SERVICE>? ПолучитьСервисыПоТипуФрагмента(int идФрагмента) => 
            _serviceRepository?.GetMany(r => r.id_ac_fragment == идФрагмента).ToList();

        public IEnumerable<SERVICE>? ПолучитьСервисы(Expression<Func<SERVICE, bool>> func) 
            => _serviceRepository?.GetMany(func);

        public RESOURCE_MEMBER? ПолучитьСубъектаРесурсаЗЛИВС(Func<RESOURCE_MEMBER, bool> func) 
            => _resourceMembersRepository?.Найти(func);

        public IEnumerable<VIEW_RESOURCE_MEMBER_EMPLOYEE>? ПолучитьСотрудниковДопущенныхКоРесурсуЗЛИВС
            (Expression<Func<VIEW_RESOURCE_MEMBER_EMPLOYEE, bool>> @where) 
            => 
                _iviewResourceMemberEmployeeRepository?.GetMany(@where);

        public IEnumerable<VIEW_RESOURCE_MEMBER_ORG>? ПолучитьОргДопущенныеКоРесурсуЗЛИВС
            (Expression<Func<VIEW_RESOURCE_MEMBER_ORG, bool>> @where) 
            => 
                _viewResourceMemberOrgRepository?.GetMany(@where);

        public IEnumerable<AC_FRAGMENT>? ПолучитьФрагменты(Expression<Func<AC_FRAGMENT, bool>> @where) => 
            _acFragmentRepository?.GetMany(where);
    }
}