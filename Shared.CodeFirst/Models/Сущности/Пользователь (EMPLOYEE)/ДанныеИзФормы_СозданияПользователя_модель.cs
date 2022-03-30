using System;
using System.ComponentModel.DataAnnotations;
using QWERTY.Shared.Enums;
using static QWERTY.Shared.Enums.Standard.Range;
using static QWERTY.Shared.Enums.Standard.Length;

namespace QWERTY.Shared.Models.Сущности
{
    public class ДанныеИзФормы_СозданияПользователя_модель : ДанныеИзФормы  
    {
        [Required,
         MinLength(Min2_Max100.MinLength),
         MaxLength(Min2_Max100.MaxLength)]
        public string? family { get; set; }
        

        [Required,
         MinLength(Min2_Max100.MinLength),
         MaxLength(Min2_Max100.MaxLength)]
        public string? name { get; set; }
        
        
        [Required,
         MinLength(Min2_Max100.MinLength),
         MaxLength(Min2_Max100.MaxLength)]
        public string? patronymic { get; set; }
        
        [Required,
         MinLength(Min2_Max20.MinLength),
         MaxLength(Min2_Max20.MaxLength)]
        public string? login_name { get; set; }
        
        
        [Required, 
         MinLength(Annotation.email.MinLength),
         MaxLength(Annotation.email.MaxLength),
         EmailAddress]
        public string? email { get; set; }

        public bool? is_active { get; set; }


        [Required,
         Range
         (Min1_MaxValue.Min,
             Annotation.tnum.Max)]
        public int? tnum { get; set; }


        [Required,
        Range
            (Min1_MaxValue.Min,
            Min1_MaxValue.Max)]
        public int? id_job { get; set; }
        
        [Required,
         Range
            (Min1_MaxValue.Min,
             Min1_MaxValue.Max)]
        public int? id_form_perm { get; set; }

        [Required,
         Range
        (Min1_MaxValue.Min,
            Min1_MaxValue.Max)]
        public int? id_domen { get; set; }
        
        public int? id_fio { get; set; }

        public int? id_login { get; set; }
        public int? id_user { get; set; }
        
        
        [Required]
        public DateTime? job_begin_date { get; set; }
        
        [Required]
        public override RequestParams? request_params { get; set; }


        public ДанныеИзФормы_СозданияПользователя_модель()
        {
            
        }
    }
}