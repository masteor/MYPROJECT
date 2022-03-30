using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Shared.Db.Configuration.Таблицы
{
    public class EXECUTION_Configuration : EntityTypeConfiguration<EXECUTION>
    {
        public EXECUTION_Configuration()
        {
            ToTable("_EXECUTION", _EntityBase.SchemaName);

            HasKey(e => e.id);
            Property(e => e.id).HasColumnName("ID").IsRequired();
            
            Property(e => e.id_request).HasColumnName("ID_REQUEST").IsRequired();
            Property(e => e.id_executor).HasColumnName("ID_EXECUTOR").IsRequired();
            Property(e => e.date_1).HasColumnName("DATE_1").IsRequired();
            Property(e => e.date_2).HasColumnName("DATE_2").IsOptional();
            Property(e => e.id_request_state_1).HasColumnName("ID_REQUEST_STATE_1").IsRequired();
            Property(e => e.id_request_state_2).HasColumnName("ID_REQUEST_STATE_2").IsOptional();
            
            //HasMany(e=>e.)
        }
    }
}