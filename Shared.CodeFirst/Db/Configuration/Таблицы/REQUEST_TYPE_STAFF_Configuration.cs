using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Shared.Db.Configuration.Таблицы
{
    public class REQUEST_TYPE_STAFF_Configuration : EntityTypeConfiguration<REQUEST_TYPE_STAFF>
    {
        public REQUEST_TYPE_STAFF_Configuration()
        {
            ToTable("_REQUEST_TYPE_STAFF", _EntityBase.SchemaName);

            HasKey(e => e.id);
            Property(e => e.id).HasColumnName("ID").IsRequired();

            Property(e => e.id_request_type).HasColumnName("ID_REQUEST_TYPE").IsRequired();
            Property(e => e.id_staff).HasColumnName("ID_STAFF").IsRequired();
        }
    }
}