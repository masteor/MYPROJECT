/*using DBPSA.Web.App.Core.Extensions;
 using DBPSA.Web.App.Core.Extensions.Entity;
 using DBPSA.Web.App.Core.Helpers;*/
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using DBPSA.Shared.Db.Entities;
using DBPSA.Shared.Db.Entities.Представления;

namespace DBPSA.Web.Core.Db
{
    /// <summary>
    /// _ResourceService
    /// </summary>
    public partial class ОбщиеСервисы
    {
        /*------------------------------------------------------------------------------------------------------------*/
        #region Типы объектов
            protected List<OBJECT_TYPE> ПолучитьВсеТипыОбъектов() => ПолучитьТипыОбъектов(r => true).ToList();

            protected IEnumerable<OBJECT_TYPE> ПолучитьТипыОбъектов(Expression<Func<OBJECT_TYPE, bool>> where) => _ResourceService.ПолучитьТипыОбъектов(where);

            protected IEnumerable<OBJECT_TYPE> ПолучитьТипыОбъектов(int идТипаСервиса) => ПолучитьТипыОбъектов(r => r.ID_SERVICE_TYPE == идТипаСервиса);

            protected List<OBJECT_TYPE> ПолучитьПодчиненныеТипыОбъектов(int типСервиса) => ПолучитьТипыОбъектов(r => 
                    r.ID_SERVICE_TYPE == типСервиса && (r.MAIN_OBJECT == null || r.MAIN_OBJECT == 0)).ToList();
            
            protected OBJECT_TYPE ПолучитьГлавныйОбъектИзТиповОбъектов(int типСервиса) => _ResourceService.ПолучитьГлавныйОбъектИзТиповОбъектов(типСервиса);
            
            protected OBJECT_TYPE ПолучитьТипОбъекта(string имяТипаОбъекта) => _ResourceService.ПолучитьТипОбъектаПоИмени(имяТипаОбъекта);
        #endregion
        /*------------------------------------------------------------------------------------------------------------*/
        #region Сервисы
            protected List<SERVICE> ПолучитьВсеСервисы() => _ResourceService.ПолучитьВсеСервисы().ToList();
            protected List<SERVICE> ПолучитьВсеСервисыПоТипуСервиса(int идТипаСервиса) => _ResourceService.ПолучитьВсеСервисыПоТипуСервиса(идТипаСервиса).ToList();
        #endregion
        /*------------------------------------------------------------------------------------------------------------*/
        #region Типы сервисов
            protected SERVICE_TYPE ПолучитьТипСервиса(string названиеСервиса) => _ResourceService.ПолучитьТипСервисаПоНазванию(названиеСервиса);
            protected List<SERVICE_TYPE> ПолучитьТипыСервисов(Expression<Func<SERVICE_TYPE, bool>> where) => _ResourceService.ПолучитьВсеТипыСервисов(where).ToList();
            protected List<SERVICE_TYPE> ПолучитьВсеТипыСервисов() => ПолучитьТипыСервисов(r => true);
            
        #endregion
        /*------------------------------------------------------------------------------------------------------------*/
        #region Ресурсы
            protected RESOURCE СоздатьРесурс(RESOURCE ресурс) => _ResourceService.СоздатьРесурс(ресурс);
            protected IEnumerable<RESOURCE> ПолучитьВсеРесурсы() => _ResourceService.ПолучитьВсеРесурсы().ToList();
            protected List<RESOURCE> ПолучитьСуществующиеРесурсы(DateTime? data) => 
                НаДату(_ResourceService.ПолучитьВсеРесурсы(r => r.идЗаявкиНаУдаление == null && r.идЗаявкиНаСоздание != 0), data);

            protected RESOURCE ПолучитьРесурс(int идРесурса) => _ResourceService.ПолучитьРесурс(идРесурса);

            
            protected List<OBJECT> ПолучитьВсеОбъекты() => _ResourceService.ПолучитьВсеОбъекты().ToList();
            /// <summary>
            /// 
            /// </summary>
            /// <param name="идОбъекта"></param>
            /// <returns></returns>
            protected List<VIEW_OBJECT_USER_RIGHTS_DISTINCTED> ПолучитьДопущенныхКОбъектуРесурса
                (int идОбъекта) => _ResourceService
                .ПолучитьДопущенныхКОбъектуРесурса(r=> r.ID_OBJECT == идОбъекта
                && (r.ID_LOGIN != 0 || r.ID_ORG != 0))
                .ToList();
            /// <summary>
            /// 
            /// </summary>
            /// <param name="data"></param>
            /// <returns></returns>
            protected List<VIEW_OBJECT_USER_RIGHTS_DISTINCTED> ПолучитьРесурсыИСубьектовДоступа(DateTime? data = null)
            {
                return НаДату(_ResourceService.ПолучитьДопущенныхКОбъектуРесурса
                    (r => r.ID_LOGIN != 0 || r.ID_ORG != 0), data);
                
                /*return data == null ? допущенные.ToList() : допущенные.Where(r => LinqHelpers.НаДату(r, (DateTime) data)).ToList();*/
            }
            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            protected List<RESOURCE> ПолучитьРесурсыСДопускамиИзПредставления() => 
                _ResourceService.ПолучитьРесурсыСДопусками(r=> r.ID_RESOURCE != null && r.РЕСУРС != null)
                .Select(r=> r.РЕСУРС).ToList();
            /// <summary>
            /// 
            /// </summary>
            /// <param name="идРесурса"></param>
            /// <returns></returns>
            /// <exception cref="Exception"></exception>
            protected List<VIEW_OBJECT_USER_RIGHTS_DISTINCTED> ПолучитьДопущенныхКРесурсу(int идРесурса)
            {
                var ресурс = ПолучитьРесурс(идРесурса);
                var идОбъекта = ресурс.идОбъекта;
                if (идОбъекта.IsNull()) throw new Exception($"Ошибка. У ресурса с ид={идРесурса} нет объекта с ид={идОбъекта}");
                var допущенныхКОбъектуРесурса = ПолучитьДопущенныхКОбъектуРесурса(идОбъекта);
                return допущенныхКОбъектуРесурса;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            protected List<RESOURCE> ПолучитьВсеРесурсыИмеющихСубъектовДоступа() =>
                _ResourceService.ПолучитьДопущенныхКОбъектуРесурса
                        (r => r.ID_RESOURCE != null && r.РЕСУРС != null)
                    .Select(r => r.РЕСУРС).ToList();

        #endregion
        /*------------------------------------------------------------------------------------------------------------*/
        #region Профили
            protected PROFILE СоздатьПрофиль(PROFILE профиль) => _ResourceService.СоздатьПрофиль(профиль);

            protected List<PROFILE> ПолучитьПрофилиПривязанныеКОбъекту(int идОбъекта) =>
                _ResourceService.ПоискПоТаблице_RIGHT(r => r.ID_OBJECT == идОбъекта).Select(r => r.PROFILE).ToList();
        #endregion
        /*------------------------------------------------------------------------------------------------------------*/
        #region ГруппыПравТипаОбъекта
            protected List<RIGHT_DESCR> ГруппыПрав(int идТипаОбъекта) => 
                _ResourceService.ГруппыПравТипаОбъекта(идТипаОбъекта).Select(r=> r.ГРУППА_ПРАВ).ToList();

        #endregion
        /*------------------------------------------------------------------------------------------------------------*/
        #region Права
            protected RIGHT СвязатьПравоСОбъектомПрофиля(RIGHT право) => _ResourceService.СоздатьПраво(право);

            protected IEnumerable<RIGHT> ПолучитьВсёИзТаблицы_RIGHT() =>
                ПолучитьВсёИзТаблицы_RIGHT(right => true);
            
            protected IEnumerable<RIGHT> ПолучитьВсёИзТаблицы_RIGHT(Expression<Func<RIGHT, bool>> where) =>
                _ResourceService.ПоискПоТаблице_RIGHT(where);
            
        #endregion
        /*------------------------------------------------------------------------------------------------------------*/
        #region Объекты
            protected OBJECT СоздатьОбъектРесурса(OBJECT объектРесурса)
            {
                try
                {
                    return _ResourceService.СоздатьОбъект(объектРесурса);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                    throw;
                }
            }
            
            protected OBJECT ПолучитьОбъект(int идОбъекта) => _ResourceService.ПолучитьОбъект(идОбъекта);
            
            protected List<OBJECT> ПолучитьВсеОбъектыИзТаблицы_RIGHT() => ПолучитьВсёИзТаблицы_RIGHT().ПолучитьОбъекты().ToList();

            #endregion
        /*------------------------------------------------------------------------------------------------------------*/
        #region Типы секретности
            protected List<SECRET_TYPE> ПолучитьВсеТипыСекретностиРесурсов() => _ResourceService.ПолучитьВсеТипыСекретностиРесурсов(r => true).ToList();
        #endregion
        /*------------------------------------------------------------------------------------------------------------*/
        #region Субъекты доступа входящие в профиль

        protected MEMBER ПредоставитьСубъектуДоступКПрофилю(MEMBER субъект) =>
            _ResourceService.Создать(субъект);
        
        protected List<MEMBER> ПолучитьВсеПрофилиУКоторыхЕстьСубъекты()
        {
            var list = _ResourceService.ПолучитьВсехСубъектовПрофилей(m => m.ID_PROFILE != 0)
                .ToList();
                list.RemoveAll(r => r.ID_LOGIN == null && r.ID_ORG == null);
                return list;
        }

        protected List<MEMBER> ПолучитьВсехСубъектовПрофилей() => ПолучитьВсехСубъектовПрофилей(member => true).ToList();
        protected List<MEMBER> ПолучитьВсехСубъектовПрофилей(Expression<Func<MEMBER, bool>> where) => _ResourceService.ПолучитьВсехСубъектовПрофилей(where).ToList();

        #endregion
        /*------------------------------------------------------------------------------------------------------------*/
        #region Фрагменты

        protected List<AC_FRAGMENT> ПолучитьФрагменты(Expression<Func<AC_FRAGMENT,bool>> where) => _ResourceService.ПолучитьФрагменты(where).ToList();
        protected List<AC_FRAGMENT> ПолучитьВсеФрагменты() => ПолучитьФрагменты(r => true);

        #endregion
        /*------------------------------------------------------------------------------------------------------------*/

    }
}