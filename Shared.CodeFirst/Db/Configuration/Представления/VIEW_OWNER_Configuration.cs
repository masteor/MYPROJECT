using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities;
using QWERTY.Shared.Db.Entities.Представления;

namespace QWERTY.Shared.Db.Configuration.Представления
{
    public class VIEW_OWNER_Configuration : EntityTypeConfiguration<VIEW_OWNER>
    {
        public VIEW_OWNER_Configuration()
        {
            ToTable(ИмяТаблицы.ViewOwner, _EntityBase.SchemaName);

            HasKey(e => new {e.id});

            Property(e => e.id).HasColumnName(ИмяКолонки.ID_EMPLOYEE).IsRequired();
            Property(e => e.name).HasColumnName(ИмяКолонки.FIO_FULL).IsOptional();
        }
    }
}
