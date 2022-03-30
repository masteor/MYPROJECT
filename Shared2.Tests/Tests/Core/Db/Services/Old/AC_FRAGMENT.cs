using System;
using System.Collections.Generic;
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
    public class AC_FRAGMENT_RepositoryTests : Init
    {
        /// <summary>
        /// настройка 
        /// </summary>
        public static AC_FRAGMENT_Repository Setup()
        {
            return new AC_FRAGMENT_Repository(DB_FACTORY);
        }

        [Test]
        public void AC_FRAGMENT__Create()
        {
            var acF = Create(new ФрагментыЗЛИВС
            {
                КороткоеНазвание = "имя12",
                FNAME = "фамилия12",
                
            });
            Assert.NotNull(acF);
        }

        [Test]
        public void AC_FRAGMENT__Read()
        {
            var r = Read(null);
            Assert.NotNull(r);
        }
        
        [Test]
        public void AC_FRAGMENT__Delete()
        {
            ФрагментыЗЛИВС acF = new ФрагментыЗЛИВС
            {
                ID = 0,
                КороткоеНазвание = "1",
                FNAME = "2",
                /*Домен = new List<Домен>() { }*/
            };
            acF = Create(acF);
            Assert.IsNotNull(acF);
            
            var repository = Setup();
            var r = repository.GetById(acF.ID);
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
        public void AC_FRAGMENT__GetAll__DoesNotThrow()
        {
            // подготовка
            var repository = Setup();

            // действие
            var result = repository.GetAll();
            //TestDelegate testDelegate = () => repository.GetById(1);
            TestDelegate testDelegate = () => repository.GetAll();

            // утверждение
            Assert.DoesNotThrow(testDelegate);
            /*Assert.IsNotNull(repository.GetAll());*/
        }
        
        [Test]
        public void AC_FRAGMENT__CRU()
        {
            var entity_to_create = new ФрагментыЗЛИВС
            {
                КороткоеНазвание = "1",
                FNAME = "2",
            };
            /*Домен = new List<Домен>()*/

            var entity_to_update = new ФрагментыЗЛИВС()
            {
                ID = 0, // не обновляем
                КороткоеНазвание = "11",
                FNAME = "22",
                /*Домен = new List<Домен>() // не обновляем
                {
                    
                }*/ 
            };

            // подготовка
            ФрагментыЗЛИВС e;

            #region create
            e = upd(entity_to_create);
            Create(e);
            e.Should().NotBeEquivalentTo(entity_to_create, options => options.Including(o => o.ID));
            #endregion

            #region read
            // read - check create command
            var e_rereaded = Read(e.ID);
            e_rereaded.Should().BeEquivalentTo(e, opt => opt.Excluding(o=>o.SERVICE)); 
            // warn: сомнительная эквивалентность, объект e_rereaded имеет один признак (_entityWrapper), которое не имеет объект e
            #endregion

            #region update
            // предпроверка
            Assert.NotNull(e);
            // подготовка
            e.КороткоеНазвание = entity_to_update.КороткоеНазвание;
            e.FNAME = entity_to_update.FNAME;
            // действие
            Update(e);
            // read - check update command
            Read(e.ID).Should().BeEquivalentTo(entity_to_update, opt => opt.Excluding(o=>o.ID).Excluding(o=>o.SERVICE)); // ID не проверяется, все остальные проверяются
            /*Read(e.ID).Should().BeEquivalentTo(entity_to_update, opt => opt.Including(o=>o.NAME).Including(o=>o.FNAME).Including(o=>o.Домен)); // проверяются только эти*/
            Read(e.ID).Should().NotBeEquivalentTo(entity_to_update, opt => opt.Including(o => o.ID)); // проверяется только ID
            #endregion

            /*var e_for_delete = Read(e.ID);
                    Assert.IsNotNull(e_for_delete);

                    /*Delete(e_for_delete);#1#
                
                var repository = Setup();
                Action action_delete = () => repository.Delete(e_for_delete);
                Action action_commit = () => repository.Commit();
                action_delete.Should().NotThrow();
                action_commit.Should().NotThrow();

                //read - check delete command
                    Assert.NotNull(e_for_delete);
                    e_rereaded = Read(e_for_delete.ID);
                    e_rereaded.Should().BeEquivalentTo(e_rereaded);*/
        }

        ///// <summary>
        ///// процедура обновления некоторых полей объекта
        ///// </summary>
        ///// <param name="acF_new">обновляемый объект</param>
        ///// <param name="acF_old">объект с которого происходит обновление</param>
        //private void update(ref ФрагментыЗЛИВС acF_new, ref ФрагментыЗЛИВС acF_old)
        //{
        //    acF_new.ID = acF_old.ID;
        //    acF_new.NAME = acF_old.NAME;
        //    acF_new.FNAME = acF_old.FNAME;

        //    Assert.IsNotNull(acF_new);
        //    Assert.IsNotNull(acF_old);
        //}

        //[Test]
        //public void T_update()
        //{
        //    // подготовка
        //    var acF_old = new ФрагментыЗЛИВС
        //    {
        //        ID = 1,
        //        NAME = "1",
        //        FNAME = "2",
        //        Домен = new List<Домен>()
        //    };
        //    var acF_new = new ФрагментыЗЛИВС
        //    {
        //        ID = 0,
        //        NAME = null,
        //        FNAME = null,
        //        Домен = null
        //    };

        //    // действие
        //    update(ref acF_new, ref acF_old);

        //    // утверждение
        //    acF_new.Should().BeEquivalentTo(acF_old, options => options.Excluding(o => o.Домен).Excluding(o=>o.ID));
        //}

        //public static T Clone<T>(T source)
        ФрагментыЗЛИВС upd(ФрагментыЗЛИВС updater)
        {
            var acF = new ФрагментыЗЛИВС
            {
                ID = updater.ID, 
                FNAME = updater.FNAME, 
                КороткоеНазвание = updater.КороткоеНазвание,
                SERVICE = updater.SERVICE
            };
            // acF.Домен = updater.Домен; // warn: копируется не объект, а ссылка

            return acF;
        }

        private static ФрагментыЗЛИВС Create(ФрагментыЗЛИВС acF)
        {
            // предпроверка
            Assert.IsTrue(acF.ID == 0);
            /*Assert.IsNotNull(acF.Домен);*/

            // подготовка
            var repository = Setup();

            // действие
            Action act_add = () => repository.Add(acF); // acF меняется по ссылке, это значит в вызывающей процедуре он тоже поменяется
            Action act_commit = () => repository.Commit();

            // утверждение
            act_add.Should().NotThrow();
            act_commit.Should().NotThrow();
            //Assert.NotNull(acF);
            Assert.IsTrue(acF.ID > 0);

            return acF;
        }

        private static ФрагментыЗЛИВС Read(int? id)
        {
            // подготовка
            var repository = Setup();

            ФрагментыЗЛИВС e_readed;
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

        private void Delete(ФрагментыЗЛИВС acF)
        {
            // подготовка
            var repository = Setup();

            // действие
            // Action act_delete = () => repository.Delete(e_for_delete);
            Action act_delete = () => repository.Delete(acF);
            /*Action act_delete = () => repository.Delete(Read(acF.ID));*/
            Action act_commit = () => repository.Commit();
            //утверждение
            act_delete.Should().NotThrow();
            act_commit.Should().NotThrow();
        }

        private void Update(ФрагментыЗЛИВС acF)
        {
            // подготовка
            var repository = Setup();
            Assert.NotNull(acF);

            // действие
            Action act_update = () => repository.Update(acF);
            Action act_commit = () => repository.Commit();

            // проверка
            act_update.Should().NotThrow();
            act_commit.Should().NotThrow();
        }
    }
}
