using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities;
using QWERTY.Shared.Db.Entities.Системные_таблицы;

namespace QWERTY.Shared.Db.Configuration.Системные_таблицы
{
    public class ATTRI_Configuration : EntityTypeConfiguration<ATTRI>
    {
        public ATTRI_Configuration()
        {
            ToTable(ИмяТаблицы.ATTRI, _EntityBase.SchemaName);

            HasKey(e => new {e.S21, e.S22});

            Property(e => e.S21).HasColumnName("$$$S21").IsRequired();
            Property(e => e.S22).HasColumnName("$$$S22").IsRequired();
            Property(e => e.S23).HasColumnName("$$$S23").IsRequired();
        }
    }
}
