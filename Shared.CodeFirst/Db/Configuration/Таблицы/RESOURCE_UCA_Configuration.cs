using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Shared.Db.Configuration.Таблицы
{
    public class RESOURCE_UCA_Configuration : EntityTypeConfiguration<RESOURCE_UCA>
    {
        public RESOURCE_UCA_Configuration()
        {
            ToTable("_RESOURCE_UCA", _EntityBase.SchemaName);

            HasKey(e => e.id);
            Property(e => e.id).HasColumnName("ID").IsRequired();

            Property(e => e.id_uca_list).HasColumnName("ID_UCA_LIST").IsRequired();
            Property(e => e.id_resource).HasColumnName("ID_RESOURCE").IsRequired();
            Property(e => e.id_request_1).HasColumnName("ID_REQUEST_1").IsRequired();
            Property(e => e.id_request_2).HasColumnName("ID_REQUEST_2").IsOptional();
        }
    }
}