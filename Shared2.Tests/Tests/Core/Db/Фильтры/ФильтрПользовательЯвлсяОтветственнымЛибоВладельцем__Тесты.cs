using System;
using System.Collections.Generic;
using AutoFixture;
using QWERTY.Shared.Db.Entities.Представления;
using QWERTY.Shared2.Tests.Обслуживание_Тестов;
using NUnit.Framework;
using static QWERTY.Shared2.Tests.Tests.Core.Models.Модульные_Тесты.InitModule;

namespace QWERTY.Shared2.Tests.Tests.Core.Db.Фильтры
{
    [TestFixture]
    public class ФильтрПользовательЯвлсяОтветственнымЛибоВладельцем__Тесты : Init
    {
        [Test]
        public void ПривилегированныйПользователь__ЛогинЕсть__ВозвращаютсяВсеРезультаты()
        {
            List<VIEW_RESOURCES_BY_OT_ST> list = ПолучитьФикстуру<List<VIEW_RESOURCES_BY_OT_ST>>();

            int идПользователя = ПолучитьФикстуру<int>();
            Assert.IsTrue(CommonService!.ФильтрТолькоДляПривилегированныйОтветственныйВладелец
            (
                list,
                идПользователя,
                true
            ).Count == list.Count);    
            
            Assert.IsTrue(list.TrueForAll(v => v.id_user_owner != идПользователя));
            Assert.IsTrue(list.TrueForAll(v => v.id_user_responsible != идПользователя));
        }
        
        [Test]
        public void НепривилегированныйПользователь__ЛогинЕсть__ВозвращаетПодходящийРезультат()
        {
            var идПользователя = ПолучитьФикстуру<int>();

            {
                List<VIEW_RESOURCES_BY_OT_ST> list = new List<VIEW_RESOURCES_BY_OT_ST>
                {
                    new VIEW_RESOURCES_BY_OT_ST
                    {
                        id_user_responsible = 0,
                        id_user_owner = 0,
                    },
                    new VIEW_RESOURCES_BY_OT_ST
                    {
                        id_user_responsible = идПользователя,
                        id_user_owner = 0,
                    },
                };

                var результат = CommonService!
                    .ФильтрТолькоДляПривилегированныйОтветственныйВладелец(list, идПользователя, false);

                Assert.True(результат.Count == 1);
            }
            
            {
                List<VIEW_RESOURCES_BY_OT_ST> list = new List<VIEW_RESOURCES_BY_OT_ST>
                {
                    new VIEW_RESOURCES_BY_OT_ST
                    {
                        id_user_responsible = 0,
                        id_user_owner = идПользователя,
                    },
                    new VIEW_RESOURCES_BY_OT_ST
                    {
                        id_user_responsible = 0,
                        id_user_owner = 0,
                    },
                };

                var результат = CommonService!
                    .ФильтрТолькоДляПривилегированныйОтветственныйВладелец(list, идПользователя, false);

                Assert.True(результат.Count == 1);
            }
            
            {
                List<VIEW_RESOURCES_BY_OT_ST> list = new List<VIEW_RESOURCES_BY_OT_ST>
                {
                    new VIEW_RESOURCES_BY_OT_ST
                    {
                        id_user_responsible = 0,
                        id_user_owner = идПользователя,
                    },
                    new VIEW_RESOURCES_BY_OT_ST
                    {
                        id_user_responsible = идПользователя,
                        id_user_owner = 0,
                    },
                };

                var результат = CommonService!
                    .ФильтрТолькоДляПривилегированныйОтветственныйВладелец(list, идПользователя, false);

                Assert.AreEqual(2, результат.Count);
            }
        }
    }
}