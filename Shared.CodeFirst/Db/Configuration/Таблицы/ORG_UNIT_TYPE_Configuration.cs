using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Shared.Db.Configuration.Таблицы
{
    public class ORG_UNIT_TYPE_Configuration : EntityTypeConfiguration<ORG_UNIT_TYPE>
    {
        public ORG_UNIT_TYPE_Configuration()
        {
            ToTable("_ORG_UNIT_TYPE", _EntityBase.SchemaName);

            HasKey(e => e.id);
            Property(e => e.id).HasColumnName("ID").IsRequired();

            Property(e => e.name).HasColumnName("NAME").HasMaxLength(50).IsRequired();

            /*HasMany(e => e.ORG)
                .WithRequired(e => e.ORG_UNIT_TYPE)
                .HasForeignKey(e => e.id_unit_type)
                .WillCascadeOnDelete(false);*/
        }
    }
}