using System.Data.Entity.ModelConfiguration;
using DBPSA.Shared.Db.Entities;
using DBPSA.Shared.Db.Entities.Представления;

namespace DBPSA.Shared.Db.Configuration.Представления
{
    public class VIEW_REPORT_ALL_RESOURCES_FROM_PRD_Configuration : EntityTypeConfiguration<VIEW_REPORT_ALL_RESOURCES_FROM_PRD>
    {
        public VIEW_REPORT_ALL_RESOURCES_FROM_PRD_Configuration()
        {
            ToTable(ИмяТаблицы.ViewReportAllResourcesFromPrd, _EntityBase.SchemaName);

            HasKey(e => new {e.id});
            Property(e => e.id).HasColumnName(ИмяКолонки.ID).IsRequired();
            
            Property(e => e.resource_name).HasColumnName(ИмяКолонки.RESOURCE_NAME).IsOptional();
            Property(e => e.service_type_name).HasColumnName(ИмяКолонки.SERVICE_TYPE_NAME).IsRequired();
            Property(e => e.service_name).HasColumnName(ИмяКолонки.SERVICE_NAME).IsRequired();
            Property(e => e.frag_name).HasColumnName(ИмяКолонки.FRAG_NAME).IsRequired();
            Property(e => e.path).HasColumnName(ИмяКолонки.PATH).IsOptional();
            Property(e => e.description).HasColumnName(ИмяКолонки.DESCRIPTION).IsOptional();
            Property(e => e.secret_type_name).HasColumnName(ИмяКолонки.SECRET_TYPE_NAME).IsRequired();
            Property(e => e.owner).HasColumnName(ИмяКолонки.OWNER);
            Property(e => e.responsible).HasColumnName(ИмяКолонки.RESPONSIBLE).IsRequired();
            Property(e => e.create_date_1).HasColumnName(ИмяКолонки.CREATE_DATE_1).IsOptional();
            Property(e => e.create_date_2).HasColumnName(ИмяКолонки.CREATE_DATE_2).IsOptional();
            Property(e => e.create_request_state).HasColumnName(ИмяКолонки.CREATE_REQUEST_STATE).IsOptional();
            Property(e => e.end_date_1).HasColumnName(ИмяКолонки.END_DATE_1).IsOptional();
            Property(e => e.end_date_2).HasColumnName(ИмяКолонки.END_DATE_2).IsOptional();
            Property(e => e.end_request_state).HasColumnName(ИмяКолонки.END_REQUEST_STATE).IsOptional();
            Property(e => e.reg_num).HasColumnName(ИмяКолонки.REG_NUM).IsOptional();
        }
    }
}
