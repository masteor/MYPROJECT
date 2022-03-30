using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities;
using QWERTY.Shared.Db.Entities.Представления;

namespace QWERTY.Shared.Db.Configuration.Представления
{
    public class VIEW_AC_ACCESS_ORG_Configuration : EntityTypeConfiguration<VIEW_AC_ACCESS_ORG>
    {
        public VIEW_AC_ACCESS_ORG_Configuration()
        {
            ToTable(ИмяТаблицы.ViewAcAccessOrg, _EntityBase.SchemaName);

            HasKey(e => new {e.id_ac_access});

            Property(e => e.id_ac_access).HasColumnName("ID_AC_ACCESS").IsRequired();
            Property(e => e.id_request_1).HasColumnName("ID_REQUEST_1").IsRequired();
            Property(e => e.request_1_date_2).HasColumnName("REQUEST_1_DATE_2").IsOptional();
            Property(e => e.id_request_2).HasColumnName("ID_REQUEST_2").IsOptional();
            Property(e => e.request_2_date_2).HasColumnName("REQUEST_2_DATE_2").IsOptional();
            Property(e => e.tnum).HasColumnName("TNUM").IsRequired();
            Property(e => e.id_org).HasColumnName("ID_ORG").IsRequired();
            Property(e => e.org_fname).HasColumnName("ORG_FNAME").IsRequired();
            Property(e => e.id_org_parent).HasColumnName("ID_ORG_PARENT").IsRequired();
            Property(e => e.id_org_unit_type).HasColumnName("ID_ORG_UNIT_TYPE").IsRequired();
            Property(e => e.org_unit_type_name).HasColumnName("ORG_UNIT_TYPE_NAME").IsRequired();
            Property(e => e.name_1).HasColumnName("NAME_1").IsRequired();
            Property(e => e.name_2).HasColumnName("NAME_2").IsRequired();
            Property(e => e.name_3).HasColumnName("NAME_3").IsRequired();
        }
    }
}

