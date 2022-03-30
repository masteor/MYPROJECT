using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities;
using QWERTY.Shared.Db.Entities.Представления;

namespace QWERTY.Shared.Db.Configuration.Представления
{
    public class VIEW_REPORT_RESOURCES_WHERE_AM_I_Configuration : EntityTypeConfiguration<VIEW_REPORT_RESOURCES_WHERE_AM_I>
    {
        public VIEW_REPORT_RESOURCES_WHERE_AM_I_Configuration()
        {
            ToTable(ИмяТаблицы.VIEW_REPORT_RESOURCES_WHERE_AM_I, _EntityBase.SchemaName);

            HasKey(e => new {e.id});

            Property(e => e.id).HasColumnName(ИмяКолонки.ID).IsRequired();
            Property(e => e.id_resource).HasColumnName(ИмяКолонки.ID_RESOURCE).IsRequired();
            Property(e => e.resource_name).HasColumnName(ИмяКолонки.RESOURCE_NAME).IsRequired();
            Property(e => e.object_type_name).HasColumnName(ИмяКолонки.OBJECT_TYPE_NAME).IsRequired();
            Property(e => e.object_type_id).HasColumnName(ИмяКолонки.OBJECT_TYPE_ID).IsRequired();
            Property(e => e.service_type_name).HasColumnName(ИмяКолонки.SERVICE_TYPE_NAME).IsRequired();
            Property(e => e.service_name).HasColumnName(ИмяКолонки.SERVICE_NAME).IsRequired();
            Property(e => e.frag_id).HasColumnName(ИмяКолонки.FRAG_ID).IsRequired();
            Property(e => e.frag_name).HasColumnName(ИмяКолонки.FRAG_NAME).IsRequired();
            Property(e => e.path).HasColumnName(ИмяКолонки.PATH).IsRequired();
            Property(e => e.description).HasColumnName(ИмяКолонки.DESCRIPTION).IsRequired();
            Property(e => e.secret_type_name).HasColumnName(ИмяКолонки.SECRET_TYPE_NAME).IsRequired();
            Property(e => e.fio_owner).HasColumnName(ИмяКолонки.FIO_OWNER).IsRequired();

            Property(e => e.id_user_responsible).HasColumnName(ИмяКолонки.ID_USER_RESPONSIBLE).IsRequired();
            Property(e => e.id_user_owner).HasColumnName(ИмяКолонки.ID_USER_OWNER).IsRequired();
            
            // Property(e => e.login_responsible).HasColumnName(ИмяКолонки.LOGIN_RESPONSIBLE).IsRequired();
            // Property(e => e.login_owner).HasColumnName(ИмяКолонки.LOGIN_OWNER).IsRequired();
            
            Property(e => e.fio_responsible).HasColumnName(ИмяКолонки.FIO_RESPONSIBLE).IsRequired();
            Property(e => e.id_request_1).HasColumnName(ИмяКолонки.ID_REQUEST_1).IsRequired();
            Property(e => e.parent_1).HasColumnName(ИмяКолонки.PARENT_1).IsRequired();
            Property(e => e.id_request_type_code_1).HasColumnName(ИмяКолонки.ID_REQUEST_TYPE_CODE_1).IsRequired();
            
            Property(e => e.create_date_1).HasColumnName(ИмяКолонки.CREATE_DATE_1).IsRequired();
            Property(e => e.create_date_2).HasColumnName(ИмяКолонки.CREATE_DATE_2).IsRequired();
            Property(e => e.create_date_2_str).HasColumnName(ИмяКолонки.CREATE_DATE_2_STR).IsRequired();
            
            Property(e => e.create_request_state).HasColumnName(ИмяКолонки.CREATE_REQUEST_STATE).IsRequired();
            Property(e => e.create_request_state_name).HasColumnName(ИмяКолонки.CREATE_REQUEST_STATE_NAME).IsRequired();
            Property(e => e.id_request_2).HasColumnName(ИмяКолонки.ID_REQUEST_2).IsRequired();
            Property(e => e.parent_2).HasColumnName(ИмяКолонки.PARENT_2).IsRequired();
            Property(e => e.id_request_type_code_2).HasColumnName(ИмяКолонки.ID_REQUEST_TYPE_CODE_2).IsRequired();
            Property(e => e.end_date_1).HasColumnName(ИмяКолонки.END_DATE_1).IsRequired();
            Property(e => e.end_date_2).HasColumnName(ИмяКолонки.END_DATE_2).IsRequired();
            Property(e => e.end_request_state).HasColumnName(ИмяКолонки.END_REQUEST_STATE).IsRequired();
            Property(e => e.end_request_state_name).HasColumnName(ИмяКолонки.END_REQUEST_STATE_NAME).IsRequired();
            Property(e => e.reg_num).HasColumnName(ИмяКолонки.REG_NUM).IsRequired();
        }
    }
}
