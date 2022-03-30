using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Shared.Db.Configuration.Таблицы
{
    public class RIGHT_GROUP_Configuration : EntityTypeConfiguration<RIGHT_GROUP>
    {
        public RIGHT_GROUP_Configuration()
        {
            ToTable("_RIGHT_GROUP", _EntityBase.SchemaName);

            HasKey(e => e.id);
            Property(e => e.id).HasColumnName("ID").IsRequired();

            Property(e => e.id_group).HasColumnName("ID_GROUP").IsOptional();
            Property(e => e.id_right).HasColumnName("ID_RIGHT").IsOptional();
            Property(e => e.description).HasColumnName("DESCRIPTION").HasMaxLength(50).IsRequired();

            /*HasMany(e => e.RIGHT)
                .WithRequired(e => e.RIGHT_GROUP)
                .HasForeignKey(e => e.ID_RIGHT_GROUP)
                .WillCascadeOnDelete(false);*/
        }
    }
}