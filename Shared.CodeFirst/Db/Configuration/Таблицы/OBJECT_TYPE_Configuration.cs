using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Shared.Db.Configuration.Таблицы
{
    public class OBJECT_TYPE_Configuration : EntityTypeConfiguration<OBJECT_TYPE>
    {
        public OBJECT_TYPE_Configuration()
        {
            ToTable("_OBJECT_TYPE", _EntityBase.SchemaName);

            HasKey(e => e.id);
            Property(e => e.id).HasColumnName("ID").IsRequired();

            Property(e => e.name).HasColumnName("NAME").HasMaxLength(50).IsRequired();
            Property(e => e.id_service_type).HasColumnName("ID_SERVICE_TYPE").IsRequired();
            Property(e => e.main_object).HasColumnName("MAIN_OBJECT").IsOptional();
            Property(e => e.code).HasColumnName(ИмяКолонки.CODE).IsRequired();
            Property(e => e.icon).HasColumnName(ИмяКолонки.ICON).IsRequired();

            /*HasMany(e => e.OBJECT)
                 .WithRequired(e => e.ТИП_ОБЪЕКТА)
                 .HasForeignKey(e => e.id_object_type)
                 .WillCascadeOnDelete(false);

            HasMany(e => e.ПРАВА_ТИПОВ_ОБЪЕКТОВ)
                .WithRequired(e => e.ТИП_ОБЪЕКТА)
                .HasForeignKey(e => e.id_object_type)
                .WillCascadeOnDelete(false);
            
            HasMany(e => e.VIEW_OBJECT_USER_RIGHTS_DISTINCTED)
                .WithRequired(e => e.ТИП_ОБЪЕКТА)
                .HasForeignKey(e => e.id_object_type)
                .WillCascadeOnDelete(false);*/
        }
    }
}