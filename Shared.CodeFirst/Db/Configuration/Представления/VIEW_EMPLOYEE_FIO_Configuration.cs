using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities;
using QWERTY.Shared.Db.Entities.Представления;

namespace QWERTY.Shared.Db.Configuration.Представления
{
    public class VIEW_EMPLOYEE_FIO_Configuration : EntityTypeConfiguration<VIEW_EMPLOYEE_FIO>
    {
        public VIEW_EMPLOYEE_FIO_Configuration()
        {
            // Следующая строка закомментирована потому что представление формируется через SQL запрос
            // ToTable(ИмяТаблицы.ViewEmployeeFio, _EntityBase.SchemaName);

            HasKey(e => new {e.id_user});

            Property(e => e.id_user).HasColumnName(ИмяКолонки.ID_USER).IsRequired();
            Property(e => e.fio_full).HasColumnName(ИмяКолонки.FIO_FULL).IsOptional();
            Property(e => e.id_org).HasColumnName(ИмяКолонки.ID_ORG).IsOptional();
            Property(e => e.fname).HasColumnName(ИмяКолонки.FNAME).IsOptional();
            Property(e => e.fio_full_fname).HasColumnName(ИмяКолонки.FIO_FULL_FNAME).IsOptional();
        }
    }
}
