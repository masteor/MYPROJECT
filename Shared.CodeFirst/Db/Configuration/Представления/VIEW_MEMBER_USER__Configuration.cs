using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities;
using QWERTY.Shared.Db.Entities.Представления;

namespace QWERTY.Shared.Db.Configuration.Представления
{
    public class VIEW_MEMBER_USER_Configuration : EntityTypeConfiguration<VIEW_MEMBER_USER>
    {
        public VIEW_MEMBER_USER_Configuration()
        {
            ToTable(ИмяТаблицы.VIEW_MEMBER_USER, _EntityBase.SchemaName);

            HasKey(e => new {e.id});

            Property(e => e.id).HasColumnName(ИмяКолонки.ID).IsRequired();
            Property(e => e.id_member).HasColumnName(ИмяКолонки.ID_MEMBER).IsRequired();
            Property(e => e.id_profile).HasColumnName(ИмяКолонки.ID_PROFILE).IsRequired();
            Property(e => e.id_user).HasColumnName(ИмяКолонки.ID_USER).IsRequired();
            Property(e => e.id_org).HasColumnName(ИмяКолонки.ID_ORG).IsRequired();
            Property(e => e.fio_full).HasColumnName(ИмяКолонки.FIO_FULL).IsRequired();
        }
    }
}
