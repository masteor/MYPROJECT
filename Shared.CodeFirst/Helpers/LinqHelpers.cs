using System;
using System.Collections.Generic;
using System.Linq;
using QWERTY.Shared.Db;
using QWERTY.Shared.Enums;

namespace QWERTY.Shared.Helpers
{
    public interface ILinqHelpers
    {
        bool ПерваяДатаМеньшеВторой(DateTime? date1, DateTime? date2);
        Func<T, bool> ФильтрВалидныеДнф<T>() where T : Requested;
        Func<T, bool> ФильтрНеВалидныеДнф<T>() where T : Requested;
        IEnumerable<T>? СуществуетНаДату<T>(IEnumerable<T>? enumerable, DateTime? dateTime) where T : Requested;
        Func<T, bool> ФильтрСуществуетНаДату<T>(DateTime? dateTime) where T : Requested;
        Func<T, bool> ФильтрНеСуществуетНаДату<T>(DateTime? dateTime) where T : Requested;
    }
    
    public class LinqHelpers : ILinqHelpers
    {
        public LinqHelpers()
        {
            
        }

        /// <summary>
        /// Фильтр для выявления валидных объектов в классах, которые наследуются от Requested
        /// логика разработана с использованием дискретной математики на основе булевого вектора
        /// функции, с последующей минимизацией, если более подробно, то фильтр должен найти
        /// такие объекты, для которых верно 4 следующих состояния:
        /// 
        /// 1. create_request_state != null
        /// && create_date_1 != null - остальные равны нулл
        /// 
        /// 2. create_request_state != null
        /// && create_date_1 != null
        /// && create_date_2 != null - остальные равны нулл
        /// && create_date_1 <= create_date_2 
        ///
        /// 3. create_request_state != null
        /// && create_date_1 != null
        /// && create_date_2 != null
        /// && create_date_1 <= create_date_2
        /// && end_request_state != null
        /// && end_date_1 != null - остальные равны нулл
        /// && create_date_2 <= end_date_1 
        ///
        /// 4. create_request_state != null
        /// && create_date_1 != null
        /// && create_date_2 != null
        /// && create_date_1 <= create_date_2
        /// && end_request_state != null
        /// && end_date_1 != null
        /// && create_date_2 <= end_date_1
        /// && end_date_2 != null
        /// && end_date_1 <= end_date_2
        ///
        /// Ничего не понятно? Не берите в голову - главное что ОНО работает =)
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public Func<T, bool> ФильтрВалидныеДнф<T>() where T : Requested => r =>
        {
            var (x1, x2, x3, x4, x5, x6, x7, x8, x9) = ПодготовкаКоФильтрации(r);
            return
                x1 && x2 && x3 && x4 && x5 && x6 && x7 && x8 && x9 ||
                x1 && x2 && !x3 && x4 && x5 && x6 && x7 && x8 && !x9 ||
                x1 && !x2 && !x3 && x4 && x5 && x6 && !x7 && !x8 && !x9 ||
                !x1 && !x2 && !x3 && x4 && x5 && !x6 && !x7 && !x8 && !x9;
        };


        private (bool x1, bool x2, bool x3, bool x4, bool x5, bool x6, bool x7, bool x8, bool x9)
            ПодготовкаКоФильтрации<T>(T r) where T : Requested
        {
            var x1 = ПерваяДатаМеньшеВторой(r.create_date_1, r.create_date_2);
            var x2 = ПерваяДатаМеньшеВторой(r.create_date_2, r.end_date_1);
            var x3 = ПерваяДатаМеньшеВторой(r.end_date_1, r.end_date_2);
            var x4 = r.create_request_state != null && r.create_request_state > 0;
            var x5 = r.create_date_1 != null;
            var x6 = r.create_date_2 != null;
            var x7 = r.end_request_state != null && r.end_request_state > 0;
            var x8 = r.end_date_1 != null;
            var x9 = r.end_date_2 != null;
            return (x1, x2, x3, x4, x5, x6, x7, x8, x9);
        }

        public Func<T, bool> ФильтрНеВалидныеДнф<T>() where T : Requested => r =>
        {
            var (x1, x2, x3, x4, x5, x6, x7, x8, x9) = ПодготовкаКоФильтрации(r);
            return
                !x4 || !x5 || x1 && !x6 || !x1 && x2 || x2 && !x7 || x2 && !x8
                || !x2 && x3 || x3 && !x9 || !x1 && x6 || !x2 && x7 || !x2 && x8 || !x3 && x9;
        };

        public bool ПерваяДатаМеньшеВторой(DateTime? date1, DateTime? date2) 
            => 
                date1 <= date2;

        /// <summary>
        /// Проводит валидацию коллекции и, если есть дата, фильтрует элементы
        /// </summary>
        /// <param name="enumerable"></param>
        /// <param name="dateTime"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IEnumerable<T>? СуществуетНаДату<T>(IEnumerable<T>? enumerable, DateTime? dateTime) where T : Requested 
            =>
                dateTime switch
                {
                    // переходим к фильтрации
                    // если даты нет, т.е. равна нулл - тогда фильтрации нет, отдаем обратно список
                    null => (enumerable ?? Array.Empty<T>()).Where(ФильтрВалидныеДнф<T>()),  
                    _ => enumerable?
                        .Where(ФильтрВалидныеДнф<T>())
                        .Where(ФильтрСуществуетНаДату<T>(dateTime))
                };

        /// <summary>
        /// Фильтр выбирает объекты, которые существуют на определенную дату
        /// работает только с валидными объектами,
        /// поэтому, перед использованием этого фильтра
        /// надо использовать предфильтр-валидатор
        /// Func<T, bool> ФильтрВалидныеДнф<T>() where T : Requested
        /// </summary>
        /// <param name="dateTime"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public Func<T, bool> ФильтрСуществуетНаДату<T>(DateTime? dateTime) where T : Requested => r =>
        {
            var (x1, x2, x3, x4) = предподготовкаКоФильтруНаДату(dateTime, r);
            return x1 && (x2 || x4 || !x3);
        };
        
        public static Func<T, bool> ФильтрНаходятсяНаЭтапеСоздания<T>()
            where T : CreateRequestState => r 
            => 
            r.create_request_state == (int) ИдСтатусаЗаявки.Зарегистрирована
            || r.create_request_state == (int) ИдСтатусаЗаявки.Открыта
            || r.create_request_state == (int) ИдСтатусаЗаявки.Отложена;
        
        public static Func<T, bool> ФильтрВыполнены<T>()
            where T : CreateRequestState => r 
            => 
            r.create_request_state != (int) ИдСтатусаЗаявки.Зарегистрирована
            && r.create_request_state != (int) ИдСтатусаЗаявки.Открыта
            && r.create_request_state != (int) ИдСтатусаЗаявки.Отложена;
        

        private (bool x1, bool x2, bool x3, bool x4) предподготовкаКоФильтруНаДату<T>(DateTime? dateTime, T r)
            where T : Requested
        {
            var x1 = dateTime != null
                     && r.create_request_state == 4
                     && r.create_date_2 != null
                     && r.create_date_2 <= dateTime;

            var x2 = r.end_date_2 == null;
            var x3 = r.end_request_state == 4;
            var x4 = dateTime < r.end_date_2;
            return (x1, x2, x3, x4);
        }

        public Func<T, bool> ФильтрНеСуществуетНаДату<T>(DateTime? dateTime) where T : Requested => r =>
        {
            var (x1, x2, x3, x4) = предподготовкаКоФильтруНаДату(dateTime, r);
            return !x1 || !x2 && x3 && !x4;
        };

        public static Func<T, bool> ФильтрПользЯвлсяОтветственным<T>(int? идПользователя)
            where T : IEMPLOYEE_RESPONSIBLE_OWNER
            => v
                => v.id_user_responsible != null
                   &&
                   v.id_user_responsible == идПользователя;
    }
}
