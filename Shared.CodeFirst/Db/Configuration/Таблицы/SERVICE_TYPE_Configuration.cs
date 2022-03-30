using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Shared.Db.Configuration.Таблицы
{
    public class SERVICE_TYPE_Configuration : EntityTypeConfiguration<SERVICE_TYPE>
    {
        public SERVICE_TYPE_Configuration()
        {
            ToTable("_SERVICE_TYPE", _EntityBase.SchemaName);

            HasKey(e => e.id);
            Property(e => e.id).HasColumnName("ID").IsRequired();

            Property(e => e.название).HasColumnName("NAME").HasMaxLength(255).IsRequired();
            Property(e => e.префикс).HasColumnName("PREFIX").HasMaxLength(10).IsRequired();
            Property(e => e.разделитель).HasColumnName("DELIMITER").HasMaxLength(10).IsRequired();
            Property(e => e.обёртка).HasColumnName("WRAPPER").HasMaxLength(10).IsRequired();
            Property(e => e.уровень_вложенности).HasColumnName("NESTING_LEVEL").IsRequired();

            /*HasMany(e => e.ТИПЫ_ОБЪЕКТОВ)
                .WithRequired(e => e.SERVICE_TYPE)
                .HasForeignKey(e => e.id_service_type)
                .WillCascadeOnDelete(false);

            HasMany(e => e.СЕРВИСЫ)
                .WithRequired(e => e.SERVICE_TYPE)
                .HasForeignKey(e => e.id_service_type)
                .WillCascadeOnDelete(false);*/
        }
    }
}