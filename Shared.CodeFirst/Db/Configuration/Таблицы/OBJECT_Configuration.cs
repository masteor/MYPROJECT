using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Shared.Db.Configuration.Таблицы
{
    public class OBJECT_Configuration : EntityTypeConfiguration<OBJECT>
    {
        public OBJECT_Configuration()
        {
            ToTable("_OBJECT", _EntityBase.SchemaName);

            HasKey(e => new {e.id});
            Property(e => e.id).HasColumnName("ID").IsRequired();

            Property(e => e.name).HasColumnName("NAME").HasMaxLength(255).IsRequired();
            Property(e => e.id_parent_object).HasColumnName("ID_PARENT_OBJECT").IsOptional();
            Property(e => e.id_object_type).HasColumnName("ID_OBJECT_TYPE").IsRequired();
            Property(e => e.id_request_1).HasColumnName("ID_REQUEST_1").IsRequired();
            Property(e => e.ид_заявки_на_удаление).HasColumnName("ID_REQUEST_2").IsOptional();

            /*HasMany(e => e.ПРАВА)
                .WithRequired(e => e.OBJECT)
                .HasForeignKey(e => e.id_object)
                .WillCascadeOnDelete(false);
            
            HasMany(e => e.ОБЪЕКТЫ)
                .WithOptional(e => e.РОДИТЕЛЬСКИЙ_ОБЪЕКТ)
                .HasForeignKey(e => e.id_parent_object);

            HasMany(e => e.РЕСУРСЫ)
                .WithRequired(e => e.ОБЪЕКТ)
                .HasForeignKey(e => e.ид_объекта)
                .WillCascadeOnDelete(false);*/

        }
    }
}