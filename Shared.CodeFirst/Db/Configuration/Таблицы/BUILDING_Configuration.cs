using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Shared.Db.Configuration.Таблицы
{
    public class BUILDING_Configuration : EntityTypeConfiguration<BUILDING>
    {
        public BUILDING_Configuration()
        {
            ToTable("_BUILDING", _EntityBase.SchemaName);

            HasKey(e => e.id);
            Property(e => e.id).HasColumnName("ID").IsRequired();
            
            Property(e => e.название_здания).HasColumnName("NAME").HasMaxLength(10).IsRequired();
            Property(e => e.id_prom_area).HasColumnName("ID_PROM_AREA").IsRequired();

            /*HasMany(e => e.ROOM)
                .WithRequired(e => e.BUILDING)
                .HasForeignKey(e => e.id_building)
                .WillCascadeOnDelete(false);*/
        }
    }
}