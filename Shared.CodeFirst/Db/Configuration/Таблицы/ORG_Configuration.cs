using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Shared.Db.Configuration.Таблицы
{
    public class ORG_Configuration : EntityTypeConfiguration<ORG>
    {
        public ORG_Configuration()
        {
            ToTable("_ORG", _EntityBase.SchemaName);

            HasKey(e => e.id);
            Property(e => e.id).HasColumnName("ID").IsRequired();

            Property(e => e.kod).HasColumnName("KOD").IsRequired();
            Property(e => e.fname).HasColumnName("FNAME").HasMaxLength(255).IsRequired();
            Property(e => e.id_user_boss).HasColumnName("ID_USER_BOSS").IsRequired();
            Property(e => e.id_parent).HasColumnName("ID_PARENT").IsOptional();
            Property(e => e.id_unit_type).HasColumnName("ID_UNIT_TYPE").IsRequired();
            Property(e => e.id_new).HasColumnName("ID_NEW").IsOptional();
            Property(e => e.is_active).HasColumnName("ISACTIVE").IsOptional();
            Property(e => e.id_request_1).HasColumnName("ID_REQUEST_1").IsRequired();
            Property(e => e.id_request_2).HasColumnName("ID_REQUEST_2").IsOptional();

            /*HasMany(e => e.СОТРУДНИКИ_В_СТРУКТУРЕ_1)
                 .WithRequired(e => e.ORG)
                 .HasForeignKey(e => e.id_org)
                 .WillCascadeOnDelete(false);
            
            HasMany(e => e.СОТРУДНИКИ_В_СТРУКТУРЕ_2)
                .WithRequired(e => e.СТРУКТУРНАЯ_ЕДИНИЦА_ПОЛЬЗОВАТЕЛЯ)
                .HasForeignKey(e => e.id_org_employee_in_org)
                .WillCascadeOnDelete(false);
            
            HasMany(e => e.СОТРУДНИКИ_В_СТРУКТУРЕ_3)
                .WithRequired(e => e.СТРУКТУРНАЯ_ЕДИНИЦА_С_ДОСТУПОМ)
                .HasForeignKey(e => e.id_org)
                .WillCascadeOnDelete(false);

            HasMany(e => e.MEMBER)
                .WithOptional(e => e.ORG)
                .HasForeignKey(e => e.id_org);

            HasMany(e => e.ДОЧЕРНИЕ_СТРУКТУРЫ)
                .WithOptional(e => e.ORG_PARENT)
                .HasForeignKey(e => e.id_parent);

            HasMany(e => e.ORG_OLD)
                .WithOptional(e => e.ORG_NEW)
                .HasForeignKey(e => e.id_new);*/
        }
    }
}