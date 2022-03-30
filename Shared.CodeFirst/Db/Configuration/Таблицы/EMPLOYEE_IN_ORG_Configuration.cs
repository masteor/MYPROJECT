using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Shared.Db.Configuration.Таблицы
{
    public class EMPLOYEE_IN_ORG_Configuration : EntityTypeConfiguration<EMPLOYEE_IN_ORG>
    {
        public EMPLOYEE_IN_ORG_Configuration()
        {
            ToTable("_EMPLOYEE_IN_ORG", _EntityBase.SchemaName);

            HasKey(e => new {e.id});
            Property(e => e.id).HasColumnName("ID").IsRequired();
            
            Property(e => e.id_user).HasColumnName("ID_USER").IsRequired();
            Property(e => e.id_org).HasColumnName("ID_ORG").IsRequired();
            Property(e => e.id_request_1).HasColumnName("ID_REQUEST_1").IsOptional();
            Property(e => e.id_request_2).HasColumnName("ID_REQUEST_2").IsOptional();
        }
    }
}