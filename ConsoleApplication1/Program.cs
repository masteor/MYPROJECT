using System;
using System.Collections.Generic;
using System.Linq;

namespace ПрототипСохранениеОбъектовДереваВоБД
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var objectsArray = ObjectsArray2(); // ObjectsArray1();

            var модель = new{ProfileObjects = objectsArray};

            var хвосты = ПолучитьХвосты();
            
            /*Console.WriteLine("Хвосты:");
            Console.WriteLine("--------------------------------------------------------------------------------------");
            foreach (var i in хвосты) Console.Write($"[{i}]");
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------------------------------");*/

            List<OBJECT> созданныеОбъектыВоБД = new List<OBJECT>();

            var dbCounter = 1234;
            var ресурс = new OBJECT
            {
                id = 1000,
                id_parent_object = null,
                name = "Ресурс1"
            };

            
            foreach (var хвостId in хвосты)
            {
                var ветка = ПолучитьВеткуПоХвосту(хвостId);

                /*Console.WriteLine("Очередная ветвь:");
                foreach (var i in ветка) Console.Write($"[{i}]");
                Console.WriteLine();*/
                
                // создаем объекты в базе данных для сформированной ветки
                foreach (var листId in ветка)
                {
                    // если объект с таким ид уже создавался, тогда создаем пропускаем создание объекта 
                    if (ПолучитьОбъектДереваПоИд(листId).iddb != null) continue;
                    
                    // псевдо-создание объекта в БД с целью получения ид
                    var созданныйОбъектВоБД = new OBJECT
                    {
                        id = ++dbCounter,
                        name = ПолучитьОбъектДереваПоИд(листId).ObjectName,
                        id_parent_object = НайтиИдРодителяИзБД(листId),
                    }; 
                    
                    // объект создан в базе данных - берем его ид и добавляем к структуре объектов дерева
                    ПолучитьОбъектДереваПоИд(листId).iddb = созданныйОбъектВоБД.id;
                    
                    Console.WriteLine($"листId={листId}, созданныйОбъект.id = {созданныйОбъектВоБД.id}, id_parent_object = {созданныйОбъектВоБД.id_parent_object}");
                    
                    // сохраняем ид созданного объекта в БД и его ид в дереве
                    созданныеОбъектыВоБД.Add(созданныйОбъектВоБД);
                }
            }
            
            int? НайтиИдРодителяИзБД(int листId)
            {
                var parent = ПолучитьОбъектДереваПоИд(листId).parent;
                return parent == null
                    // если лист не имеет родительских объектов,
                    // тогда это корневой объект и должен цепляться напрямую к ресурсу
                    ? ресурс.id
                    // иначе его надо прицепить к iddb уже созданного объекта
                    : ПолучитьОбъектДереваПоИд(parent).iddb;
            }

            IEnumerable<int> ПолучитьХвосты() 
                =>
                модель.ProfileObjects
                    .Where(v => модель.ProfileObjects.All(v1 => v1.parent != v.id))
                    .Select(v => v.id);

            
            ProfileObjects ПолучитьОбъектДереваПоИд(int? ид) 
                => 
                    модель.ProfileObjects.First(v => v.id == ид);

            List<int> ПолучитьВеткуПоХвосту(int хвостId)
            {
                List<int> ветка = new List<int>();
                var path = ""; // путь будет собираться в массив
                int? parentId = хвостId;

                int[]? rights = null;

                do
                {
                    // при первой итерации в ветку добавляется сначала хвост
                    // при последующих итерациях в ветку добавляются родитель хвоста, родитель-родителя хвоста и т.д.
                    // пока не будет достигнут корневой объект ветки
                    ветка.Add((int) parentId);
                    // находим очередной объект 
                    var obj = ПолучитьОбъектДереваПоИд(parentId);
                    parentId = obj.parent; // получаем ссылку на следующего родителя
                    // rights = [...obj.RightDescriptions]
                    path = '\\' + $"[id:{obj.id}]" + obj.ObjectName + path;
                } while (parentId != null);

                // разворачиваем список ветки, потому что элементы идут от последнего к первому, 
                // а надо наоборот от первого к последнему -
                // именно в такой последовательности они будут записаны в базу данных
                ветка.Reverse();
                return ветка;
            }
        }


        private static ProfileObjects[] ObjectsArray2()
        {
            return new ProfileObjects[]
            {
                new ProfileObjects
                {
                    id = 15,
                    parent = null, // корневой
                    ObjectName = "name15",
                    RightDescriptions = new int[] {1, 2, 3},
                },
                new ProfileObjects
                {
                    id = 16,
                    parent = null, // корневой
                    ObjectName = "name16",
                    RightDescriptions = new int[] {1, 2, 3},
                },
                new ProfileObjects
                {
                    id = 17,
                    parent = null, // корневой
                    ObjectName = "name17",
                    RightDescriptions = new int[] {1, 2, 3},
                },
            };
        }
                
        private static ProfileObjects[] ObjectsArray1()
        {
            return new ProfileObjects[]
            {
                new ProfileObjects
                {
                    id = 15,
                    parent = null, // корневой
                    ObjectName = "name15",
                    RightDescriptions = new int[]{1,2,3},
                },
                new ProfileObjects
                {
                    id = 16,
                    parent = null, // корневой
                    ObjectName = "name16",
                    RightDescriptions = new int[]{1,2,3},
                },
                new ProfileObjects
                {
                    id = 1,
                    parent = null,
                    ObjectName = "name1",
                    RightDescriptions = new int[]{1,2,3},
                },
                new ProfileObjects
                {
                    id = 2,
                    parent = 1,
                    ObjectName = "name2",
                    RightDescriptions = new int[]{1,2,3},
                },
                new ProfileObjects
                {
                    id = 3,
                    parent = 2,
                    ObjectName = "name3",
                    RightDescriptions = new int[]{1,2,3},
                },
                new ProfileObjects
                {
                    id = 4,
                    parent = 3,
                    ObjectName = "name4",
                    RightDescriptions = new int[]{1,2,3},
                },
                new ProfileObjects
                {
                    id = 5,
                    parent = 4,
                    ObjectName = "name5",
                    RightDescriptions = new int[]{1,2,3},
                },
                new ProfileObjects
                {
                    id = 6,
                    parent = 5,
                    ObjectName = "name6",
                    RightDescriptions = new int[]{1,2,3},
                },
                new ProfileObjects
                {
                    id = 7,
                    parent = 6,
                    ObjectName = "name7",
                    RightDescriptions = new int[]{1,2,3},
                },
                new ProfileObjects
                {
                    id = 8,
                    parent = 2,
                    ObjectName = "name8",
                    RightDescriptions = new int[]{1,2,3},
                },
                new ProfileObjects
                {
                    id = 9,
                    parent = 8,
                    ObjectName = "name9",
                    RightDescriptions = new int[]{1,2,3},
                },
                new ProfileObjects
                {
                    id = 10,
                    parent = 9,
                    ObjectName = "name10",
                    RightDescriptions = new int[]{1,2,3},
                },
                new ProfileObjects
                {
                    id = 11,
                    parent = 10,
                    ObjectName = "name11",
                    RightDescriptions = new int[]{1,2,3},
                },
                new ProfileObjects
                {
                    id = 12,
                    parent = 11,
                    ObjectName = "name12",
                    RightDescriptions = new int[]{1,2,3},
                },
                new ProfileObjects
                {
                    id = 13,
                    parent = 12,
                    ObjectName = "name13",
                    RightDescriptions = new int[]{1,2,3},
                },
                new ProfileObjects
                {
                    id = 14,
                    parent = 6,
                    ObjectName = "name14",
                    RightDescriptions = new int[]{1,2,3},
                },
                new ProfileObjects
                {
                    id = 17,
                    parent = 15, 
                    ObjectName = "name17",
                    RightDescriptions = new int[]{1,2,3},
                },
                new ProfileObjects
                {
                    id = 18,
                    parent = 15, 
                    ObjectName = "name18",
                    RightDescriptions = new int[]{1,2,3},
                },
                new ProfileObjects
                {
                    id = 19,
                    parent = 18, 
                    ObjectName = "name19",
                    RightDescriptions = new int[]{1,2,3},
                },
            };
        }

        internal class OBJECT
        {
            public int id;
            public string name;
            public int? id_parent_object;

            public OBJECT()
            {
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="лист"></param>
        /// <returns>id созданного объекта</returns>
        /// <exception cref="NotImplementedException"></exception>
        private static int СоздатьЛистВоБД(OBJECT o)
        {
            return o.id;
        }
    }

    internal class СозданныйОбъект
    {
        /// <summary>
        /// id созданного листа в БД
        /// </summary>
        internal int idDB;
        
        /// <summary>
        /// id листа в структуре дерева
        /// </summary>
        internal int id;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idDb"></param>
        /// <param name="id"></param>
        public СозданныйОбъект(int idDb, int id)
        {
            idDB = idDb;
            this.id = id;
        }
    }

    public class ProfileObjects
    {
        /// <summary>
        /// id объекта в структуре объектов 
        /// </summary>
        public int id { get; set; } = 0;

        public int? iddb { get; set; }

        /// <summary>
        /// id родительского объекта в структуре объектов 
        /// </summary>
        public int? parent { get; set; } = null;

        /// <summary>
        /// Имя объекта, добавляемого в профиль
        /// </summary>
        public string ObjectName { get; set; } = "";

        /// <summary>
        /// Ид типа объекта, добавляемого в профиль
        /// </summary>
        public int? ObjectTypeId { get; set; }

        /// <summary>
        /// Права, назначаемые на объект профиля
        /// </summary>
        public int[]? RightDescriptions { get; set; } = null;

        public ProfileObjects(
            int id,
            int? parent,
            string objectName,
            int? objectTypeId,
            int[]? rightDescriptions
        )
        {
            this.id = id;
            this.parent = parent;
            ObjectName = objectName;
            ObjectTypeId = objectTypeId;
            RightDescriptions = rightDescriptions;
        }

        public ProfileObjects()
        {
        }
    }
}