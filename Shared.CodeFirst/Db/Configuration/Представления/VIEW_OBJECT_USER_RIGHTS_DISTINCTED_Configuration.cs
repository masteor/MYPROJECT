using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities;
using QWERTY.Shared.Db.Entities.Представления;

namespace QWERTY.Shared.Db.Configuration.Представления
{
    public class VIEW_OBJECT_USER_RIGHTS_DISTINCTED_Configuration : EntityTypeConfiguration<VIEW_OBJECT_USER_RIGHTS_DISTINCTED>
    {
        public VIEW_OBJECT_USER_RIGHTS_DISTINCTED_Configuration()
        {
            ToTable(ИмяТаблицы.VIEW_OBJECT_USER_RIGHTS_DISTINCT, _EntityBase.SchemaName);

            HasKey(e => new {e.id_object, e.id_member, e.id_profile });

            Property(e => e.id_object).HasColumnName("ID_OBJECT").IsRequired();
            Property(e => e.object_name).HasColumnName("OBJECT_NAME").HasMaxLength(255).IsRequired();
            Property(e => e.id_parent_object).HasColumnName("ID_PARENT_OBJECT").IsRequired();
            Property(e => e.id_object_type).HasColumnName("ID_OBJECT_TYPE").IsRequired();
            Property(e => e.id_resource).HasColumnName("ID_RESOURCE").IsRequired();
            Property(e => e.id_profile).HasColumnName("ID_PROFILE").IsRequired();
            Property(e => e.profile_name).HasColumnName("PROFILE_NAME").HasMaxLength(100).IsRequired();
            Property(e => e.id_login).HasColumnName("ID_LOGIN").IsRequired();
            Property(e => e.id_org).HasColumnName("ID_ORG").IsRequired();
            Property(e => e.id_org_employee_in_org).HasColumnName("ID_ORG_EMPLOYEE_IN_ORG").IsRequired();
            Property(e => e.id_member).HasColumnName("ID_MEMBER").IsRequired();
            Property(e => e.id_member_request_1).HasColumnName("ID_MEMBER_REQUEST_1").IsRequired();
            Property(e => e.id_member_request_2).HasColumnName("ID_MEMBER_REQUEST_2").IsRequired();
            Property(e => e.login_name).HasColumnName("LOGIN_NAME").HasMaxLength(50).IsRequired();
            Property(e => e.id_user).HasColumnName("ID_USER").IsRequired();
            Property(e => e.id_domen).HasColumnName("ID_DOMEN").IsRequired();
            Property(e => e.id_employee).HasColumnName("ID_EMPLOYEE").IsRequired();
            Property(e => e.tnum).HasColumnName("TNUM").IsRequired();
            Property(e => e.id_job).HasColumnName("ID_JOB").IsRequired();
            Property(e => e.id_form_perm).HasColumnName("ID_FORM_PERM").IsRequired();
            Property(e => e.id_fio).HasColumnName("ID_FIO").IsRequired();
            Property(e => e.name_1).HasColumnName("NAME_1").IsRequired();
            Property(e => e.name_2).HasColumnName("NAME_2").IsRequired();
            Property(e => e.name_3).HasColumnName("NAME_3").IsRequired();
        }
    }
}
