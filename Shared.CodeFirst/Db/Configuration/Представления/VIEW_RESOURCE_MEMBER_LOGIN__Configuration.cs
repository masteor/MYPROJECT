using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities;
using QWERTY.Shared.Db.Entities.Представления;

namespace QWERTY.Shared.Db.Configuration.Представления
{
    public class VIEW_RESOURCE_MEMBER_EMPLOYEE_Configuration : EntityTypeConfiguration<VIEW_RESOURCE_MEMBER_EMPLOYEE>
    {
        public VIEW_RESOURCE_MEMBER_EMPLOYEE_Configuration()
        {
            ToTable(ИмяТаблицы.VIEW_RESOURCE_MEMBER_EMPLOYEE, _EntityBase.SchemaName);

            HasKey(e => new {e.id_resource_member});

            Property(e => e.id_resource_member).HasColumnName(ИмяКолонки.ID_RESOURCE_MEMBER).IsRequired();
            Property(e => e.id_user).HasColumnName(ИмяКолонки.ID_USER).IsRequired();
            Property(e => e.id_resource).HasColumnName(ИмяКолонки.ID_RESOURCE).IsRequired();
            Property(e => e.id_object).HasColumnName(ИмяКолонки.ID_OBJECT).IsRequired();
            Property(e => e.id_user_responsible).HasColumnName(ИмяКолонки.ID_USER_RESPONSIBLE).IsRequired();
            Property(e => e.id_user_owner).HasColumnName(ИмяКолонки.ID_USER_OWNER).IsRequired();
            Property(e => e.fio_full).HasColumnName(ИмяКолонки.FIO_FULL).IsRequired();
            Property(e => e.job_name).HasColumnName(ИмяКолонки.JOB_NAME).IsRequired();
            Property(e => e.org_fname).HasColumnName(ИмяКолонки.ORG_FNAME).IsRequired();
            Property(e => e.id_request_1).HasColumnName(ИмяКолонки.ID_REQUEST_1).IsRequired();
            Property(e => e.id_request_2).HasColumnName(ИмяКолонки.ID_REQUEST_2).IsRequired();
        }
    }
}
