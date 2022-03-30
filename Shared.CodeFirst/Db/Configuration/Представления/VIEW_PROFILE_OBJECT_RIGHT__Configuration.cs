using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities;
using QWERTY.Shared.Db.Entities.Представления;

namespace QWERTY.Shared.Db.Configuration.Представления
{
    public class VIEW_PROFILE_OBJECT_RIGHT_Configuration : EntityTypeConfiguration<VIEW_PROFILE_OBJECT_RIGHT>
    {
        public VIEW_PROFILE_OBJECT_RIGHT_Configuration()
        {
            ToTable(ИмяТаблицы.VIEW_PROFILE_OBJECT_RIGHT, _EntityBase.SchemaName);

            HasKey(e => new {e.id_right});

            Property(e => e.id_right).HasColumnName(ИмяКолонки.ID_RIGHT).IsRequired();
            Property(e => e.id_profile).HasColumnName(ИмяКолонки.ID_PROFILE).IsRequired();
            Property(e => e.profile_name).HasColumnName(ИмяКолонки.PROFILE_NAME).IsRequired();
            Property(e => e.id_object).HasColumnName(ИмяКолонки.ID_OBJECT).IsRequired();
            Property(e => e.id_parent_object).HasColumnName(ИмяКолонки.ID_PARENT_OBJECT).IsRequired();
            Property(e => e.object_name).HasColumnName(ИмяКолонки.OBJECT_NAME).IsRequired();
            Property(e => e.object_type_name).HasColumnName(ИмяКолонки.OBJECT_TYPE_NAME).IsRequired();
            Property(e => e.id_right_descr).HasColumnName(ИмяКолонки.ID_RIGHT_DESCR).IsRequired();
            Property(e => e.description).HasColumnName(ИмяКолонки.DESCRIPTION).IsRequired();

            Property(e => e.id_user_owner).HasColumnName(ИмяКолонки.ID_USER_OWNER).IsRequired();
            Property(e => e.id_user_responsible).HasColumnName(ИмяКолонки.ID_USER_RESPONSIBLE).IsRequired();
            Property(e => e.id_user_recipient).HasColumnName(ИмяКолонки.ID_USER_RECIPIENT).IsRequired();
            
        }
    }
}
