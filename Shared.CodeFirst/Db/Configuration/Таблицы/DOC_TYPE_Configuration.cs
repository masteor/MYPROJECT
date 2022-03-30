using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Shared.Db.Configuration.Таблицы
{
    public class DOC_TYPE_Configuration : EntityTypeConfiguration<DOC_TYPE>
    {
        public DOC_TYPE_Configuration()
        {
            ToTable("_DOC_TYPE", _EntityBase.SchemaName);

            HasKey(entity => entity.id);
            Property(entity => entity.id).HasColumnName("ID").IsRequired();
            
            Property(entity => entity.name).HasColumnName("NAME").HasMaxLength(100).IsRequired();

            /*HasMany(e => e.DOC)
                .WithRequired(e => e.DOC_TYPE)
                .HasForeignKey(e => e.id_doc_type)
                .WillCascadeOnDelete(false);*/
        }
    }
}
