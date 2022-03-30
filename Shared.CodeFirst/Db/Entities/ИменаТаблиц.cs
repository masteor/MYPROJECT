namespace QWERTY.Shared.Db.Entities
{
    public class ИмяТаблицы
    {
        public const string VIEW_MEMBER_ORG = "_VIEW_MEMBER_ORG";
        public const string VIEW_MEMBER_USER = "_VIEW_MEMBER_USER";
        public const string VIEW_RIGHT_DESCR = "_VIEW_RIGHT_DESCR";

        public const string VIEW_REPORT_ALL_PROFILES = "_VIEW_REPORT_ALL_PROFILES";
        public const string VIEW_PROFILE_OBJECT_RIGHT = "_VIEW_PROFILE_OBJECT_RIGHT";
        public const string VIEW_OBJECT_USER_RIGHTS_DISTINCT = "_VIEW_OBJECT_USER_RIGHTS_DISTINCT";
        public const string VIEW_RESOURCE_USER_RIGHT = "_VIEW_RESOURCE_USER_RIGHT";
        public const string VIEW_REPORT_RESOURCES_WHERE_AM_I = "_VIEW_REPORT_RESOURCES_WHERE_AM_I";
        public const string VIEW_RESOURCE_MEMBER_ORG = "_VIEW_RESOURCE_MEMBER_ORG";
        // public const string VIEW_RESOURCE_MEMBER_LOGIN = "_VIEW_RESOURCE_MEMBER_LOGIN";
        public const string VIEW_RESOURCE_MEMBER_EMPLOYEE = "_VIEW_RESOURCE_MEMBER_EMPLOYEE";
        public const string RESOURCE_MEMBERS = "_RESOURCE_MEMBERS";
        public const string REQUEST_STATE = "_REQUEST_STATE";
        public const string ViewEmployeeExt = "_VIEW_EMPLOYEE_EXT";

        // zlivs
        public const string Room = "_ROOM";
        public const string StaffUnit = "_STAFF_UNIT";
        public const string ViewResource = "_VIEW_RESOURCE";
        public const string ViewEmployee = "_VIEW_EMPLOYEE";
        public const string ViewEmployeePrd = "_VIEW_EMPLOYEE_PRD";
        public const string ViewEmployeeLogin = "_VIEW_EMPLOYEE_LOGIN";
        public const string ViewEmployeeLoginPrd = "_VIEW_EMPLOYEE_LOGIN_PRD";
        public const string ViewStaffUnitLogins = "_VIEW_STAFF_UNIT_LOGINS";
        public const string Employee = "_EMPLOYEE";
        public const string Login = "_LOGIN";
        public const string REQUEST = "_REQUEST";
        public const string RESOURCE = "_RESOURCE";
        public const string OBJECT = "_OBJECT";
        public const string OBJECT_TYPE = "_OBJECT_TYPE";

        // zlivs

        // для получения данных с PRD
        public const string ViewReportAllResourcesFromPrd = "_VIEW_REPORT_ALL_RESOURCES_FROM_PRD";
        public const string ViewReportRsdFromPrd = "_VIEW_REPORT_RSD_FROM_PRD"; // "_REPORT_RSD_FROM_PRD";
        public const string ViewReportAllRequests = "_VIEW_REPORT_ALL_REQUESTS";
        
        public const string ViewReportAcAccess = "_VIEW_REPORT_AC_ACCESS";
        public const string ViewReportAcAccessPrd = "_VIEW_REPORT_AC_ACCESS_PRD"; // zlivs
        public const string ViewReportAllResources = "_VIEW_REPORT_ALL_RESOURCES";
        public const string ViewArmUser = "_VIEW_ARM_USER";
        public const string SYSRL = "$$$SYSRL";
        public const string ATTRI = "$$$ATTRI";
        public const string ViewReportRSD = "_VIEW_REPORT_RSD";
        public const string ViewEmployeeFio = "_VIEW_EMPLOYEE_FIO";
        public const string ViewOwner = "_VIEW_OWNER";
        public const string ViewProfile = "_VIEW_PROFILE";
        public const string ViewResourceExt = "_VIEW_RESOURCE_EXT";
        public const string ViewResourcesByOtSt = "_VIEW_RESOURCES_BY_OT_ST";
        public const string ViewFio = "_VIEW_FIO";

        public const string ViewAcAccessOrg = "_VIEW_AC_ACCESS_ORG";
        public const string ViewArmRoomUser = "_VIEW_ARM_ROOM_USER";
        public const string ViewObjectUserRights = "_VIEW_OBJECT_USER_RIGHTS";


        
    }

    public enum ИдТаблицыВоБазеДанных
    {
        ViewReportAcAccess = 64,
        SYSRL = 1,
        ATTRI = 2
    }

    public static class ИмяКолонки
    {
        public const string TYPE = "TYPE";
        public const string CREATE_DATE_2_STR = "CREATE_DATE_2_STR";
        public const string FIO_FULL_FNAME = "FIO_FULL_FNAME";
        public const string DATESTR_1 = "DATESTR_1";
        public const string OBJECT_TYPE_ID = "OBJECT_TYPE_ID";
        public const string FRAG_ID = "FRAG_ID";
        public const string ICON = "ICON";
        public const string MAIN_OBJECT = "MAIN_OBJECT";
        public const string OBJECT_TYPE_MAIN_OBJECT = "OBJECT_TYPE_MAIN_OBJECT";
        public const string RIGHT_DESCR_TYPE = "RIGHT_DESCR_TYPE";
        public const string ID_AC_FRAGMENT = "ID_AC_FRAGMENT";
        public const string ID_FRAG = "ID_FRAG";
        public const string ID_REQUEST_STATE = "ID_REQUEST_STATE";
        public const string ID_USER_1 = "ID_USER_1";
        public const string ID_USER_2 = "ID_USER_2";
        public const string ID_REQUEST_TYPE = "ID_REQUEST_TYPE";
        public const string ID_REQUEST_2_PARENT = "ID_REQUEST_2_PARENT";
        public const string ID_REQUEST_1_PARENT = "ID_REQUEST_1_PARENT";
        public const string ID_REQUEST_PARENT = "ID_REQUEST_PARENT";
        public const string ID_USER_RECIPIENT = "ID_USER_RECIPIENT";
        public const string ID_USER_SENDER = "ID_USER_SENDER";
        public const string ID_RIGHT = "ID_RIGHT";
        public const string FIO_RESPONSIBLE = "FIO_RESPONSIBLE";
        public const string FIO_OWNER = "FIO_OWNER";
        public const string RECIPIENT_LOGIN = "RECIPIENT_LOGIN";
        public const string SENDER_LOGIN = "SENDER_LOGIN";
        public const string LOGIN_OWNER = "LOGIN_OWNER";
        public const string ID_USER_OWNER = "ID_USER_OWNER";
        public const string LOGIN_RESPONSIBLE = "LOGIN_RESPONSIBLE";
        public const string ID_USER_RESPONSIBLE = "ID_USER_RESPONSIBLE";
        public const string RQ2_ID = "RQ2_ID";
        public const string RQ2_PARENT = "RQ2_PARENT";
        public const string RQ1_PARENT = "RQ1_PARENT";
        public const string RQ1_ID = "RQ1_ID";
        public const string FIO_FULL_LOGIN = "FIO_FULL_LOGIN";
        public const string FNAME = "FNAME";
        public const string ID_PARENT = "ID_PARENT";
        public const string DOC_REG_DATE = "DOC_REG_DATE";
        public const string DOC_REG_NUM = "DOC_REG_NUM";
        public const string STATE = "STATE";
        public const string CONTENTS = "CONTENTS";
        public const string ID_DOC_TYPE = "ID_DOC_TYPE";
        public const string ID_RESOURCE_MEMBER = "ID_RESOURCE_MEMBER";
        public const string RESPONSIBLE_JOB_NAME = "RESPONSIBLE_JOB_NAME";
        public const string RESPONSIBLE_SHORT_NAME = "RESPONSIBLE_SHORT_NAME";
        public const string OWNER_JOB_NAME = "OWNER_JOB_NAME";
        public const string OWNER_ORG_FNAME = "OWNER_ORG_FNAME";
        public const string OWNER_SHORT_NAME = "OWNER_SHORT_NAME";
        public const string RESPONSIBLE_ORG_FNAME = "RESPONSIBLE_ORG_FNAME";
        public const string REG_NUM_ARM = "REG_NUM_ARM";
        public const string ARM_ID_NEW = "ARM_ID_NEW";
        public const string REG_NUM_LOGBOOK = "REG_NUM_LOGBOOK";
        public const string ROOM_NUM = "ROOM_NUM";
        public const string BUILDING_NAME = "BUILDING_NAME";
        public const string PROM_AREA_NAME = "PROM_AREA_NAME";
        public const string ARM_USER_ID_USER = "ARM_USER_ID_USER";
        public const string USER_ROOM_ID_USER = "USER_ROOM_ID_USER";
        public const string ARM_ID_REQUEST_1 = "ARM_ID_REQUEST_1";
        public const string ARM_ID_REQUEST_2 = "ARM_ID_REQUEST_2";
        public const string CREATE_REQUEST_STATE_NAME = "CREATE_REQUEST_STATE_NAME";
        public const string CREATE_REQUEST_STATE_CODE = "CREATE_REQUEST_STATE_CODE";
        public const string END_REQUEST_STATE_NAME = "END_REQUEST_STATE_NAME";
        public const string END_REQUEST_STATE_CODE = "END_REQUEST_STATE_CODE";
        public const string ID_STAFF = "ID_STAFF";
        public const string FP_NAME = "FP_NAME";
        public const string FP_DESCRIPTION = "FP_DESCRIPTION";
        public const string ID_REQUEST_TYPE_CODE_1 = "ID_REQUEST_TYPE_CODE_1";
        public const string ID_REQUEST_TYPE_CODE_2 = "ID_REQUEST_TYPE_CODE_2";
        public const string CODE = "CODE";
        public const string REQUEST_TYPE_CODE = "REQUEST_TYPE_CODE";
        public const string AC_FRAGMENT = "AC_FRAGMENT";

        // добавлено в zlivs
        public const string NUM = "NUM";
        public const string ID_BUILDING = "ID_BUILDING";
        public const string PARENT = "PARENT";
        public const string PARENT_1 = "PARENT_1";
        public const string PARENT_2 = "PARENT_2";
        public const string ID_REQUEST_1 = "ID_REQUEST_1";
        public const string ID_REQUEST_2 = "ID_REQUEST_2";
        public const string EMAIL = "EMAIL";
        public const string ID_REQUEST_0 = "ID_REQUEST_0";
        public const string DEP_UTYPE_NAME = "DEP_UTYPE_NAME";
        public const string DEP_UTYPE_CODE = "DEP_UTYPE_CODE";
        public const string DIV_UTYPE_NAME = "DIV_UTYPE_NAME";
        public const string DIV_UTYPE_CODE = "DIV_UTYPE_CODE";
        public const string ROOM = "ROOM";
        public const string LAB_BOSS_FIO_FULL = "LAB_BOSS_FIO_FULL";
        public const string DIV_BOSS_FIO_FULL = "DIV_BOSS_FIO_FULL";
        public const string DEP_BOSS_FIO_FULL = "DEP_BOSS_FIO_FULL";
        public const string LAB_DESCR = "LAB_DESCR";
        public const string DIV_DESCR = "DIV_DESCR";
        public const string DEP_DESCR = "DEP_DESCR";
        public const string PROM_AREA = "PROM_AREA";
        public const string BUILD = "BUILD";
        public const string HPHONE = "HPHONE";
        public const string WPHONE = "WPHONE";
        public const string IS_ACTIVE_DESCR = "IS_ACTIVE_DESCR";
        public const string EMPLOYEE_FIO_FULL = "EMPLOYEE_FIO_FULL";
        public const string IS_ACTIVE_STRING = "IS_ACTIVE_STRING";
        public const string IS_ACTIVE = "IS_ACTIVE";
        public const string ORG_FNAME = "ORG_FNAME";
        public const string PATRONYMIC = "PATRONYMIC";
        public const string ID_AC_ACCESS = "ID_AC_ACCESS";
        public const string FAMILY = "FAMILY";
        public const string ROLE = "ROLE";
        public const string DATE_2 = "DATE_2";
        // добавлено в zlivs
        
        public const string REQUEST_STATE_ID = "REQUEST_STATE_ID";
        public const string ID_DOC = "ID_DOC";
        public const string REQUEST_STATE_NAME = "REQUEST_STATE_NAME";
        public const string SENDER = "SENDER";
        public const string RECIPIENT = "RECIPIENT";
        public const string REQUEST_TYPE_NAME = "REQUEST_TYPE_NAME";
        public const string DATE_1 = "DATE_1";
        public const string ID_REQUEST = "ID_REQUEST";
        public const string REG_NUM = "REG_NUM";
        public const string RESPONSIBLE = "RESPONSIBLE";
        public const string OWNER = "OWNER";
        public const string SECRET_TYPE_NAME = "SECRET_TYPE_NAME";
        public const string DESCRIPTION = "DESCRIPTION";
        public const string PATH = "PATH";
        public const string FRAG_NAME = "FRAG_NAME";
        public const string SERVICE_TYPE_NAME = "SERVICE_TYPE_NAME";
        public const string ID = "ID";
        public const string SFIO = "SFIO";
        public const string TNUM = "TNUM";
        public const string ARM_REG_NUM = "ARM_REG_NUM";
        public const string ARM_USER_ROLE_NAME = "ARM_USER_ROLE_NAME";
        public const string CREATE_DATE_1 = "CREATE_DATE_1";
        public const string CREATE_DATE_2 = "CREATE_DATE_2";
        public const string CREATE_REQUEST_STATE = "CREATE_REQUEST_STATE";
        public const string END_DATE_1 = "END_DATE_1";
        public const string END_DATE_2 = "END_DATE_2";
        public const string END_REQUEST_STATE = "END_REQUEST_STATE";
        public const string RESOURCE_NAME = "RESOURCE_NAME";
        public const string PROFILE_NAME = "PROFILE_NAME";
        public const string LOGIN = "LOGIN";
        public const string ORG_NAME = "ORG_NAME";
        public const string FIO_FULL = "FIO_FULL";
        public const string JOB_NAME = "JOB_NAME";
        public const string FORM_PERM = "FORM_PERM";
        public const string NAME = "NAME";
        
        public const string RESOURCE_ID_OBJECT = "RESOURCE_ID_OBJECT";
        public const string ID_OBJECT_TYPE = "ID_OBJECT_TYPE";
        public const string ID_SERVICE_TYPE = "ID_SERVICE_TYPE";
        public const string OBJECT_NAME = "OBJECT_NAME";
        public const string OBJECT_TYPE_NAME = "OBJECT_TYPE_NAME";
        public const string ID_USER = "ID_USER";
        public const string ID_NEW = "ID_NEW";

        public const string SERVICE_NAME = "SERVICE_NAME";
        public const string ID_OBJECT = "ID_OBJECT";
        public const string ID_PARENT_OBJECT = "ID_PARENT_OBJECT";
        public const string ID_RESOURCE = "ID_RESOURCE";
        public const string ID_PROFILE = "ID_PROFILE";
        public const string ID_RIGHT_DESCR = "ID_RIGHT_DESCR";
        public const string ID_LOGIN = "ID_LOGIN";
        public const string ID_ORG = "ID_ORG";
        public const string ID_MEMBER = "ID_MEMBER";
        public const string LOGIN_NAME = "LOGIN_NAME";
        public const string ID_DOMEN = "ID_DOMEN";
        public const string ID_EMPLOYEE = "ID_EMPLOYEE";
        public const string ID_JOB = "ID_JOB";
        public const string ID_FORM_PERM = "ID_FORM_PERM";

        public const string ID_FIO = "ID_FIO";
        public const string NAME_1 = "NAME_1";
        public const string NAME_2 = "NAME_2";
        public const string NAME_3 = "NAME_3";
        public const string NOTID = "NOTID";
        public const string GUID = "GUID";
        
        
        
    }
}