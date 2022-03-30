using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Shared.Db.Configuration.Таблицы
{
    public class FORM_PERM_Configuration : EntityTypeConfiguration<FORM_PERM>
    {
        public FORM_PERM_Configuration()
        {
            ToTable("_FORM_PERM", _EntityBase.SchemaName);

            HasKey(e => e.id);
            Property(e => e.id).HasColumnName("ID").IsRequired();
            
            Property(e => e.name).HasColumnName("NAME").HasMaxLength(20).IsRequired();
            Property(e => e.description).HasColumnName("DESCRIPTION").HasMaxLength(255).IsRequired();

            /*HasMany(e => e.EMPLOYEE)
                .WithRequired(e => e.ФОРМА_ДОПУСКА)
                .HasForeignKey(e => e.id_form_perm)
                .WillCascadeOnDelete(false);
            
            HasMany(e => e.VIEW_OBJECT_USER_RIGHTS_DISTINCTED)
                .WithRequired(e => e.ФОРМА_ДОПУСКА)
                .HasForeignKey(e => e.id_form_perm)
                .WillCascadeOnDelete(false);*/
        }
    }
}