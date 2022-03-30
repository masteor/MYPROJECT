using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities;
using QWERTY.Shared.Db.Entities.Представления;

namespace QWERTY.Shared.Db.Configuration.Представления
{
    public class VIEW_STAFF_UNIT_LOGINS_Configuration : EntityTypeConfiguration<VIEW_STAFF_UNIT_LOGINS>
    {
        public VIEW_STAFF_UNIT_LOGINS_Configuration()
        {
            ToTable(ИмяТаблицы.ViewStaffUnitLogins, _EntityBase.SchemaName);

            HasKey(e => new {e.id});

            Property(e => e.id).HasColumnName(ИмяКолонки.ID).IsRequired();
            Property(e => e.name).HasColumnName(ИмяКолонки.NAME).IsOptional();
            Property(e => e.role).HasColumnName(ИмяКолонки.ROLE).IsOptional();
            Property(e => e.login).HasColumnName(ИмяКолонки.LOGIN).IsOptional();
            Property(e => e.is_active).HasColumnName(ИмяКолонки.IS_ACTIVE).IsOptional();
        }
    }
}
