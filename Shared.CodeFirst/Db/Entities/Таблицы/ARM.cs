using System.Collections.Generic;

namespace QWERTY.Shared.Db.Entities.Таблицы
{
    /// <summary>
    /// Список армов в данном фрагменте
    /// </summary>
    public class ARM : _EntityBase
    {
        private string _regNumArm;
        private string _regNumLogbook;
        private int _idRequest1;

        /*public ARM()
        {
            СТАРЫЕ_АРМЫ = new HashSet<ARM>();
            УСТРОЙСТВА = new HashSet<ARM_DEVICE>();
            ДОПУСКИ_СОТРУДНИКОВ = new HashSet<ARM_USER>();
        }*/

        public int id { get; set; }
        public string рег_номер_арма { get; set; }
        public string рег_номер_формуляра
        {
            get => _regNumLogbook;
            set => _regNumLogbook = value;
            /*get => ThrowExceptionIfNullOrEmpty(_regNumLogbook);
            set => _regNumLogbook = ThrowExceptionIfNullOrEmpty(value, true);*/
        }
        
        public int? ид_помещения { get; set; }
        public int? ид_актуальной_записи { get; set; }
        public int? ид_заявки_постановки_на_учёт { get; set; }
        /// <summary>
        /// ид заявки снятия с учета
        /// </summary>
        public int? ид_заявки_снятия_с_учёта { get; set; }
        
        /*public virtual ARM АКТУАЛЬНЫЙ { get; set; }
        public virtual ROOM ПОМЕЩЕНИЕ_В_КОТОРОМ_НАХОДИТСЯ { get; set; }
        public virtual REQUEST ЗАЯВКА_ПОСТАНОВКИ_НА_УЧЁТ { get; set; }
        public virtual REQUEST ЗАЯВКА_СНЯТИЯ_С_УЧЁТА { get; set; }*/

        /*public virtual ICollection<ARM> СТАРЫЕ_АРМЫ { get; set; }
        public virtual ICollection<ARM_DEVICE> УСТРОЙСТВА { get; set; }
        public virtual ICollection<ARM_USER> ДОПУСКИ_СОТРУДНИКОВ { get; set; }*/

    }
}
