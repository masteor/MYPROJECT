using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Shared.Db.Configuration.Таблицы
{
    public class DEVICE_PERM_Configuration : EntityTypeConfiguration<DEVICE_PERM>
    {
        public DEVICE_PERM_Configuration()
        {
            ToTable("_DEVICE_PERM", _EntityBase.SchemaName);

            HasKey(e => e.id);
            Property(e => e.id).HasColumnName("ID").IsRequired();
            
            Property(e => e.name).HasColumnName("NAME").HasMaxLength(50).IsRequired();

            /*HasMany(e => e.ARM_DEVICE)
                .WithRequired(e => e.DEVICE_PERM)
                .HasForeignKey(e => e.ид_типа_разрешения_на_устройство)
                .WillCascadeOnDelete(false);*/
        }
    }
}