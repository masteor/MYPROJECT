using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities;
using QWERTY.Shared.Db.Entities.Представления;

namespace QWERTY.Shared.Db.Configuration.Представления
{
    public class VIEW_RESOURCE_Configuration : EntityTypeConfiguration<VIEW_RESOURCE>
    {
        public VIEW_RESOURCE_Configuration()
        {
            ToTable(ИмяТаблицы.ViewResource, _EntityBase.SchemaName);

            HasKey(e => new {e.id_resource});

            Property(e => e.id_resource).HasColumnName(ИмяКолонки.ID_RESOURCE).IsRequired();
            Property(e => e.path).HasColumnName(ИмяКолонки.PATH).IsRequired();
            Property(e => e.description).HasColumnName(ИмяКолонки.DESCRIPTION).IsRequired();
            Property(e => e.secret_type_name).HasColumnName(ИмяКолонки.SECRET_TYPE_NAME).IsRequired();
            Property(e => e.owner).HasColumnName(ИмяКолонки.OWNER).IsRequired();
            Property(e => e.responsible).HasColumnName(ИмяКолонки.RESPONSIBLE).IsRequired();
            Property(e => e.service_type_name).HasColumnName(ИмяКолонки.SERVICE_TYPE_NAME).IsRequired();
            Property(e => e.ac_fragment).HasColumnName(ИмяКолонки.AC_FRAGMENT).IsRequired();
            Property(e => e.object_name).HasColumnName(ИмяКолонки.OBJECT_NAME).IsRequired();
            Property(e => e.object_type_name).HasColumnName(ИмяКолонки.OBJECT_TYPE_NAME).IsRequired();
        }
    }
}
