using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Shared.Db.Configuration.Таблицы
{
    public class ARM_DEVICE_Configuration : EntityTypeConfiguration<ARM_DEVICE>
    {
        public ARM_DEVICE_Configuration()
        {
            ToTable("_ARM_DEVICE", _EntityBase.SchemaName);

            HasKey(e => e.id);
            Property(e => e.id).HasColumnName("ID").IsRequired();
            
            Property(e => e.ид_арма).HasColumnName("ID_ARM").IsRequired();
            Property(e => e.ид_устройства).HasColumnName("ID_DEVICE").IsRequired();
            Property(e => e.ид_типа_разрешения_на_устройство).HasColumnName("ID_DEVICE_PERM").IsRequired();
            Property(e => e.ид_заявки_начала_разрешения).HasColumnName("ID_REQUEST_1").IsRequired();
            Property(e => e.ид_заявки_окончания_разрешения).HasColumnName("ID_REQUEST_2").IsOptional();
        }
    }
}