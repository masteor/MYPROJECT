using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using QWERTY.Shared.Extensions;

namespace QWERTY.Shared.Models.Валидатор.Пользовательская_валидация
{
    public class MyValidation
    {
        public static ValidationResult ArrayOfIdsValidate(int?[]? intArray)
        {
            if (intArray is null) 
                return new ValidationResult("массив не может быть null");

            if (intArray.Length < 1)
                return new ValidationResult("в массиве должно быть хотя бы одно число");

            if (intArray.Any(i => i is null))
                return new ValidationResult("массив не может иметь null значения");
            
            if (intArray.Any(i => i < 1))
                return new ValidationResult("значения не могут быть меньше 1");

            return ValidationResult.Success;
        }
        
        
        public static ValidationResult NotRequiredArrayOfIdsValidate(int?[]? intArray)
        {
            // if (intArray is null) return new ValidationResult("массив не может быть null, он должен быть хотя бы пустой []");

            /*if (intArray.Length < 1)
                return new ValidationResult("в массиве должно быть хотя бы одно число");*/

            if ((intArray ?? Array.Empty<int?>()).Any(i => i is null))
                return new ValidationResult("массив не может иметь null значения");
            
            if ((intArray ?? Array.Empty<int?>()).Any(i => i < 1))
                return new ValidationResult("значения не могут быть меньше 1");

            return ValidationResult.Success;
        }
        

        public static ValidationResult ValidateComplexModel(RequestParams t)
        {
            if (t.Валидна()) return ValidationResult.Success;
            
            Console.WriteLine($@"Валидация не пройдена: {t.ПолучитьРезультатыВалидации().First()}");
            return t.ПолучитьРезультатыВалидации().First();

        }
    }
}