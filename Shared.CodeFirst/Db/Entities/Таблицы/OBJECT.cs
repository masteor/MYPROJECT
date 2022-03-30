using System.Collections.Generic;
using QWERTY.Shared.Models.Заявки.Заявка_на_создание_защищаемого_ресурса;
using QWERTY.Shared.Models.Заявки.Заявка_на_создание_профиля_доступа_на_ресурс;

namespace QWERTY.Shared.Db.Entities.Таблицы
{
    /// <summary>
    /// Объекты
    /// </summary>
    public class OBJECT : Id
    {
        public OBJECT()
        {
            
        }
        /// <summary>
        /// 
        /// </summary>
        /*public OBJECT()
        {
            ОБЪЕКТЫ = new HashSet<OBJECT>();
            РЕСУРСЫ = new HashSet<RESOURCE>();
            ПРАВА = new HashSet<RIGHT>();
        }*/

        public OBJECT(IДанныеИзФормы_СозданиеЗащищаемогоРесурса_модель _) 
        {
            name = _.ObjectName!;
            id_parent_object = _.ParentObjectId;
            id_object_type = (int) _.ObjectTypeId!;
            id_request_1 = 0;
            ид_заявки_на_удаление = null;
        }

        public OBJECT(ДанныеИзФормы_СозданиеПрофиляДоступа_модель _, ProfileObject o, int идРодителя)
        {
            name = o.ObjectName!;
            id_parent_object = идРодителя;
            id_object_type = (int) o.ObjectTypeId!;
            id_request_1 = 0;
            ид_заявки_на_удаление = null;
        }

        /// <summary>
        /// 
        /// </summary>
        public override int id { get; set; } = 0;

        public string name { get; set; } = "";
        public int? id_parent_object { get; set; }
        public int id_object_type { get; set; }
        public sealed override int id_request_1 { get; set; } = 0;
        public int? ид_заявки_на_удаление { get; set; }

        /*public virtual OBJECT? РОДИТЕЛЬСКИЙ_ОБЪЕКТ { get; set; }
        public virtual OBJECT_TYPE? ТИП_ОБЪЕКТА { get; set; }
        
        public virtual REQUEST? ЗАЯВКА_НА_СОЗДАНИЕ { get; set; }
        public virtual REQUEST? ЗАЯВКА_УДАЛЕНИЯ_ОБЪЕКТА { get; set; }
        public virtual ICollection<RESOURCE>? РЕСУРСЫ { get; set; }
        public virtual ICollection<OBJECT>? ОБЪЕКТЫ { get; set; }
        public virtual ICollection<RIGHT>? ПРАВА { get; set; }*/
    }
}
