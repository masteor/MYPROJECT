using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Shared.Db.Configuration.Таблицы
{
    public class ARM_USER_ROLE_Configuration : EntityTypeConfiguration<ARM_USER_ROLE>
    {
        public ARM_USER_ROLE_Configuration()
        {
            ToTable("_ARM_USER_ROLE", _EntityBase.SchemaName);

            HasKey(e => e.id);
            Property(e => e.id).HasColumnName("ID").IsRequired();
            Property(e => e.name).HasColumnName("NAME").HasMaxLength(50).IsRequired();
            
            /*HasMany(e => e.ARM_USER)
                .WithRequired(e => e.ARM_USER_ROLE)
                .HasForeignKey(e => e.ид_роли_сотрудника)
                .WillCascadeOnDelete(false);*/
        }
    }
}