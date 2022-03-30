using System.Collections.Generic;
using QWERTY.Shared.Db.Entities.Представления;
using QWERTY.Shared.Models.Заявки.Заявка_на_создание_защищаемого_ресурса;

namespace QWERTY.Shared.Db.Entities.Таблицы
{
    /// <summary>
    /// Ресурс
    /// </summary>
    public class RESOURCE : Id
    {
        public RESOURCE()
        {
            
        }
        /*public RESOURCE()
        {
            ПУНКТЫ_ПЕРЕЧНЕЙ = new HashSet<RESOURCE_UCA>();
            ИСТОРИЯ_РЕСУРСА = new HashSet<RESOURCE>();
            РЕСУРСЫ_С_СУБЪЕКТАМИ_ДОСТУПА_ПОЛНАЯ = new HashSet<VIEW_OBJECT_USER_RIGHTS_DISTINCTED>();
            VIEW_RESOURCE_USER_RIGHTS = new HashSet<VIEW_RESOURCE_USER_RIGHT>();
        }*/

        public RESOURCE(IДанныеИзФормы_СозданиеЗащищаемогоРесурса_модель _, int объектРесурсаId)
        {
            id_service = null;
            id_service_type = (int) _.ServiceTypeId!;
            id_ac_fragment = (int) _.FragmentId!;
            id_object = объектРесурсаId;
            this.path = _.path;
            this.description = _.description;
            id_secret_type = (int) _.SecretTypeId!;
            id_user_owner = (int) _.OwnerId!;
            id_user_responsible = (int) _.ResponsibleId!;
            id_new = _.NewId;
            id_request_1 = 0;
            id_request_2 = null;
        }

        public override int id { get; set; } = 0;
        public int? id_service { get; set; }
        public int id_service_type { get; set; } = 0;
        
        // ид_фрагмента
        public int id_ac_fragment { get; set; } = 0;
        
        // ид_объекта
        public int id_object { get; set; }
        
        // 
        public string? path { get; set; }
        public string? description { get; set; }
        
        // ид_типа_секретности
        public int id_secret_type { get; set; }
        
        // ид_владельца
        public int id_user_owner { get; set; }
        
        // ид_ответственного
        public int id_user_responsible { get; set; }
        
        // ид_актуального
        public int? id_new { get; set; }
        
        // ид_заявки_на_создание
        public sealed override int id_request_1 { get; set; }
        
        // ид_заявки_на_удаление
        public int? id_request_2 { get; set; }


        /*public virtual SECRET_TYPE? ТИП_СЕКРЕТНОСТИ { get; set; }
        public virtual RESOURCE? АКТУАЛЬНЫЙ { get; set; }
        public virtual EMPLOYEE? ВЛАДЕЛЕЦ { get; set; }
        public virtual EMPLOYEE? ОТВЕТСТВЕННЫЙ { get; set; }
        public virtual OBJECT? ОБЪЕКТ { get; set; }
        public virtual REQUEST? ЗАЯВКА_НА_СОЗДАНИЕ { get; set; }
        public virtual REQUEST? ЗАЯВКА_НА_УДАЛЕНИЕ { get; set; }
        public virtual SERVICE? СЕРВИС { get; set; }
        
        public virtual ICollection<RESOURCE_UCA>? ПУНКТЫ_ПЕРЕЧНЕЙ { get; set; }
        public virtual ICollection<RESOURCE>? ИСТОРИЯ_РЕСУРСА { get; set; }
        public virtual ICollection<VIEW_OBJECT_USER_RIGHTS_DISTINCTED>? РЕСУРСЫ_С_СУБЪЕКТАМИ_ДОСТУПА_ПОЛНАЯ { get; set; } 
        public virtual ICollection<VIEW_RESOURCE_USER_RIGHT>? VIEW_RESOURCE_USER_RIGHTS { get; }*/
    }
}
