using System.Data.Entity;
using QWERTY.Shared.Db.Configuration.Представления;
using QWERTY.Shared.Db.Configuration.Системные_таблицы;
using QWERTY.Shared.Db.Configuration.Таблицы;

namespace QWERTY.Shared.Db
{
    public partial class _QWERTY_Entities
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new DIC_Configuration());

            modelBuilder.Configurations.Add(new AC_ACCESS_Configuration());
            modelBuilder.Configurations.Add(new AC_FRAGMENT_Configuration());
            modelBuilder.Configurations.Add(new SERVICE_Configuration());
            modelBuilder.Configurations.Add(new ARM_Configuration());
            modelBuilder.Configurations.Add(new ARM_DEVICE_Configuration());
            modelBuilder.Configurations.Add(new BUILDING_Configuration());
            modelBuilder.Configurations.Add(new ARM_USER_Configuration());
            modelBuilder.Configurations.Add(new ARM_USER_ROLE_Configuration());
            modelBuilder.Configurations.Add(new DEVICE_Configuration());
            modelBuilder.Configurations.Add(new DEVICE_PERM_Configuration());
            modelBuilder.Configurations.Add(new DEVICE_TYPE_Configuration());
            modelBuilder.Configurations.Add(new DOC_Configuration());
            modelBuilder.Configurations.Add(new DOC_TYPE_Configuration());
            modelBuilder.Configurations.Add(new EMPLOYEE_Configuration());
            modelBuilder.Configurations.Add(new EMPLOYEE_IN_ORG_Configuration());
            modelBuilder.Configurations.Add(new EXECUTION_Configuration());
            modelBuilder.Configurations.Add(new FIO_Configuration());
            modelBuilder.Configurations.Add(new FORM_PERM_Configuration());
            modelBuilder.Configurations.Add(new JOB_Configuration());
            modelBuilder.Configurations.Add(new LOGIN_Configuration());
            modelBuilder.Configurations.Add(new MEMBER_Configuration());
            modelBuilder.Configurations.Add(new NOTIFY_REQUEST_Configuration());
            modelBuilder.Configurations.Add(new NOTIFY_SUB_Configuration());
            modelBuilder.Configurations.Add(new OBJECT_Configuration());
            modelBuilder.Configurations.Add(new OBJECT_TYPE_Configuration());
            modelBuilder.Configurations.Add(new ORG_Configuration());
            modelBuilder.Configurations.Add(new ORG_UNIT_TYPE_Configuration());
            modelBuilder.Configurations.Add(new PROFILE_Configuration());
            modelBuilder.Configurations.Add(new PROM_AREA_Configuration());
            modelBuilder.Configurations.Add(new REQUEST_Configuration());
            modelBuilder.Configurations.Add(new REQUEST_STATE_Configuration());
            modelBuilder.Configurations.Add(new REQUEST_TYPE_Configuration());
            modelBuilder.Configurations.Add(new REQUEST_TYPE_STAFF_Configuration());
            modelBuilder.Configurations.Add(new RESOURCE_Configuration());
            modelBuilder.Configurations.Add(new RESOURCE_MEMBERS_Configuration());
            modelBuilder.Configurations.Add(new RESOURCE_RESP_Configuration());
            modelBuilder.Configurations.Add(new RESOURCE_UCA_Configuration());
            modelBuilder.Configurations.Add(new RIGHT_Configuration());
            modelBuilder.Configurations.Add(new RIGHT_DESCRIPTION_Configuration());
            modelBuilder.Configurations.Add(new RIGHT_GROUP_Configuration());
            modelBuilder.Configurations.Add(new RIGHT_OBJECT_TYPE_Configuration());
            modelBuilder.Configurations.Add(new ROOM_Configuration());
            modelBuilder.Configurations.Add(new RSO_Configuration());
            modelBuilder.Configurations.Add(new SECRET_TYPE_Configuration());
            modelBuilder.Configurations.Add(new SERVICE_TYPE_Configuration());
            modelBuilder.Configurations.Add(new STAFF_Configuration());
            modelBuilder.Configurations.Add(new STAFF_UNIT_Configuration());
            modelBuilder.Configurations.Add(new UCA_LIST_Configuration());
            modelBuilder.Configurations.Add(new USER_ROOM_Configuration());
            
            // представления
            modelBuilder.Configurations.Add(new VIEW_OBJECT_USER_RIGHTS_Configuration());
            modelBuilder.Configurations.Add(new VIEW_OBJECT_USER_RIGHTS_DISTINCTED_Configuration());
            modelBuilder.Configurations.Add(new VIEW_RESOURCE_USER_RIGHT_Configuration());
            modelBuilder.Configurations.Add(new VIEW_AC_ACCESS_ORG_Configuration());
            modelBuilder.Configurations.Add(new VIEW_EMPLOYEE_EXT_Configuration());
            modelBuilder.Configurations.Add(new VIEW_ARM_ROOM_USER_Configuration());
            modelBuilder.Configurations.Add(new VIEW_RESOURCE_EXT_Configuration());
            modelBuilder.Configurations.Add(new VIEW_REPORT_AC_ACCESS_Configuration());
            modelBuilder.Configurations.Add(new VIEW_REPORT_ALL_RESOURCES_Configuration());
            modelBuilder.Configurations.Add(new VIEW_ARM_USER_Configuration());
            modelBuilder.Configurations.Add(new VIEW_REPORT_RSD_Configuration());
            modelBuilder.Configurations.Add(new VIEW_EMPLOYEE_FIO_Configuration());
            modelBuilder.Configurations.Add(new VIEW_OWNER_Configuration());
            modelBuilder.Configurations.Add(new VIEW_PROFILE_Configuration());
            modelBuilder.Configurations.Add(new VIEW_RESOURCES_BY_OT_ST_Configuration());
            modelBuilder.Configurations.Add(new VIEW_FIO_Configuration());
            modelBuilder.Configurations.Add(new VIEW_STAFF_UNIT_LOGINS_Configuration());
            modelBuilder.Configurations.Add(new VIEW_EMPLOYEE_LOGIN_Configuration());
            modelBuilder.Configurations.Add(new VIEW_EMPLOYEE_Configuration());
            modelBuilder.Configurations.Add(new VIEW_RESOURCE_Configuration	());
            modelBuilder.Configurations.Add(new VIEW_RESOURCE_MEMBER_EMPLOYEE_Configuration());
            modelBuilder.Configurations.Add(new VIEW_RESOURCE_MEMBER_ORG_Configuration());
            modelBuilder.Configurations.Add(new VIEW_PROFILE_OBJECT_RIGHT_Configuration());
            modelBuilder.Configurations.Add(new VIEW_REPORT_ALL_PROFILES_Configuration());
            modelBuilder.Configurations.Add(new VIEW_RIGHT_DESCR_Configuration());
            modelBuilder.Configurations.Add(new VIEW_MEMBER_USER_Configuration());
            modelBuilder.Configurations.Add(new VIEW_MEMBER_ORG_Configuration());
            
            //PRD
            /*modelBuilder.Configurations.Add(new VIEW_REPORT_ALL_RESOURCES_FROM_PRD_Configuration());*/
            /*modelBuilder.Configurations.Add(new VIEW_REPORT_RSD_FROM_PRD_Configuration());*/
            /*modelBuilder.Configurations.Add(new VIEW_EMPLOYEE_PRD__Configuration());*/
            /*modelBuilder.Configurations.Add(new VIEW_EMPLOYEE_LOGIN_PRD__Configuration());*/
            
            // для админов
            modelBuilder.Configurations.Add(new VIEW_REPORT_ALL_REQUESTS_Configuration());
            
            // для пользователей
            modelBuilder.Configurations.Add(new VIEW_REPORT_RESOURCES_WHERE_AM_I_Configuration());
            
            // системные таблицы
            modelBuilder.Configurations.Add(new SYSRL_Configuration());   
            modelBuilder.Configurations.Add(new ATTRI_Configuration());
            
            // test
            modelBuilder.Configurations.Add(new TEST_Configuration());
        }
    }
}