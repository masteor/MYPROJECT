namespace QWERTY.Shared.Enums
{
    /*public class НазваниеСтатусовЗаявок
    {
        public const string Зарегистрирована = "Зарегистрирована";
        public const string Открыта = "Открыта";
        public const string Отложена = "Отложена";
        public const string Закрыта = "Закрыта";
        public const string Отменена = "Отменена";
        public const string Удалена = "Удалена";
        public const string Отклонена = "Отклонена";
    }*/

    public enum ИдСтатусаЗаявки
    {
        Зарегистрирована = 1,
        Открыта = 2,
        Отложена = 3,
        Выполнена = 4,
        Отменена = 5,
        Удалена = 6,
        Отклонена = 7,
        ROLLBACK = 9
    }

    public class БуквенныеКодыСтатусовЗаявок
    {
        public const string Зарегистрирована = "default";
        public const string Открыта = "active";
        public const string Отложена = "paused";
        public const string Выполнена = "finished";
        public const string Отменена = "canceled";
        public const string Удалена = "deleted";
        public const string Отклонена = "rejected";
        public const string ROLLBACKED = "rollbacked";
    }
}