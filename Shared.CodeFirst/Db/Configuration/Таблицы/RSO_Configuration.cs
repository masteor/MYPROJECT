using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Shared.Db.Configuration.Таблицы
{
    public class RSO_Configuration : EntityTypeConfiguration<RSO>
    {
        public RSO_Configuration()
        {
            ToTable("_RSO", _EntityBase.SchemaName);

            HasKey(e => e.id);
            Property(e => e.id).HasColumnName("ID").IsRequired();

            Property(e => e.id_user).HasColumnName("ID_USER").IsRequired();
            Property(e => e.comment).HasColumnName("COMMENT").HasMaxLength(255).IsRequired();
        }
    }
}