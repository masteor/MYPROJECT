using System.ComponentModel.DataAnnotations;
using QWERTY.Shared.Enums;
using QWERTY.Shared.Models.Валидатор.Пользовательская_валидация;

namespace QWERTY.Shared.Models.Заявки.Заявка_на_создание_профиля_доступа_на_ресурс
{
    public class ProfileObject : Валидатор.Валидатор
    {
        /// <summary>
        /// id объекта в структуре объектов 
        /// </summary>
        [Required]
        [Range(Standard.Range.Min1_MaxValue.Min,
            Standard.Range.Min1_MaxValue.Max)]
        public int? id { get; set; }

        /// <summary>
        /// используется при разборе дерева на стороне веб-приложения
        /// </summary>
        public int? iddb { get; set; } = null;

        /// <summary>
        /// id родительского объекта в структуре объектов 
        /// </summary>
        [Range(Standard.Range.Min1_MaxValue.Min,
            Standard.Range.Min1_MaxValue.Max)]
        public int? parent { get; set; }
        
        /// <summary>
        /// Имя объекта, добавляемого в профиль
        /// </summary>
        [Required]
        [MinLength(Annotation.ObjectName.MinLength)]
        [MaxLength(Annotation.ObjectName.MaxLength)]
        public string? ObjectName { get; set; }
        
        /// <summary>
        /// Ид типа объекта, добавляемого в профиль
        /// </summary>
        [Required]
        [Range(Standard.Range.Min1_MaxValue.Min,
            Standard.Range.Min1_MaxValue.Max)]
        public int? ObjectTypeId { get; set; }
        
        /// <summary>
        /// Права, назначаемые на объект профиля
        /// </summary>
        [Required]
        [CustomValidation(typeof(MyValidation), nameof(MyValidation.ArrayOfIdsValidate))]
        public int?[]? RightDescriptions { get; set; }

        public override bool Валидна() 
            => 
                ПроверитьВалидностьОбъекта(new object?[] {this});
    }
}