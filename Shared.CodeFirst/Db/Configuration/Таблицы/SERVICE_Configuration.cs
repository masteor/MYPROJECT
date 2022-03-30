using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Shared.Db.Configuration.Таблицы
{
    public class SERVICE_Configuration : EntityTypeConfiguration<SERVICE>
    {
        public SERVICE_Configuration()
        {
            ToTable("_SERVICE", _EntityBase.SchemaName);

            HasKey(e => e.id);
            Property(e => e.id).HasColumnName("ID").IsRequired();

            Property(e => e.net_name).HasColumnName("NET_NAME").IsRequired().HasMaxLength(50);
            Property(e => e.server_type).HasColumnName("SERVER_TYPE").IsRequired().HasMaxLength(50);
            Property(e => e.description).HasColumnName("DESCRIPTION").IsRequired().HasMaxLength(255);
            Property(e => e.id_service_type).HasColumnName("ID_SERVICE_TYPE").IsRequired();
            Property(e => e.id_ac_fragment).HasColumnName("ID_AC_FRAGMENT").IsRequired();
            Property(e => e.id_new).HasColumnName("ID_NEW").IsOptional();
            Property(e => e.id_request_1).HasColumnName("ID_REQUEST_1").IsRequired();
            Property(e => e.id_request_2).HasColumnName("ID_REQUEST_2").IsOptional();

            /*HasMany(e => e.RESOURCE)
                .WithOptional(e => e.СЕРВИС)
                .HasForeignKey(e => e.ид_сервиса);

            HasMany(e => e.SERVICE_1)
                .WithOptional(e => e.SERVICE2)
                .HasForeignKey(e => e.id_new);*/
        }
    }
}