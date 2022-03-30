using System;
using System.ComponentModel.DataAnnotations;
using QWERTY.Shared.Enums;

namespace QWERTY.Shared.Models.Сущности
{
    public class ДанныеИзФормы_СозданияЛогина_модель : ДанныеИзФормы
    {
        [Required,
         Range(
             Standard.Range.Min1_MaxValue.Min,
             Standard.Range.Min1_MaxValue.Max)]
        public int? id_user { get; set; }
        
        [Required,
         MinLength(Annotation.login_name.MinLength),
         MaxLength(Annotation.login_name.MaxLength)]
        public string? login_name { get; set; }
        
        [Required,
         MinLength(Annotation.email.MinLength),
         MaxLength(Annotation.email.MaxLength), 
         EmailAddress]
        public string? email { get; set; }

        public bool? is_active { get; set; }

        [Required,
         Range(
             Standard.Range.Min1_MaxValue.Min,
             Standard.Range.Min1_MaxValue.Max)]
        public int? id_domen { get; set; }
        
        [Required]
        public override RequestParams? request_params { get; set; }


        public ДанныеИзФормы_СозданияЛогина_модель()
        {
            throw new NotImplementedException();
        }

        public ДанныеИзФормы_СозданияЛогина_модель(ДанныеИзФормы_СозданияЛогина_модель м)
        {
            throw new NotImplementedException();
            email = м.email;
            id_domen = м.id_domen;
            login_name = м.login_name;
        }
    }
}