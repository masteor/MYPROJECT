using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Shared.Db.Configuration.Таблицы
{
    public class RIGHT_DESCRIPTION_Configuration : EntityTypeConfiguration<RIGHT_DESCR>
    {
        public RIGHT_DESCRIPTION_Configuration()
        {
            ToTable("_RIGHT_DESCR", _EntityBase.SchemaName);

            HasKey(e => e.id);
            Property(e => e.id).HasColumnName("ID").IsRequired();

            Property(e => e.description).HasColumnName("DESCRIPTION").IsRequired().HasMaxLength(50);
            Property(e => e.type).HasColumnName("TYPE").IsOptional();
            Property(e => e.id_service_type).HasColumnName("ID_SERVICE_TYPE").IsRequired();

            /*HasMany(e => e.ГРУППЫ_ПРАВ)
                .WithOptional(e => e.ГРУППА)
                .HasForeignKey(e => e.id_group);

            HasMany(e => e.ПРАВА)
                .WithOptional(e => e.ЭЛЕМ_ПРАВО)
                .HasForeignKey(e => e.id_right);

            HasMany(e => e.ПРАВА_ТИПОВ_ОБЪЕКТОВ)
                .WithRequired(e => e.ГРУППА_ПРАВ)
                .HasForeignKey(e => e.id_right_descr);

            HasMany(e => e.RIGHTS)
                .WithRequired(e => e.RIGHT_DESCR)
                .HasForeignKey(e => e.id_right_descr);*/
        }
    }
}