using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Shared.Db.Configuration.Таблицы
{
    public class PROFILE_Configuration : EntityTypeConfiguration<PROFILE>
    {
        public PROFILE_Configuration()
        {
            ToTable("_PROFILE", _EntityBase.SchemaName);

            HasKey(e => e.id);
            Property(e => e.id).HasColumnName("ID").IsRequired();

            Property(e => e.name).HasColumnName("NAME").HasMaxLength(100).IsRequired();
            Property(e => e.id_request_1).HasColumnName("ID_REQUEST_1").IsRequired();
            Property(e => e.ид_заявки_на_удаление).HasColumnName("ID_REQUEST_2").IsOptional();

            /*HasMany(e => e.MEMBERS)
                .WithRequired(e => e.PROFILE)
                .HasForeignKey(e => e.id_profile)
                .WillCascadeOnDelete(false);

            HasMany(e => e.RIGHT)
                .WithRequired(e => e.PROFILE)
                .HasForeignKey(e => e.id_profile)
                .WillCascadeOnDelete(false);*/
        }
    }
}