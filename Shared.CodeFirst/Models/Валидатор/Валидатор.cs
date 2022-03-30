using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using QWERTY.Shared.Extensions;

namespace QWERTY.Shared.Models.Валидатор
{
    public abstract class Валидатор
    {
        private  Exception? _exception = null;
        public  Exception? получитьИсключение => _exception;

        private readonly List<ValidationResult> Results = new List<ValidationResult>();
        
        public IEnumerable<ValidationResult> ПолучитьРезультатыВалидации() => Results;

        internal  bool ПроверитьВалидностьОбъекта(object? childsThis)
        {
            try
            {
                if (childsThis is null)
                {
                    Console.WriteLine("childsThis is null");
                    throw new ArgumentNullException(nameof(childsThis));
                }

                if (ВалиднаDataAnnotation(childsThis)) return true;
                
                Console.WriteLine(ПолучитьРезультатыВалидации().First().ErrorMessage);
                throw new ArgumentNullException($"{ПолучитьРезультатыВалидации().First().ErrorMessage}");

                return true;
            }
            catch (Exception e)
            {
                _exception = e;                
                return false;
            }
        }

        private  bool ВалиднаDataAnnotation(object instance) => 
            Validator.TryValidateObject (
                instance,
                new ValidationContext(instance),
                Results,
                true
            );

        public abstract bool Валидна();
    }
}