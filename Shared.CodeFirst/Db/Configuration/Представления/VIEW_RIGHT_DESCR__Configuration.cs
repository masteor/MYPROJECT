using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities;
using QWERTY.Shared.Db.Entities.Представления;

namespace QWERTY.Shared.Db.Configuration.Представления
{
    public class VIEW_RIGHT_DESCR_Configuration : EntityTypeConfiguration<VIEW_RIGHT_DESCR>
    {
        public VIEW_RIGHT_DESCR_Configuration()
        {
            ToTable(ИмяТаблицы.VIEW_RIGHT_DESCR, _EntityBase.SchemaName);

            HasKey(e => e.id);

            Property(e => e.id).HasColumnName(ИмяКолонки.ID).IsRequired();
            Property(e => e.id_right_descr).HasColumnName(ИмяКолонки.ID_RIGHT_DESCR).IsRequired();
            Property(e => e.type).HasColumnName(ИмяКолонки.TYPE).IsRequired();
            Property(e => e.description).HasColumnName(ИмяКолонки.DESCRIPTION).IsRequired();
            Property(e => e.id_service_type).HasColumnName(ИмяКолонки.ID_SERVICE_TYPE).IsRequired();
            Property(e => e.id_object_type).HasColumnName(ИмяКолонки.ID_OBJECT_TYPE).IsRequired();
            Property(e => e.object_type_name).HasColumnName(ИмяКолонки.OBJECT_TYPE_NAME).IsRequired();
            Property(e => e.main_object).HasColumnName(ИмяКолонки.MAIN_OBJECT).IsRequired();
        }
    }
}
