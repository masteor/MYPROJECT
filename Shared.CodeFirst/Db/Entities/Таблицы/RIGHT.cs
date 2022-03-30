using System;

namespace QWERTY.Shared.Db.Entities.Таблицы
{
    /// <summary>
    /// Связь профилей, объектов и прав на них
    /// </summary>
    public class RIGHT : Id
    {
        public RIGHT()
        {
            
        }
        
        public override int id { get; set; }
        public int id_profile { get; set; }
        public int id_object { get; set; }
        public int id_right_descr { get; set; }
        public override int id_request_1 { get; set; }
        public int? id_request_2 { get; set; }
        public DateTime? created_date_time { get; set; }

        
        /*public virtual OBJECT OBJECT { get; set; }
        public virtual PROFILE PROFILE { get; set; }
        public virtual REQUEST ЗАЯВКА_НА_СОЗДАНИЕ { get; set; }
        // public virtual REQUEST REQUEST_0 { get; set; }
        public virtual REQUEST REQUEST_1 { get; set; }
        public virtual RIGHT_DESCR RIGHT_DESCR { get; set; }*/
        
        
        public RIGHT(int idObject, int idProfile, int idRightDescr)
        {
            id_profile = idProfile;
            id_object = idObject;
            id_right_descr = idRightDescr;
        }

        /*public RIGHT(OBJECT o, PROFILE profile, REQUEST заявкаНаСоздание, REQUEST request1, RIGHT_DESCR rightDescr)
        {
            OBJECT = o;
            PROFILE = profile;
            ЗАЯВКА_НА_СОЗДАНИЕ = заявкаНаСоздание;
            REQUEST_1 = request1;
            RIGHT_DESCR = rightDescr;
        }*/
    }
}
