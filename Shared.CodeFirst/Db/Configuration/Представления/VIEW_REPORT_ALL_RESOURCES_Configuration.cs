using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities;
using QWERTY.Shared.Db.Entities.Представления;

namespace QWERTY.Shared.Db.Configuration.Представления
{
    public class VIEW_REPORT_ALL_RESOURCES_Configuration : EntityTypeConfiguration<VIEW_REPORT_ALL_RESOURCES>
    {
        public VIEW_REPORT_ALL_RESOURCES_Configuration()
        {
            ToTable(ИмяТаблицы.ViewReportAllResources, _EntityBase.SchemaName);

            HasKey(e => e.id);
            Property(e => e.id).HasColumnName(ИмяКолонки.ID).IsRequired();
            
            Property(e => e.id_resource).HasColumnName(ИмяКолонки.ID_RESOURCE).IsRequired();
            Property(e => e.resource_name).HasColumnName(ИмяКолонки.RESOURCE_NAME).IsOptional();
            
            Property(e => e.object_type_name).HasColumnName(ИмяКолонки.OBJECT_TYPE_NAME).IsRequired();
            Property(e => e.service_type_name).HasColumnName(ИмяКолонки.SERVICE_TYPE_NAME).IsRequired();
            Property(e => e.service_name).HasColumnName(ИмяКолонки.SERVICE_NAME).IsRequired();
            
            Property(e => e.frag_name).HasColumnName(ИмяКолонки.FRAG_NAME).IsRequired();
            Property(e => e.id_frag).HasColumnName(ИмяКолонки.ID_FRAG).IsOptional();
            Property(e => e.path).HasColumnName(ИмяКолонки.PATH).IsOptional();
            Property(e => e.description).HasColumnName(ИмяКолонки.DESCRIPTION).IsOptional();
            Property(e => e.secret_type_name).HasColumnName(ИмяКолонки.SECRET_TYPE_NAME).IsRequired();
            
            // Property(e => e.login_owner).HasColumnName(ИмяКолонки.LOGIN_OWNER).IsRequired();
            Property(e => e.id_user_owner).HasColumnName(ИмяКолонки.ID_USER_OWNER).IsRequired();
            Property(e => e.owner).HasColumnName(ИмяКолонки.OWNER).IsRequired();
            Property(e => e.owner_short_name).HasColumnName(ИмяКолонки.OWNER_SHORT_NAME).IsRequired();
            Property(e => e.owner_org_fname).HasColumnName(ИмяКолонки.OWNER_ORG_FNAME).IsRequired();
            Property(e => e.owner_job_name).HasColumnName(ИмяКолонки.OWNER_JOB_NAME).IsRequired();
            
            // Property(e => e.login_responsible).HasColumnName(ИмяКолонки.LOGIN_RESPONSIBLE).IsOptional();
            Property(e => e.id_user_responsible).HasColumnName(ИмяКолонки.ID_USER_RESPONSIBLE).IsOptional();
            Property(e => e.responsible).HasColumnName(ИмяКолонки.RESPONSIBLE).IsRequired();
            Property(e => e.responsible_short_name).HasColumnName(ИмяКолонки.RESPONSIBLE_SHORT_NAME).IsRequired();
            Property(e => e.responsible_job_name).HasColumnName(ИмяКолонки.RESPONSIBLE_JOB_NAME).IsRequired();
            Property(e => e.responsible_org_fname).HasColumnName(ИмяКолонки.RESPONSIBLE_ORG_FNAME).IsRequired();
            Property(e => e.id_request_type_code_1).HasColumnName(ИмяКолонки.ID_REQUEST_TYPE_CODE_1).IsOptional();
            
            
            Property(e => e.id_request_type_code_2).HasColumnName(ИмяКолонки.ID_REQUEST_TYPE_CODE_2).IsOptional();
            Property(e => e.id_request_1).HasColumnName(ИмяКолонки.ID_REQUEST_1).IsOptional();
            Property(e => e.id_request_2).HasColumnName(ИмяКолонки.ID_REQUEST_2).IsOptional();
            Property(e => e.id_request_1_parent).HasColumnName(ИмяКолонки.ID_REQUEST_1_PARENT).IsOptional();
            Property(e => e.id_request_2_parent).HasColumnName(ИмяКолонки.ID_REQUEST_2_PARENT).IsOptional();
            
            Property(e => e.reg_num).HasColumnName(ИмяКолонки.REG_NUM).IsOptional();
            
            Property(e => e.create_date_1).HasColumnName(ИмяКолонки.CREATE_DATE_1).IsOptional();
            Property(e => e.create_date_2).HasColumnName(ИмяКолонки.CREATE_DATE_2).IsOptional();
            Property(e => e.create_request_state).HasColumnName(ИмяКолонки.CREATE_REQUEST_STATE).IsOptional();
            Property(e => e.create_request_state_name).HasColumnName(ИмяКолонки.CREATE_REQUEST_STATE_NAME).IsOptional();
            
            Property(e => e.end_date_1).HasColumnName(ИмяКолонки.END_DATE_1).IsOptional();
            Property(e => e.end_date_2).HasColumnName(ИмяКолонки.END_DATE_2).IsOptional();
            Property(e => e.end_request_state).HasColumnName(ИмяКолонки.END_REQUEST_STATE).IsOptional();
            Property(e => e.end_request_state_name).HasColumnName(ИмяКолонки.END_REQUEST_STATE_NAME).IsOptional();
        }
    }
}
