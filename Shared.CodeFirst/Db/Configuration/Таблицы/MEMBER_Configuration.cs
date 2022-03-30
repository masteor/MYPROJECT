using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Shared.Db.Configuration.Таблицы
{
    public class MEMBER_Configuration : EntityTypeConfiguration<MEMBER>
    {
        public MEMBER_Configuration()
        {
            ToTable("_MEMBER", _EntityBase.SchemaName);

            HasKey(e => e.id);
            Property(e => e.id).HasColumnName("ID").IsRequired();
            
            Property(e => e.id_profile).HasColumnName("ID_PROFILE").IsRequired();
            Property(e => e.id_user).HasColumnName(ИмяКолонки.ID_USER).IsOptional();
            Property(e => e.id_org).HasColumnName("ID_ORG").IsOptional();
            Property(e => e.id_request_1).HasColumnName("ID_REQUEST_1").IsRequired();
            Property(e => e.ид_заявки_прекращения_доступа).HasColumnName("ID_REQUEST_2").IsOptional();
        }
    }
}