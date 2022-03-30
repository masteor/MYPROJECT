using System;
using System.Collections.Generic;
using System.Linq;
using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Extensions.Entity;
using NUnit.Framework;

namespace QWERTY.Shared2.Tests.Tests.Core.Extensions.Entity
{
    public class EMPLOYEE_Extention__tests
    {
        DateTime _dateTimeNow = DateTime.Now;
        
        [Test]
        public void Проверка_расширения__Действующий()
        {
            Assert.True
                (ДействующиеСотрудники()
                .All(employee => employee.Действующий()));
            
            Assert.False
                (НеДействующиеСотрудники()
                .All(employee => employee.Действующий()));
        }
        
        [Test]
        public void Проверка_расширения__Действующие()
        {
            {
                IEnumerable<EMPLOYEE> employees = new List<EMPLOYEE>(); 
                Assert.AreEqual(employees.Действующие().Count, 0);    
            }
            
            {
                Assert.AreEqual(ДействующиеСотрудники().Действующие().Count, ДействующиеСотрудники().Count());
            }
            
            {
                Assert.AreEqual(НеДействующиеСотрудники().Действующие().Count, 0);
            }
        }

        [Test]
        public void Проверка_перечислений_использующихся_в_тестах()
        {
            Assert.True(DatesWithNullAndDateTimeNow().Contains(null));
            Assert.True(DatesWithNullAndDateTimeNow().Any(d => d.GetValueOrDefault() == _dateTimeNow));
            
            Assert.False(DatesWithNullWithoutDateTimeNow().Contains(_dateTimeNow));
            Assert.True(DatesWithNullWithoutDateTimeNow().Contains(null));
            
            Assert.False(NotNullDatesWithoutDateTimeNow().Contains(_dateTimeNow));
        }

        
        IEnumerable<EMPLOYEE> ДействующиеСотрудники() =>
            Валидные_JobBeginDates()
                .SelectMany(jobBeginDate => JobEndDatesДляДействующихСотрудников(),
                    (jobBeginDate, jobEndDate) =>
                        new EMPLOYEE
                        {
                            job_begin_date = jobBeginDate,
                            job_end_date = jobEndDate
                        });

        IEnumerable<DateTime?> JobEndDatesДляДействующихСотрудников()
        {
            yield return null;
            yield return _dateTimeNow.AddHours(1);
            yield return DateTime.MaxValue;
        }

        IEnumerable<EMPLOYEE> НеДействующиеСотрудники()
        {
            yield return new EMPLOYEE();

            foreach (var jobBeginDate in НеВалидные_JobBeginDates())
            foreach (var jobEndDate in DatesWithNullAndDateTimeNow())
                yield return new EMPLOYEE
                {
                    job_begin_date = jobBeginDate,
                    job_end_date = jobEndDate
                };
        }

        IEnumerable<DateTime> NotNullDatesWithoutDateTimeNow()
        {
            yield return DateTime.MinValue;
            yield return _dateTimeNow.AddDays(1);
            yield return _dateTimeNow.Subtract(new TimeSpan(1, 0,0, 0));
            yield return DateTime.MaxValue;
        }
        
        IEnumerable<DateTime?> DatesWithNullAndDateTimeNow()
        {
            yield return _dateTimeNow;
            foreach (var date in DatesWithNullWithoutDateTimeNow())
                yield return date;
        }
        
        IEnumerable<DateTime?> DatesWithNullWithoutDateTimeNow()
        {
            yield return null;
            foreach (var date in NotNullDatesWithoutDateTimeNow())
                yield return date;
        }

        IEnumerable<DateTime?> НеВалидные_JobBeginDates()
        {
            yield return null;
            yield return _dateTimeNow.AddDays(1);
            yield return DateTime.MaxValue;
        }
        
        IEnumerable<DateTime> Валидные_JobBeginDates()
        {
            yield return DateTime.MinValue;
            yield return new DateTime(1950, 1,1);
            yield return _dateTimeNow;
        }
        

        // действие
        // ReSharper disable once ExpressionIsAlwaysNull
//        void TestDelegate() => 
            
        // утверждение
  //      Assert.DoesNotThrow(TestDelegate);
    }
}