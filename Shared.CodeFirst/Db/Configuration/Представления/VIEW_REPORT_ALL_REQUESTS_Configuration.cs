using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities;
using QWERTY.Shared.Db.Entities.Представления;

namespace QWERTY.Shared.Db.Configuration.Представления
{
    public class VIEW_REPORT_ALL_REQUESTS_Configuration : EntityTypeConfiguration<VIEW_REPORT_ALL_REQUESTS>
    {
        public VIEW_REPORT_ALL_REQUESTS_Configuration()
        {
            ToTable(ИмяТаблицы.ViewReportAllRequests, _EntityBase.SchemaName);

            HasKey(e => new {e.id});
            
            Property(e => e.id).HasColumnName(ИмяКолонки.ID).IsRequired();
            Property(e => e.id_request).HasColumnName(ИмяКолонки.ID_REQUEST).IsRequired();
            
            Property(e => e.parent).HasColumnName(ИмяКолонки.PARENT).IsOptional();
            
            Property(e => e.datestr_1).HasColumnName(ИмяКолонки.DATESTR_1).IsOptional();
            Property(e => e.date_1).HasColumnName(ИмяКолонки.DATE_1).IsOptional();
            Property(e => e.request_type_name).HasColumnName(ИмяКолонки.REQUEST_TYPE_NAME).IsOptional();
            Property(e => e.request_type_code).HasColumnName(ИмяКолонки.REQUEST_TYPE_CODE).IsOptional();
            Property(e => e.sender).HasColumnName(ИмяКолонки.SENDER).IsOptional();
            Property(e => e.id_user_sender).HasColumnName(ИмяКолонки.ID_USER_SENDER).IsOptional();
            Property(e => e.recipient).HasColumnName(ИмяКолонки.RECIPIENT).IsOptional();
            
            Property(e => e.id_user_recipient).HasColumnName(ИмяКолонки.ID_USER_RECIPIENT).IsOptional();
            Property(e => e.create_request_state).HasColumnName(ИмяКолонки.CREATE_REQUEST_STATE).IsOptional();
            
            Property(e => e.request_state_name).HasColumnName(ИмяКолонки.REQUEST_STATE_NAME).IsOptional();
            Property(e => e.id_doc).HasColumnName(ИмяКолонки.ID_DOC).IsOptional();
        }
    }
}
