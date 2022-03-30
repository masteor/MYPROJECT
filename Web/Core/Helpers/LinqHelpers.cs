using System;
using System.Collections.Generic;
using System.Linq;
using DBPSA.Shared.Db.Entities;
using DBPSA.Shared.Db.Entities.Представления;
using DBPSA.Shared.Db.Entities.Таблицы;

namespace DBPSA.Web.Core.Helpers
{
    public static class LinqHelpers
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="acAccessOrg"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        /*public static bool НаДату(VIEW_OBJECT_USER_RIGHTS_DISTINCTED acAccessOrg, DateTime data) =>
            НаДату(data, acAccessOrg?.ЗаявкаПредоставленияДоступаСубъектуК_Профилю?.ДатаЗавершения,
            acAccessOrg?.ЗАЯВКА_ПРЕКРАЩЕНИЯ_ДОСТУПА_СУБЪЕКТУ_К_ПРОФИЛЮ?.ДатаЗавершения);*/
        /// <summary>
        ///
        /// </summary>
        /// <param name="acAccessOrg"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        /*public static bool НаДату(VIEW_AC_ACCESS_ORG acAccessOrg, DateTime data) => НаДату
            (data, acAccessOrg?.ЗаявкаРазрешенияДопуска?.ДатаЗавершения, acAccessOrg?.ЗаявкаПрекращенияДопуска?.ДатаЗавершения);*/
        /// <summary>
        ///
        /// </summary>
        /// <param name="armUser"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        /*public static bool НаДату(ARM_USER armUser, DateTime data) => НаДату
            (data, armUser?.ЗаявкаРазрешенияДопуска?.ДатаЗавершения, armUser?.ЗаявкаПрекращенияДопуска?.ДатаЗавершения);*/
        /// <summary>
        ///
        /// </summary>
        /// <param name="arm"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        /*public static bool НаДату(ARM arm, DateTime data) => НаДату
            (data, arm?.ЗАЯВКА_ПОСТАНОВКИ_НА_УЧЁТ?.ДатаЗавершения, arm?.ЗАЯВКА_СНЯТИЕ_С_УЧЁТА?.ДатаЗавершения);*/
        /// <summary>
        ///
        /// </summary>
        /// <param name="enumerable"></param>
        /// <param name="data"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static List<T> НаДату<T>(IEnumerable<T> enumerable, DateTime? data)
        {
            return data == null ? enumerable.ToList() : enumerable.Where(r => НаДату(r, (DateTime) data)).ToList();

            /*if (typeof(T) == typeof(ARM)) { return enumerable.Where(r => НаДату(r as ARM, _data)).ToList(); }
            if (typeof(T) == typeof(VIEW_OBJECT_USER_RIGHTS_DISTINCTED)) { return enumerable.Where(r => НаДату(r as VIEW_OBJECT_USER_RIGHTS_DISTINCTED, _data)).ToList(); }
            if (typeof(T) == typeof(VIEW_AC_ACCESS_ORG)) { return enumerable.Where(r => НаДату(r as VIEW_AC_ACCESS_ORG, _data)).ToList(); }
            if (typeof(T) == typeof(ARM_USER)) { return enumerable.Where(r => НаДату(r as ARM_USER, _data)).ToList(); }
            if (typeof(T) == typeof(VIEW_ARM_ROOM_USER)) { return enumerable.Where(r => НаДату(r as VIEW_ARM_ROOM_USER, _data)).ToList(); }

            throw new NotImplementedException($"Нет реализации для данного типа {typeof(T)}");*/
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="viewArmRoomUser"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        /*public static bool НаДату(VIEW_ARM_ROOM_USER viewArmRoomUser, DateTime data) => НаДату
            (data, viewArmRoomUser?.ДАТА_ПОСТАНОВКИ_НА_УЧЁТ, viewArmRoomUser?.ДАТА_СНЯТИЯ_С_УЧЁТА);*/
        /// <summary>
        ///
        /// </summary>
        /// <param name="sdfsdf"></param>
        /// <param name="data"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool НаДату<T>(T entity, DateTime data)
        {
            if (typeof(T) == typeof(ARM)) { return НаДату(data,
                (entity as ARM)?.ЗАЯВКА_ПОСТАНОВКИ_НА_УЧЁТ?.дата_завершения,
                (entity as ARM)?.ЗАЯВКА_СНЯТИЯ_С_УЧЁТА?.дата_завершения); }

            if (typeof(T) == typeof(VIEW_OBJECT_USER_RIGHTS_DISTINCTED)) { return НаДату(data,
                (entity as VIEW_OBJECT_USER_RIGHTS_DISTINCTED)?.ЗАЯВКА_ПРЕДОСТАВЛЕНИЯ_ДОСТУПА_СУБЪЕКТУ_К_ПРОФИЛЮ?.дата_завершения,
                (entity as VIEW_OBJECT_USER_RIGHTS_DISTINCTED)?.ЗАЯВКА_ПРЕКРАЩЕНИЯ_ДОСТУПА_СУБЪЕКТУ_К_ПРОФИЛЮ?.дата_завершения); }

            if (typeof(T) == typeof(VIEW_AC_ACCESS_ORG)) { return НаДату(data,
                (entity as VIEW_AC_ACCESS_ORG)?.ЗАЯВКА_РАЗРЕШЕНИЯ_ДОПУСКА?.дата_завершения,
                (entity as VIEW_AC_ACCESS_ORG)?.ЗАЯВКА_ПРЕКРАЩЕНИЯ_ДОПУСКА?.дата_завершения); }

            if (typeof(T) == typeof(ARM_USER)) { return НаДату(data,
                (entity as ARM_USER)?.ЗАЯВКА_РАЗРЕШЕНИЯ_ДОПУСКА?.дата_завершения,
                (entity as ARM_USER)?.ЗАЯВКА_ПРЕКРАЩЕНИЯ_ДОПУСКА?.дата_завершения); }

            if (typeof(T) == typeof(VIEW_ARM_ROOM_USER)) { return НаДату(data,
                (entity as VIEW_ARM_ROOM_USER)?.дата_постановки_на_учёт,
                (entity as VIEW_ARM_ROOM_USER)?.дата_снятия_с_учёта); }

            if (typeof(T) == typeof(RESOURCE)) { return НаДату(data,
                    (entity as RESOURCE)?.ЗАЯВКА_НА_СОЗДАНИЕ?.дата_завершения,
                    (entity as RESOURCE)?.ЗАЯВКА_НА_УДАЛЕНИЕ?.дата_завершения); }

            throw new NotImplementedException($"Нет реализации для данного типа {typeof(T)}");
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="data"></param>
        /// <param name="датаРазрешения"></param>
        /// <param name="датаПрекращения"></param>
        /// <returns></returns>
        private static bool НаДату(DateTime data, DateTime? датаРазрешения, DateTime? датаПрекращения)
        {
            if (датаРазрешения == null) return false; // нет даты завершения заявки на разрешение допуска, то нет и допуска
            if (датаПрекращения == null) датаПрекращения = DateTime.MaxValue;
            return DateTime.Compare(data, датаРазрешения.Value) > 0 && DateTime.Compare(data, датаПрекращения.Value) < 0;
        }
    }
}
