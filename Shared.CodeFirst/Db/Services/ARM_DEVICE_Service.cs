using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using QWERTY.Shared.Db.Entities.Представления;
using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Enums;

namespace QWERTY.Shared.Db.Services
{
    public partial interface ICommonService // в прошлом IARM_DEVICE_Service
    {
        #region ARM
        //--------------------------------------------------------------------------------------------------------------
        ARM? ПолучитьАРМпоРегНомеру(string регНомер);
        IEnumerable<ARM>? _ПолучитьАРМы(Expression<Func<ARM, bool>> @where);
        List<ARM> ПолучитьАРМы(Expression<Func<ARM, bool>> where);
        List<ARM> ПолучитьАРМы(Expression<Func<ARM, bool>> where, DateTime? data);
        List<ARM> ПолучитьВсеАРМы(DateTime? data = null);
        
        //--------------------------------------------------------------------------------------------------------------
        #endregion


        #region VIEW_ARM_ROOM_USER
        //--------------------------------------------------------------------------------------------------------------
        IEnumerable<VIEW_ARM_ROOM_USER>? ПолучитьАРМы_из_представления(
            Expression<Func<VIEW_ARM_ROOM_USER, bool>> @where);
        IEnumerable<VIEW_ARM_ROOM_USER>? ПолучитьСуществующиеАРМы(DateTime? data = null);
        //--------------------------------------------------------------------------------------------------------------
        #endregion


        #region AC_ACCESS
        //--------------------------------------------------------------------------------------------------------------
        AC_ACCESS? СоздатьДопускСотрудникавАС(AC_ACCESS допуск);
        IEnumerable<AC_ACCESS>? ПолучитьВсеДопускивАС(Expression<Func<AC_ACCESS, bool>> expression);
        List<AC_ACCESS> ПолучитьВсеДопускивАС();
        List<AC_ACCESS> ПолучитьВсехДопущенныхкРаботевАС();
        //--------------------------------------------------------------------------------------------------------------
        #endregion


        #region ARM_USER_ROLE
        //--------------------------------------------------------------------------------------------------------------
        IEnumerable<ARM_USER_ROLE>? ПолучитьВсеРолиПользователейАрмов();
        ARM_USER_ROLE? ПолучитьРольПользователяАрмаПоНазванию(string названиеРоли);
        //--------------------------------------------------------------------------------------------------------------
        #endregion


        #region VIEW_AC_ACCESS_ORG
        //--------------------------------------------------------------------------------------------------------------
        List<VIEW_AC_ACCESS_ORG> ПолучитьДопущенныхкРаботевАС_OLD(Query_mode? mode, DateTime? data = null);
        //--------------------------------------------------------------------------------------------------------------
        #endregion


        #region VIEW_REPORT_AC_ACCESS (ОТЧЁТ)
        List<VIEW_REPORT_AC_ACCESS> ПолучитьДопущенныхкРаботевАС(int idOrg);
        IEnumerable<VIEW_REPORT_AC_ACCESS>? ПолучитьВсеДопускивАС_через_представление(
            Expression<Func<VIEW_REPORT_AC_ACCESS, bool>> @where);
        IEnumerable<VIEW_REPORT_AC_ACCESS>? ПолучитьСуществующиеДопускиАС(DateTime? data);
        IEnumerable<VIEW_REPORT_AC_ACCESS>? ПолучитьДопущенныхкРаботевАС(Query_mode? mode, DateTime? data = null);
        #endregion


        #region ARM_USER
        //--------------------------------------------------------------------------------------------------------------
        ARM_USER? СоздатьДопускСотрудникаНаАрм(ARM_USER допуск);
        IEnumerable<ARM_USER>? ПолучитьВсеДопускиНаАРМы(Expression<Func<ARM_USER, bool>> @where);
        IEnumerable<ARM_USER> ПолучитьДопускиПользователейНаАРМы(DateTime? data = null);

        public IEnumerable<VIEW_ARM_USER>? ПолучитьДопускиПользователейНаАРМы(
            Expression<Func<VIEW_ARM_USER, bool>> @where);
        public IEnumerable<VIEW_ARM_USER>? ПолучитьСуществующиеДопускиПользователейНаАРМы(DateTime? data = null);
        //--------------------------------------------------------------------------------------------------------------

        #endregion
    }
    public partial class Common_Service // ARM_DEVICE_Service : IARM_DEVICE_Service
    {
        public ARM? ПолучитьАРМпоРегНомеру(string регНомер) =>
            _armRepository?.Найти(a => a.рег_номер_арма == регНомер);

        public IEnumerable<ARM>? _ПолучитьАРМы(Expression<Func<ARM, bool>> @where) => _armRepository?.GetMany(where);

        public List<ARM> ПолучитьАРМы(Expression<Func<ARM, bool>> @where) => (_ПолучитьАРМы(@where) ?? Array.Empty<ARM>()).ToList();

        public List<ARM> ПолучитьАРМы(Expression<Func<ARM, bool>> @where, DateTime? data)
        {
            throw new NotImplementedException();
            /*return _linqHelpers.НаДату(ПолучитьАРМы(@where), data);*/
        }

        public List<ARM> ПолучитьВсеАРМы(DateTime? data = null) => ПолучитьАРМы(r=> true, data).ToList();
        
        /*var arms = _ArmUserDeviceService.ПолучитьАРМы(where).ToList();
            return data == null ? arms.ToList() : arms.Where(r => LinqHelpers.НаДату(r, (DateTime) data)).ToList();*/

        public IEnumerable<VIEW_ARM_ROOM_USER>? ПолучитьАРМы_из_представления(
            Expression<Func<VIEW_ARM_ROOM_USER, bool>> @where) =>
            _viewArmRoomUserRepository?.GetMany(@where);

        public IEnumerable<VIEW_ARM_ROOM_USER>? ПолучитьСуществующиеАРМы(DateTime? data = null) => _linqHelpers?.СуществуетНаДату
            (ПолучитьАРМы_из_представления
            (r => true), data);
        
        public AC_ACCESS? СоздатьДопускСотрудникавАС(AC_ACCESS допуск)
        {
            var r = _acAccessRepository?.Создать(допуск);
            _acAccessRepository?.Коммитнуть();
            return r;
        }

        public IEnumerable<ARM_USER_ROLE>? ПолучитьВсеРолиПользователейАрмов() => _armUserRoleRepository?.GetAll();
        public ARM_USER_ROLE? ПолучитьРольПользователяАрмаПоНазванию(string названиеРоли) =>
            _armUserRoleRepository?.Найти(a => string.Equals(a.name, названиеРоли, StringComparison.OrdinalIgnoreCase));

        public IEnumerable<AC_ACCESS>? ПолучитьВсеДопускивАС(Expression<Func<AC_ACCESS, bool>> expression) => _acAccessRepository?.GetMany(expression);
        public List<AC_ACCESS> ПолучитьВсеДопускивАС() => (ПолучитьВсеДопускивАС(r => true) ?? Array.Empty<AC_ACCESS>()).ToList();

        public IEnumerable<VIEW_REPORT_AC_ACCESS>? ПолучитьВсеДопускивАС_через_представление
            (Expression<Func<VIEW_REPORT_AC_ACCESS, bool>> @where) => _viewReportAcAccessRepository?.GetMany(@where);

        public IEnumerable<VIEW_REPORT_AC_ACCESS>? ПолучитьСуществующиеДопускиАС(DateTime? data) =>
            _linqHelpers?.СуществуетНаДату(
                    ПолучитьВсеДопускивАС_через_представление(r => true),
                    data);

        public List<VIEW_REPORT_AC_ACCESS> ПолучитьДопущенныхкРаботевАС(int idOrg)
        {
            throw new NotImplementedException();
            /*return ПолучитьВсеДопускивАС_через_представление(r => r. == idOrg;*/
        }

        public IEnumerable<VIEW_REPORT_AC_ACCESS>? ПолучитьДопущенныхкРаботевАС(Query_mode? mode,
            DateTime? data = null)
        {
            try
            {
                return ПолучитьСуществующиеДопускиАС(data);
                
                IEnumerable<VIEW_REPORT_AC_ACCESS> list;
                mode ??= Query_mode.Все;
                
                
                // todo: выборка по Query_mode не работает
                return (List<VIEW_REPORT_AC_ACCESS>) (mode switch
                {
                    Query_mode.Все => ПолучитьСуществующиеДопускиАС(data),
                    // нужен ID_ORG подразделения из представления VIEW_AC_ACCESS_ORG
                    Query_mode.По_подразделению => throw new NotImplementedException(),
                    // нужен ID_ORG отдела из представления VIEW_AC_ACCESS_ORG
                    Query_mode.По_отделу => throw new NotImplementedException(),
                    _ => throw new ArgumentOutOfRangeException(nameof(mode), mode, null)
                });
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
        }
        
        public List<VIEW_AC_ACCESS_ORG> ПолучитьДопущенныхкРаботевАС_OLD(Query_mode? mode, DateTime? data = null)
        {
            throw new NotImplementedException();
        }

        public ARM_USER? СоздатьДопускСотрудникаНаАрм(ARM_USER допуск)
        {
            var r = _armUserRepository?.Создать(допуск);
            _armUserRepository?.Коммитнуть();
            return r;
        }

        public List<AC_ACCESS> ПолучитьВсехДопущенныхкРаботевАС()
        {
            try
            {
                var accesses = _acAccessRepository?.GetAll();
                return (accesses ?? Array.Empty<AC_ACCESS>()).Where(r => r.ид_заявки_прекращения_допуска == null && r.ид_заявки_разрешения_допуска != 0).ToList();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }

        public IEnumerable<ARM_USER>? ПолучитьВсеДопускиНаАРМы(Expression<Func<ARM_USER, bool>> @where) => _armUserRepository?.GetMany(where);
        public IEnumerable<ARM_USER> ПолучитьДопускиПользователейНаАРМы(DateTime? data = null)
        {
            throw new NotImplementedException();
            /*return _linqHelpers.НаДату(ПолучитьВсеДопускиНаАРМы(r => true), data);*/
        }

        public IEnumerable<VIEW_ARM_USER>? ПолучитьДопускиПользователейНаАРМы(
            Expression<Func<VIEW_ARM_USER, bool>> @where) => 
            _viewArmUserRepository?.GetMany(@where);

        public IEnumerable<VIEW_ARM_USER>? ПолучитьСуществующиеДопускиПользователейНаАРМы(DateTime? data = null) => _linqHelpers?.СуществуетНаДату
                (ПолучитьДопускиПользователейНаАРМы
                (r => true), data);


        /*return data == null ? допуски.ToList() : допуски.Where(r => LinqHelpers.НаДату(r, (DateTime) data)).ToList();*/
    }
}
