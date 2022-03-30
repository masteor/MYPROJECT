using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Shared.Db.Configuration.Таблицы
{
    public class SECRET_TYPE_Configuration : EntityTypeConfiguration<SECRET_TYPE>
    {
        public SECRET_TYPE_Configuration()
        {
            ToTable("_SECRET_TYPE", _EntityBase.SchemaName);

            HasKey(e => e.id);
            Property(e => e.id).HasColumnName("ID").IsRequired();

            Property(e => e.name).HasColumnName("NAME").IsRequired().HasMaxLength(50);
            Property(e => e.code).HasColumnName(ИмяКолонки.CODE).IsOptional();

            /*HasMany(e => e.RESOURCE)
                .WithRequired(e => e.ТИП_СЕКРЕТНОСТИ)
                .HasForeignKey(e => e.ид_типа_секретности)
                .WillCascadeOnDelete(false);*/
        }
    }
}