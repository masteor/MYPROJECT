using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using DBPSA.Shared.Db.Entities;
using DBPSA.Shared.Db.Entities.Представления;
using DBPSA.Web.Core.Enums;
using DBPSA.Web.Core.Helpers;

namespace DBPSA.Web.Core.Db
{
    public partial class ОбщиеСервисы
    {
    // =================================================================================================================
    #region AC_ACCESS
        protected List<AC_ACCESS> ПолучитьВсехДопущенныхкРаботевАС()
        {
            try
            {
                var accesses = _ArmUserDeviceService.ПолучитьВсехКомуПредоставлялсяДоступвАС();
                return accesses.Where(r => r.идЗаявкиПрекращенияДоступа == null && r.идЗаявкиРазрешенияДопуска != 0).ToList();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        protected List<VIEW_AC_ACCESS_ORG> ПолучитьДопущенныхкРаботевАС(Query_mode? mode, DateTime? data = null)
        {
            try
            {
                IEnumerable<VIEW_AC_ACCESS_ORG> list;
                /*Expression<Func<VIEW_AC_ACCESS_ORG, bool>> expression = m => true;*/
                mode = mode ?? Query_mode.Все;
                switch (mode)
                {
                    case Query_mode.Все:
                        list = _ArmUserDeviceService.ПолучитьВсеДопускивАС_через_представление(m => true);
                        break;
                    case Query_mode.По_подразделению:
                        // нужен ID_ORG подразделения из представления VIEW_AC_ACCESS_ORG
                        throw new NotImplementedException();
                    case Query_mode.По_отделу:
                        // нужен ID_ORG отдела из представления VIEW_AC_ACCESS_ORG 
                        throw new NotImplementedException();
                    default:
                        throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
                }

                return LinqHelpers.НаДату(list, data);
                /*return data == null ? list.ToList() : list.Where(r => LinqHelpers.НаДату(r, (DateTime) data)).ToList();*/
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idOrg"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        protected List<VIEW_AC_ACCESS_ORG> ПолучитьДопущенныхкРаботевАС(int idOrg) => 
            _ArmUserDeviceService.ПолучитьВсеДопускивАС_через_представление(r => r.ID_ORG == idOrg).ToList();

        protected List<AC_ACCESS> ПолучитьВсеДопускивАС() => new List<AC_ACCESS>(_ArmUserDeviceService.ПолучитьВсеДопускивАС(r => true));


        /// <summary>
        /// 
        /// </summary>
        /// <param name="допуск"></param>
        protected void УдалитьДопускСотрудникавАС(AC_ACCESS допуск) => Удалить(допуск);

    #endregion
    // =================================================================================================================
    #region ARM_USER
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data">дата, когда существует допуск, если null, тогда возвращает допуски без контроля дат</param>
        /// <returns></returns>
        protected List<ARM_USER> ПолучитьДопускиПользователейНаАРМы(DateTime? data = null)
        {
            return LinqHelpers.НаДату(_ArmUserDeviceService.ПолучитьВсеДопускиНаАРМы(r => true), data);
            /*return data == null ? допуски.ToList() : допуски.Where(r => LinqHelpers.НаДату(r, (DateTime) data)).ToList();*/
        }
    #endregion
    // =================================================================================================================
    #region ARM
        protected List<ARM> ПолучитьВсеАРМы(DateTime? data = null) => ПолучитьАРМы(r=> true, data).ToList();

        protected List<ARM> ПолучитьАРМы(Expression<Func<ARM, bool>> where, DateTime? data = null)
        {
            return LinqHelpers.НаДату(_ArmUserDeviceService.ПолучитьАРМы(where), data);
            /*var arms = _ArmUserDeviceService.ПолучитьАРМы(where).ToList();
            return data == null ? arms.ToList() : arms.Where(r => LinqHelpers.НаДату(r, (DateTime) data)).ToList();*/
        }
        
        protected List<VIEW_ARM_ROOM_USER> ПолучитьВсеАРМы_из_представления(DateTime? data = null)
        {
            return LinqHelpers.НаДату(_ArmUserDeviceService.ПолучитьАРМы_из_представления(r => true), data);
            /*var arms = _ArmUserDeviceService.ПолучитьАРМы_из_представления(r=> true).ToList();
            return data == null ? arms.ToList() : arms.Where(r => LinqHelpers.НаДату(r, (DateTime) data)).ToList();*/
        }
        #endregion
    // =================================================================================================================
        /*СоответствующиеДате(data ?? DateTime.Now)*/
    }
}