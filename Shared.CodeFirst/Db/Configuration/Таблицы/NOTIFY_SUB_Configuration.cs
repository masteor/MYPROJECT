using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Shared.Db.Configuration.Таблицы
{
    public class NOTIFY_SUB_Configuration : EntityTypeConfiguration<NOTIFY_SUB>
    {
        public NOTIFY_SUB_Configuration()
        {
            ToTable("_NOTIFY_SUB", _EntityBase.SchemaName);

            HasKey(e => e.id);
            Property(e => e.id).HasColumnName("ID").IsRequired();
            
            Property(e => e.subscriber).HasColumnName("SUBSCRIBER").IsRequired();
            Property(e => e.producer).HasColumnName("PRODUCER").IsRequired();
            Property(e => e.state).HasColumnName("STATE").IsRequired();
        }
    }
}