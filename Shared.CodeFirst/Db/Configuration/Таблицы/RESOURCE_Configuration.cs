using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Shared.Db.Configuration.Таблицы
{
    public class RESOURCE_Configuration : EntityTypeConfiguration<RESOURCE>
    {
        public RESOURCE_Configuration()
        {
            ToTable("_RESOURCE", _EntityBase.SchemaName);

            HasKey(e => e.id);
            Property(e => e.id).HasColumnName("ID").IsRequired();

            Property(e => e.id_service).HasColumnName("ID_SERVICE").IsOptional();
            Property(e => e.id_service_type).HasColumnName("ID_SERVICE_TYPE").IsRequired();
            Property(e => e.id_ac_fragment).HasColumnName("ID_AC_FRAGMENT").IsRequired();
            Property(e => e.id_object).HasColumnName("ID_OBJECT").IsRequired();
            Property(e => e.path).HasColumnName("PATH").IsMaxLength().IsOptional();
            Property(e => e.description).HasColumnName("DESCRIPTION").IsMaxLength().IsOptional();
            Property(e => e.id_secret_type).HasColumnName("ID_SECRET_TYPE").IsRequired();
            Property(e => e.id_user_owner).HasColumnName("ID_USER_OWNER").IsRequired();
            Property(e => e.id_user_responsible).HasColumnName("ID_USER_RESPONSIBLE").IsRequired();
            Property(e => e.id_new).HasColumnName("ID_NEW").IsOptional();
            Property(e => e.id_request_1).HasColumnName("ID_REQUEST_1").IsRequired();
            Property(e => e.id_request_2).HasColumnName("ID_REQUEST_2").IsOptional();

            /*HasMany(e => e.ПУНКТЫ_ПЕРЕЧНЕЙ)
                .WithRequired(e => e.RESOURCE)
                .HasForeignKey(e => e.id_resource)
                .WillCascadeOnDelete(false);
            
            HasMany(e => e.ИСТОРИЯ_РЕСУРСА)
                .WithOptional(e => e.АКТУАЛЬНЫЙ)
                .HasForeignKey(e => e.ид_актуального);

            HasMany(e => e.РЕСУРСЫ_С_СУБЪЕКТАМИ_ДОСТУПА_ПОЛНАЯ)
                .WithRequired(e => e.РЕСУРС)
                .HasForeignKey(e => e.id_resource);

            HasMany(e => e.VIEW_RESOURCE_USER_RIGHTS)
                .WithOptional(e => e.РЕСУРС)
                .HasForeignKey(e => e.id_resource);*/
        }
    }
}