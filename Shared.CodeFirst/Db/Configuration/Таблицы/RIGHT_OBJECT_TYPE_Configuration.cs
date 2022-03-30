using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Shared.Db.Configuration.Таблицы
{
    public class RIGHT_OBJECT_TYPE_Configuration : EntityTypeConfiguration<RIGHT_OBJECT_TYPE>
    {
        public RIGHT_OBJECT_TYPE_Configuration()
        {
            ToTable("_RIGHT_OBJECT_TYPE", _EntityBase.SchemaName);

            HasKey(e => e.id);

            Property(e => e.id).HasColumnName("ID").IsRequired();
            Property(e => e.id_object_type).HasColumnName("ID_OBJECT_TYPE").IsRequired();
            Property(e => e.id_right_descr).HasColumnName("ID_RIGHT_DESCR").IsRequired();
        }
    }
}