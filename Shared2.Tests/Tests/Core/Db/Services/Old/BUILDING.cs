using System;
using DBPSA.Shared.Db.Configuration;
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
    public class BUILDING_RepositoryTests : Init
    {
        /// <summary>
        /// настройка 
        /// </summary>
        public static BUILDING_Repository Setup()
        {
            return new BUILDING_Repository(DB_FACTORY);
        }

        [Test]
        public void TEST_Create()
        {
            var sd = new BUILDING_Configuration();
            /*var model = Create(new BUILDING
            {
                NET_NAME = "Test_Create_NET_NAME",
                SERVER_TYPE = "Test_Create_SERVER_TYPE",
                int = 1
            });*/
            var model = Create(new BUILDING
            {
                NAME = "TEST_Creat",
                ID_PROM_AREA = 1
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
            /*var model = new BUILDING
            {
                ID = 0,
                NET_NAME = "Test_Delete_NET_NAME",
                int = 2
            };*/
            var model = new BUILDING
            {
                ID = 0,
                NAME = "TEST_Delet",
                ID_PROM_AREA = 2
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
            /*var entity_to_create = new BUILDING
            {
                NET_NAME = "TEST_CRU",
                SERVER_TYPE = "TEST_CRU",
                int = 3
            };*/
            var entity_to_create = new BUILDING
            {
                NAME = "TEST_CRU",
                ID_PROM_AREA = 3
            };
            
            /*var entity_to_update = new BUILDING
            {
                ID = 0, // не обновляем
                NET_NAME = "TEST_CRU_UPDATED",
                int = 4
            };*/
            var entity_to_update = new BUILDING
            {
                ID = 0,
                NAME = "CRU_UPDATE",
                ID_PROM_AREA = 4
            };

            // подготовка
            BUILDING e;

            #region create
            e = Upd(entity_to_create);
            Create(e);
            e.Should().NotBeEquivalentTo(entity_to_create, options => options.Including(o => o.ID));
            #endregion

            #region read
            // read - check create command
            var e_rereaded = Read(e.ID);
            e_rereaded.Should().BeEquivalentTo(e, opt=>opt.Excluding(o=>o.ROOM)); 
            // warn: сомнительная эквивалентность, объект e_rereaded имеет один признак (_entityWrapper), которое не имеет объект e
            #endregion

            #region update
            
            // предпроверка
            Assert.NotNull(e);
            
            // подготовка
            /*e.NET_NAME = entity_to_update.NET_NAME;
            e.SERVER_TYPE = entity_to_update.SERVER_TYPE;*/
            e.NAME = entity_to_update.NAME;
            e.ID_PROM_AREA = entity_to_update.ID_PROM_AREA;
            
            // действие
            Update(e);
            // read - check update command
            Read(e.ID).Should().BeEquivalentTo(entity_to_update, opt => opt
                .Excluding(o=>o.ID)
                .Excluding(o=>o.ROOM)
                .Excluding(o=>o.PROM_AREA)); // ID не проверяется, все остальные проверяются
            /*Read(e.ID).Should().BeEquivalentTo(entity_to_update, opt => opt.Including(o=>o.NAME).Including(o=>o.FNAME).Including(o=>o.Домен)); // проверяются только эти*/
            Read(e.ID).Should().NotBeEquivalentTo(entity_to_update, opt => opt.Including(o => o.ID)); // проверяется только ID
            #endregion
        }

        // =====================================================================================================
        // Приватные функции
        // =====================================================================================================

        private static BUILDING Upd(BUILDING u)
        {
            /*var model = new BUILDING
            {
                ID = u.ID,
                NET_NAME = u.NET_NAME,
            };*/
            var model = new BUILDING
            {
                ID = u.ID,
                NAME = u.NAME,
                ID_PROM_AREA = u.ID_PROM_AREA
            };
            return model;
        }

        private static BUILDING Create(BUILDING model)
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

        private static BUILDING Read(int? id)
        {
            // подготовка
            var repository = Setup();

            BUILDING e_readed;
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
        
        private void Delete(BUILDING model)
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

        private static void Update(BUILDING model)
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
