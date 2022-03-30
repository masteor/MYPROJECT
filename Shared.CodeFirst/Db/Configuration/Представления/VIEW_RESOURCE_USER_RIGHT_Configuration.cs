using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities;
using QWERTY.Shared.Db.Entities.Представления;

namespace QWERTY.Shared.Db.Configuration.Представления
{
    public class VIEW_RESOURCE_USER_RIGHT_Configuration : EntityTypeConfiguration<VIEW_RESOURCE_USER_RIGHT>
    {
        public VIEW_RESOURCE_USER_RIGHT_Configuration()
        {
            ToTable(ИмяТаблицы.VIEW_RESOURCE_USER_RIGHT, _EntityBase.SchemaName);

            HasKey(e => new {e.id_object} );
            
            Property(e => e.id_object).HasColumnName("ID_OBJECT").IsRequired();
            Property(e => e.id_resource).HasColumnName("ID_RESOURCE").IsOptional();
            Property(e => e.имя_объекта).HasColumnName("OBJECT_NAME").IsRequired();
        }
    }
}