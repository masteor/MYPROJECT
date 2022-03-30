using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using QWERTY.Shared.Db;
using QWERTY.Shared.Db.Entities.Представления;
using QWERTY.Shared.Db.Infrastructure;
using QWERTY.Shared.Db.Repositories;
using QWERTY.Shared.Db.Services;
using QWERTY.Shared.Db.Validation;
using QWERTY.Shared.Db.Компараторы;
using QWERTY.Shared.Enums;
using QWERTY.Shared.Extensions;
using QWERTY.Shared.Helpers;
using QWERTY.Shared.Models;
using QWERTY.Web.Core;
using QWERTY.Web.Core.Authentication;
using QWERTY.Web.Core.Extensions;
using QWERTY.Web.Models.ReportAjax;

namespace QWERTY.Web.Controllers.Ajax
{
    public class ReportAjaxController : WebBaseController
    {
        private new readonly ICommonService CommonService;

        /*private ОбщиеСервисы _общиеСервисыImplementation;*/
        public ReportAjaxController(ICommonService commonService)
        {
            CommonService = commonService;
        }

        private int колвоЗаписей => -1; // -1 - все записи

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetAcAccess(string? dateTime)
        {
            try
            {
                var data = CommonService
                    .ПолучитьДопущенныхкРаботевАС(mode: Query_mode.Все, data: dateTime.ЗапарситьДату());
                
                return JsonSuccess(data: data);
            }
            catch (Exception e)
            {
                return Json(
                    data: JsonModel.СоздатьСообщениеОбОшибке(data: null, msg: $"Ошибка в методе {nameof(GetAcAccess)}: {e.Message}"),
                    behavior: JsonRequestBehavior.AllowGet
                );
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet]
        public JsonResult GetAllResources(string? dateTime)
        {
            try
            {
                var data = CommonService
                    .ПолучитьВсе_Или_СуществующиеНаДату_Ресурсы(data: dateTime.ЗапарситьДату());
                
                return JsonSuccess(data: data);
            }
            catch (Exception e)
            {
                return Json(
                    data: JsonModel.СоздатьСообщениеОбОшибке(data: null, msg: $"Ошибка в методе {nameof(GetAllResources)}: {e.Message}"),
                    behavior: JsonRequestBehavior.AllowGet
                );
            }
        }

        
        
        
        
        
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetAllResourcesFromPrd(string? dateTime)
        {
            try
            {
                throw new NotImplementedException("Метод [GetAllResourcesFromPrd] требует переделки. PRD больше нет");
                /*var data = CommonService
                    .ПолучитьСуществующиеРесурсыИзPrd(data: dateTime.ЗапарситьДату());
                
                return JsonSuccess(data: data);*/

                return JsonSuccess(null);
            }
            catch (Exception e)
            {
                return Json(
                    data: JsonModel.СоздатьСообщениеОбОшибке(data: null,
                        msg: $"Ошибка в методе {nameof(GetAllResourcesFromPrd)}: {e.Message}"),
                    behavior: JsonRequestBehavior.AllowGet
                );
            }
        }

        [HttpGet]
        public JsonResult GetRsdFromPrd(string? dateTime)
        {
            try
            {
                throw new NotImplementedException("переделать метод [GetRsdFromPrd]");
                /*var data = CommonService
                    .ПолучитьСуществующиеРесурсыИСубьектовДоступаИзPrd(dateTime: dateTime.ЗапарситьДату());
                
                return JsonSuccess(data: data);*/
                
                return JsonSuccess(null);
            }
            catch (Exception e)
            {
                return Json(
                    data: JsonModel.СоздатьСообщениеОбОшибке(data: null, msg: $"Ошибка в методе {nameof(GetRsdFromPrd)}: {e.Message}"),
                    behavior: JsonRequestBehavior.AllowGet
                );
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetAllArmUsers(string? dateTime)
        {
            try
            {
                var data = CommonService
                    .ПолучитьСуществующиеДопускиПользователейНаАРМы(data: dateTime!.ЗапарситьДату());
                
                return JsonSuccess(data: data);
            }
            catch (Exception e)
            {
                return Json(
                    data: JsonModel.СоздатьСообщениеОбОшибке(data: null, msg: $"Ошибка в методе {nameof(GetAllArmUsers)}: {e.Message}"),
                    behavior: JsonRequestBehavior.AllowGet
                );
            }
        }

        /// <summary>
        /// ПЕРЕЧЕНЬ_АРМ_В_АС
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetAllArms(string? dateTime)
        {
            try
            {
                var data = CommonService
                    .ПолучитьСуществующиеАРМы(data: dateTime.ЗапарситьДату());
                
                return JsonSuccess(data: data);
            }
            catch (Exception e)
            {
                return Json(
                    data: JsonModel.СоздатьСообщениеОбОшибке(data: null, msg: $"Ошибка в методе {nameof(GetAllArms)}: {e.Message}"),
                    behavior: JsonRequestBehavior.AllowGet
                );
            }
        }

        /*[HttpGet]
        public JsonResult USERS_ACCEPTED_RESOURCE(int? id)
        {
            if (id == null) return Json(data: null, behavior: JsonRequestBehavior.AllowGet);
            try
            {
                var list = _commonService.ПолучитьДопущенныхКРесурсу(идРесурса: (int)id);
                list = list.ПолучитьДиапазон(to: колвоЗаписей);

                var data = list
                    .Select(selector: r 
                        => new ДопущенныйКРесурсу(r: r));
                
                return JsonSuccess(data: data);
            }
            catch (Exception e)
            {
                return Json(
                    data: JsonModel.СоздатьСообщениеОбОшибке(data: null, msg: $"Ошибка в методе {nameof(GetAllArms)}: {e.Message}"),
                    behavior: JsonRequestBehavior.AllowGet
                );
            }
        }*/

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet]
        public JsonResult GetAllResourcesWithMembers(string? dateTime)
        {
            throw new NotImplementedException();
            
            /*var list = _commonService.ПолучитьРесурсыСДопускамиИзПредставления(dateTime.ЗапарситьДату());
            return Json(list.Select(r => new СуществующийРесурс(r)), JsonRequestBehavior.AllowGet);*/
        }
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetRsd(string? dateTime)
        {
            try
            {
                var data = CommonService
                    .ПолучитьСуществующиеРесурсыИСубьектовДоступа(dateTime: dateTime.ЗапарситьДату());

                return JsonSuccess(data: data);
            }
            catch (Exception e)
            {
                return Json(
                    data: JsonModel.СоздатьСообщениеОбОшибке(data: null, msg: $"Ошибка в методе {nameof(GetRsd)}: {e.Message}"),
                    behavior: JsonRequestBehavior.AllowGet
                );
            }
        }

        /*[HttpGet]
        public JsonResult RegisteredRequests() =>
            Json(_commonService.ПолучитьЗаявки(r => r.ид_текущего_состояния_заявки == (int) IdСтатусаЗаявки.Закрыта),
                JsonRequestBehavior.AllowGet);*/
        
        /// <summary>
        /// Забираем заявки, которые находятся в статусе Зарегистрирована, Открыта, Отложена
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult ActiveRequests(string? domainAccount)
        {
            try
            {
                ServiceRoles.ThrowIfNotPrivileged(domainAccount);
                
                // забираем только главные заявки, без подчиненных
                var заявкиИзПредставления = CommonService
                    .ПолучитьЗаявкиИзПредставления(v => v.parent == null);
                
                var data = ((заявкиИзПредставления ?? Array.Empty<VIEW_REPORT_ALL_REQUESTS>())
                    .Where(predicate: LinqHelpers.ФильтрНаходятсяНаЭтапеСоздания<CreateRequestState>()))
                        .ToList();
                
                // преобразуем дату в строку, потому что Javascript не понимает формат даты
                    
                return JsonSuccess(data: data);
            }
            catch (Exception e)
            {
                return ExceptionJson(e, nameof(ActiveRequests));
                
                return Json(
                    data: JsonModel.СоздатьСообщениеОбОшибке(data: null, msg: $"Ошибка в методе {nameof(ActiveRequests)}: {e.Message}"),
                    behavior: JsonRequestBehavior.AllowGet
                );
            }
        }
        
        
        /// <summary>
        /// Выполненные заявки для админа
        /// </summary>
        /// <param name="domainAccount"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        [HttpGet]
        public JsonResult FinishedRequests(string? domainAccount)
        {
            try
            {
                ServiceRoles.ThrowIfNotPrivileged(domainAccount);
                
                // забираем только главные заявки, без подчиненных
                var заявкиИзПредставления = CommonService
                    .ПолучитьЗаявкиИзПредставления(v => v.parent == null);
                
                var data = (заявкиИзПредставления ?? Array.Empty<VIEW_REPORT_ALL_REQUESTS>())
                    .Where(predicate: LinqHelpers.ФильтрВыполнены<CreateRequestState>())
                    .ToList();
                
                return JsonSuccess(data: data);
            }
            catch (Exception e)
            {
                return ExceptionJson(e, nameof(FinishedRequests));
            }
        }


        

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public JsonResult GetTest()
        {
            Common_Service service = new Common_Service
                (repository: new TEST_Repository
                (dbFactory: new DbFactory(connectionString: "QWERTY")));
            
            return Json(data: service._testRepository?.GetAll(),
                behavior: JsonRequestBehavior.AllowGet);
        }

        /*protected override Expression<Func<ARM_USER, bool>> СоответствующиеДате(DateTime data)
        {
            Expression<Func<ARM_USER, bool>> where = armUser =>
                armUser.ЗаявкаРазрешенияДопуска != null
                && armUser.ЗаявкаРазрешенияДопуска.ДатаЗавершения != null
                && armUser.ЗаявкаРазрешенияДопуска.ДатаЗавершения <= data
                && armUser.ЗаявкаПрекращенияДопуска != null
                && armUser.ЗаявкаПрекращенияДопуска.ДатаЗавершения != null
                && armUser.ЗаявкаПрекращенияДопуска.ДатаЗавершения >= data;

            return where;*/
        /*
                    Expression<Func<ARM_USER, bool>> where = armUser =>
                        armUser.ЗаявкаРазрешенияДопуска != null
                        && armUser.ЗаявкаРазрешенияДопуска.ДатаЗавершения != null
                        && armUser.ЗаявкаРазрешенияДопуска.ДатаЗавершения.Value.Ticks <= data.Ticks
                        && armUser.ЗаявкаПрекращенияДопуска != null
                        && armUser.ЗаявкаПрекращенияДопуска.ДатаЗавершения != null
                        && armUser.ЗаявкаПрекращенияДопуска.ДатаЗавершения.Value.Ticks >= data.Ticks;
                    return where;
        */



    }
}
