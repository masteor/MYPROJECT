
 // Таблицы или Представления
 // Таблицы или Представления







/* ---------------------------------------------------------------------------------------------------
*    ЭТО АВТОМАТИЧЕСКИ ГЕНЕРИРУЕМЫЙ ФАЙЛ
*    НЕ РЕДАКТИРУЙТЕ ЕГО - ВСЕ ИЗМЕНЕНИЯ БУДУТ УДАЛЕНЫ
*
*    РЕЗУЛЬТАТ СОХРАНИТЬ ЗДЕСЬ: \Db\Configuration\Представления\VIEW_MEMBER_ORG_Configuration.cs
* ---------------------------------------------------------------------------------------------------*/
using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities;
using QWERTY.Shared.Db.Entities.Представления;

namespace QWERTY.Shared.Db.Configuration.Представления
{
    public class VIEW_MEMBER_ORG_Configuration : EntityTypeConfiguration<VIEW_MEMBER_ORG>
    {
        public VIEW_MEMBER_ORG_Configuration()
        {
            ToTable(ИмяТаблицы.VIEW_MEMBER_ORG, _EntityBase.SchemaName);

            HasKey(e => new {e.id});

            Property(e => e.id).HasColumnName(ИмяКолонки.ID).IsRequired();
            Property(e => e.id_member).HasColumnName(ИмяКолонки.ID_MEMBER).IsRequired();
            Property(e => e.id_profile).HasColumnName(ИмяКолонки.ID_PROFILE).IsRequired();
            Property(e => e.id_user).HasColumnName(ИмяКолонки.ID_USER).IsRequired();
            Property(e => e.id_org).HasColumnName(ИмяКолонки.ID_ORG).IsRequired();
            Property(e => e.org_fname).HasColumnName(ИмяКолонки.ORG_FNAME).IsRequired();
        }
    }
}
