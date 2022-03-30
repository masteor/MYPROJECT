using System.Data.Entity;
using QWERTY.Shared.Db.Entities.Представления;
using QWERTY.Shared.Db.Entities.Системные_таблицы;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Shared.Db
{
    public partial class _QWERTY_Entities
    {
        public virtual DbSet<DIC> DIC { get; set; }

        public virtual DbSet<AC_FRAGMENT> AC_FRAGMENT { get; set; }
        public virtual DbSet<ARM> ARM { get; set; }
        public virtual DbSet<ARM_DEVICE> ARM_DEVICE { get; set; }
        public virtual DbSet<ARM_USER> ARM_USER { get; set; }
        public virtual DbSet<ARM_USER_ROLE> ARM_USER_ROLE { get; set; }
        public virtual DbSet<BUILDING> BUILDING { get; set; }
        public virtual DbSet<DEVICE> DEVICE { get; set; }
        public virtual DbSet<DEVICE_PERM> DEVICE_PERM { get; set; }
        public virtual DbSet<DEVICE_TYPE> DEVICE_TYPE { get; set; }
        public virtual DbSet<DOC> DOC { get; set; }
        public virtual DbSet<DOC_TYPE> DOC_TYPE { get; set; }
        public virtual DbSet<EMPLOYEE> EMPLOYEE { get; set; }
        public virtual DbSet<EMPLOYEE_IN_ORG> EMPLOYEE_IN_ORG { get; set; }
        public virtual DbSet<EXECUTION> EXECUTION { get; set; }
        public virtual DbSet<FIO> FIO { get; set; }
        public virtual DbSet<FORM_PERM> FORM_PERM { get; set; }
        public virtual DbSet<JOB> JOB { get; set; }
        public virtual DbSet<LOGIN> LOGIN { get; set; }
        public virtual DbSet<MEMBER> MEMBER { get; set; }
        public virtual DbSet<NOTIFY_REQUEST> NOTIFY_REQUEST { get; set; }
        public virtual DbSet<NOTIFY_SUB> NOTIFY_SUB { get; set; }
        public virtual DbSet<OBJECT> OBJECT { get; set; }
        public virtual DbSet<OBJECT_TYPE> OBJECT_TYPE { get; set; }
        public virtual DbSet<ORG> ORG { get; set; }
        public virtual DbSet<ORG_UNIT_TYPE> ORG_UNIT_TYPE { get; set; }
        public virtual DbSet<PROFILE> PROFILE { get; set; }
        public virtual DbSet<PROM_AREA> PROM_AREA { get; set; }
        public virtual DbSet<REQUEST> REQUEST { get; set; }
        public virtual DbSet<REQUEST_STATE> REQUEST_STATE { get; set; }
        public virtual DbSet<REQUEST_TYPE> REQUEST_TYPE { get; set; }
        public virtual DbSet<REQUEST_TYPE_STAFF> REQUEST_TYPE_STAFF { get; set; }
        public virtual DbSet<RESOURCE> RESOURCE { get; set; }
        public virtual DbSet<RESOURCE_MEMBER> RESOURCE_MEMBERS { get; set; }
        public virtual DbSet<RESOURCE_RESP> RESOURCE_RESP { get; set; }
        public virtual DbSet<RESOURCE_UCA> RESOURCE_UCA { get; set; }
        public virtual DbSet<RIGHT> RIGHT { get; set; }
        public virtual DbSet<RIGHT_DESCR> RIGHT_DESCRIPTION { get; set; }
        public virtual DbSet<RIGHT_GROUP> RIGHT_GROUP { get; set; }
        public virtual DbSet<RIGHT_OBJECT_TYPE> RIGHT_OBJECT_TYPE { get; set; }
        public virtual DbSet<ROOM> ROOM { get; set; }
        public virtual DbSet<RSO> RSO { get; set; }
        public virtual DbSet<SECRET_TYPE> SECRET_TYPE { get; set; }
        public virtual DbSet<SERVICE> SERVICE { get; set; }
        public virtual DbSet<SERVICE_TYPE> SERVICE_TYPE { get; set; }
        public virtual DbSet<STAFF> STAFF { get; set; }
        public virtual DbSet<STAFF_UNIT> STAFF_UNIT { get; set; }
        public virtual DbSet<UCA_LIST> UCA_LIST { get; set; }
        public virtual DbSet<USER_ROOM> USER_ROOM { get; set; }

        // представления
        public virtual DbSet<VIEW_OBJECT_USER_RIGHTS> ViewObjectUserRights { get; set; }
        public virtual DbSet<VIEW_OBJECT_USER_RIGHTS_DISTINCTED> ViewObjectUserRightsDistincted { get; set; }
        public virtual DbSet<VIEW_RESOURCE_USER_RIGHT> VIEW_RESOURCE_USER_RIGHT { get; set; }
        public virtual DbSet<VIEW_AC_ACCESS_ORG> ViewAcAccessOrgs { get; set; }
        public virtual DbSet<VIEW_EMPLOYEE_EXT> ViewEmployeeExts { get; set; }
        public virtual DbSet<VIEW_ARM_ROOM_USER> ViewArmRoomUsers { get; set; }
        public virtual DbSet<VIEW_RESOURCE_EXT> ViewResourceExt { get; set; }
        public virtual DbSet<VIEW_RESOURCES_BY_OT_ST> ViewResourcesByOtSt { get; set; }
        public virtual DbSet<VIEW_REPORT_AC_ACCESS> ViewReportAcAccess { get; set; }
        public virtual DbSet<VIEW_ARM_USER> ViewArmUsers  { get; set; }
        public virtual DbSet<VIEW_REPORT_ALL_RESOURCES> ViewReportAllResources { get; set; }
        public virtual DbSet<VIEW_REPORT_RSD> ViewReportRsd { get; set; }
        public virtual DbSet<VIEW_EMPLOYEE_FIO> ViewEmployeeFios { get; set; }
        public virtual DbSet<VIEW_OWNER> ViewOwners { get; set; }
        public virtual DbSet<VIEW_PROFILE> ViewProfiles { get; set; }
        public virtual DbSet<VIEW_FIO> ViewFios { get; set; }
        public virtual DbSet<VIEW_STAFF_UNIT_LOGINS> ViewStaffUnitLogins { get; set; }
        public virtual DbSet<VIEW_EMPLOYEE_LOGIN> ViewEmployeeLogins { get; set; }
        public virtual DbSet<VIEW_EMPLOYEE> ViewEmployee { get; set; }
        public virtual DbSet<VIEW_RESOURCE> ViewResources { get; set; }
        public virtual DbSet<VIEW_RESOURCE_MEMBER_EMPLOYEE> ViewResourceMemberLogins { get; set; }
        public virtual DbSet<VIEW_RESOURCE_MEMBER_ORG> ViewResourceMemberOrgs { get; set; }
        public virtual DbSet<VIEW_PROFILE_OBJECT_RIGHT> ViewProfileObjectRights { get; set; }
        public virtual DbSet<VIEW_REPORT_ALL_PROFILES> ViewReportAllProfiles { get; set; }
        public virtual DbSet<VIEW_RIGHT_DESCR> ViewRightDescrs { get; set; }
        public virtual DbSet<VIEW_MEMBER_USER> ViewMemberUsers { get; set; }
        public virtual DbSet<VIEW_MEMBER_ORG> ViewMemberOrgs { get; set; }
        
        // PRD
        /*public virtual DbSet<VIEW_REPORT_RSD_FROM_PRD> ViewReportRsdFromPrd { get; set; }
        public virtual DbSet<VIEW_EMPLOYEE_LOGIN_PRD> ViewEmployeeLoginsPrd { get; set; }
        public virtual DbSet<VIEW_REPORT_ALL_RESOURCES_FROM_PRD> ViewReportAllResourcesFromPrd { get; set; }
        public virtual DbSet<VIEW_EMPLOYEE_PRD> ViewEmployeePrds { get; set; }*/
        // public virtual DbSet<VIEW_REPORT_AC_ACCESS_PRD> ViewReportAcAccessPrds { get; set; } // zlivs
        
        // для админов
        public virtual DbSet<VIEW_REPORT_ALL_REQUESTS> ViewReportAllRequests { get; set; }
        
        // для пользователей
        public virtual DbSet<VIEW_REPORT_RESOURCES_WHERE_AM_I> ViewReportResourcesWhereAmI { get; set; }
        
        // системные таблицы
        public virtual DbSet<SYSRL> Sysrls { get; set; }
        
        // test
        public virtual DbSet<TEST> Tests { get; set; }
        
    }
}