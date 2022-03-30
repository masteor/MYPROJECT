namespace QWERTY.Shared.Enums
{
    public class БуквенныеКодыТиповЗаявок
    {
        public const string ЗаявкаНаСоздание_PROFILE = "CREATE_PROFILE";
        public const string ЗаявкаНаСоздание_RIGHT = "CREATE_RIGHT";
        public const string ЗаявкаНаСоздание_MEMBER = "CREATE_MEMBER";
        public const string ЗаявкаНаСоздание_RESOURCE = "CREATE_RESOURCE";
        public const string ЗаявкаНаСоздание_RESOURCE_MEMBER = "CREATE_RESOURCE_MEMBER";
        public const string ЗаявкаНаСоздание_OBJECT = "CREATE_OBJECT";
        public const string ЗаявкаНаСоздание_DOC = "CREATE_DOC";
        
        public const string ЗаявкаНаСозданиеЗащищаемогоРесурса = "CRRES";
        public const string ЗаявкаНаСозданиеЗащищаемогоРесурсаЗЛИВС = "CRRESZLIVS";
        public const string ЗаявкаНаУдалениеФио = "DELFIO";
        public const string ЗаявкаНаСозданиеПрофиляДоступа = "CRPROFILEOBJECTS";
        public const string ЗаявкаНаПредоставлениеДоступаСубъектам = "CRMEMBER";
        public const string ЗаявкаНаСозданиеПользователя = "CREMP";
        public const string ЗаявкаНаСозданиеЛогинаВоДомене = "CRLOGIN";
        public const string ЗаявкаНаСозданиеФио = "CRFIO";
        public const string ЗаявкаНаИзменениеСтатусаЗаявки = "CHREQSTATUS";
    }
}