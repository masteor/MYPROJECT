using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Shared.Db.Configuration.Таблицы
{
    public class JOB_Configuration : EntityTypeConfiguration<JOB>
    {
        public JOB_Configuration()
        {
            ToTable("_JOB", _EntityBase.SchemaName);

            HasKey(e => e.id);
            Property(e => e.id).HasColumnName("ID").IsRequired();
            
            Property(e => e.name).HasColumnName("NAME").HasMaxLength(255).IsRequired();

            /*HasMany(e => e.EMPLOYEE)
                .WithRequired(e => e.ДОЛЖНОСТЬ)
                .HasForeignKey(e => e.id_job)
                .WillCascadeOnDelete(false);
            
            HasMany(e=> e.VIEW_OBJECT_USER_RIGHTS)
                .WithRequired(e=> e.ДОЛЖНОСТЬ)
                .HasForeignKey(e=> e.id_job)
                .WillCascadeOnDelete(false);*/
        }
    }
}