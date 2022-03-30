using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities;
using QWERTY.Shared.Db.Entities.Представления;

namespace QWERTY.Shared.Db.Configuration.Представления
{
    public class VIEW_RESOURCE_EXT_Configuration : EntityTypeConfiguration<VIEW_RESOURCE_EXT>
    {
        public VIEW_RESOURCE_EXT_Configuration()
        {
            ToTable(ИмяТаблицы.ViewResourceExt, _EntityBase.SchemaName);

            HasKey(e => e.id_resource);
            Property(e => e.id_resource).HasColumnName(ИмяКолонки.ID_RESOURCE).IsRequired();
            
            Property(e => e.resource_id_object).HasColumnName(ИмяКолонки.RESOURCE_ID_OBJECT).IsOptional();
            Property(e => e.id_object).HasColumnName(ИмяКолонки.ID_OBJECT).IsOptional();
            Property(e => e.object_name).HasColumnName(ИмяКолонки.OBJECT_NAME).IsOptional();
            Property(e => e.id_object_type).HasColumnName(ИмяКолонки.ID_OBJECT_TYPE).IsOptional();
            Property(e => e.object_type_name).HasColumnName(ИмяКолонки.OBJECT_TYPE_NAME).IsOptional();
            
            Property(e => e.id_service_type).HasColumnName(ИмяКолонки.ID_SERVICE_TYPE).IsOptional();
            
            Property(e => e.create_date_1).HasColumnName(ИмяКолонки.CREATE_DATE_1).IsOptional();
            Property(e => e.create_date_2).HasColumnName(ИмяКолонки.CREATE_DATE_2).IsOptional();
            Property(e => e.create_request_state).HasColumnName(ИмяКолонки.CREATE_REQUEST_STATE).IsOptional();
            
            Property(e => e.end_date_1).HasColumnName(ИмяКолонки.END_DATE_1).IsOptional();
            Property(e => e.end_date_2).HasColumnName(ИмяКолонки.END_DATE_2).IsOptional();
            Property(e => e.end_request_state).HasColumnName(ИмяКолонки.END_REQUEST_STATE).IsOptional();
        }
    }
}