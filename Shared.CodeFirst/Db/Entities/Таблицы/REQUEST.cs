using System;
using System.Collections.Generic;
using QWERTY.Shared.Db.Entities.Представления;

namespace QWERTY.Shared.Db.Entities.Таблицы
{
    public interface IREQUEST
    {
        public int id { get; set; }
        public int id_request_type { get; set; }
        public DateTime date_1 { get; set; }
        public DateTime? date_2 { get; set; }
        public int id_user_1 { get; set; }
        public int id_user_2 { get; set; }
        public int id_request_state { get; set; }
        public int? id_doc { get; set; }
        public string? reg_num { get; set; }
        public int? parent { get; set; }
    }

    /// <summary>
    /// Заявки
    /// </summary>
    public sealed class REQUEST : _EntityBase, IREQUEST
    {
        /*public REQUEST()
        {
            ARM = new HashSet<ARM>();
            AC_ACCESS1 = new HashSet<AC_ACCESS>();
            AC_ACCESS2 = new HashSet<AC_ACCESS>();
            ARM1 = new HashSet<ARM>();
            ARM_DEVICE = new HashSet<ARM_DEVICE>();
            ARM_DEVICE1 = new HashSet<ARM_DEVICE>();
            ARM_USER = new HashSet<ARM_USER>();
            ARM_USER1 = new HashSet<ARM_USER>();
            DEVICE = new HashSet<DEVICE>();
            DEVICE1 = new HashSet<DEVICE>();
            RIGHT = new HashSet<RIGHT>();
            RIGHT1 = new HashSet<RIGHT>();
            RESOURCE_UCA = new HashSet<RESOURCE_UCA>();
            RESOURCE_UCA1 = new HashSet<RESOURCE_UCA>();
            RESOURCE_RESP = new HashSet<RESOURCE_RESP>();
            RESOURCE_RESP1 = new HashSet<RESOURCE_RESP>();
            MEMBER = new HashSet<MEMBER>();
            MEMBER1 = new HashSet<MEMBER>();
            PROFILE = new HashSet<PROFILE>();
            PROFILE1 = new HashSet<PROFILE>();
            EMPLOYEE = new HashSet<EMPLOYEE>();
            EMPLOYEE1 = new HashSet<EMPLOYEE>();
            EMPLOYEE_ORG_2 = new HashSet<EMPLOYEE_IN_ORG>();
            EMPLOYEE_ORG_1 = new HashSet<EMPLOYEE_IN_ORG>();
            EXECUTION = new HashSet<EXECUTION>();
            FIO = new HashSet<FIO>();
            FIO1 = new HashSet<FIO>();
            
            NOTIFY_REQUEST = new HashSet<NOTIFY_REQUEST>();
            OBJECT = new HashSet<OBJECT>();
            OBJECT1 = new HashSet<OBJECT>();
            ORG = new HashSet<ORG>();
            ORG1 = new HashSet<ORG>();
            RESOURCE = new HashSet<RESOURCE>();
            RESOURCE1 = new HashSet<RESOURCE>();
            SERVICE = new HashSet<SERVICE>();
            SERVICE1 = new HashSet<SERVICE>();
            STAFF = new HashSet<STAFF>();
            STAFF1 = new HashSet<STAFF>();
            STAFF_UNIT = new HashSet<STAFF_UNIT>();
            STAFF_UNIT1 = new HashSet<STAFF_UNIT>();
            USER_ROOM = new HashSet<USER_ROOM>();
            USER_ROOM1 = new HashSet<USER_ROOM>();
            VIEW_AC_ACCESS_ORG_1 = new HashSet<VIEW_AC_ACCESS_ORG>();
            VIEW_AC_ACCESS_ORG_2 = new HashSet<VIEW_AC_ACCESS_ORG>();
            VIEW_OBJECT_USER_RIGHTS_1 = new HashSet<VIEW_OBJECT_USER_RIGHTS_DISTINCTED>();
            VIEW_OBJECT_USER_RIGHTS_2 = new HashSet<VIEW_OBJECT_USER_RIGHTS_DISTINCTED>();
        }*/

        public REQUEST(IREQUEST _)
        {
            id = _.id;
            id_request_type = _.id_request_type;
            date_1 = _.date_1;
            date_2 = _.date_2;
            id_user_1 = _.id_user_1;
            id_user_2 = _.id_user_2;
            id_request_state = _.id_request_state;
            id_doc = _.id_doc;
            reg_num = _.reg_num;
            parent = _.parent;
        }

        public REQUEST()
        {
        }

        public int id { get; set; }
        
        // ид_типа_заявки
        public int id_request_type { get; set; }
        
        // дата_создания
        public DateTime date_1 { get; set; }
        
        // дата_завершения
        public DateTime? date_2 { get; set; }
        
        // ид_пользователя_подавшего_заявку
        public int id_user_1 { get; set; }
        
        // ид_пользователя_получателя_услуги
        public int id_user_2 { get; set; }
        
        // ид_текущего_статуса_заявки
        public int id_request_state { get; set; }
        
        public int? id_doc { get; set; }
        
        // регистрационный_номер
        public string reg_num { get; set; } = "";

        public int? parent { get; set; }

        // public virtual DOC? DOC { get; set; }
//        public REQUEST_TYPE? REQUEST_TYPE { get; set; }
        /*public virtual REQUEST_STATE? REQUEST_STATE { get; set; }*/
        /*public EMPLOYEE? EMPLOYEE2 { get; set; }
        public EMPLOYEE? EMPLOYEE3 { get; set; }*/

        /*public ICollection<EMPLOYEE_IN_ORG>? EMPLOYEE_ORG_2 { get; set; }
        public ICollection<EMPLOYEE_IN_ORG>? EMPLOYEE_ORG_1 { get; set; }
        public ICollection<EXECUTION>? EXECUTION { get; set; }
        public ICollection<FIO>? FIO { get; set; }
        public ICollection<FIO>? FIO1 { get; set; }
        
        public ICollection<NOTIFY_REQUEST>? NOTIFY_REQUEST { get; set; }
        public ICollection<OBJECT>? OBJECT { get; set; }
        public ICollection<OBJECT>? OBJECT1 { get; set; }
        public ICollection<ORG>? ORG { get; set; }
        public ICollection<ORG>? ORG1 { get; set; }
        public ICollection<RESOURCE>? RESOURCE { get; set; }
        public ICollection<RESOURCE>? RESOURCE1 { get; set; }
        public ICollection<SERVICE>? SERVICE { get; set; }
        public ICollection<SERVICE>? SERVICE1 { get; set; }
        public ICollection<STAFF>? STAFF { get; set; }
        public ICollection<STAFF>? STAFF1 { get; set; }
        public ICollection<STAFF_UNIT>? STAFF_UNIT { get; set; }
        public ICollection<STAFF_UNIT>? STAFF_UNIT1 { get; set; }
        public ICollection<USER_ROOM>? USER_ROOM { get; set; }
        public ICollection<USER_ROOM>? USER_ROOM1 { get; set; }
        public ICollection<PROFILE>? PROFILE { get; set; }
        public ICollection<PROFILE>? PROFILE1 { get; set; }
        public ICollection<RIGHT>? RIGHT { get; set; }
        public ICollection<RIGHT>? RIGHT1 { get; set; }
        public ICollection<RESOURCE_RESP>? RESOURCE_RESP { get; set; }
        public ICollection<RESOURCE_RESP>? RESOURCE_RESP1 { get; set; }
        public ICollection<MEMBER>? MEMBER { get; set; }
        public ICollection<MEMBER>? MEMBER1 { get; set; }
        public ICollection<ARM>? ARM { get; set; }
        public ICollection<ARM>? ARM1 { get; set; }
        public ICollection<ARM_DEVICE>? ARM_DEVICE { get; set; }
        public ICollection<ARM_DEVICE>? ARM_DEVICE1 { get; set; }
        public ICollection<ARM_USER>? ARM_USER { get; set; }
        public ICollection<ARM_USER>? ARM_USER1 { get; set; }
        public ICollection<AC_ACCESS>? AC_ACCESS1 { get; set; }
        public ICollection<AC_ACCESS>? AC_ACCESS2 { get; set; }
        public ICollection<DEVICE>? DEVICE { get; set; }
        public ICollection<DEVICE>? DEVICE1 { get; set; }
        public ICollection<RESOURCE_UCA>? RESOURCE_UCA { get; set; }
        public ICollection<RESOURCE_UCA>? RESOURCE_UCA1 { get; set; }
        public ICollection<EMPLOYEE>? EMPLOYEE { get; set; }
        public ICollection<EMPLOYEE>? EMPLOYEE1 { get; set; }
        public ICollection<VIEW_AC_ACCESS_ORG>? VIEW_AC_ACCESS_ORG_1 { get; }
        public ICollection<VIEW_AC_ACCESS_ORG>? VIEW_AC_ACCESS_ORG_2 { get; set; }

        public ICollection<VIEW_OBJECT_USER_RIGHTS_DISTINCTED>? VIEW_OBJECT_USER_RIGHTS_1 { get; set; }
        public ICollection<VIEW_OBJECT_USER_RIGHTS_DISTINCTED>? VIEW_OBJECT_USER_RIGHTS_2 { get; set; }*/

        #region Функции и вычисляемые свойства

        // public DateTime КогдаЗаявкаВыполнена() => дата_завершения ?? default;
        // public bool Выполнена() => дата_завершения != null;

        #endregion
    }
}
