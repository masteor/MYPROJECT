using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities;
using QWERTY.Shared.Db.Entities.Представления;

namespace QWERTY.Shared.Db.Configuration.Представления
{
    public class VIEW_OBJECT_USER_RIGHTS_Configuration : EntityTypeConfiguration<VIEW_OBJECT_USER_RIGHTS>
    {
        public VIEW_OBJECT_USER_RIGHTS_Configuration()
        {
            ToTable(ИмяТаблицы.ViewObjectUserRights, _EntityBase.SchemaName);


            HasKey(e => new { e.id_object, e.id_member, e.id_profile });
            Property(e => e.id_object).HasColumnName(ИмяКолонки.ID_OBJECT);
            
            Property(e => e.object_name).HasColumnName(ИмяКолонки.OBJECT_NAME).HasMaxLength(255).IsRequired();
            Property(e => e.id_parent_object).HasColumnName(ИмяКолонки.ID_PARENT_OBJECT).IsOptional();
            Property(e => e.id_object_type).HasColumnName(ИмяКолонки.ID_OBJECT_TYPE).IsRequired();
            Property(e => e.id_resource).HasColumnName(ИмяКолонки.ID_RESOURCE).IsOptional();
            Property(e => e.id_profile).HasColumnName(ИмяКолонки.ID_PROFILE).IsRequired();
            Property(e => e.id_right_descr).HasColumnName(ИмяКолонки.ID_RIGHT_DESCR).IsRequired();
            Property(e => e.profile_name).HasColumnName(ИмяКолонки.PROFILE_NAME).HasMaxLength(100).IsRequired();
            Property(e => e.id_login).HasColumnName(ИмяКолонки.ID_LOGIN).IsOptional();
            Property(e => e.id_org).HasColumnName(ИмяКолонки.ID_ORG).IsOptional();
            Property(e => e.id_member).HasColumnName(ИмяКолонки.ID_MEMBER).IsRequired();
            Property(e => e.login_name).HasColumnName(ИмяКолонки.LOGIN_NAME).HasMaxLength(50).IsRequired();
            Property(e => e.id_user).HasColumnName(ИмяКолонки.ID_USER).IsRequired();
            Property(e => e.id_domen).HasColumnName(ИмяКолонки.ID_DOMEN).IsRequired();
            Property(e => e.id_employee).HasColumnName(ИмяКолонки.ID_EMPLOYEE).IsRequired();
            Property(e => e.tnum).HasColumnName(ИмяКолонки.TNUM).IsRequired();
            Property(e => e.id_job).HasColumnName(ИмяКолонки.ID_JOB).IsRequired();
            Property(e => e.id_form_perm).HasColumnName(ИмяКолонки.ID_FORM_PERM).IsRequired();
            Property(e => e.id_fio).HasColumnName(ИмяКолонки.ID_FIO).IsRequired();
            Property(e => e.name_1).HasColumnName(ИмяКолонки.NAME_1).IsRequired();
            Property(e => e.name_2).HasColumnName(ИмяКолонки.NAME_2).IsRequired();
            Property(e => e.name_3).HasColumnName(ИмяКолонки.NAME_3).IsRequired();

            /*HasMany(e => e.OBJECT)
                .WithRequired(e => e.ТИП_ОБЪЕКТА)
                .HasForeignKey(e => e.ID_OBJECT_TYPE)
                .WillCascadeOnDelete(false);*/

            /*HasMany(e => e.ПРАВА_ТИПОВ_ОБЪЕКТОВ)
                .WithRequired(e => e.ТИП_ОБЪЕКТА)
                .HasForeignKey(e => e.ID_OBJECT_TYPE);*/
        }
    }
}
