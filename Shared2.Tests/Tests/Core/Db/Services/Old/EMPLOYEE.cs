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
    public class EMPLOYEE_RepositoryTests : Init
    {
        /// <summary>
        /// настройка 
        /// </summary>
        public static Employee_Repository Setup()
        {
            return new Employee_Repository(DB_FACTORY);
        }

        [Test]
        public void TEST_Create()
        {
            /*var model = Create(new EMPLOYEE
            {
                NET_NAME = "Test_Create_NET_NAME",
                SERVER_TYPE = "Test_Create_SERVER_TYPE",
            });*/
            var model = Create(new EMPLOYEE
            {
                ТабельныйНомер = 0,
                ID_JOB = 0,
                ID_LOGIN = null,
                ID_FORM_PERM = 0,
                ДатаПриемаНаРаботу = DateTime.Now,
                ДатаУвольнения = null,
                ID_NEW = null,
                ID_REQUEST_1 = 0,
                ID_REQUEST_2 = null
            });
            Assert.NotNull(model);
        }

        [Test]
        public void TEST_Read()
        {
            var r = Read(null);
            Assert.NotNull(r);
        }
        
        [Test]
        public void TEST_Delete()
        {
            /*var model = new EMPLOYEE
            {
                ID = 0,
                NET_NAME = "Test_Delete_NET_NAME",
            };*/
            var model = new EMPLOYEE
            {
                ID = 0,
                ТабельныйНомер = 0,
                ID_JOB = 0,
                ID_LOGIN = null,
                ID_FORM_PERM = 0,
                ДатаПриемаНаРаботу = DateTime.Now,
                ДатаУвольнения = null,
                ID_NEW = null,
                ID_REQUEST_1 = 0,
                ID_REQUEST_2 = null
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
            /*var entity_to_create = new EMPLOYEE
            {
                NET_NAME = "TEST_CRU",
                SERVER_TYPE = "TEST_CRU",
            };*/
            var entity_to_create = new EMPLOYEE
            {
                ТабельныйНомер = 0,
                ID_JOB = 0,
                ID_LOGIN = null,
                ID_FORM_PERM = 0,
                ДатаПриемаНаРаботу = DateTime.Now,
                ДатаУвольнения = null,
                ID_NEW = null,
                ID_REQUEST_1 = 0,
                ID_REQUEST_2 = null
            };
            
            /*var entity_to_update = new EMPLOYEE
            {
                ID = 0, // не обновляем
                NET_NAME = "TEST_CRU_UPDATED",
            };*/
            var entity_to_update = new EMPLOYEE
            {
                ID = 0,
                ТабельныйНомер = 9,
                ID_JOB = 9,
                ID_LOGIN = null,
                ID_FORM_PERM = 9,
                ДатаПриемаНаРаботу = DateTime.Now,
                ДатаУвольнения = null,
                ID_NEW = null,
                ID_REQUEST_1 = 9,
                ID_REQUEST_2 = null
            };

            // подготовка
            EMPLOYEE e;

            #region create
            e = Upd(entity_to_create);
            Create(e);
            e.Should().NotBeEquivalentTo(entity_to_create, options => options.Including(o => o.ID));
            #endregion

            #region read
            // read - check create command
            var e_rereaded = Read(e.ID);
            e_rereaded.Should().BeEquivalentTo(e, opt => opt
                .Excluding(o=> o.ID)
                .Excluding(o=>o.ДатаПриемаНаРаботу)
                .Excluding(o=>o.AC_ACCESS)); 
            // warn: сомнительная эквивалентность, объект e_rereaded имеет один признак (_entityWrapper), которое не имеет объект e
            #endregion

            #region update
            
            // предпроверка
            Assert.NotNull(e);
            
            // подготовка
            /*e.NET_NAME = entity_to_update.NET_NAME;
            e.SERVER_TYPE = entity_to_update.SERVER_TYPE;*/
            e.ДатаПриемаНаРаботу = entity_to_update.ДатаПриемаНаРаботу;
            e.ДатаУвольнения = entity_to_update.ДатаУвольнения;
            e.ТабельныйНомер = entity_to_update.ТабельныйНомер;
            e.ID_JOB = entity_to_update.ID_JOB;
            e.ID_NEW = entity_to_update.ID_NEW;
            e.ID_LOGIN = entity_to_update.ID_LOGIN;
            e.ID_REQUEST_1 = entity_to_update.ID_REQUEST_1;
            e.ID_REQUEST_2 = entity_to_update.ID_REQUEST_2;
            e.ID_FORM_PERM = entity_to_update.ID_FORM_PERM;
            
            // действие
            Update(e);
            // read - check update command
            Read(e.ID).Should().BeEquivalentTo(entity_to_update, opt => opt
                .Excluding(o=> o.ID)
                .Excluding(o=>o.ДатаПриемаНаРаботу)
                .Excluding(o=>o.ЗаявкаПриемаНаРаботу)
                .Excluding(o=>o.AC_ACCESS)); // ID не проверяется, все остальные проверяются
            /*Read(e.ID).Should().BeEquivalentTo(entity_to_update, opt => opt.Including(o=>o.NAME).Including(o=>o.FNAME).Including(o=>o.Домен)); // проверяются только эти*/
            Read(e.ID).Should().NotBeEquivalentTo(entity_to_update, opt => opt.Including(o => o.ID)); // проверяется только ID
            #endregion
        }

        // =====================================================================================================
        // Приватные функции
        // =====================================================================================================

        private static EMPLOYEE Upd(EMPLOYEE u)
        {
            /*var model = new EMPLOYEE
            {
                ID = u.ID,
                NET_NAME = u.NET_NAME,
            };*/
            var model = new EMPLOYEE
            {
                ID = u.ID,
                ТабельныйНомер = u.ТабельныйНомер,
                ID_JOB = u.ID_JOB,
                ID_LOGIN = u.ID_LOGIN,
                ID_FORM_PERM = u.ID_FORM_PERM,
                ДатаПриемаНаРаботу = u.ДатаПриемаНаРаботу,
                ДатаУвольнения = u.ДатаУвольнения,
                ID_NEW = u.ID_NEW,
                ID_REQUEST_1 = u.ID_REQUEST_1,
                ID_REQUEST_2 = u.ID_REQUEST_2 
            };
            return model;
        }

        private static EMPLOYEE Create(EMPLOYEE model)
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

        private static EMPLOYEE Read(int? id)
        {
            // подготовка
            var repository = Setup();

            EMPLOYEE e_readed;
            // действие
            if (id != null) 
            {
                e_readed = repository.GetById((int) id);
            }
            else 
            {
                e_readed = repository.Найти(x=> x.ID > 0);
            }
            Action act_commit = () => repository.Commit();

            // утверждение
            act_commit.Should().NotThrow();
            Assert.NotNull(e_readed);
            /*Assert.IsNotNull(e_readed.Домен);*/

            return e_readed;
        }
        
        private void Delete(EMPLOYEE model)
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

        private static void Update(EMPLOYEE model)
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
