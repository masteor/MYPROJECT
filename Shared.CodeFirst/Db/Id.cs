using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Shared.Db
{
    public abstract class Id : _EntityBase
    {
        public abstract int id { get; set; }
        public abstract int id_request_1 { get; set; }
    }
}