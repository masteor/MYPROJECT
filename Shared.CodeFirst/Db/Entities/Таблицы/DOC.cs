using System;
using System.Collections.Generic;

namespace QWERTY.Shared.Db.Entities.Таблицы
{
    /// <summary>
    /// Таблица электронных документов
    /// </summary>
    public class DOC : Id
    {
        private int _idDocType;
        private byte[] _contents;
        private DateTime _date1;
        private string _docRegNum;

        public DOC()
        {
            // DOC_CHILD = new HashSet<DOC>();
            // REQUEST = new HashSet<REQUEST>();
        }

        public override int id { get; set; }
        public int id_doc_type { get; set; }
        public string path { get; set; }

        /*public byte[] CONTENTS
        {
            get => ThrowExceptionIfNullOrEmpty(_contents);
            set => _contents = ThrowExceptionIfNullOrEmpty(value);
        }*/
        
        public DateTime date_1 { get; set; }
        public int? state { get; set; }
        public string doc_reg_num { get; set; }

        /// <summary>
        /// дата подписания документа
        /// </summary>
        public DateTime? doc_reg_date { get; set; }
        public int? id_parent { get; set; }
        public override int id_request_1 { get; set; }
        public int? ид_заявки_на_удаление { get; set; }

        // public virtual DOC DOC_PARENT { get; set; }
        
        // public virtual DOC_TYPE DOC_TYPE { get; set; }
        
        // public virtual ICollection<DOC> DOC_CHILD { get; set; }
        // public virtual ICollection<REQUEST> REQUEST { get; set; }
    }
}
