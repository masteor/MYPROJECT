using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Shared.Db.Configuration.Таблицы
{
    public class DEVICE_TYPE_Configuration : EntityTypeConfiguration<DEVICE_TYPE>
    {
        public DEVICE_TYPE_Configuration()
        {
            ToTable("_DEVICE_TYPE", _EntityBase.SchemaName);

            HasKey(e => e.id);
            Property(e => e.id).HasColumnName("ID").IsRequired();
            
            Property(e => e.name).HasColumnName("NAME").HasMaxLength(50).IsRequired();

            /*HasMany(e => e.DEVICE)
                .WithRequired(e => e.DEVICE_TYPE)
                .HasForeignKey(e => e.id_device_type)
                .WillCascadeOnDelete(false);*/
        }
    }
}