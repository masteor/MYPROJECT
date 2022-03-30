using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Shared.Db.Configuration.Таблицы
{
    public class NOTIFY_REQUEST_Configuration : EntityTypeConfiguration<NOTIFY_REQUEST>
    {
        public NOTIFY_REQUEST_Configuration()
        {
            ToTable("_NOTIFY_REQUEST", _EntityBase.SchemaName);

            HasKey(e => e.id);
            Property(e => e.id).HasColumnName("ID").IsRequired();
            
            Property(e => e.id_request).HasColumnName("ID_REQUEST").IsRequired();
            Property(e => e.id_user).HasColumnName("ID_USER").IsRequired();
        }
    }
}