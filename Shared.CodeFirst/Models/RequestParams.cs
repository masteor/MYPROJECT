using System;
using System.ComponentModel.DataAnnotations;
using QWERTY.Shared.Extensions;
using static QWERTY.Shared.Enums.Annotation;
using static QWERTY.Shared.Models.Валидатор.Валидатор;

namespace QWERTY.Shared.Models
{
    public class RequestParams : Валидатор.Валидатор
    {
        public DateTime? create_date_time { get; set; }
        
        public DateTime? end_date_time { get; set; }
        
        [Required]
        [MinLength(login_name.MinLength),
         MaxLength(login_name.MaxLength)]
        public string? sender_login { get; set; }
        
        [MinLength(login_name.MinLength),
         MaxLength(login_name.MaxLength)]
        public string? recipient_login { get; set; }
        
        // public string? request_state_name { get; set; }
        public int? request_state_id { get; set; }
        
        public byte?[]? doc { get; set; }
        
        public string? reg_number { get; set; }

        public int? parent { get; set; }


        public RequestParams()
        {
            
        }

        public RequestParams(string? senderLogin) : this()
        {
            sender_login = senderLogin;
        }

        public RequestParams(RequestParams? _) : this()
        {
            if (_.IsNull()) return;
            
            create_date_time = _!.create_date_time;
            doc = _.doc;
            end_date_time = _.end_date_time;
            parent = _.parent;
            recipient_login = _.recipient_login;
            reg_number = _.reg_number;
            request_state_id = _.request_state_id;
            sender_login = _.sender_login;
        }

        public override bool Валидна() 
            => 
                ПроверитьВалидностьОбъекта(this);
    }
}