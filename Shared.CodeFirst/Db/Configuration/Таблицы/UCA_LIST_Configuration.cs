using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Shared.Db.Configuration.Таблицы
{
    public class UCA_LIST_Configuration : EntityTypeConfiguration<UCA_LIST>
    {
        public UCA_LIST_Configuration()
        {
            ToTable("_UCA_LIST", _EntityBase.SchemaName);

            HasKey(e => e.id);
            Property(e => e.id).HasColumnName("ID").IsRequired();

            Property(e => e.name).HasColumnName("NAME").IsRequired().HasMaxLength(255);

            /*HasMany(e => e.RESOURCE_UCA)
                .WithRequired(e => e.UCA_LIST)
                .HasForeignKey(e => e.id_uca_list)
                .WillCascadeOnDelete(false);*/
        }
    }
}