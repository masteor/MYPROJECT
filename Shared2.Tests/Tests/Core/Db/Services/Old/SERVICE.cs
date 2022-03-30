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
    public class SERVICE_RepositoryTests : Init
    {
        /// <summary>
        /// настройка 
        /// </summary>
        private static SERVICE_Repository Setup()
        {
            return new SERVICE_Repository(DB_FACTORY);
        }

        [Test]
        public void TEST_Create()
        {
            /*var model = Create(new Домен
            {
                NET_NAME = "Test_Create_NET_NAME",
                SERVER_TYPE = "Test_Create_SERVER_TYPE",
            });*/
            var model = Create(new SERVICE
            {
                NET_NAME = nameof(TEST_Create),
                SERVER_TYPE = nameof(TEST_Create),
                DESCRIPTION = nameof(TEST_Create),
                ID_SERVICE_TYPE = 0,
                ID_AC_FRAGMENT = 4,
                ID_NEW = null,
                ID_REQUEST_1 = 0,
                ID_REQUEST_2 = null,
                
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
            /*var model = new Домен
            {
                ID = 0,
                NET_NAME = "Test_Delete_NET_NAME",
            };*/
            var model = new SERVICE
            {
                ID = 0,
                NET_NAME = nameof(TEST_Delete),
                SERVER_TYPE = nameof(TEST_Delete),
                DESCRIPTION = nameof(TEST_Delete),
                ID_SERVICE_TYPE = 0,
                ID_AC_FRAGMENT = 4,
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
            var all = repository.GetAll();
            TestDelegate testDelegate = () => repository.GetAll();

            // утверждение
            Assert.NotNull(all);
            Assert.DoesNotThrow(testDelegate);
            /*Assert.IsNotNull(repository.GetAll());*/
        }
        
        // CRU, а не CRUD потому, что операция DELETE внутри данного теста не проходит, не разобрался почему
        // тест DELETE запускается отдельно
        [Test]
        public void TEST_CRU() 
        {
            /*var entity_to_create = new Домен
            {
                NET_NAME = "TEST_CRU",
                SERVER_TYPE = "TEST_CRU",
            };*/
            var entity_to_create = new SERVICE
            {
                NET_NAME = nameof(TEST_CRU),
                SERVER_TYPE = nameof(TEST_CRU),
                DESCRIPTION = nameof(TEST_CRU),
                ID_SERVICE_TYPE = 0,
                ID_AC_FRAGMENT = 4,
                ID_NEW = null,
                ID_REQUEST_1 = 0,
                ID_REQUEST_2 = null
            };
            
            /*var entity_to_update = new Домен
            {
                ID = 0, // не обновляем
                NET_NAME = "TEST_CRU_UPDATED",
            };*/
            var entity_to_update = new SERVICE
            {
                ID = 0,
                NET_NAME = "TEST_CRU_UPDATED",
                SERVER_TYPE = "TEST_CRU_UPDATED",
                DESCRIPTION = "TEST_CRU_UPDATED",
                ID_SERVICE_TYPE = 0,
                ID_AC_FRAGMENT = 4,
                ID_NEW = null,
                ID_REQUEST_1 = 0,
                ID_REQUEST_2 = null
            };

            // подготовка
            SERVICE e;

            #region create
            e = Upd(entity_to_create);
            Create(e);
            e.Should().NotBeEquivalentTo(entity_to_create, options => options.Including(o => o.ID));
            #endregion

            #region read
            // read - check create command
            var e_rereaded = Read(e.ID);
            e_rereaded.Should().BeEquivalentTo(e, opt=>opt.Excluding(o=>o.AC_FRAGMENT)); 
            // warn: сомнительная эквивалентность, объект e_rereaded имеет один признак (_entityWrapper), которое не имеет объект e
            #endregion

            #region update
            
            // предпроверка
            Assert.NotNull(e);
            
            // подготовка
            /*e.NET_NAME = entity_to_update.NET_NAME;
            e.SERVER_TYPE = entity_to_update.SERVER_TYPE;*/
            e.ID_NEW = entity_to_update.ID_NEW;
            e.NET_NAME = entity_to_update.NET_NAME;
            e.ID_REQUEST_1 = entity_to_update.ID_REQUEST_1;
            e.ID_REQUEST_2 = entity_to_update.ID_REQUEST_2;
            e.SERVER_TYPE = entity_to_update.SERVER_TYPE;
            e.DESCRIPTION = entity_to_update.DESCRIPTION;
            e.ID_AC_FRAGMENT = entity_to_update.ID_AC_FRAGMENT;
            e.ID_SERVICE_TYPE = entity_to_update.ID_SERVICE_TYPE;
            
            // действие
            Update(e);
            // read - check update command
            Read(e.ID).Should().BeEquivalentTo(entity_to_update, opt => opt.Excluding(o=>o.ID).Excluding(o=>o.AC_FRAGMENT)); // ID не проверяется, все остальные проверяются
            /*Read(e.ID).Should().BeEquivalentTo(entity_to_update, opt => opt.Including(o=>o.NAME).Including(o=>o.FNAME).Including(o=>o.Домен)); // проверяются только эти*/
            Read(e.ID).Should().NotBeEquivalentTo(entity_to_update, opt => opt.Including(o => o.ID)); // проверяется только ID
            #endregion
        }

        // =====================================================================================================
        // Приватные функции
        // =====================================================================================================

        private static SERVICE Upd(SERVICE u)
        {
            /*var model = new Домен
            {
                ID = u.ID,
                NET_NAME = u.NET_NAME,
            };*/
            var model = new SERVICE
            {
                ID = u.ID,
                NET_NAME = u.NET_NAME,
                SERVER_TYPE = u.SERVER_TYPE,
                DESCRIPTION = u.DESCRIPTION,
                ID_SERVICE_TYPE = u.ID_SERVICE_TYPE,
                ID_AC_FRAGMENT = u.ID_AC_FRAGMENT,
                ID_NEW = u.ID_NEW,
                ID_REQUEST_1 = u.ID_REQUEST_1,
                ID_REQUEST_2 = u.ID_REQUEST_2
            };
            return model;
        }

        private static SERVICE Create(SERVICE model)
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

        private static SERVICE Read(int? id)
        {
            // подготовка
            var repository = Setup();

            SERVICE e_readed;
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
        
        private void Delete(SERVICE model)
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

        private static void Update(SERVICE model)
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
