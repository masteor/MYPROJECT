using QWERTY.Shared.Атрибуты;

namespace QWERTY.Shared.Db
{
    public abstract class CreateRequestState : _EntityBase
    {
        [DataTableColumn("Статус заявки на создание")]
        public abstract int? create_request_state { get; set; }
    }
}