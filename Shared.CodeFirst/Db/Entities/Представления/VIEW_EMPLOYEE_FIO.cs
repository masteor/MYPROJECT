namespace QWERTY.Shared.Db.Entities.Представления
{
    public class VIEW_EMPLOYEE_FIO : _EntityBase
    {
    
        public int id_user { get; set; }
        public string? fio_full { get; set;}
        public int id_org { get; set;}
        public string? fname { get; set;}

        public string? fio_full_fname { get; set; }
    }
}
