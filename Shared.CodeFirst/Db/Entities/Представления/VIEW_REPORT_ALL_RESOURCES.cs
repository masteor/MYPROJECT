using System;
using QWERTY.Shared.Атрибуты;

namespace QWERTY.Shared.Db.Entities.Представления
{
    public class VIEW_REPORT_ALL_RESOURCES : Requested, IEMPLOYEE_RESPONSIBLE_OWNER
    {
        // это счетчик строк таблицы (rownum AS "ID")
        public int id { get; set; } = 0;
        
        public int id_resource { get; set; } = 0;

        // имя ресурса
        public string resource_name { get; set; } = "";

        // название типа ресурса 
        public string object_type_name { get; set; } = "";

        [DataTableColumn("Тип сервиса")] public string service_type_name { get; set; } = "";

        [DataTableColumn("Имя сервиса")] public string service_name { get; set; } = "";

        [DataTableColumn("Фрагмент")] public string frag_name { get; set; } = "";

        public int id_frag { get; set; } = 0;

        [DataTableColumn("Путь")] public string path { get; set; } = "";

        [DataTableColumn("Описание")] public string description { get; set; } = "";

        [DataTableColumn("Тип секретности")] 
        public string secret_type_name { get; set; } = "";

        // полное фио владельца ресурса
        public string owner { get; set; } = "";
        
        // короткое имя владельца ресурса
        public string owner_short_name { get; set; } = "";
        
        // структурная единица, где работает владелец р.
        public string owner_org_fname { get; set; } = "";
        
        // должность владельца р.         
        public string owner_job_name { get; set; } = "";
        
        // полное фио ответственного за р.
        public string responsible { get; set; } = "";
        
        // короткое фио ответственного за р.
        public string responsible_short_name { get; set; } = "";
        
        // структурная единица, где работает ответственный за р.
        public string responsible_org_fname { get; set; } = "";
        
        // должность ответственного за р.
        public string responsible_job_name { get; set;} = "";
        

        // public string org_fname { get; set; }

        // код заявки на создание
        public string id_request_type_code_1 { get; set; } = "";
        
        // код заявки на удаление
        public string id_request_type_code_2 { get; set; } = "";

        // ид заявки на создание
        public int? id_request_1 { get; set; } = 0;
        
        // ид заявки на удаление
        public int? id_request_2 { get; set; } = 0;
        public int? id_request_1_parent { get; set; } = 0;
        public int? id_request_2_parent { get; set; } = 0;

        [DataTableColumn("Рег.номер заявки")] public string reg_num { get; set; } = "";

        public override DateTime? create_date_1 { get; set; }
        public override DateTime? create_date_2 { get; set; }
        public override int? create_request_state { get; set; }
        public string? create_request_state_name { get; set; }
        public override DateTime? end_date_1 { get; set; }
        public override DateTime? end_date_2 { get; set; }
        public override int? end_request_state { get; set; }
        public string? end_request_state_name { get; set; }
        
        // public string? login_responsible { get; set; }
        // public string? login_owner { get; set; }

        public int id_user_owner { get; set; } = 0;
        public int id_user_responsible { get; set; } = 0;
    }
}
