using System;
using System.ComponentModel.DataAnnotations;
using QWERTY.Shared.Enums;
using QWERTY.Shared.Models.Валидатор.Пользовательская_валидация;
using QWERTY.Shared.Models.Заявки.Заявка_на_создание_защищаемого_ресурса;

namespace QWERTY.Shared.Models.Заявки
{
    public sealed class ДанныеИзФормы_СозданиеЗащищаемогоРесурсаЗЛИВС_модель 
        : 
            ПереченьСубъектовДоступа,
            IДанныеИзФормы_СозданиеЗащищаемогоРесурса_модель
    {
        [Required]
        [CustomValidation(typeof(MyValidation), nameof(MyValidation.ValidateComplexModel))]
        public override RequestParams? request_params { get; set; }
        
        [Range
        (Standard.Range.Min1_MaxValue.Min,
         Standard.Range.Min1_MaxValue.Max)]
        public int? ParentObjectId { get; set; }
        
        [Range
        (Standard.Range.Min1_MaxValue.Min,
         Standard.Range.Min1_MaxValue.Max)]
        public int? NewId { get; set; }

        [MinLength(Annotation.path.MinLength)]
        [MaxLength(Annotation.path.MaxLength)]
        public string? path { get; set; }
        
        [MinLength(Annotation.description.MinLength)]
        [MaxLength(Annotation.description.MaxLength)]
        public string? description { get; set; }

        [Required]
        [Range 
        (Standard.Range.Min1_MaxValue.Min,
        Standard.Range.Min1_MaxValue.Max)]
        public int? ObjectTypeId { get; set; }
        
        [Range 
        (Standard.Range.Min1_MaxValue.Min,
            Standard.Range.Min1_MaxValue.Max)]
        public int? ObjectId { get; set; }

        [Required]
        [Range (Standard.Range.Min1_MaxValue.Min,
             Standard.Range.Min1_MaxValue.Max)]
        public int? FragmentId { get; set; }

        [Required,
         Range (Standard.Range.Min1_MaxValue.Min,
             Standard.Range.Min1_MaxValue.Max)]
        public int? ServiceTypeId { get; set; }


        [Required]
        [MinLength(Annotation.ObjectName.MinLength),
         MaxLength(Annotation.ObjectName.MaxLength)]
        public string? ObjectName { get; set; }

        [Required,
         Range (Standard.Range.Min1_MaxValue.Min,
             Standard.Range.Min1_MaxValue.Max)]
        public int? SecretTypeId { get; set; }

        [Required]
        [Range
        (Standard.Range.Min1_MaxValue.Min,
        Standard.Range.Min1_MaxValue.Max)]
        public int? ResponsibleId { get; set; }

        [Required,
         Range (Standard.Range.Min1_MaxValue.Min,
             Standard.Range.Min1_MaxValue.Max)]
        public int? OwnerId { get; set; }

        [Required]
        [CustomValidation(typeof(MyValidation), nameof(MyValidation.NotRequiredArrayOfIdsValidate))]
        public int?[]? UserIds { get; set; }

        [Required]
        [CustomValidation(typeof(MyValidation), nameof(MyValidation.NotRequiredArrayOfIdsValidate))]
        public int?[]? OrgIds { get; set; }
        
        public override bool Валидна() 
            => ПроверитьВалидностьОбъекта(this);

        public ДанныеИзФормы_СозданиеЗащищаемогоРесурсаЗЛИВС_модель()
        {
            
        }
    }
}