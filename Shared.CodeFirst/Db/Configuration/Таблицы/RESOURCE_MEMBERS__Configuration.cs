using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Shared.Db.Configuration.Таблицы
{
    public class RESOURCE_MEMBERS_Configuration : EntityTypeConfiguration<RESOURCE_MEMBER>
    {
        public RESOURCE_MEMBERS_Configuration()
        {
            ToTable(ИмяТаблицы.RESOURCE_MEMBERS, _EntityBase.SchemaName);

            HasKey(e => new {e.id});
            Property(e => e.id).HasColumnName(ИмяКолонки.ID).IsRequired();
            
            Property(e => e.id_resource).HasColumnName(ИмяКолонки.ID_RESOURCE).IsRequired();
            // Property(e => e.id_login).HasColumnName(ИмяКолонки.ID_LOGIN).IsOptional();
            Property(e => e.id_user).HasColumnName(ИмяКолонки.ID_USER).IsOptional();
            Property(e => e.id_org).HasColumnName(ИмяКолонки.ID_ORG).IsOptional();
            Property(e => e.id_request_1).HasColumnName(ИмяКолонки.ID_REQUEST_1).IsRequired();
            Property(e => e.id_request_2).HasColumnName(ИмяКолонки.ID_REQUEST_2).IsOptional();
        }
    }
}
