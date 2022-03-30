using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Shared.Db.Configuration.Таблицы
{
    public class AC_ACCESS_Configuration : EntityTypeConfiguration<AC_ACCESS>
    {
        public AC_ACCESS_Configuration()
        {
            ToTable("_AC_ACCESS", _EntityBase.SchemaName);

            HasKey(e => e.id);
            Property(e => e.id).HasColumnName("ID").IsRequired();

            Property(e => e.ид_пользователя).HasColumnName("ID_USER").IsRequired();
            Property(e => e.ид_заявки_разрешения_допуска).HasColumnName("ID_REQUEST_1").IsOptional();
            Property(e => e.ид_заявки_прекращения_допуска).HasColumnName("ID_REQUEST_2").IsOptional();
            Property(e => e.номер_приказа_о_допуске).HasColumnName("ORDER_NUMBER").IsOptional();
        }
    }
}