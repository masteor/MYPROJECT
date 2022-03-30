using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Shared.Db.Configuration.Таблицы
{
    public class AC_FRAGMENT_Configuration : EntityTypeConfiguration<AC_FRAGMENT>
    {
        public AC_FRAGMENT_Configuration()
        {
            ToTable("_AC_FRAGMENT", _EntityBase.SchemaName);

            HasKey(k => k.id);
            Property(p => p.id).HasColumnName("ID").IsRequired();
            Property(p => p.name).HasColumnName("NAME").IsRequired().HasMaxLength(50);
            Property(p => p.fname).HasColumnName("FNAME").IsRequired();
            Property(p => p.prefix).HasColumnName("PREFIX").IsOptional();
            Property(p => p.code).HasColumnName(ИмяКолонки.CODE).IsOptional();

            /*HasMany(e => e.ВХОДИТ_В_СЕРВИСЫ)
                .WithRequired(e => e.AC_FRAGMENT)
                .HasForeignKey(e => e.id_ac_fragment)
                .WillCascadeOnDelete(false);*/
        }
    }
}
