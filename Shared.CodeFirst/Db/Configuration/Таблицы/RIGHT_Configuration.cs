using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Shared.Db.Configuration.Таблицы
{
    public class RIGHT_Configuration : EntityTypeConfiguration<RIGHT>
    {
        public RIGHT_Configuration()
        {
            ToTable("_RIGHT", _EntityBase.SchemaName);

            HasKey(e => e.id);
            Property(e => e.id).HasColumnName("ID").IsRequired();

            Property(e => e.id_profile).HasColumnName("ID_PROFILE").IsRequired();
            Property(e => e.id_object).HasColumnName("ID_OBJECT").IsRequired();
            Property(e => e.id_right_descr).HasColumnName("ID_RIGHT_DESCR").IsRequired();
            Property(e => e.id_request_1).HasColumnName("ID_REQUEST_1").IsRequired();
            Property(e => e.id_request_2).HasColumnName("ID_REQUEST_2").IsOptional();
            Property(e => e.created_date_time).HasColumnName("CREATED").IsOptional();
        }
    }
}