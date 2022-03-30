using System;
using DBPSA.Shared.Атрибуты;

namespace DBPSA.Shared.Db.Entities.Представления
{
    public class VIEW_REPORT_ALL_RESOURCES_FROM_PRD : Requested
    {
        [DataTableColumn("№")]
        public int id { get; set; }
        
        [DataTableColumn("Имя")]
        public string resource_name { get; set; }

        [DataTableColumn("Тип сервиса")]
        public string service_type_name { get; set; }

        [DataTableColumn("Имя сервиса")]
        public string service_name { get; set;}

        [DataTableColumn("Фрагмент")]
        public string frag_name { get; set;}

        [DataTableColumn("Путь")]
        public string path { get; set;}

        [DataTableColumn("Описание")]
        public string description { get; set;}

        [DataTableColumn("Тип секретности")]
        public string secret_type_name { get; set;}

        [DataTableColumn("Владелец")]
        public string owner { get; set;}

        [DataTableColumn("Ответственный")]
        public string responsible { get; set;}
        
        [DataTableColumn("Рег.номер заявки")]
        public string reg_num { get; set; }

        public override DateTime? create_date_1 { get; set; }
        public override DateTime? create_date_2 { get; set; }
        public override int? create_request_state { get; set; }
        public override DateTime? end_date_1 { get; set; }
        public override DateTime? end_date_2 { get; set; }
        public override int? end_request_state { get; set; }
    }
}
