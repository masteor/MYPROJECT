#define DEBUG
using System;
using System.Collections.Generic;
using System.Linq;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Shared.Extensions.Entity
{
    public static class EMPLOYEE_Extension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="employees"></param>
        /// <returns></returns>
        public static List<EMPLOYEE> Действующие(this IEnumerable<EMPLOYEE> employees) => 
            employees.Where(e => e.Действующий()).ToList();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static bool Действующий(this EMPLOYEE e)
        {
            if (e.job_begin_date == null) return false;
            
            var nowTicks = DateTime.Now.Ticks;
            var датаУвольненияВТиках = e.job_end_date?.Ticks ?? DateTime.MaxValue.Ticks;
            var датаПриёмаНаРаботуВТиках = e.job_begin_date?.Ticks ?? DateTime.MinValue.Ticks;
            return датаУвольненияВТиках > nowTicks && датаПриёмаНаРаботуВТиках <= nowTicks;
        }   
    }
}