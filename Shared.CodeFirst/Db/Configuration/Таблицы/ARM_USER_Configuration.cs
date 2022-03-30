using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Shared.Db.Configuration.Таблицы
{
    public class ARM_USER_Configuration : EntityTypeConfiguration<ARM_USER>
    {
        public ARM_USER_Configuration()
        {
            ToTable("_ARM_USER", _EntityBase.SchemaName);

            HasKey(e => e.id);
            Property(e => e.id).HasColumnName("ID").IsRequired();
            
            Property(e => e.ид_сотрудника).HasColumnName("ID_USER").IsRequired();
            Property(e => e.ид_арма).HasColumnName("ID_ARM").IsRequired();
            Property(e => e.ид_роли_сотрудника).HasColumnName("ID_ROLE").IsRequired();
            Property(e => e.ид_заявки_разрешения_допуска).HasColumnName("ID_REQUEST_1").IsRequired();
            Property(e => e.ид_заявки_прекращения_доступа).HasColumnName("ID_REQUEST_2").IsOptional();
        }
    }
}