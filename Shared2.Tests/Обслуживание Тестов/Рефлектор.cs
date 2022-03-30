using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using QWERTY.Shared.Models;

namespace QWERTY.Shared2.Tests.Обслуживание_Тестов
{
    public class Рефлектор
    {
        public static IEnumerable<PropertyInfo> ПолучитьВсеСвойства<T>(T? модель) where T : class
        {
            if (модель == null) yield break;

            Type type = модель.GetType();
            var properties = type.GetProperties
            (
                BindingFlags.Public
                | BindingFlags.Instance
                | BindingFlags.GetField
                | BindingFlags.GetProperty
                | BindingFlags.DeclaredOnly
            );
            
            foreach (var propertyInfo in properties)
                yield return propertyInfo;
        }

        public static IEnumerable<T> ПолучитьМоделиСИзмененнымСвойством<T>(T модель) where T : class, new()
        {
            var получитьВсеСвойства = ПолучитьВсеСвойства(модель);
            foreach (var свойство in получитьВсеСвойства)
            foreach (var значение in ПолучитьНеВалидныеЗначенияОтТипаСвойства(свойство.PropertyType))
            {
                // todo: метод работает не до конца верно, нужно, чтобы исходная модель не менялась
                // todo: т.е. необходимо создать копию модели и только её менять
                // todo: также необходимо выяснить почему для модели типа RequestParams не меняется свойство recipient_login
                
                // если свойство НЕ имеет атрибута [Требуется] ([Required]) и оно может быть null, 
                // тогда значение null в этом свойстве будет делать всю модель Валидной, несмотря на то, что в модель подсовываются невалидные значения, поэтому,
                // для таких свойств надо пропускать значения null, потому что это валидное (разрешенное) для них значение
                // если свойство не имеет атрибута Required - просто пропускаем такое значение
                if (свойство.GetCustomAttributes(true).Any()
                    &&
                    !свойство.GetCustomAttributes<System.ComponentModel.DataAnnotations.RequiredAttribute>()
                        .Any()) continue;

                свойство.SetValue(модель, значение);
                yield return (модель);
            }
        }
        
        
        public static IEnumerable<RequestParams> ПолучитьМоделиСИзмененнымСвойством(RequestParams модель)
        {
            foreach (var свойство in ПолучитьВсеСвойства(модель))
            {
                if (свойство.PropertyType == typeof(System.Exception)) continue;
                foreach (var значение in ПолучитьНеВалидныеЗначенияОтТипаСвойства(свойство.PropertyType))
                {
                    if (свойство.GetCustomAttributes(true).Any()
                        &&
                        !свойство.GetCustomAttributes<System.ComponentModel.DataAnnotations.RequiredAttribute>()
                            .Any()) continue;
                
                    свойство.SetValue(модель, значение);
                    yield return new RequestParams(модель);
                }
            }
        }

        public static ICollection? ПолучитьНеВалидныеЗначенияОтТипаСвойства(Type type) 
        {
            if (type == typeof(int?)) return НеВалидные.неВалидныеЦелые_Nullable;

            if (type == typeof(int)) return НеВалидные.неВалидныеЦелые_NotNullable;

            if (type == typeof(string)) return НеВалидные.неВалидныеСтроки_Nullable;
            
            if (type == typeof(DateTime)) return НеВалидные.неВалидныеДаты_NotNullable;
            
            if (type == typeof(DateTime?)) return НеВалидные.неВалидныеДаты_Nullable;
            
            if (type == typeof(byte?[])) return НеВалидные.неВалидныеМассивыСоДанными_Nullable;

            if (type == typeof(System.Exception)) return null;

            throw new NotImplementedException("Обработка данного типа не реализована");
        }
    }
}