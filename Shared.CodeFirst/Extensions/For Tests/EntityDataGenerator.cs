using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using QWERTY.Shared.Helpers;

namespace QWERTY.Shared.Extensions.For_Tests
{
    public interface IEntityDataGenerator
    {
        List<DateTime?> УбратьДубликаты(List<DateTime?> list);
        public List<DateTime?> УбратьВсеНуллевые(List<DateTime?> list);
        List<ОбъектПроверки> СгенерироватьВалидныеИНеВалидныеДанные(TimeSpan смещениеВремениДляГенерацииДатыОтчета,
            DateTime?[] dateCreateArr1,
            DateTime?[] dateCreateArr2,
            DateTime?[] dateEndArr1,
            DateTime?[] dateEndArr2,
            int?[] statusArr1,
            int?[] statusArr2);
        
        List<DateTime?> ПолучитьДатуБольшеМеньшеРавно(DateTime? dt, TimeSpan? sp);
        List<DateTime?> ПолучитьДатыОтчётовБезДубликатов(DateTime?[] dates, TimeSpan? sp);
        ОбъектПроверки НеСуществует(ОбъектПроверки o);
        DateTime? УменьшитьДатуНаСмещение(DateTime? dt, TimeSpan? смещениеВремени);
        DateTime? УвеличитьДатуНаСмещение(DateTime? dt, TimeSpan? sp);
    }
    
    public class EntityDataGenerator : IEntityDataGenerator
    {
        private readonly ILinqHelpers _linqHelpers;
        
        public EntityDataGenerator()
        {
            _linqHelpers = new LinqHelpers();
        }

        /// <summary>
        /// только генерация валидных и не валидных данных, без фильтров и прочих проверок
        /// </summary>
        /// <returns></returns>
        public List<ОбъектПроверки> СгенерироватьВалидныеИНеВалидныеДанные
        (
            TimeSpan смещениеВремениДляГенерацииДатыОтчета, 
            DateTime?[] dateCreateArr1, 
            DateTime?[] dateCreateArr2,
            DateTime?[] dateEndArr1,
            DateTime?[] dateEndArr2,
            int?[] statusArr1,
            int?[] statusArr2
        ) 
            => 
        (
            from st2 in statusArr2.AsParallel()
            from st1 in statusArr1.AsParallel()
            from date1 in dateCreateArr1.AsParallel()
            from date2 in dateCreateArr2.AsParallel()
            from date3 in dateEndArr1.AsParallel()
            from date4 in dateEndArr2.AsParallel()
            from oneOfDate in new[] {date1, date2, date3, date4}.AsParallel()
            from dt in ПолучитьДатуБольшеМеньшеРавно(oneOfDate, смещениеВремениДляГенерацииДатыОтчета).AsParallel()
            where dt != null
                select new ОбъектПроверки
                {
                    create_date_1 = date1,
                    create_date_2 = date2,
                    end_date_1 = date3,
                    end_date_2 = date4,
                    create_request_state = st1,
                    end_request_state = st2,
                    Результат = false,
                    ДатаОтчета = dt
                }
        )
        .ToList();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="sp"></param>
        /// <returns></returns>
        public List<DateTime?> ПолучитьДатуБольшеМеньшеРавно(DateTime? dt, TimeSpan? sp) =>
            sp == null || sp == TimeSpan.Zero || dt == null
                ? new List<DateTime?> {dt}
                : УбратьВсеНуллевые(new List<DateTime?>
                {
                    УменьшитьДатуНаСмещение(dt, sp),
                    dt,
                    УвеличитьДатуНаСмещение(dt, sp)
                });

        public List<DateTime?> ПолучитьДатыОтчётовБезДубликатов(DateTime?[] dates, TimeSpan? sp)
        {
            if (dates == null) return null;
            var list = new List<DateTime?>();
            foreach (var date in dates.Where(d => d != null))
            {
                list.AddRange(ПолучитьДатуБольшеМеньшеРавно(date, sp));
            }

            return УбратьДубликаты(list);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public List<DateTime?> УбратьДубликаты(List<DateTime?> list) => 
            new List<DateTime?>(list.Distinct(new СравнитьДаты()));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public List<DateTime?> УбратьВсеНуллевые(List<DateTime?> list) => 
            list.FindAll(x => x != null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="sp"></param>
        /// <returns></returns>
        public DateTime? УменьшитьДатуНаСмещение(DateTime? dt, TimeSpan? sp)
        {
            // универсальная предпроверка
            if (dt == null) return null;
            if (sp == null) return dt;
            // если sp меньше тика, тогда не надо выполнять операцию
            if (sp.Value.Ticks < new TimeSpan(0).Ticks) return dt;
            if (sp.Value.Ticks > DateTime.MaxValue.Ticks) return DateTime.MaxValue;

            return dt.Value.Ticks - sp.Value.Ticks <= DateTime.MinValue.Ticks
                ? DateTime.MinValue
                : dt.Value.Subtract((TimeSpan) sp); 
        }
        
        
        public DateTime? УвеличитьДатуНаСмещение(DateTime? dt, TimeSpan? sp)
        {
            // универсальная предпроверка
            if (dt == null) return null;
            if (sp == null) return dt;
            // если sp меньше тика, тогда не надо выполнять операцию
            if (sp.Value.Ticks < new TimeSpan(0).Ticks) return dt;
            if (sp.Value.Ticks > DateTime.MaxValue.Ticks) return DateTime.MaxValue;
        
            // dt != null
            // смещениеВремени != null

            return dt.Value.Ticks + sp.Value.Ticks >= DateTime.MaxValue.Ticks
                ? DateTime.MaxValue
                : dt.Value.Add((TimeSpan) sp);
        }
        

        /// <summary>
        /// определяет несуществующие объекты
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public ОбъектПроверки НеСуществует(ОбъектПроверки o)
        {
            IEnumerable<EntityClass> entityClasses = new []
            {
                new EntityClass (o)
            };

            var list = _linqHelpers.СуществуетНаДату(entityClasses, o.ДатаОтчета).ToList();
            var результатМетодаСуществуетНаДату = list.Count != 0;
            
            // по умолчанию считается, что объект изначально существует
            o.Результат = false;

            if (o.end_date_1 <= o.end_date_2
                && o.end_date_2 <= o.ДатаОтчета
                && o.end_request_state == 4)
            {
                o.Результат = true;
                if (результатМетодаСуществуетНаДату == o.Результат)
                {
                    Debug.WriteLine($"Ошибка перехвачена");
                }
            }
            
            // объект не создан
            if (o.create_request_state != 4 || o.create_request_state == null)
            {
                o.Результат = true;
                
                if (результатМетодаСуществуетНаДату == o.Результат)
                {
                    Debug.WriteLine($"Ошибка перехвачена");
                }
            }

            // создание объекта не завершено
            if (o.create_date_1 <= o.ДатаОтчета
                && 
                (o.create_date_2 == null || o.ДатаОтчета < o.create_date_2))
            {
                o.Результат = true;
                
                if (результатМетодаСуществуетНаДату == o.Результат)
                {
                    Debug.WriteLine($"Ошибка перехвачена");
                }
            }
            
            // создание объекта не начиналось
            if (o.ДатаОтчета < o.create_date_1)
            {
                o.Результат = true;
                
                if (результатМетодаСуществуетНаДату == o.Результат)
                {
                    Debug.WriteLine($"Ошибка перехвачена");
                }
            }

            return o;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ОбъектПроверки : EntityClass
    {
        public DateTime? ДатаОтчета;
        public bool Результат;

        public ОбъектПроверки()
        {

        }
    }

    /// <summary>
    /// Сравнивает только не нуллевые значения, для нуллевых всегда возвращает ложь
    /// </summary>
    public class СравнитьДаты : IEqualityComparer<DateTime?>
    {
        public bool Equals(DateTime? date1, DateTime? date2) 
            => 
            date1 == date2;

        public int GetHashCode(DateTime? dateTime)
        {
            return dateTime.GetHashCode();
        }
    }
}