using System.ComponentModel.DataAnnotations;
using QWERTY.Shared.Enums;
using QWERTY.Shared.Models.Валидатор.Пользовательская_валидация;

namespace QWERTY.Shared.Models.Заявки.Заявка_на_предоставление_доступа_к_защищаемым_ресурсам
{
    public class ДанныеИзФормы_ПредоставлениеДоступаСубъектам_модель : ПереченьСубъектовДоступа
    {
        [Required]
        [Range
        (Standard.Range.Min1_MaxValue.Min,
            Standard.Range.Min1_MaxValue.Max)]
        public int? ProfileId { get; set; }

        [Required]
        [CustomValidation(typeof(MyValidation), nameof(MyValidation.ValidateComplexModel))]
        public override RequestParams? request_params { get; set; }
        
        [CustomValidation(typeof(MyValidation), nameof(MyValidation.NotRequiredArrayOfIdsValidate))]
        public int?[]? UserIds { get; set; }
        
        [CustomValidation(typeof(MyValidation), nameof(MyValidation.NotRequiredArrayOfIdsValidate))]
        public int?[]? OrgIds { get; set; }

        public override bool Валидна()
            =>
                ПроверитьВалидностьОбъекта(this);


    }
}