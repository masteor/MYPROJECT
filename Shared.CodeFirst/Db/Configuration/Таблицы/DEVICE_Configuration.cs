using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Shared.Db.Configuration.Таблицы
{
    public class DEVICE_Configuration : EntityTypeConfiguration<DEVICE>
    {
        public DEVICE_Configuration()
        {
            ToTable("_DEVICE", _EntityBase.SchemaName);

            HasKey(e => e.id);
            Property(e => e.id).HasColumnName("ID").IsRequired();
            
            Property(e => e.reg_num).HasColumnName("REG_NUM").HasMaxLength(50).IsRequired();
            Property(e => e.id_device_type).HasColumnName("ID_DEVICE_TYPE").IsRequired();
            Property(e => e.id_new).HasColumnName("ID_NEW").IsOptional();
            Property(e => e.id_request_1).HasColumnName("ID_REQUEST_1").IsRequired();
            Property(e => e.id_request_2).HasColumnName("ID_REQUEST_2").IsOptional();

            /*HasMany(e => e.ARM_DEVICE)
                .WithRequired(e => e.DEVICE)
                .HasForeignKey(e => e.ид_устройства)
                .WillCascadeOnDelete(false);

            HasMany(e => e.DEVICE_OLD)
                .WithOptional(e => e.DEVICE_NEW)
                .HasForeignKey(e => e.id_new);*/
        }
    }
}