using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using QWERTY.Shared.Enums;
using QWERTY.Shared.Models.Валидатор.Пользовательская_валидация;

namespace QWERTY.Shared.Models.Заявки.Заявка_на_создание_профиля_доступа_на_ресурс
{
    public class ДанныеИзФормы_СозданиеПрофиляДоступа_модель : ДанныеИзФормы
    {
        /// <summary>
        /// Имя профиля
        /// </summary>
        [Required]
        [MinLength(Annotation.ProfileName.MinLength)]
        [MaxLength(Annotation.ProfileName.MaxLength)]
        public string? ProfileName { get; set; }
        
        
        /// <summary>
        /// Ид главного (родительского) объекта ресурса [OBJECT], к которому будут добавляться другие объекты (дочерние)
        /// </summary>
        [Required]
        [Range(Standard.Range.Min1_MaxValue.Min,
        Standard.Range.Min1_MaxValue.Max)]
        public int? ResourceObjectId { get; set; }
        
        /// <summary>
        /// добавляемые в профиль объекты
        /// </summary>
        [Required]
        [MinLength(1)]
        public ProfileObject?[]? ProfileObjects { get; set; }
        
        [Required]
        [CustomValidation(typeof(MyValidation), nameof(MyValidation.ValidateComplexModel))]
        public sealed override RequestParams? request_params { get; set; }
        
        public override bool Валидна() 
            => 
                ПроверитьВалидностьОбъекта(this);
    }
}