using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Shared.Db.Configuration.Таблицы
{
    public class PROM_AREA_Configuration : EntityTypeConfiguration<PROM_AREA>
    {
        public PROM_AREA_Configuration()
        {
            ToTable("_PROM_AREA", _EntityBase.SchemaName);

            HasKey(e => e.id);
            Property(e => e.id).HasColumnName("ID").IsRequired();

            Property(e => e.name).HasColumnName("NAME").HasMaxLength(50).IsRequired();

            /*HasMany(e => e.BUILDING)
                .WithRequired(e => e.PROM_AREA)
                .HasForeignKey(e => e.id_prom_area)
                .WillCascadeOnDelete(false);*/
        }
    }
}