using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Shared.Db.Configuration.Таблицы
{
    public class STAFF_Configuration : EntityTypeConfiguration<STAFF>
    {
        public STAFF_Configuration()
        {
            ToTable("_STAFF", _EntityBase.SchemaName);

            HasKey(e => e.id);
            Property(e => e.id).HasColumnName("ID").IsRequired();

            Property(e => e.name).HasColumnName("NAME").IsRequired().HasMaxLength(255);
            Property(e => e.role).HasColumnName("ROLE").IsRequired().HasMaxLength(50);
            Property(e => e.id_new).HasColumnName("ID_NEW").IsOptional();
            Property(e => e.id_request_1).HasColumnName("ID_REQUEST_1").IsRequired();
            Property(e => e.id_request_2).HasColumnName("ID_REQUEST_2").IsOptional();

            /*HasMany(e => e.REQUEST_TYPE_STAFF)
                .WithRequired(e => e.STAFF)
                .HasForeignKey(e => e.id_staff)
                .WillCascadeOnDelete(false);
            
            HasMany(e => e.STAFF_1)
                .WithOptional(e => e.STAFF2)
                .HasForeignKey(e => e.id_new);

            HasMany(e => e.STAFF_UNIT)
                .WithRequired(e => e.STAFF)
                .HasForeignKey(e => e.id_staff)
                .WillCascadeOnDelete(false);*/
        }
    }
}