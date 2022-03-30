using System.Collections.Generic;
using QWERTY.Shared.Models.Заявки.Заявка_на_создание_профиля_доступа_на_ресурс;

namespace QWERTY.Shared.Db.Entities.Таблицы
{
    /// <summary>
    /// Имена профилей
    /// </summary>
    public class PROFILE : Id
    {
        /*public PROFILE()
        {
            MEMBERS = new HashSet<MEMBER>();
            RIGHT = new HashSet<RIGHT>();
        }*/

        public PROFILE(ДанныеИзФормы_СозданиеПрофиляДоступа_модель _)
        {
            this.name = _.ProfileName!;
            id_request_1 = 0;
            ид_заявки_на_удаление = null;   
        }

        public PROFILE()
        {
        }

        public override int id { get; set; }

        /// имя профиля        
        public string? name { get; set; }
        public sealed override int id_request_1 { get; set; }
        public int? ид_заявки_на_удаление { get; set; }

        /*public virtual ICollection<RIGHT> RIGHT { get; set; }
        public virtual ICollection<MEMBER> MEMBERS { get; set; }
        public virtual REQUEST ЗАЯВКА_НА_СОЗДАНИЕ { get; set; }
        public virtual REQUEST ЗАЯВКА_НА_УДАЛЕНИЕ { get; set; }*/
    }
}
