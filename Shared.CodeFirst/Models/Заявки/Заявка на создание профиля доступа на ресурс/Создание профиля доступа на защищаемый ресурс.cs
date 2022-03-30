using System;
using System.Collections.Generic;
using System.Linq;
using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Db.Services;
using QWERTY.Shared.Enums;
using QWERTY.Shared.Helpers;
using QWERTY.Shared.Models._Создатель;
using QWERTY.Shared.Properties;
using log4net;

namespace QWERTY.Shared.Models.Заявки.Заявка_на_создание_профиля_доступа_на_ресурс
{
    public class СозданиеПрофиляДоступаНаЗащищаемыйРесурс : Создатель<ДанныеИзФормы>
    {
        public readonly PROFILE_STRUCT ProfileStruct;
        private readonly REQUEST request;

        public СозданиеПрофиляДоступаНаЗащищаемыйРесурс
        (
            ICommonService? commonService,
            ILog? log,
            string? логинПользователяСервиса,
            ДанныеИзФормы_СозданиеПрофиляДоступа_модель? модель, 
            REQUEST? родительскаяЗаявка
        )
            : base (
                commonService,
                log,
                логинПользователяСервиса,
                модель,
                родительскаяЗаявка
            )
        {
            ProfileStruct = new PROFILE_STRUCT();
            
            try
            {
                #region Создаем главную заявку, а на основе её делаем подчиненные
                
                request = СоздатьЗаявкуПоИмениТипа(
                    БуквенныеКодыТиповЗаявок.ЗаявкаНаСозданиеПрофиляДоступа,
                    модель!.request_params!,
                    РодительскаяЗаявка
                );
                
                ProfileStruct.Request = request;

                #endregion
                

                #region Создаем имя профиля

                var профиль = СоздатьПрофиль(new PROFILE(модель!), модель.request_params!, request!);
                ProfileStruct.Profile = профиль;

                #endregion
                
                
                #region Создаем права для ресурса
                
                // ищем ресурс среди объектов профиля, он всегда первый (id = 1)
                var ресурсОбъектПрофиля= 
                    модель.ProfileObjects?.FirstOrDefault(v => v?.parent == null && v?.id == 1) 
                    ?? throw new Exception("Не могу найти запись ресурса в модель.ProfileObjects");
                
                СоздатьПраваДляОбъектаПрофиля
                (
                    профиль.id,
                    (int) модель.ResourceObjectId!,
                    ресурсОбъектПрофиля.RightDescriptions,
                    модель.request_params!, 
                    request!
                );

                // ресурс уже создан и объект для ресурса тоже, 
                // поэтому, помечаем, что его создавать не надо
                ресурсОбъектПрофиля.iddb = модель.ResourceObjectId; 
                #endregion

                
                #region Разбираем дерево объектов профиля

                IEnumerable<int?> хвосты = ПолучитьХвосты(модель.ProfileObjects!);
                
                foreach (var хвостId in хвосты)
                {
                    if (хвостId == null) throw new ArgumentNullException(nameof(хвостId)); 
                    var ветка = ПолучитьВеткуПоХвосту((int) хвостId, модель.ProfileObjects!);

                    #region для дебага
                    /*Console.WriteLine("Очередная ветвь:");
                    foreach (var i in ветка) Console.Write($"[{i}]");
                    Console.WriteLine();*/
                    #endregion

                    #region Создаем объекты в базе данных для сформированной ветки

                    foreach (var листId in ветка)
                    {
                        // если объект с таким ид уже создавался, тогда пропускаем создание объекта 
                        if (ПолучитьОбъектДереваПоИд(листId, модель.ProfileObjects).iddb != null) continue;

                        // получаем объект который собираемся создать в БД
                        var o = ПолучитьОбъектДереваПоИд(листId, модель.ProfileObjects);

                        // находим, кто будет являться родителем для нового объекта
                        var id_parent_object = НайтиИдРодителяИзБД(листId, модель.ProfileObjects, (int) модель.ResourceObjectId);
                        
                        // создаем объект
                        var объект = СоздатьОбъектРесурса(new OBJECT(модель!, o, id_parent_object), модель.request_params!, request!);
                
                        // добавляем права на созданный объект
                        var праваДляОбъектаПрофиля = СоздатьПраваДляОбъектаПрофиля
                        (
                            профиль.id,
                            объект.id,
                            o.RightDescriptions,
                            модель.request_params!, 
                            request!
                        );
                
                        ProfileStruct.Objects?.Add(new PROFILE_STRUCT.OBJECT_STRUCT
                        {
                            Object = объект,
                            Rights = праваДляОбъектаПрофиля
                        });
                            
                        // объект создан в базе данных - берем его ид и добавляем к структуре объектов дерева
                        ПолучитьОбъектДереваПоИд(листId, модель.ProfileObjects!).iddb = объект.id;
                    
                        Console.WriteLine($@"листId={листId}, созданныйОбъект.id = {объект.id}, id_parent_object = {объект.id_parent_object}");
                    }
                    #endregion
                }
                #endregion
                
                Result = JsonHelper.СоздатьJsonМодель(
                    ProfileStruct.ПолучитьОбъектРезультата(),
                    Ошибка,
                    $"Заявка на создание профиля [{профиль.name}] успешно создана");
            }
            catch (Exception e)
            {
                Ошибка = e;
                if (request?.id > 1) ОткатитьВсеСозданныеЗаявки(request?.id);
                Result = JsonHelper.СоздатьJsonМодель(Ошибка);
                throw;
            }

        }

        private IEnumerable<int> ПолучитьВеткуПоХвосту(int хвостId, ProfileObject?[] модель)
        {
            List<int> ветка = new List<int>();
            int? parentId = хвостId;

            do
            {
                // при первой итерации в ветку добавляется сначала хвост
                // при последующих итерациях в ветку добавляются родитель хвоста, родитель-родителя хвоста и т.д.
                // пока не будет достигнут корневой объект ветки
                ветка.Add((int) parentId);
                // находим очередной объект 
                var obj = ПолучитьОбъектДереваПоИд(parentId, модель);
                parentId = obj.parent; // получаем ссылку на следующего родителя
                // rights = [...obj.RightDescriptions]
                // path = '\\' + $"[id:{obj.id}]" + obj.ObjectName + path;
            } while (parentId != null);

            // разворачиваем список ветки, потому что элементы идут от последнего к первому, 
            // а надо наоборот от первого к последнему -
            // именно в такой последовательности они будут записаны в базу данных
            ветка.Reverse();
            return ветка;
        }
        
        ProfileObject ПолучитьОбъектДереваПоИд(int? ид, IEnumerable<ProfileObject?> модель) 
            => 
                модель.First(v => v.id == ид);
        
        int НайтиИдРодителяИзБД(int листId, IEnumerable<ProfileObject?> модель, int идРесурса)
        {
            var parent = ПолучитьОбъектДереваПоИд(листId, модель).parent;
            return (int) (parent == null
                // если лист не имеет родительских объектов,
                // тогда это корневой объект и должен цепляться напрямую к ресурсу
                ? идРесурса
                // иначе его надо прицепить к iddb уже созданного объекта
                : ПолучитьОбъектДереваПоИд(parent, модель).iddb);
        }

        private IEnumerable<int?> ПолучитьХвосты(IEnumerable<ProfileObject?> модель) 
            =>
            модель
                .Where(v => модель.All(v1 => v1.parent != v.id))
                .Select(v => v.id);

        /// <summary>
        /// 
        /// </summary>
        public class PROFILE_STRUCT
        {
            public PROFILE_STRUCT()
            {
                Objects = new List<OBJECT_STRUCT>();
            }
        
            public class OBJECT_STRUCT
            {
                public OBJECT? Object;
                public List<RIGHT>? Rights;
            }

            public REQUEST? Request;
            public PROFILE? Profile;
            public readonly List<OBJECT_STRUCT>? Objects;

            public object ПолучитьОбъектРезультата() 
                =>
                new
                {
                    _request = new
                    {
                        Request?.id
                    },
                    _profile = new
                    {
                        requestId = Profile?.id_request_1,
                        Profile?.id,
                        Profile?.name,
                        
                        _objects = Objects?.ConvertAll(o 
                            => new 
                            {
                                _object = new
                                {
                                    requestId = o.Object?.id_request_1,
                                    o.Object?.id,
                                    o.Object?.name,
                        
                                    _rights = o.Rights?.ConvertAll(r 
                                        => new
                                        {
                                            _right = new
                                            {
                                                requestId = r.id_request_1,
                                                r.id,
                                                r.id_object,
                                                r.id_profile,
                                                r.id_right_descr
                                            }
                                        })
                                } 
                            })
                    }
                };
        }
    }
}