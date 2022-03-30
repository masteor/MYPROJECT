using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Shared.Db.Configuration.Таблицы
{
    public class RESOURCE_RESP_Configuration : EntityTypeConfiguration<RESOURCE_RESP>
    {
        public RESOURCE_RESP_Configuration()
        {
            ToTable("_RESOURCE_RESP", _EntityBase.SchemaName);

            HasKey(e => e.id);
            Property(e => e.id).HasColumnName("ID").IsRequired();

            Property(e => e.id_resource).HasColumnName("ID_RESOURCE").IsRequired();
            Property(e => e.id_user).HasColumnName("ID_USER").IsRequired();
            Property(e => e.id_request_1).HasColumnName("ID_REQUEST_1").IsRequired();
            Property(e => e.id_request_2).HasColumnName("ID_REQUEST_2").IsOptional();
            

            //HasMany(e=>e.)
        }
    }
}