using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities;
using QWERTY.Shared.Db.Entities.Представления;

namespace QWERTY.Shared.Db.Configuration.Представления
{
    public class VIEW_REPORT_ALL_PROFILES_Configuration : EntityTypeConfiguration<VIEW_REPORT_ALL_PROFILES>
    {
        public VIEW_REPORT_ALL_PROFILES_Configuration()
        {
            ToTable(ИмяТаблицы.VIEW_REPORT_ALL_PROFILES, _EntityBase.SchemaName);

            HasKey(e => new {e.id});
            
            Property(e => e.id).HasColumnName(ИмяКолонки.ID).IsRequired();
            Property(e => e.id_right_descr).HasColumnName(ИмяКолонки.ID_RIGHT_DESCR).IsRequired();
            Property(e => e.description).HasColumnName(ИмяКолонки.DESCRIPTION).IsRequired();
            Property(e => e.id_profile).HasColumnName(ИмяКолонки.ID_PROFILE).IsOptional();
            Property(e => e.id_request).HasColumnName(ИмяКолонки.ID_REQUEST).IsOptional();
            Property(e => e.id_request_parent).HasColumnName(ИмяКолонки.ID_REQUEST_PARENT).IsOptional();
            Property(e => e.profile_name).HasColumnName(ИмяКолонки.PROFILE_NAME).IsOptional();
            Property(e => e.resource_name).HasColumnName(ИмяКолонки.RESOURCE_NAME).IsOptional();            
            Property(e => e.object_type_name).HasColumnName(ИмяКолонки.OBJECT_TYPE_NAME).IsOptional();
            Property(e => e.service_type_name).HasColumnName(ИмяКолонки.SERVICE_TYPE_NAME).IsOptional();
            Property(e => e.frag_name).HasColumnName(ИмяКолонки.FRAG_NAME).IsOptional();
            Property(e => e.secret_type_name).HasColumnName(ИмяКолонки.SECRET_TYPE_NAME).IsOptional();
            Property(e => e.id_user_sender).HasColumnName(ИмяКолонки.ID_USER_SENDER).IsOptional();
            Property(e => e.id_user_recipient).HasColumnName(ИмяКолонки.ID_USER_RECIPIENT).IsOptional();
        }
    }
}
