
 






/* ---------------------------------------------------------------------------------------------------
*    ЭТО АВТОМАТИЧЕСКИ ГЕНЕРИРУЕМЫЙ ФАЙЛ
*    НЕ РЕДАКТИРУЙТЕ ЕГО - ВСЕ ИЗМЕНЕНИЯ БУДУТ УДАЛЕНЫ
*
*    РЕЗУЛЬТАТ СОХРАНИТЬ ЗДЕСЬ: \Db\Configuration\Системные таблицы\SYSRL_Configuration.cs
* ---------------------------------------------------------------------------------------------------*/
using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities;
using QWERTY.Shared.Db.Entities.Системные_таблицы;

namespace QWERTY.Shared.Db.Configuration.Системные_таблицы
{
    public class SYSRL_Configuration : EntityTypeConfiguration<SYSRL>
    {
        public SYSRL_Configuration()
        {
            ToTable(ИмяТаблицы.SYSRL, _EntityBase.SchemaName);

            HasKey(e => new {e.S11});

            Property(e => e.S11).HasColumnName("$$$S11").IsRequired();
            Property(e => e.S13).HasColumnName("$$$S13").IsRequired();
        }
    }
}
