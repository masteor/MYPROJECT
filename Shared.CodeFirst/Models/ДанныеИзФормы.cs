using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using QWERTY.Shared.Models.Валидатор.Пользовательская_валидация;

namespace QWERTY.Shared.Models
{
    public class ДанныеИзФормы : Валидатор.Валидатор
    {
        public virtual int? id { get; set; }
        
        /// <summary>
        /// параметры, необходимые для создания заявки
        /// </summary>
        [Required]
        [CustomValidation(typeof(MyValidation), nameof(MyValidation.ValidateComplexModel))]
        public virtual RequestParams? request_params { get; set; }

        private bool ДатаВалидна(DateTime? dateTime) => 
                dateTime != null 
            && (dateTime >= new DateTime(2000, 1, 1)
            && dateTime <= DateTime.Now);

        protected bool ДатаНЕвалидна(DateTime? dateTime) => !ДатаВалидна(dateTime);
        
        protected static string Print(object? s) => s != null ? s.ToString() : "null";


        public ДанныеИзФормы()
        {
        }

        public override bool Валидна() 
            => 
                ПроверитьВалидностьОбъекта(this);
    }
}