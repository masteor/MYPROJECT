using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Shared.Db.Configuration.Таблицы
{
    public class  DIC_Configuration : EntityTypeConfiguration<DIC>
    {
        public DIC_Configuration()
        {
            ToTable("__DIC", _EntityBase.SchemaName);

            HasKey(e => e.id);
            Property(e => e.id).HasColumnName("ID").IsRequired();

            Property(e => e.eng).HasColumnName("ENG").IsRequired();
            Property(e => e.rus).HasColumnName("RUS").IsRequired();
        }
    }
}