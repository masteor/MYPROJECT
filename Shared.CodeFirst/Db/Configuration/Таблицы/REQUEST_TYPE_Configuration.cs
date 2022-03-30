using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Shared.Db.Configuration.Таблицы
{
    public class REQUEST_TYPE_Configuration : EntityTypeConfiguration<REQUEST_TYPE>
    {
        public REQUEST_TYPE_Configuration()
        {
            ToTable("_REQUEST_TYPE", _EntityBase.SchemaName);

            HasKey(e => e.id);
            Property(e => e.id).HasColumnName("ID").IsRequired();

            Property(e => e.name).HasColumnName("NAME").HasMaxLength(255).IsRequired();
            Property(e => e.sdescription).HasColumnName("SDESCRIPTION").HasMaxLength(255).IsRequired();
            Property(e => e.id_parent).HasColumnName("ID_PARENT").IsOptional();
            Property(e => e.maintenance).HasColumnName("MAINTENANCE").IsOptional();
            Property(e => e.code).HasColumnName("CODE").IsOptional();
            Property(e => e.templateName).HasColumnName("TEMPLATE_NAME").IsOptional();

            /*HasMany(e => e.REQUEST)
                .WithRequired(e => e.REQUEST_TYPE)
                .HasForeignKey(e => e.ид_типа_заявки)
                .WillCascadeOnDelete(false);*/

            /*HasMany(e => e.REQUEST_TYPE_1)
                .WithOptional(e => e.REQUEST_TYPE_2)
                .HasForeignKey(e => e.id_parent);*/

            /*HasMany(e => e.REQUEST_TYPE_STAFF)
                .WithRequired(e => e.REQUEST_TYPE)
                .HasForeignKey(e => e.id_request_type)
                .WillCascadeOnDelete(false);*/
        }
    }
}