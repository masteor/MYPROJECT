using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using Antlr.Runtime.Misc;
using QWERTY.Shared.Db.Entities.Представления;
using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Db.Infrastructure;
using QWERTY.Shared.Db.Repositories;
using QWERTY.Shared.Db.Services;
using QWERTY.Shared.Doc;
using QWERTY.Shared.Enums;
using QWERTY.Shared.Extensions;
using QWERTY.Shared.Helpers;
using QWERTY.Shared.Models;
using QWERTY.Shared.Models._Создатель;
using QWERTY.Shared.Models.Заявки;
using QWERTY.Shared.Models.Заявки.Заявка_на_создание_защищаемого_ресурса;
using QWERTY.Shared.Models.Заявки.Заявка_на_создание_профиля_доступа_на_ресурс;
using QWERTY.Shared.Models.Заявки.Заявка_на_предоставление_доступа_к_защищаемым_ресурсам;
using QWERTY.Shared.Models.Сущности;
using QWERTY.Web.Core;
using QWERTY.Web.Core.Authentication;
using static QWERTY.Web.Core.Authentication.AppRoleProvider;
using QWERTY.Web.Models.ReportAjax;
using log4net;
using static QWERTY.Shared.Enums.БуквенныеКодыТиповЗаявок;
using Autofac;
using Autofac.Features.OwnedInstances;
using QWERTY.Shared.Db.Запросы;
using QWERTY.Web.Properties;

namespace QWERTY.Web.Controllers.Ajax
{
    public class RequestAjaxController : WebBaseController
    {
        private protected new readonly ICommonService CommonService;
        // protected IContainer? _container;
        
        const string ЗНАЧЕНИЕ_НЕ_ОПРЕДЕЛЕНО = "<Значение не определено>";
        
        private readonly EMPLOYEE? _пользовательСервиса;

        public RequestAjaxController(ICommonService commonService)
        {
            CommonService = commonService;
            _пользовательСервиса = ПользовательСервиса(
                CommonService,
                Log,
                CurrentUserAccount?.Login);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetEmployees()
        {
            try
            {
                var data = CommonService
                    .ПолучитьВсехДействующихСотрудниковДляВыпадающегоСписка();

                return JsonSuccess(data);
            }
            catch (Exception e)
            {
                return ExceptionJson(e, nameof(GetEmployees));
            }
        }
        
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetViewEmployeeLogins()
        {
            try
            {
                // получаем только пользователей, у которых логин активен
                var data = (
                        CommonService.GET_VIEW_EMPLOYEE_LOGINS
                            (v => v.is_active == true)
                        ?? 
                        Array.Empty<VIEW_EMPLOYEE_LOGIN>())
                    .ToList();

                return JsonSuccess(data);
            }
            catch (Exception e)
            {
                return ExceptionJson(e, nameof(GetViewEmployeeLogins));
            }
        }

        /// <summary>
        /// Получаем модель пользователя сервиса по его логину,
        /// используется в режиме FakeUser
        /// </summary>
        /// <param name="login"></param>
        /// <param name="domainAccount"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        [HttpGet]
        public JsonResult GetUserModel(string? login, string? domainAccount)
        {
            try
            {
                ServiceRoles.ThrowIfNotPrivileged(domainAccount);
                
                if (login == null) throw new ArgumentNullException(nameof(login));
                    
                var userDomainAccount = $"{Settings.Default.FRAGMENT}\\{login}";
                var roles = AppRoleProvider.GetRolesForUser(userDomainAccount);

                var e = CommonService
                    .ПолучитьДанныеПользователяПоСуществующемуЛогинуИзПредставления(login);

                var model = new
                {
                    roles,
                    domainAccount = userDomainAccount,
                    fio = e?.fio_full,
                    idUser = e?.id_user
                };
                
                return JsonSuccess(model);
            }
            catch (Exception e)
            {
                return ExceptionJson(e, nameof(GetUserModel));
            }
        }
        

        [HttpGet]
        public JsonResult GetEmployee(int? tnum)
        {
            try
            {
                throw new NotImplementedException("Нужен метод [ПолучитьСотрудникаИзПредставления]");
                /*var data = CommonService
                    .ПолучитьСотрудникаИзПредставленияPRD(v => v.tnum == tnum);

                return JsonSuccess(data);*/

                return JsonSuccess(null);
            }
            catch (Exception e)
            {
                return ExceptionJson(e, nameof(GetEmployee));
            }
        }
        

        [HttpGet]
        public JsonResult GetOrgEntities()
        {
            try
            {
                var структуруОрганизации = CommonService.ПолучитьСтруктуруОрганизации();
                var data = new ОргЕдиницы(структуруОрганизации).Получить();
                
                return JsonSuccess(data);
            }
            catch (Exception e)
            {
                return ExceptionJson(e, nameof(GetOrgEntities));
            }
        }

        [HttpPost]
        public JsonResult CreateMember(ДанныеИзФормы_ПредоставлениеДоступаСубъектам_модель? модель)
        {
            object? result = null;  
            try
            {
                var создатьПредоставитьДоступСубъектам = new Создать_ПредоставитьДоступСубъектам(
                    CommonService, 
                    Log,
                    модель?.request_params?.sender_login,
                    модель,
                    null
                );

                result = создатьПредоставитьДоступСубъектам.ПолучитьJsonМодель();
            }
            catch (Exception e)
            {
                Logger?.ОтправитьОшибкуВ_Лог(e);
                result = JsonHelper.СоздатьJsonМодель(e);
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public ActionResult AC_ACCESS()
        {
            throw new NotImplementedException();   
        }

        /*public RequestAjaxController(ICommon_Service commonService) : base(commonService)
        {
            _commonService = commonService;
        }*/
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ServiceTypeId"></param>
        /// <param name="FragmentId"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetService(int? ServiceTypeId , int? FragmentId)
        {
            try
            {
                /*Expression<Func<SERVICE, bool>> expression = r =>
                    (fragmentId == null || fragmentId == 0 || r.ID_AC_FRAGMENT == fragmentId)
                    && (serviceTypeId == null || serviceTypeId == 0 || r.ID_SERVICE_TYPE == serviceTypeId);*/ 
                Expression<System.Func<SERVICE, bool>> expression = r 
                    =>
                    r.id_ac_fragment == FragmentId 
                    && r.id_service_type == ServiceTypeId;
                
                var data = new Сервисы(CommonService.ПолучитьСервисы(expression)).Получить();
                
                return JsonSuccess(data);
            }
            catch (Exception e)
            {
                return ExceptionJson(e, nameof(GetService));
            }

            // return Json(null, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet]
        public JsonResult GetServiceType(int? objectTypeId)
        {
            try
            {
                object? data;
                if (objectTypeId.IsNullZeroOrLess())
                {
                    data = new ТипыСервисов(CommonService.ПолучитьВсеТипыСервисов().ToList()).Получить(); 
                } 
                else
                {
                    var idServiceType = CommonService.ПолучитьТипОбъекта(r => r.id == objectTypeId).id_service_type;
                    var типыСервисов = CommonService.ПолучитьТипыСервисов(r => r.id == idServiceType).ToList();
                    data = new ТипыСервисов(типыСервисов).Получить();
                }
                
                return JsonSuccess(data);
            }
            catch (Exception e)
            {
                return ExceptionJson(e, nameof(GetServiceType));
            }
        }

        /// <summary>
        /// Получить все типы объектов
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetObjectType()
        {
            try
            {
                return JsonSuccess(CommonService.ПолучитьТипыОбъектов(v => true));
            }
            catch (Exception e)
            {
                return ExceptionJson(e, nameof(GetObjectType));
            }
        }

        public JsonResult GetObjectTypeById(int? id = null)
        {
            try
            {
                var data = id.IsNullZeroOrLess() ? null : 
                    new {
                        name = CommonService.ПолучитьТипОбъекта(o => o.id == id).name 
                    };
                
                return JsonSuccess(data);
            }
            catch (Exception e)
            {
                return ExceptionJson(e, nameof(GetObjectTypeById));
            }
        }

        /// <summary>
        /// Типы секретности
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet]
        public JsonResult GetSecretType()
        {
            try
            {
                var data = CommonService.ПолучитьВсеТипыСекретностиРесурсов();
                
                return JsonSuccess(data);
            }
            catch (Exception e)
            {
                return ExceptionJson(e, nameof(GetSecretType));
            }
        }

        /// <summary>
        /// Ответственные
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetResponsible()
        {
            try
            {
                var data = CommonService
                    .ПолучитьВсехДействующихСотрудниковДляВыпадающегоСписка()
                    .ToList();
                
                return JsonSuccess(data);
            }
            catch (Exception e)
            {
                return ExceptionJson(e, nameof(GetResponsible));
            }
        }

        /// <summary>
        /// Владельцы
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetOwners()
        {
            try
            {
                var data = CommonService.ПолучитьВсехНачальниковОтделений();
                
                return JsonSuccess(data);
            }
            catch (Exception e)
            {
                return ExceptionJson(e, nameof(GetOwners));
            }
        }

        /// <summary>
        /// Фрагменты
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetFragments()
        {
            try
            {
                var data = CommonService.ПолучитьВсеФрагменты().ToList(); 
                
                return JsonSuccess(data);
            }
            catch (Exception e)
            {
                return ExceptionJson(e, nameof(GetFragments));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult CheckObjectName(string name = null)
        {
            try
            {
                var data = string.IsNullOrWhiteSpace(name)
                    ? null
                    : new
                    {
                        isExist = CommonService.СуществуетЛиИмяСуществующегоРесурса(DateTime.Now, name)
                    };
                
                return JsonSuccess(data);
            }
            catch (Exception e)
            {
                return ExceptionJson(e, nameof(CheckObjectName));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tnum"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult CheckTnum(int? tnum)
        {
            throw new NotImplementedException();
            /*try
            {
                var data = tnum.IsNullZeroOrLess()
                    ? null
                    : new
                    {
                        isExist = _commonService
                            .ПолучитьРасширенныйEMPLOYEE(r => r.tnum == tnum) != null
                    };
                
                return JsonSuccess(data);
            }
            catch (Exception e)
            {
                return ExceptionJson(e, nameof(CheckTnum));
            }*/
        }

        
        
        /*
        /// <summary>
        /// Получить существующие ресурсы по типу сервиса и типу объекта ресурса
        /// используется в "Форма добавления объектов в профиль"
        /// \QWERTY.Frontend\src\views\Requests\Create\FormCreateProfile\Index.vue
        /// Ресурсы предоставляются только для ответственных, владельцев и
        /// привилегированных, последним дана такая возможность, чтобы они
        /// могли делать заявки для других пользователей 
        /// </summary>
        /// <param name="serviceTypeId"></param>
        /// <param name="objectTypeId"></param>
        /// <param name="domainAccount"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetResources(int? serviceTypeId, int? objectTypeId, string? domainAccount)
        {
            try
            {
                var isPrivileged = ServiceRoles.IsPrivileged(domainAccount);
                var exp = CommonService.Expression_OT_ST(serviceTypeId, objectTypeId);

                var allItems = (
                    CommonService.ПолучитьСуществующиеРесурсыДляФормы(exp, DateTime.Now)
                    ?? 
                    Array.Empty<VIEW_RESOURCES_BY_OT_ST>()
                ).ToList();

                /*var items2 = (
                    CommonService.ПолучитьРесурсыДляФормыНаЭтапеСоздания() 
                    ?? Array.Empty<VIEW_RESOURCES_BY_OT_ST>()
                ).ToList();
                
                var allItems = items1.Concat(items2).ToList();#1#


                var employee = ПолучитьПользователяПоДоменнойУчеткеСоПроверкойThrow
                    (CommonService, Log, domainAccount);
                
                var list = CommonService.ФильтрТолькоДляПривилегированныйОтветственныйВладелец (
                    allItems,
                    employee.id,
                    isPrivileged
                );
                
                return JsonSuccess(list);
            }
            catch (Exception e)
            {
                return ExceptionJson(e, nameof(GetResources));
            }
        }
        */

        /// <summary>
        /// Получить существующие и на этапе регистрации ресурсы по ид Фрагмента
        /// 
        /// Ресурсы предоставляются только для ответственных, владельцев и
        /// привилегированных, последним дана такая возможность, чтобы они
        /// могли делать заявки для других пользователей
        /// </summary>
        /// <param name="domainAccount"></param>
        /// <param name="id_fragment"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetExistentAndRegisteredResources(string? domainAccount, int? id_fragment)
        {
            try
            {
                ПроверитьПараметрИдЕслиНадоКинутьИсключение(id_fragment, nameof(id_fragment));
                
                var isPrivileged = ServiceRoles.IsPrivileged(domainAccount);

                var items1 = (
                    CommonService.ПолучитьСуществующиеРесурсыДляФормыСоУсловием(
                        v => v.id_ac_fragment == id_fragment,
                        
                        DateTime.Now
                    )
                    ?? 
                    Array.Empty<VIEW_RESOURCES_BY_OT_ST>()
                ).ToList();

                var items2 = (
                    CommonService.ПолучитьРесурсыДляФормыНаЭтапеРегистрация() 
                    ?? Array.Empty<VIEW_RESOURCES_BY_OT_ST>()
                ).ToList();
                
                var allItems = items1.Concat(items2).ToList();

                var employee = ПолучитьПользователяПоДоменнойУчеткеСоПроверкойThrow
                    (CommonService, Log, domainAccount);
                
                var list = CommonService.ФильтрТолькоДляПривилегированныйОтветственныйВладелец (
                    allItems,
                    employee.id,
                    isPrivileged
                ).ToList();
                
                return JsonSuccess(list);
            }
            catch (Exception e)
            {
                return ExceptionJson(e, nameof(GetExistentAndRegisteredResources));
            }
        }
        
        /// <summary>
        /// Получить существующие ресурсы по ид Фрагмента
        /// </summary>
        /// <param name="domainAccount"></param>
        /// <param name="id_fragment"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetExistentResources(string? domainAccount, int? id_fragment)
        {
            try
            {
                ПроверитьПараметрИдЕслиНадоКинутьИсключение(id_fragment, nameof(id_fragment));
                var isPrivileged = ServiceRoles.IsPrivileged(domainAccount);

                var allItems = (
                    CommonService.ПолучитьСуществующиеРесурсыДляФормыСоУсловием(
                        r => r.id_ac_fragment == id_fragment,
                        DateTime.Now
                    )
                    ?? 
                    Array.Empty<VIEW_RESOURCES_BY_OT_ST>()
                ).ToList();

                var employee = ПолучитьПользователяПоДоменнойУчеткеСоПроверкойThrow
                    (CommonService, Log, domainAccount);
                
                var list = CommonService.ФильтрТолькоДляПривилегированныйОтветственныйВладелец (
                    allItems,
                    employee.id,
                    isPrivileged
                );
                
                return JsonSuccess(list);
            }
            catch (Exception e)
            {
                return ExceptionJson(e, nameof(GetExistentResources));
            }
        }


        [HttpGet]
        public JsonResult GetResource(int? id)
        {
            try
            {
                return JsonSuccess((CommonService
                        .ПолучитьРесурсыИзПредставления(r => r.id_resource == id) 
                                    ?? Array.Empty<VIEW_REPORT_ALL_RESOURCES>())
                    .FirstOrDefault());
            }
            catch (Exception e)
            {
                return ExceptionJson(e, nameof(GetResource));
            }
        }


        [HttpGet]
        public JsonResult GetObjectServiceTypes()
        {
            try
            {
                var типыОбъектов = CommonService.ПолучитьВсеТипыОбъектов();
                var типыСервисов= CommonService.ПолучитьВсеТипыСервисов();

                var result = типыОбъектов.Select(ot => new
                {
                    ot.id,
                    ot.name,
                    ot.id_service_type,
                    ot.main_object,
                    ot.code,
                    ot.icon,
                    service_type = типыСервисов.FirstOrDefault(st => st.id == ot.id_service_type)    
                }).ToList();
                
                return JsonSuccess(result);
            }
            catch (Exception e)
            {
                return ExceptionJson(e, nameof(GetObjectServiceTypes));
            }
        }
        

        [HttpGet]
        public JsonResult GetResourceMemberLoginZLIVS(int? idObjectResource, string? domainAccount)
        {
            // VIEW_RESOURCE_MEMBER_EMPLOYEE
                
            try
            {
                // без доменной учетки данные не отдаём
                ServiceRoles.ThrowIfNullOrWhiteSpace(domainAccount);

                ПроверитьПараметрИдЕслиНадоКинутьИсключение(idObjectResource, nameof(idObjectResource));
                
                // проверяем привилегии учетки
                var isPrivileged = ServiceRoles.IsPrivileged(domainAccount);
                var employee = ПолучитьПользователяПоДоменнойУчеткеСоПроверкойThrow(CommonService, Log, domainAccount);

                var enumerable = (CommonService
                    .ПолучитьСотрудниковДопущенныхКоРесурсуЗЛИВС(v
                        => v.id_object == idObjectResource) 
                                  ?? Array.Empty<VIEW_RESOURCE_MEMBER_EMPLOYEE>())
                    .ToList();

                var data = CommonService
                    .ФильтрТолькоДляПривилегированныйОтветственныйВладелец(
                        enumerable,
                        employee.id,
                        isPrivileged
                    );

                return JsonSuccess(data);
            }
            catch (Exception e)
            {
                return ExceptionJson(e, nameof(GetResourceMemberLoginZLIVS));
            }
        }
        
        
        [HttpGet]
        public JsonResult GetResourceMemberOrgZLIVS(int? idObjectResource, string? domainAccount)
        {
            try
            {
                // без доменной учетки данные не отдаём
                ServiceRoles.ThrowIfNullOrWhiteSpace(domainAccount);

                ПроверитьПараметрИдЕслиНадоКинутьИсключение(idObjectResource, nameof(idObjectResource));
                
                // проверяем привилегии учетки
                var isPrivileged = ServiceRoles.IsPrivileged(domainAccount);
                var employee = ПолучитьПользователяПоДоменнойУчеткеСоПроверкойThrow(CommonService, Log, domainAccount);

                var enumerable = (CommonService
                                      .ПолучитьОргДопущенныеКоРесурсуЗЛИВС(v
                                          => v.id_object == idObjectResource) 
                                  ?? Array.Empty<VIEW_RESOURCE_MEMBER_ORG>())
                    .ToList();

                var data = CommonService
                    .ФильтрТолькоДляПривилегированныйОтветственныйВладелец(
                        enumerable,
                        employee.id,
                        isPrivileged
                    );

                return JsonSuccess(data);
            }
            catch (Exception e)
            {
                return ExceptionJson(e, nameof(GetResourceMemberOrgZLIVS));
            }
        }
        

        /// <summary>
        /// Заявка создания ресурса
        /// </summary>
        /// <param name="модель"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CreateResourceZLIVS(ДанныеИзФормы_СозданиеЗащищаемогоРесурсаЗЛИВС_модель? модель)
        {
            object? result = null;  
            try
            {
                var созданиеЗащищаемогоРесурсаЗливс = new СозданиеЗащищаемогоРесурсаЗЛИВС(
                    CommonService, 
                    DocPaths,
                    Log,
                    модель?.request_params?.sender_login,
                    модель,
                    null
                );

                result = созданиеЗащищаемогоРесурсаЗливс.ПолучитьJsonМодель();
            }
            catch (Exception e)
            {
                Logger?.ОтправитьОшибкуВ_Лог(e);
                result = JsonHelper.СоздатьJsonМодель(e);
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        
        
        [HttpGet]
        public FileResult? GetBinaryDocument(int? id, string? domainAccount)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(domainAccount)) throw new ArgumentNullException(nameof(domainAccount));
                
                var документПоИд = CommonService.ПолучитьДокументПоИд
                    (id ?? throw new ArgumentNullException(nameof(id)));
                
                Document document = new Document(CommonService, Log, DocPaths);
                byte[] документИзХранилища = document.ПолучитьДокументИзХранилища(документПоИд.path);

                return new FileContentResult
                    (документИзХранилища, 
                    "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
            }
            catch (Exception e)
            {
                return null;
                /*return Json(
                    data: JsonModel.СоздатьСообщениеОбОшибке(data: null, msg: $"Ошибка в методе {nameof(GetBinaryDocument)}: {e.Message}"),
                    behavior: JsonRequestBehavior.AllowGet
                );*/
            }
        }
        

        /// <summary>
        /// Заявка создания ресурса
        /// </summary>
        /// <param name="модель"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CreateResource(ДанныеИзФормы_СозданиеЗащищаемогоРесурса_модель? модель)
        {
            object? result = null;
            try
            {
                var созданиеЗащищаемогоРесурса = new СозданиеЗащищаемогоРесурса(
                    CommonService,
                    Log,
                    модель?.request_params?.sender_login,
                    модель,
                    null
                );

                result = созданиеЗащищаемогоРесурса.ПолучитьJsonМодель();
            }
            catch (Exception e)
            {
                Logger?.ОтправитьОшибкуВ_Лог(e);
                result = JsonHelper.СоздатьJsonМодель(e);
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        
        
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult CheckProfileName(string name = null)
        {
            try
            {
                var data = string.IsNullOrWhiteSpace(name)
                    ? null
                    : new
                    {
                        isExist = CommonService.СуществуетЛиИмяПрофиляВСуществующихПрофилях(DateTime.Now, name)
                    };
                
                return JsonSuccess(data);
            }
            catch (Exception e)
            {
                return ExceptionJson(e, nameof(CheckProfileName));
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="модель"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult AddProfileObjects(ДанныеИзФормы_СозданиеПрофиляДоступа_модель? модель)
        {
            object? result = null;
            try
            {
                var профильДоступаНаЗащищаемыйРесурс = 
                    new СозданиеПрофиляДоступаНаЗащищаемыйРесурс(
                        CommonService,
                        Log,
                        модель?.request_params?.sender_login,
                        модель,
                        null
                );
                
                result = профильДоступаНаЗащищаемыйРесурс.ПолучитьJsonМодель();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                Logger?.ОтправитьОшибкуВ_Лог(e);
                return ExceptionJson(e, nameof(AddProfileObjects));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="модель"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CreateProfile(/*ДанныеИзФормы_СозданияПрофиля_модель модель*/)
        {
            throw new NotImplementedException();
            /*модель.Создать(commonService: _commonService, login: CurrentUserAccount.Login);
            return Json(data: модель.ПолучитьJsonМодель(), behavior: JsonRequestBehavior.AllowGet);*/
        }

        /// <summary>
        ///  Получить действующие профили пользователя во фрагменте
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetExistentProfiles(string? domainAccount, int? id_fragment)
        {
            try
            {
                ПроверитьПараметрИдЕслиНадоКинутьИсключение(id_fragment, nameof(id_fragment));
                
                // без доменной учетки данные не отдаём
                ServiceRoles.ThrowIfNullOrWhiteSpace(domainAccount);
                var employee = ПолучитьПользователяПоДоменнойУчеткеСоПроверкойThrow(CommonService, Log, domainAccount);
                    
                // проверяем привилегии учетки
                var isPrivileged = ServiceRoles.IsPrivileged(domainAccount);

                var viewProfiles = (CommonService
                    .ПолучитьСуществующиеНаДатуПрофилиИзПредставления(v 
                        => v.id_ac_fragment == id_fragment, DateTime.Now) ?? Array.Empty<VIEW_PROFILE>())
                    .ToList();

                var list = CommonService.ФильтрТолькоДляПривилегированныйИлиПолучательУслуги(
                    viewProfiles,
                    employee.id,
                    isPrivileged
                );
                
                return JsonSuccess(list);
            }
            catch (Exception e)
            {
                return ExceptionJson(e, nameof(GetExistentProfiles));
            }
        }
        
        
        
        /// <summary>
        ///  Получить действующие и на этапе регистрации профили пользователя во фрагменте,
        /// используеся в форме создания профиля, для предотвращения создания одноименных профилей
        /// в одном и том же фрагменте
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetExistentAndRegisteredProfiles(string? domainAccount, int? id_fragment)
        {
            try
            {
                ПроверитьПараметрИдЕслиНадоКинутьИсключение(id_fragment, nameof(id_fragment));
                
                // без доменной учетки данные не отдаём
                ServiceRoles.ThrowIfNullOrWhiteSpace(domainAccount);
                var employee = ПолучитьПользователяПоДоменнойУчеткеСоПроверкойThrow(CommonService, Log, domainAccount);
                    
                // проверяем привилегии учетки
                var isPrivileged = ServiceRoles.IsPrivileged(domainAccount);

                var viewProfiles = (CommonService
                        .ПолучитьСуществующиеНаДатуПрофилиИзПредставления(v =>
                            v.id_ac_fragment == id_fragment, DateTime.Now) ?? Array.Empty<VIEW_PROFILE>())
                    .ToList();

                var list = CommonService.ФильтрТолькоДляПривилегированныйИлиПолучательУслуги(
                    viewProfiles,
                    employee.id,
                    isPrivileged
                );
                
                return JsonSuccess(list);
            }
            catch (Exception e)
            {
                return ExceptionJson(e, nameof(GetExistentAndRegisteredProfiles));
            }
        }

        /// <summary>
        /// Получить профили привязанные ко ресурсу
        /// </summary>
        /// <param name="idObjectResource"></param>
        /// <param name="domainAccount"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        [HttpGet]
        public JsonResult GetProfilesByResource(int? idObjectResource, string? domainAccount)
        {
            try
            {
                // без доменной учетки данные не отдаём
                ServiceRoles.ThrowIfNullOrWhiteSpace(domainAccount);
                
                if (idObjectResource == null) throw new ArgumentNullException(nameof(idObjectResource));
                if (idObjectResource < 1) throw new ArgumentOutOfRangeException(nameof(idObjectResource) + "должен быть > 0");
                
                // проверяем привилегии учетки
                var isPrivileged = ServiceRoles.IsPrivileged(domainAccount);
                var employee = ПолучитьПользователяПоДоменнойУчеткеСоПроверкойThrow(CommonService, Log, domainAccount);

                var enumerable = (CommonService
                        .ПолучитьПрофилиПривязанныеКоРесурсу(idObjectResource) 
                                  ?? 
                                  Array.Empty<VIEW_PROFILE_OBJECT_RIGHT>())
                    .ToList();
                
                var data = CommonService
                    .ФильтрТолькоДляПривилегированныйОтветственныйВладелец(
                        enumerable,
                        employee.id,
                        isPrivileged);
                
                return JsonSuccess(data);
            }
            catch (Exception e)
            {
                return ExceptionJson(e, nameof(GetProfilesByResource));
            }
        }


        /// <summary>
        /// Получить ресурс по выбранному профилю, если профиль не выбран - грузим все ресурсы пользователя
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetResourceByProfile(int? idProfile, string? domainAccount)
        {
            try
            {
                // без доменной учетки данные не отдаём
                ServiceRoles.ThrowIfNullOrWhiteSpace(domainAccount);
                
                // выясняем привилегии учетки
                var isPrivileged = ServiceRoles.IsPrivileged(domainAccount);
                var employee = ПолучитьПользователяПоДоменнойУчеткеСоПроверкойThrow(CommonService, Log, domainAccount);
                var р = (CommonService
                        .ПолучитьРесурсПривязанныйКоПрофилю(idProfile) ?? Array.Empty<VIEW_PROFILE_OBJECT_RIGHT>())
                        .ToList();

                var list = CommonService.ФильтрТолькоДляПривилегированныйОтветственныйВладелец(
                    р, 
                    employee.id,
                    isPrivileged
                );

                return JsonSuccess(list);
            }
            catch (Exception e)
            {
                return ExceptionJson(e, nameof(GetResourceByProfile));
            }
        }

        /// <summary>
        /// Права, назначаемые на объекты профиля
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetRightDescr()
        {
            try
            {
                return JsonSuccess(CommonService.ПолучитьГруппыПравНаОбъектыРесурсов());
            }
            catch (Exception e)
            {
                return ExceptionJson(e, nameof(GetRightDescr));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">// warn: указывается ид объекта ресурса, а не ресурса</param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetObjectNameById(int? id)
        {
            try
            {
                var data = id.IsNullZeroOrLess()
                    ? null
                    : new {name = CommonService.ПолучитьОбъектРесурса(o => o.id == id).name};
                
                return JsonSuccess(data);
            }
            catch (Exception e)
            {
                return ExceptionJson(e, nameof(GetObjectNameById));
            }
        }

        [HttpPost]
        public JsonResult DeleteFioRequest(ДанныеИзФормы_УдаленияФИО_модель? модель)
        {
            object? result = null;

            throw new NotImplementedException();
            try
            {
                /*var репоФио = new Репо_ФИО(_commonService,
                    Log,
                    модель?.request_params?.sender_login,
                    модель,
                    null);

                репоФио?.УдалитьФиоЗаявка();
                result = репоФио?.ПолучитьJsonМодель();*/
            }
            catch (Exception e)
            {
                Logger.ОтправитьОшибкуВ_Лог(e);
                result = JsonHelper.СоздатьJsonМодель(e, $"Ошибка в методе {nameof(DeleteFioRequest)}");
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="модель"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        [HttpPost]
        public JsonResult CreateFio(ДанныеИзФормы_СозданияФИО_модель? модель)
        {
            object? result = null;

            throw new NotImplementedException();
            try
            {
                /*var репоФио = new Репо_ФИО
                (
                    _commonService,
                    Log,
                    модель?.request_params?.sender_login,
                    модель,
                    null
                );
                
                репоФио?.СоздатьФиоЗаявка();
                result = репоФио?.ПолучитьJsonМодель();*/
            }
            catch (Exception e)
            {
                Logger.ОтправитьОшибкуВ_Лог(e);
                result = JsonHelper.СоздатьJsonМодель(e);
            }
            
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Создать нового пользователя
        /// </summary>
        /// <param name="модель"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        [HttpPost]
        public JsonResult CreateEmployee(ДанныеИзФормы_СозданияПользователя_модель? модель)
        {
            throw new NotImplementedException();
            /*try
            {
                var создатьПользователя = new Создать_Пользователя
                (
                    _commonService, Log,
                    логинПользователяСервиса: модель?.request_params?.sender_login,
                    модель: модель,
                    родительскаяЗаявка: null
                );

                if (создатьПользователя.Ошибка.IsNotNull())
                    return Json(data: создатьПользователя.ПолучитьJsonМодель,
                        behavior: JsonRequestBehavior.AllowGet);
                
                

                if (создатьФио.Ошибка.IsNotNull())
                    return Json(data: заявкаНаСозданиеФио.ПолучитьJsonМодель, behavior: JsonRequestBehavior.AllowGet);

                

                var создатьПользователя = new Создать_Пользователя
                (
                    commonService: _commonService, log: Log,
                    логинПользователяСервиса: модель?.request_params?.sender_login,
                    модель: модель,
                    
                );
                
                {
                    _fio!.id_user = _employee?.id;
                    CommonService.Обновить(_fio);
                }
            
                if (создатьПользователя.Exception.IsNotNull()) { Debug.WriteLine(создатьПользователя.Exception?.Message); }
                return Json(data: создатьПользователя.ПолучитьJsonМодель(), behavior: JsonRequestBehavior.AllowGet);

            }
            catch (Exception e)
            {
                Log.Error(message: $"Ошибка в методе {nameof(CreateEmployee)}", exception: e);
                return ExceptionJson(exception: e, name: nameof(CreateResource));
            }*/
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="модель"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        [HttpPost]
        public JsonResult CreateLogin(ДанныеИзФормы_СозданияЛогина_модель? модель)
        {
            throw new NotImplementedException();
            /*try
            {
                _заявка = СоздатьЗаявкуПоИмениТипа(Типы_Заявок.ЗаявкаНаСозданиеЛогинаВоДомене);
                
                var создатьЛогин = new Создать_Логин(commonService: _commonService, log: Log, логинПользователяСервиса: модель?.request_params.sender_login, модель: модель);
                if (создатьЛогин.Exception.IsNotNull()) { Debug.WriteLine(создатьЛогин.Exception?.Message); }
                return Json(data: создатьЛогин.ПолучитьJsonМодель(), behavior: JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(data: "Ошибка при создании логина", behavior: JsonRequestBehavior.AllowGet);
            }*/
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="модель"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CreateProfileName(/*ДанныеИзФормы_СозданияИмениПрофиля_модель модель*/)
        {
            throw new NotImplementedException();
            /*try
            {
                модель.Создать(commonService: _commonService, login: CurrentUserAccount.Login);
                return Json(data: модель.ПолучитьJsonМодель(), behavior: JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(data: "Ошибка при создании профиля", behavior: JsonRequestBehavior.AllowGet);
            }*/
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetJobs()
        {
            try
            {
                var data = new Должность(CommonService.ПолучитьВсеДолжности()).Получить();
                
                return JsonSuccess(data);
            }
            catch (Exception e)
            {
                return ExceptionJson(e, nameof(GetJobs));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult CheckLogin(string name = null)
        {
            try
            {
                var data = string.IsNullOrWhiteSpace(name)
                    ? null
                    : new 
                    {
                        isExist = CommonService
                            .ПолучитьЛогин(l => l.name == name)
                            .IsNotNull()
                    };
                
                return JsonSuccess(data);
            }
            catch (Exception e)
            {
                return ExceptionJson(e, nameof(CheckLogin));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetLogins()
        {
            try
            {
                var data = new Логин(CommonService.ПолучитьВсеЛогины()).Получить();
                
                return JsonSuccess(data);
            }
            catch (Exception e)
            {
                return ExceptionJson(e, nameof(GetLogins));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetFormPerms()
        {
            try
            {
                var data = new ФормаДопуска(CommonService.ПолучитьВсеФормыДопуска()).Получить();
                
                return JsonSuccess(data);
            }
            catch (Exception e)
            {
                return ExceptionJson(e, nameof(GetFormPerms));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetFiOs()
        {
            try
            {
                var data = CommonService.ПолучитьСуществующиеФИО
                    (r => r.id_new == null, DateTime.Now);

                return JsonSuccess(data);
            }
            catch (Exception e)
            {
                return ExceptionJson(e, nameof(GetFiOs));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetFIO(int? id)
        {
            try
            {
                var data = id.IsNullZeroOrLess()
                    ? null
                    : new ФИО(CommonService.ПолучитьФИО(r => r.id == id)).Получить();
                
                return JsonSuccess(data);
            }
            catch (Exception e)
            {
                return ExceptionJson(e, nameof(GetFIO));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult UpdateFIO(ДанныеИзФормы_ОбновленияФИО_модель модель)
        {
            throw new NotImplementedException("дописать если нужен метод");
            if (модель.Валидна().Нет()) return Json(null, JsonRequestBehavior.AllowGet);
            var обновитьФио = new Обновить_ФИО(модель, CommonService, _пользовательСервиса);
            if (обновитьФио.Exception.IsNotNull()) Debug.WriteLine(обновитьФио.Exception.Message);

            return Json(обновитьФио.ПолучитьJsonМодель(), JsonRequestBehavior.AllowGet);
        }

        
        [HttpPost]
        public JsonResult RollBackRequest(int? idRequest)
        {
            object? result = null;
            
            try
            {
                if (idRequest == null || idRequest < 1)
                    throw new ArgumentOutOfRangeException(nameof(idRequest));
                
                var создатель = new Создатель<ДанныеИзФормы>(
                    CommonService, Log
                );
                
                создатель.ОткатитьВсеСозданныеЗаявки(idRequest);
            }
            catch (Exception e)
            {
                Logger?.ОтправитьОшибкуВ_Лог(e);
                result = JsonHelper.СоздатьJsonМодель(e);
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ExecuteRequest(int? idRequest, RequestParams? requestParams)
        {
            object? result = null;
            
            try
            {
                if (idRequest == null || idRequest < 1) 
                    throw new ArgumentOutOfRangeException(nameof(idRequest));

                if (requestParams == null)
                    throw new ArgumentOutOfRangeException(nameof(requestParams));
                
                if (requestParams.request_state_id < 1)
                    throw new ArgumentOutOfRangeException(nameof(requestParams.request_state_id));

                var создатель = new Создатель<ДанныеИзФормы>(
                    CommonService, Log
                );

                создатель.ИсполнитьЗаявкуСоОпределеннымСтатусом(
                    CommonService.ПолучитьЗаявкуПоИд((int) idRequest),
                    (int) requestParams.request_state_id!
                );
                
                result = создатель.ПолучитьJsonМодель();
            }
            catch (Exception e)
            {
                Logger?.ОтправитьОшибкуВ_Лог(e);
                result = JsonHelper.СоздатьJsonМодель(e);
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        
        /// <summary>
        /// Получить ресурсы где пользователь является владельцем
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="domainAccount"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        [HttpGet]
        public JsonResult GetResourcesWhereUserIsOwner(string? dateTime, string? domainAccount)
        {
            try
            {
                ServiceRoles.ThrowIfNullOrWhiteSpace(domainAccount);
                
                var employee = ПолучитьПользователяПоДоменнойУчеткеСоПроверкойThrow(CommonService, Log, domainAccount);

                var data = CommonService
                    .ПолучитьРесурсыИзПредстГдеПользтельЯвлсяВладельцем
                        (employee.id); 
                
                return JsonSuccess(data);
            }
            catch (Exception e)
            {
                return ExceptionJson(e, nameof(GetResourcesWhereUserIsOwner));
            }
        }
        
        /// <summary>
        /// Получить ресурсы, где пользователь является ответственным
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="domainAccount"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetResourcesWhereUserIsResponsible(string? dateTime, string? domainAccount)
        {
            try
            {
                ServiceRoles.ThrowIfNullOrWhiteSpace(domainAccount);
                var employee = ПолучитьПользователяПоДоменнойУчеткеСоПроверкойThrow(CommonService, Log, domainAccount);

                var data = (CommonService
                        .ПолучитьРесурсыИзПредставленияГдеПользовательЯвляетсяОтветственным(employee.id) 
                            ?? 
                            Array.Empty<VIEW_REPORT_RESOURCES_WHERE_AM_I>())
                    .ToList(); 
                
                return JsonSuccess(data);
            }
            catch (Exception e)
            {
                return ExceptionJson(e, nameof(GetResourcesWhereUserIsResponsible));
            }
        }
        
        /// <summary>
        /// Все заявки пользователя, где он является отправителем либо ответственным
        /// </summary>
        /// <param name="domainAccount"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        [HttpGet]
        public JsonResult AllMyRequests(string? domainAccount)
        {
            try
            {
                ServiceRoles.ThrowIfNullOrWhiteSpace(domainAccount);
                
                var employee = ПолучитьПользователяПоДоменнойУчеткеСоПроверкойThrow(CommonService, Log, domainAccount);
                var заявки = CommonService.ПолучитьЗаявкиИзПредставления
                    (CommonService.ГлавныеЗаявки(employee.id));
                
                return JsonSuccess(заявки);
            }
            catch (Exception e)
            {
                return ExceptionJson(e, nameof(AllMyRequests));
            }
        }


        /// <summary>
        /// Получить все профили с подробностями для привилегированного пользователя
        /// </summary>
        /// <param name="domainAccount"></param>
        /// <param name="id_fragment"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetAllProfileInfos(string? domainAccount, int? id_fragment)
        {
            try
            {
                ПроверитьПараметрИдЕслиНадоКинутьИсключение(id_fragment, nameof(id_fragment));
                
                // бросаем исключение если учетка не привилегированная 
                ServiceRoles.ThrowIfNotPrivileged(domainAccount);
                
                // var employee = ПолучитьПользователяПоДоменнойУчеткеСоПроверкой(CommonService, Log, domainAccount);

                // получаем все профили, которые существуют на текущий момент
                var profiles = 
                    (CommonService.ПолучитьСуществующиеНаДатуПрофилиИзПредставления
                         (v => v.id_ac_fragment == id_fragment, DateTime.Now)
                     ?? Array.Empty<VIEW_PROFILE>())
                    .Where(r => true)
                    .ToList();

                // если профилей нет - возвращаем пустой массив любого типа
                if (profiles.Count < 1) return JsonSuccess(Array.Empty<int>()); 

                // получаем все профили, привязанные к ресурсам, с подробностями, из представления
                var viewReportAllProfiles =
                    (CommonService.ПолучитьВсеПрофилиИзПредставления(Право.НаРесурс)
                    ?? Array.Empty<VIEW_REPORT_ALL_PROFILES>())
                    .ToList();
                
                // формируем список объектов
                var enumerable = profiles.Select((v1, i) =>
                {
                    // отбираем только действующие профили
                    var profile = viewReportAllProfiles
                        .FirstOrDefault(v => v.id_profile == v1.id);

                    // получаем дополнительные данные по профилю
                    var profileObjectRights =
                        (CommonService.ПолучитьДанныеИзПредставления_VIEW_PROFILE_OBJECT_RIGHT
                             (v2 => v2.id_profile == v1.id)
                         ?? Array.Empty<VIEW_PROFILE_OBJECT_RIGHT>());

                    return new
                    {
                        id = profile?.id,
                        profile_name = profile?.profile_name,
                        _profile = new
                        {
                            profile?.id,
                            profile?.id_profile,
                            profile?.object_type_name,
                            profile?.frag_name,
                            profile?.profile_name,
                            profile?.resource_name,
                            profile?.secret_type_name,
                            profile?.service_type_name,

                            _objects = profileObjectRights
                        },
                    };
                });
                
                return JsonSuccess(enumerable);
            }   
            catch (Exception e)
            {
                return ExceptionJson(e, nameof(GetAllProfileInfos));
            }
        }


        /// <summary>
        /// Существующие профили, которые создавал пользователь для самого себя,
        /// либо которые созданы для пользователя кем-то 
        /// </summary>
        /// <param name="domainAccount"></param>
        /// <param name="id_fragment"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        [HttpGet]
        public JsonResult MyProfiles(string? domainAccount, int? id_fragment)
        {
            try
            {
                ПроверитьПараметрИдЕслиНадоКинутьИсключение(id_fragment, nameof(id_fragment));
                
                ServiceRoles.ThrowIfNullOrWhiteSpace(domainAccount);
                var employee = ПолучитьПользователяПоДоменнойУчеткеСоПроверкойThrow(CommonService, Log, domainAccount);

                // получаем все профили пользователя, которые существуют на текущий момент
                var profiles = 
                    (
                        CommonService.ПолучитьСуществующиеНаДатуПрофилиИзПредставления
                            (v => v.id_ac_fragment == id_fragment, DateTime.Now)
                        ??
                        Array.Empty<VIEW_PROFILE>()
                    )
                    .Where(r => r.id_user_recipient == employee.id)
                    .ToList();

                // если профилей у пользователя нет - возвращаем пустой массив любого типа
                if (profiles.Count < 1) return JsonSuccess(Array.Empty<int>()); 

                // получаем все профили, привязанные к ресурсам, с подробностями, из представления, где пользователь является получателем услуги,
                // другими словами профиль создавался для него или им

                var viewReportAllProfiles =
                    CommonService.ПолучитьПрофилиИзПредставления(id_user_recipient: employee.id, Право.НаРесурс)
                    ?? Array.Empty<VIEW_REPORT_ALL_PROFILES>();
                
                // формируем список объектов
                var enumerable = profiles.Select((v1, i) =>
                {
                    var profile = viewReportAllProfiles
                        .FirstOrDefault(v => v.id_profile == v1.id);

                    var profileObjectRights =
                        (CommonService.ПолучитьДанныеИзПредставления_VIEW_PROFILE_OBJECT_RIGHT
                             (v2 => v2.id_profile == v1.id)
                         ?? Array.Empty<VIEW_PROFILE_OBJECT_RIGHT>());

                    return new
                    {
                        id = profile?.id,
                        profile_name = profile?.profile_name,
                        _profile = new
                        {
                            profile?.id,
                            profile?.id_profile,
                            profile?.object_type_name,
                            profile?.frag_name,
                            profile?.profile_name,
                            profile?.resource_name,
                            profile?.secret_type_name,
                            profile?.service_type_name,

                            _objects = profileObjectRights
                        },
                    };
                });
                
                return JsonSuccess(enumerable);
            }   
            catch (Exception e)
            {
                return ExceptionJson(e, nameof(MyProfiles));
            }
        }


        /// <summary>
        /// Подробности профиля вместе с созданными объектами 
        /// </summary>
        /// <param name="idProfile"></param>
        /// <param name="domainAccount"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        [HttpGet]
        public JsonResult GetProfileObjects(int? idProfile, string? domainAccount)
        {
            try
            {
                БроситьИсключениеЕслиАргументНуллИлиМеньшеЕдиницы(idProfile, nameof(idProfile));
                
                ServiceRoles.ThrowIfNullOrWhiteSpace(domainAccount);
                var employee = ПолучитьПользователяПоДоменнойУчеткеСоПроверкойThrow(CommonService, Log, domainAccount);

                var profile = CommonService.ПолучитьПрофильИзПредставления
                (v =>
                    v.id_profile == idProfile
                    && v.id_user_recipient == employee.id) 
                              ?? throw new Exception
                              ($@"Профиль c id={idProfile} и domainAccount={domainAccount} не найден");

                var profileObjectRights = (CommonService
                        .ПолучитьДанныеИзПредставления_VIEW_PROFILE_OBJECT_RIGHT
                            (v => v.id_profile == profile.id_profile) 
                                           ?? Array.Empty<VIEW_PROFILE_OBJECT_RIGHT>())
                    .ToList();

                return JsonSuccess(new
                {
                    _profile = new
                    {
                        profile?.id_profile,
                        profile?.object_type_name,
                        profile?.frag_name,
                        profile?.profile_name,
                        profile?.resource_name,
                        profile?.secret_type_name,
                        profile?.service_type_name,
                        
                        _objects = profileObjectRights
                    },
                });
            }   
            catch (Exception e)
            {
                return ExceptionJson(e, nameof(MyProfiles));
            }
        }

        /// <summary>
        /// Отдаем содержимое заявки для предпросмотра в представлении 
        /// </summary>
        /// <param name="idRequest"></param>
        /// <param name="requestTypeCode"></param>
        /// <param name="domainAccount"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetRequestContent(int? idRequest, string? requestTypeCode, string? domainAccount)
        {
            try
            {
                БроситьИсключениеЕслиАргументНуллИлиМеньшеЕдиницы(idRequest, nameof(idRequest));
                ServiceRoles.ThrowIfNullOrWhiteSpace(requestTypeCode);
                ServiceRoles.ThrowIfNullOrWhiteSpace(domainAccount);
                
                var employee = ПолучитьПользователяПоДоменнойУчеткеСоПроверкойThrow(CommonService, Log, domainAccount);
                var isPrivileged = ServiceRoles.IsPrivileged(domainAccount);
                
                return JsonSuccess(CommonService.ПолучитьСодержимоеЗаявки(
                    new ПолучитьСодержимоеЗаявкиМодель (
                            idRequest,
                            requestTypeCode,
                            domainAccount,
                            employee,
                            isPrivileged,
                            Log
                    )));
            }
            catch (Exception e)
            {
                return ExceptionJson(e, nameof(GetRequestContent));
            }
        }

        /// <summary>
        /// Дерево ресурсов/профилей/субъектов профилей -
        ///
        /// для привилегированных отдаем всё,
        /// для владельцев и ответственных фильтруем 
        /// </summary>
        /// <param name="domainAccount"></param>
        /// <param name="id_fragment"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        [HttpGet]
        public JsonResult GetTreeOfResources(string? domainAccount, int? id_fragment)
        {
            try
            {
                ПроверитьПараметрИдЕслиНадоКинутьИсключение(id_fragment, nameof(id_fragment));
                var isPrivileged = ServiceRoles.IsPrivileged(domainAccount);

                var employee = ПолучитьПользователяПоДоменнойУчеткеСоПроверкойThrow
                    (CommonService, Log, domainAccount);

                var действующиеРесурсы =
                    (CommonService
                        .ПолучитьДействующие(CommonService
                            .ПолучитьРесурсыИзПредставленияГдеПользовательЯвляется
                                (r => true), DateTime.Now) 
                     ?? Array.Empty<VIEW_REPORT_RESOURCES_WHERE_AM_I>())
                    .ToList();

                var отфильтрованныеДействующиеРесурсы = CommonService
                    .ФильтрТолькоДляПривилегированныйОтветственныйВладелец(
                        действующиеРесурсы,
                        employee.id,
                        isPrivileged
                    );

                if (отфильтрованныеДействующиеРесурсы?.Count < 1) return JsonSuccess(null);

                // готовим список для плоского дерева
                // List<ArrayTreeStruct> arrayTree = new List<ArrayTreeStruct>();
                List<object> arrayTree = new List<object>(); 
                
                СобратьДеревоРесурсов(отфильтрованныеДействующиеРесурсы, arrayTree);

                return JsonSuccess(arrayTree);
            }
            catch (Exception e)
            {
                return ExceptionJson(e, nameof(GetTreeOfResources));
            }


            void ПеребратьПрофили(
                IEnumerable<VIEW_PROFILE_OBJECT_RIGHT> профилиРесурса,
                ref int treeCounter,
                List<object> arrayTree, 
                int parent
            )
            {
                foreach (var проф in профилиРесурса)
                {
                    // добавляем профиль как дочерний объект ресурса
                    arrayTree.Add(new
                    {
                        id = ++treeCounter,
                        проф.id_profile,
                        name = "[П] " + проф.profile_name,
                        parent = parent,
                        type = "ПРОФИЛЬ"
                    });
                    var lastTreeCount = treeCounter;

                    // берем профиль и получаем всех сотрудников, в него входящих
                    var сотрудникиПрофиля = 
                        (CommonService
                             .ПолучитьСубъектовИзПрофиляИзПредставления
                                 (m => m.id_profile == проф.id_profile)
                                             ??
                                             Array.Empty<VIEW_MEMBER_USER>())
                        .ToList();

                    // сотрудники и оргСтруктуры должны находиться на одном уровне
                    ПеребратьПользователей(сотрудникиПрофиля, ref treeCounter, arrayTree, lastTreeCount);    

                    var оргСтруктурыПрофиля = 
                        (CommonService
                            .ПолучитьОргСтруктурыИзПрофиляИзПредставления
                                (v => v.id_profile == проф.id_profile) 
                         ?? 
                         Array.Empty<VIEW_MEMBER_ORG>())
                        .ToList();

                    ПеребратьОргСтруктуры(оргСтруктурыПрофиля, ref treeCounter, arrayTree, lastTreeCount);
                }
            }

            void ПеребратьТиповыеРесурсы(
                IEnumerable<VIEW_REPORT_RESOURCES_WHERE_AM_I> типовыеРесурсы,
                ref int treeCounter,
                List<object> arrayTree,
                int parent
            )
            {
                foreach (var типовойРесурс in типовыеРесурсы)
                {
                    // добавляем ресурс как дочерний объект типа ресурса
                    arrayTree.Add(new
                    {
                        id = ++treeCounter,
                        типовойРесурс.id_resource,
                        name = $"[Р] {типовойРесурс.resource_name}" ?? ЗНАЧЕНИЕ_НЕ_ОПРЕДЕЛЕНО,
                        parent,
                        type = "РЕСУРС"
                    });

                    var ресурс = CommonService.ПолучитьРесурсПоИд(типовойРесурс.id_resource);

                    // берем ресурс и запрашиваем его профили
                    var профилиРесурса = 
                        (CommonService
                            .ПолучитьПрофилиПривязанныеКоРесурсу(ресурс?.id_object)
                         ??
                         Array.Empty<VIEW_PROFILE_OBJECT_RIGHT>())
                        .ToList();

                    if (профилиРесурса.Count < 1) continue;

                    // перебираем все профили ресурса
                    ПеребратьПрофили(профилиРесурса, ref treeCounter, arrayTree, treeCounter);
                }
            }

            void СобратьДеревоРесурсов(
                IReadOnlyCollection<VIEW_REPORT_RESOURCES_WHERE_AM_I> действующиеРесурсы,
                List<object> arrayTree
            )
            {
                // счетчик нод дерева
                var treeCounter = 0;
                
                var типыОбъектов = 
                    (CommonService
                         .ПолучитьТипыОбъектов(o => o.main_object == 1)
                     ??
                     throw new InvalidOperationException("Не удалось получить типы объектов"))
                    .ToList();

                foreach (var типРесурса in типыОбъектов)
                {
                    // добавляем тип ресурса в массив дерева
                    arrayTree.Add(new
                    {
                        id = ++treeCounter,
                        name = типРесурса.name,
                        parent = "",
                        type = "ТИП РЕСУРСА"
                    });

                    // берем первый тип объектов и фильтруем действующие ресурсы с данным типом
                    var типовыеРесурсы =
                        действующиеРесурсы
                            .Where(r => r.object_type_id == типРесурса.id)
                            .ToList();

                    if (типовыеРесурсы.Count < 1) continue;

                    // перебираем типовые ресурсы
                    ПеребратьТиповыеРесурсы(типовыеРесурсы, ref treeCounter, arrayTree, treeCounter);
                }
            }

            static void ПеребратьПользователей
            (
                IEnumerable<VIEW_MEMBER_USER> сотрудникиПрофиля,
                ref int treeCounter,
                ICollection<object> arrayTree,
                int parent
            )
            {
                foreach (var viewMemberUser in сотрудникиПрофиля)
                {
                    // добавляем пользователя как дочерний объект профиля
                    arrayTree.Add(new
                    {
                        id = ++treeCounter,
                        id_user = viewMemberUser.id_user,
                        name = viewMemberUser.fio_full,
                        parent = parent,
                        type = "СОТРУДНИК"
                    });
                }
            }

            static void ПеребратьОргСтруктуры
            (
                IEnumerable<VIEW_MEMBER_ORG> оргСтруктурыПрофиля,
                ref int treeCounter,
                ICollection<object> arrayTree, 
                int parent
            )
            {
                foreach (var viewMemberOrg in оргСтруктурыПрофиля)
                {
                    // добавляем пользователя как дочерний объект профиля
                    arrayTree.Add(new
                    {
                        id = ++treeCounter,
                        id_org = viewMemberOrg.id_org,
                        name = viewMemberOrg.org_fname,
                        parent = parent,
                        type = "ОРГ_СТРУКТУРА"
                    });
                }
            }
        }

        private struct ArrayTreeStruct
        {
            public int id { get; set; }
            public string name { get; set; }
            public int? parent { get; set; }
            public int? id_user { get; set; }
            public int? id_org { get; set; }
            public string type { get; set; }
        }
    }
} 