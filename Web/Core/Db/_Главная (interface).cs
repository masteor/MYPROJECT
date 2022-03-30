using System;
using System.Collections.Generic;
using DBPSA.Shared.Db.Entities;
using DBPSA.Shared.Db.Entities.Представления;

namespace DBPSA.Web.Core.Db
{
    /*public interface IОбщиеСервисы
    {
        IEnumerable<EMPLOYEE> ПолучитьВсехНачальниковОтделений();
    }*/

    public partial class ОбщиеСервисы : WebBaseController
    {
        protected IARM_DEVICE_Service _ArmUserDeviceService { get; }
        protected IDOC_Service _DocService { get; }
        protected IEMPLOYEE_Service _EmployeeService { get; }
        protected IREQUEST_Service _RequestService { get; }
        protected IRESOURCE_Service _ResourceService { get; }
        protected IDIC_Service _DicService { get; set; }
        
        public ОбщиеСервисы (
            IARM_DEVICE_Service armUserDeviceService,
            IDOC_Service docService,
            IEMPLOYEE_Service employeeService,
            IREQUEST_Service requestService,
            IRESOURCE_Service resourceService,
            IDIC_Service dicService
        )
        {
            _DicService = dicService;
            _ArmUserDeviceService = armUserDeviceService;
            _DocService = docService;
            _EmployeeService = employeeService;
            _RequestService = requestService;
            _ResourceService = resourceService;
        }

        protected readonly List<Type> ArmUserDeviceServiceList = new List<Type>
            {
                typeof(ARM_USER), 
                typeof(AC_ACCESS),
                typeof(ARM),
                typeof(ARM_DEVICE),
                typeof(ARM_USER_ROLE),
                typeof(DEVICE),
                typeof(DEVICE_PERM),
                typeof(DEVICE_TYPE),
                typeof(VIEW_AC_ACCESS_ORG)
            };

        protected readonly List<Type> DocServiceList = new List<Type>
            {
                typeof(DOC),
                typeof(DOC_TYPE)
            };

        protected readonly List<Type> EmployeeServiceList = new List<Type>
            {
                typeof(BUILDING),
                typeof(EMPLOYEE),
                typeof(EMPLOYEE_IN_ORG),
                typeof(FIO),
                typeof(FORM_PERM),
                typeof(JOB),
                typeof(LOGIN),
                typeof(ORG),
                typeof(ORG_UNIT_TYPE),
                typeof(PROM_AREA),
                typeof(ROOM),
                typeof(RSO),
                typeof(STAFF),
                typeof(STAFF_UNIT),
                typeof(USER_ROOM)
            };

        protected readonly List<Type> RequestServiceList = new List<Type>
            {
                typeof(EXECUTION),
                typeof(NOTIFY_SUB),
                typeof(NOTIFY_REQUEST),
                typeof(REQUEST),
                typeof(REQUEST_STATE),
                typeof(REQUEST_TYPE),
                typeof(REQUEST_TYPE_STAFF)
            };

        protected readonly List<Type> ResourceServiceList = new List<Type>
            {
                typeof(AC_FRAGMENT),
                typeof(MEMBER),
                typeof(OBJECT),
                typeof(OBJECT_TYPE),
                typeof(PROFILE),
                typeof(RESOURCE),
                typeof(RESOURCE_RESP),
                typeof(RESOURCE_UCA),
                typeof(RIGHT),
                typeof(RIGHT_GROUP),
                typeof(RIGHT_DESCR),
                typeof(SECRET_TYPE),
                typeof(SERVICE),
                typeof(SERVICE_TYPE),
                typeof(UCA_LIST),
                typeof(RIGHT_OBJECT_TYPE),
                typeof(VIEW_OBJECT_USER_RIGHTS),
                typeof(VIEW_OBJECT_USER_RIGHTS_DISTINCTED),
                typeof(VIEW_RESOURCE_USER_RIGHT)
            };
        
        
        
        /// <summary>
        /// абстрактный класс, который требует реализации
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        /*private protected abstract Expression<Func<ARM_USER, bool>> СоответствующиеДате(DateTime date);*/

        /// <summary>
        /// 
        /// </summary>
        /// <param name="допуск">допуск пользователя на АРМ</param>
        /// <param name="repo"></param>
        protected void Обновить<TS>(TS entity)
        {
            if (ArmUserDeviceServiceList.Contains(typeof(TS))) { _ArmUserDeviceService.Обновить(entity); return; }
            if (DocServiceList.Contains(typeof(TS))) { _DocService.Обновить(entity); return; }
            if (EmployeeServiceList.Contains(typeof(TS))) { _EmployeeService.Обновить(entity); return; }
            if (RequestServiceList.Contains(typeof(TS))) { _RequestService.Обновить(entity); return; }
            if (ResourceServiceList.Contains(typeof(TS))) { _ResourceService.Обновить(entity); return; }
            
            throw new Exception($"не написан код для обработки типа {typeof(TS)}");                    
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <typeparam name="TS"></typeparam>
        /// <exception cref="Exception"></exception>
        protected void КоммитнутьРепозиторий(Type type)
        {
            if (ArmUserDeviceServiceList.Contains(type)) { _ArmUserDeviceService.Коммитнуть(type); return; }
            if (DocServiceList.Contains(type)) { _DocService.Коммитнуть(type); return; }
            if (EmployeeServiceList.Contains(type)) { _EmployeeService.Коммитнуть(type); return; }
            if (RequestServiceList.Contains(type)) { _RequestService.Коммитнуть(type); return; }
            if (ResourceServiceList.Contains(type)) { _ResourceService.Коммитнуть(type); return; }
            
            throw new Exception($"не написан код для обработки типа {type}");                    
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="entity"></param>
        /// <exception cref="Exception"></exception>
        protected void Удалить<TS>(TS entity)
        {
            if (ArmUserDeviceServiceList.Contains(typeof(TS))) { _ArmUserDeviceService.Удалить(entity); return; }
            if (DocServiceList.Contains(typeof(TS))) { _DocService.Удалить(entity); return; }
            if (EmployeeServiceList.Contains(typeof(TS))) { _EmployeeService.Удалить(entity); return; }
            if (RequestServiceList.Contains(typeof(TS))) { _RequestService.Удалить(entity); return; }
            if (ResourceServiceList.Contains(typeof(TS))) { _ResourceService.Удалить(entity); return; }
            
            throw new Exception($"не написан код для обработки типа {typeof(TS)}");                    
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <typeparam name="TS"></typeparam>
        /// <exception cref="Exception"></exception>
        protected TS Создать<TS>(TS entity) where TS : class
        {
            if (ArmUserDeviceServiceList.Contains(typeof(TS))) { return _ArmUserDeviceService.Создать(entity); }
            if (DocServiceList.Contains(typeof(TS))) { return _DocService.Создать(entity); }
            if (EmployeeServiceList.Contains(typeof(TS))) { return _EmployeeService.Создать(entity); }
            if (RequestServiceList.Contains(typeof(TS))) { return _RequestService.Создать(entity); }
            if (ResourceServiceList.Contains(typeof(TS))) { return _ResourceService.Создать(entity); }
            
            throw new Exception($"не написан код для обработки типа {typeof(TS)}");                    
        }
        
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="acAccessOrg"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="armUser"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="acAccessOrg"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        /*public static bool НаДату(VIEW_OBJECT_USER_RIGHTS_DISTINCTED acAccessOrg, DateTime data) => НаДату
            (data, acAccessOrg?.ЗаявкаПредоставленияДоступаСубъектуК_Профилю?.ДатаЗавершения,
            acAccessOrg?.ЗаявкаПрекращенияДоступаСубъектуК_Профилю?.ДатаЗавершения);*/
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="датаРазрешения"></param>
        /// <param name="датаПрекращения"></param>
        /// <returns></returns>
        
    }
}