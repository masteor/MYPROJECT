using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities;
using QWERTY.Shared.Db.Entities.Представления;

namespace QWERTY.Shared.Db.Configuration.Представления
{
    public class VIEW_RESOURCES_BY_OT_ST_Configuration : EntityTypeConfiguration<VIEW_RESOURCES_BY_OT_ST>
    {
        public VIEW_RESOURCES_BY_OT_ST_Configuration()
        {
            ToTable(ИмяТаблицы.ViewResourcesByOtSt, _EntityBase.SchemaName);

            HasKey(e => e.id);

            Property(e => e.id).HasColumnName(ИмяКолонки.ID).IsRequired();
            Property(e => e.id_object).HasColumnName(ИмяКолонки.ID_OBJECT).IsRequired();
            Property(e => e.id_resource).HasColumnName(ИмяКолонки.ID_RESOURCE).IsRequired();
            Property(e => e.id_ac_fragment).HasColumnName(ИмяКолонки.ID_AC_FRAGMENT).IsRequired();
            Property(e => e.name).HasColumnName(ИмяКолонки.NAME).IsRequired();
            
            // Property(e => e.login_responsible).HasColumnName(ИмяКолонки.LOGIN_RESPONSIBLE).IsRequired();
            // Property(e => e.login_owner).HasColumnName(ИмяКолонки.LOGIN_OWNER).IsRequired();
            
            Property(e => e.id_user_responsible).HasColumnName(ИмяКолонки.ID_USER_RESPONSIBLE).IsRequired();
            Property(e => e.id_user_owner).HasColumnName(ИмяКолонки.ID_USER_OWNER).IsRequired();
            Property(e => e.id_object_type).HasColumnName(ИмяКолонки.ID_OBJECT_TYPE).IsRequired();
            Property(e => e.id_service_type).HasColumnName(ИмяКолонки.ID_SERVICE_TYPE).IsRequired();
            Property(e => e.code).HasColumnName(ИмяКолонки.CODE).IsRequired();
            Property(e => e.icon).HasColumnName(ИмяКолонки.ICON).IsRequired();
            Property(e => e.rq1_id).HasColumnName(ИмяКолонки.RQ1_ID).IsRequired();
            Property(e => e.rq1_parent).HasColumnName(ИмяКолонки.RQ1_PARENT).IsRequired();
            Property(e => e.create_date_1).HasColumnName(ИмяКолонки.CREATE_DATE_1).IsRequired();
            Property(e => e.create_date_2).HasColumnName(ИмяКолонки.CREATE_DATE_2).IsRequired();
            Property(e => e.create_request_state).HasColumnName(ИмяКолонки.CREATE_REQUEST_STATE).IsRequired();
            Property(e => e.create_request_state_name).HasColumnName(ИмяКолонки.CREATE_REQUEST_STATE_NAME).IsRequired();
            Property(e => e.create_request_state_code).HasColumnName(ИмяКолонки.CREATE_REQUEST_STATE_CODE).IsRequired();
            Property(e => e.rq2_id).HasColumnName(ИмяКолонки.RQ2_ID).IsRequired();
            Property(e => e.rq2_parent).HasColumnName(ИмяКолонки.RQ2_PARENT).IsRequired();
            Property(e => e.end_date_1).HasColumnName(ИмяКолонки.END_DATE_1).IsRequired();
            Property(e => e.end_date_2).HasColumnName(ИмяКолонки.END_DATE_2).IsRequired();
            Property(e => e.end_request_state).HasColumnName(ИмяКолонки.END_REQUEST_STATE).IsRequired();
            Property(e => e.end_request_state_name).HasColumnName(ИмяКолонки.END_REQUEST_STATE_NAME).IsRequired();
            Property(e => e.end_request_state_code).HasColumnName(ИмяКолонки.END_REQUEST_STATE_CODE).IsRequired();
        }
    }
}
