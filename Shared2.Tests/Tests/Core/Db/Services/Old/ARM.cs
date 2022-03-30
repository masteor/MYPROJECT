using System;
using DBPSA.Shared.Db.Entities;
using DBPSA.Shared.Db.Repositories;
using FluentAssertions;
using NUnit.Framework;

namespace DBPSA.Shared.Tests.Core.Db.Services
{
    /// <summary>
    /// Сначала проверяем маппинги - правильно ли они созданы, на те ли поля они смотрят
    /// это проверяется через процедуру GetAll - самое главное тут отправка SQL запроса,
    /// а не то, что он вернет
    /// </summary>
    [TestFixture]
    public class ARM_RepositoryTests : Init
    {
        /// <summary>
        /// настройка 
        /// </summary>
        public static ARM_Repository Setup()
        {
            return new ARM_Repository(DB_FACTORY);
        }

        [Test]
        public void TEST_Create()
        {
            var acF = Create(new ARM
            {
                РегНомер = "TEST_Create",
                идПомещенияВКоторомНаходится = null,
                идАктуальнойЗаписи = null,
                идЗаявкиПостановкиНаУчёт = 1,
                идЗаявкиСнятияСУчёта = null
            });
            Assert.NotNull(acF);
        }

        [Test]
        public void Test_Read()
        {
            var r = Read(null);
            Assert.NotNull(r);
        }
        
        [Test]
        public void Test_Delete()
        {
            var model = new ARM
            {
                ID = 0,
                РегНомер = "Test_Delete",
                идПомещенияВКоторомНаходится = 2,
                идАктуальнойЗаписи = 2,
                идЗаявкиПостановкиНаУчёт = 2,
                идЗаявкиСнятияСУчёта = 2
            };
            model = Create(model);
            Assert.IsNotNull(model);
            
            var repository = Setup();
            var r = repository.GetById(model.ID);
            // repository.Найти(o=>o.NAME.Contains("1"));
            Assert.NotNull(r);

            Action action_delete = () => repository.Delete(r);
            Action action_commit = () => repository.Commit();
            action_delete.Should().NotThrow();
            action_commit.Should().NotThrow();
        }

        /// <summary>
        /// проверяем маппинги, тут главное чтобы прошел SQL запрос, без исключений, значения НЕ проверяются
        /// </summary>
        [Test]
        public void TEST_GetAll__DoesNotThrow()
        {
            // подготовка
            var repository = Setup();

            // действие
            //TestDelegate testDelegate = () => repository.GetById(1);
            TestDelegate testDelegate = () => repository.GetAll();

            // утверждение
            Assert.DoesNotThrow(testDelegate);
            /*Assert.IsNotNull(repository.GetAll());*/
        }
        
        // CRU, а не CRUD потому, что операция DELETE внутри данного теста не проходит, не разобрался почему
        // тест DELETE запускается отдельно
        [Test]
        public void TEST_CRU() 
        {
            var entity_to_create = new ARM
            {
                РегНомер = "TEST_CRU",
                идПомещенияВКоторомНаходится = 3,
                идАктуальнойЗаписи = 3,
                идЗаявкиПостановкиНаУчёт = 3,
                идЗаявкиСнятияСУчёта = 3
            };

            var entity_to_update = new ARM
            {
                // ID = 0, не обновляем
                ID = 0,
                РегНомер = "TEST_CRU_UPDATED",
                идПомещенияВКоторомНаходится = 4,
                идАктуальнойЗаписи = 4,
                идЗаявкиПостановкиНаУчёт = 4,
                идЗаявкиСнятияСУчёта = 4
            };

            // подготовка
            ARM e;

            #region create
            e = upd(entity_to_create);
            Create(e);
            e.Should().NotBeEquivalentTo(entity_to_create, options => options.Including(o => o.ID));
            #endregion

            #region read
            // read - check create command
            var e_rereaded = Read(e.ID);
            e_rereaded.Should().BeEquivalentTo(e, opt=>opt
                .Excluding(o=>o.ПОМЕЩЕНИЕ_В_КОТОРОМ_НАХОДИТСЯ)
                .Excluding(o=>o.ДОПУСКИ_СОТРУДНИКОВ)
                ); 
            // warn: сомнительная эквивалентность, объект e_rereaded имеет один признак (_entityWrapper), которое не имеет объект e
            #endregion

            #region update
            
            // предпроверка
            Assert.NotNull(e);
            
            // подготовка

            e.РегНомер = entity_to_update.РегНомер;
            e.идПомещенияВКоторомНаходится = entity_to_update.идПомещенияВКоторомНаходится;
            e.идАктуальнойЗаписи = entity_to_update.идАктуальнойЗаписи;
            e.идЗаявкиПостановкиНаУчёт = entity_to_update.идЗаявкиПостановкиНаУчёт;
            e.идЗаявкиСнятияСУчёта = entity_to_update.идЗаявкиСнятияСУчёта;

            // действие
            Update(e);
            // read - check update command
            Read(e.ID).Should().BeEquivalentTo(entity_to_update, opt => opt
                .Excluding(o=>o.ID)
                .Excluding(o=>o.АКТУАЛЬНЫЙ)
                .Excluding(o=>o.ЗАЯВКА_ПОСТАНОВКИ_НА_УЧЁТ)
                .Excluding(o=>o.ЗАЯВКА_СНЯТИЕ_С_УЧЁТА)
                .Excluding(o=>o.ДОПУСКИ_СОТРУДНИКОВ)); // ID не проверяется, все остальные проверяются
            /*Read(e.ID).Should().BeEquivalentTo(entity_to_update, opt => opt.Including(o=>o.NAME).Including(o=>o.FNAME).Including(o=>o.Домен)); // проверяются только эти*/
            Read(e.ID).Should().NotBeEquivalentTo(entity_to_update, opt => opt.Including(o => o.ID)); // проверяется только ID
            #endregion
        }

        // =====================================================================================================
        // Приватные функции
        // =====================================================================================================

        ARM upd(ARM u)
        {
            var model = new ARM
            {
                ID = u.ID,
                РегНомер = u.РегНомер,
                идПомещенияВКоторомНаходится = u.идПомещенияВКоторомНаходится,
                идАктуальнойЗаписи = u.идАктуальнойЗаписи,
                идЗаявкиПостановкиНаУчёт = u.идЗаявкиПостановкиНаУчёт,
                идЗаявкиСнятияСУчёта = u.идЗаявкиСнятияСУчёта,
            };
            return model;
        }

        private static ARM Create(ARM model)
        {
            // предпроверка
            Assert.IsTrue(model.ID == 0);
            /*Assert.IsNotNull(acF.Домен);*/

            // подготовка
            var repository = Setup();

            // действие
            Action act_add = () => repository.Add(model); // acF меняется по ссылке, это значит в вызывающей процедуре он тоже поменяется
            Action act_commit = () => repository.Commit();

            // утверждение
            act_add.Should().NotThrow();
            act_commit.Should().NotThrow();
            //Assert.NotNull(acF);
            Assert.IsTrue(model.ID > 0);

            return model;
        }

        private static ARM Read(int? id)
        {
            // подготовка
            var repository = Setup();

            ARM e_readed;
            // действие
            if (id != null) {
                e_readed = repository.GetById((int) id);
            }
            else {
                e_readed = repository.Найти(x=> x.ID > 0);
            }
            Action act_commit = () => repository.Commit();

            // утверждение
            act_commit.Should().NotThrow();
            Assert.NotNull(e_readed);
            /*Assert.IsNotNull(e_readed.Домен);*/

            return e_readed;
        }
        
        private void Delete(ARM model)
        {
            // подготовка
            var repository = Setup();

            // действие
            // Action act_delete = () => repository.Delete(e_for_delete);
            Action act_delete = () => repository.Delete(model);
            /*Action act_delete = () => repository.Delete(Read(acF.ID));*/
            Action act_commit = () => repository.Commit();
            //утверждение
            act_delete.Should().NotThrow();
            act_commit.Should().NotThrow();
        }

        private void Update(ARM model)
        {
            // подготовка
            var repository = Setup();
            Assert.NotNull(model);

            // действие
            Action act_update = () => repository.Update(model);
            Action act_commit = () => repository.Commit();

            // проверка
            act_update.Should().NotThrow();
            act_commit.Should().NotThrow();
        }        
    }
}