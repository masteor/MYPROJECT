using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using QWERTY.Shared.Db.Entities;
using QWERTY.Shared.Db.Entities.Представления;
using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Db.Запросы;

namespace QWERTY.Shared.Db.Services
{
    public partial interface ICommonService // IEMPLOYEE_Service
    {
        
        #region EMPLOYEE // Сотрудники
        //--------------------------------------------------------------------------------------------------------------
        /*EMPLOYEE? ПолучитьНачальникаОтделенияСотрудника(int табельныйНомер);
        EMPLOYEE? ПолучитьНачальникаОтделенияСотрудника(ORG? местоРаботыСотрудника);*/
/*
        EMPLOYEE? ПолучитьНачальникаСотрудника(int табельныйНомер);
*/
        EMPLOYEE? ПолучитьСотрудникаПоИд(int ид);
        EMPLOYEE? ПолучитьСотрудника(int табельныйНомер);
        // VIEW_EMPLOYEE_LOGIN_PRD? ПолучитьДанныеПользователяПоЛогинуИзПредставленияPRD(string login);
        IEnumerable<VIEW_EMPLOYEE_LOGIN>? GET_VIEW_EMPLOYEE_LOGINS(Expression<Func<VIEW_EMPLOYEE_LOGIN, bool>> where);
        VIEW_EMPLOYEE_LOGIN? ПолучитьДанныеПользователяПоСуществующемуЛогинуИзПредставления(string? login);
        EMPLOYEE? ПолучитьПользователяПоЛогину(string? login);
        EMPLOYEE? ПолучитьПользователяПоИд(int? id);
        EMPLOYEE? ПолучитьПользователя(Func<EMPLOYEE, bool> where);
        // List<EMPLOYEE?>? ПолучитьСотрудниковВПомещении(ROOM помещение);
/*
        List<EMPLOYEE>? ПолучитьВсехНачальниковОтделений();
*/
        IEnumerable<VIEW_OWNER>? ПолучитьВсехНачальниковОтделений();
        IEnumerable<EMPLOYEE>? _ПолучитьСотрудников(Expression<Func<EMPLOYEE, bool>> @where);
        IEnumerable<EMPLOYEE>? ПолучитьВсехСотрудников();
/*
        List<EMPLOYEE> ПолучитьВсехСотрудниковОтделения(EMPLOYEE руководительОтделения);
*/
        IEnumerable<VIEW_EMPLOYEE_FIO>? ПолучитьВсехДействующихСотрудниковДляВыпадающегоСписка();
        
        void УдалитьСотрудникаБезКоммита(EMPLOYEE сотрудник);
        EMPLOYEE? ПолучитьСотрудника(Func<EMPLOYEE, bool> @where);
        
        
        /*IEnumerable<VIEW_EMPLOYEE_PRD>? ПолучитьСотрудникаИзПредставленияPRD(
            Expression<Func<VIEW_EMPLOYEE_PRD, bool>> @where);*/
        
        int ПолучитьТабельныйНомер(string логин);
        
        //--------------------------------------------------------------------------------------------------------------
        #endregion
        

        #region BUILDING // Здания  
        //--------------------------------------------------------------------------------------------------------------
        IEnumerable<BUILDING>? ПолучитьВсеЗдания();
        //--------------------------------------------------------------------------------------------------------------
        #endregion
        

        #region ROOM // Помещения
        //--------------------------------------------------------------------------------------------------------------
        ROOM? ПолучитьПомещениеПоНомеруТелефона(string номерТелефона);
        ROOM? СоздатьПомещение(ROOM помещение);
        IEnumerable<ROOM>? ПолучитьПомещения(Expression<Func<ROOM, bool>> @where);
        List<ROOM> ПолучитьВсеПомещения();
        //--------------------------------------------------------------------------------------------------------------
        #endregion
        

        #region USER_ROOM // СотрудникиВПомещениях
        //--------------------------------------------------------------------------------------------------------------
        USER_ROOM? ПривязатьСотрудникаКПомещению(USER_ROOM сотрудникВПомещении);
        //--------------------------------------------------------------------------------------------------------------
        #endregion
        

        #region FIO // ФИО
        //--------------------------------------------------------------------------------------------------------------
        IEnumerable<FIO>? ПолучитьВсеФИО();
        IEnumerable<VIEW_FIO> ПолучитьСуществующиеФИО(Expression<Func<VIEW_FIO, bool>> where, DateTime? dateTime);
        
        FIO? ПолучитьФИО(Func<FIO, bool> func);
        //--------------------------------------------------------------------------------------------------------------
        #endregion
        

        #region LOGIN // Логин
        //--------------------------------------------------------------------------------------------------------------
        LOGIN? СоздатьЛогин(LOGIN логин);
        IEnumerable<LOGIN>? ПолучитьВсеЛогины();
        IEnumerable<LOGIN>? ПолучитьВсеЛогиныПользователя(int id_user);
        
        LOGIN? ПолучитьЛогин(Func<LOGIN, bool> func);

        LOGIN? ПолучитьЛогинПоИмениЛогина(string? имяЛогина);
        //--------------------------------------------------------------------------------------------------------------
        #endregion


        #region FORM_PERM
        //--------------------------------------------------------------------------------------------------------------
        List<FORM_PERM>? ПолучитьВсеФормыДопуска();
        //--------------------------------------------------------------------------------------------------------------
        #endregion


        #region ORG
        //--------------------------------------------------------------------------------------------------------------
        IEnumerable<ORG>? ПолучитьСтруктуруОрганизации(Expression<Func<ORG, bool>> @where);
        List<ORG> ПолучитьСтруктуруОрганизации();
        List<ORG> ПолучитьВсеОтделы();
        List<ORG> ПолучитьВсеОтделения();
/*
        ORG? ПолучитьМестоРаботыСотрудника(int табельныйНомер);
*/
        ORG? ПолучитьОргСтруктуру(Func<ORG, bool> func);
        
        //--------------------------------------------------------------------------------------------------------------
        #endregion
        

        #region EMPLOYEE_IN_ORG
        //--------------------------------------------------------------------------------------------------------------
        EMPLOYEE_IN_ORG? ПолучитьПользователяВСтруктуре(Func<EMPLOYEE_IN_ORG, bool> @where);
        EMPLOYEE_IN_ORG? ПолучитьПользователяВСтруктуре(int табельныйНомер);
        //--------------------------------------------------------------------------------------------------------------
        #endregion


        #region VIEW_EMPLOYEE_EXT
        //--------------------------------------------------------------------------------------------------------------
        VIEW_EMPLOYEE_EXT? ПолучитьРасширенныйEMPLOYEE(Func<VIEW_EMPLOYEE_EXT,bool> @where);
        //--------------------------------------------------------------------------------------------------------------
        #endregion
        

        #region JOB
        //--------------------------------------------------------------------------------------------------------------
        List<JOB>? ПолучитьВсеДолжности();
        //--------------------------------------------------------------------------------------------------------------
        #endregion
    }

    public partial class Common_Service // EMPLOYEE_Service : IEMPLOYEE_Service
    {
        /*public EMPLOYEE? ПолучитьНачальникаОтделенияСотрудника(int табельныйНомер) => 
            ПолучитьНачальникаОтделенияСотрудника(ПолучитьМестоРаботыСотрудника(табельныйНомер));

        public EMPLOYEE? ПолучитьНачальникаОтделенияСотрудника(ORG? местоРаботыСотрудника)
        {
            var место = местоРаботыСотрудника;
            while (место?.id_parent != null) {
                место = место.ORG_PARENT;
            }
            return место?.БОСС;
        }*/

/*
        public EMPLOYEE? ПолучитьНачальникаСотрудника(int табельныйНомер) => 
            ПолучитьПользователяВСтруктуре(табельныйНомер)?.ORG.БОСС;
*/

        public EMPLOYEE? ПолучитьСотрудникаПоИд(int ид) => ПолучитьСотрудника(r => r.id == ид);
        public EMPLOYEE? ПолучитьСотрудника(int табельныйНомер) => ПолучитьСотрудника(r => r.tnum == табельныйНомер);

        /*public VIEW_EMPLOYEE_LOGIN_PRD? ПолучитьДанныеПользователяПоЛогинуИзПредставленияPRD(string login)
        {
            try
            {
                var viewEmployeeLogin = _viewEmployeeLoginPrdRepository?
                    .Найти(v => string.Equals(v.login, login, StringComparison.OrdinalIgnoreCase));
                
                return viewEmployeeLogin;
            }
            catch (Exception e)
            {
                throw new Exception($"Не могу получить пользователя с login: {login}", e);
            } 
        }*/

        public IEnumerable<VIEW_EMPLOYEE_LOGIN>? GET_VIEW_EMPLOYEE_LOGINS(
            Expression<Func<VIEW_EMPLOYEE_LOGIN, bool>> @where) 
            => 
                _viewEmployeeLoginRepository?.GetMany(@where);

        public VIEW_EMPLOYEE_LOGIN? ПолучитьДанныеПользователяПоСуществующемуЛогинуИзПредставления(string? login)
            =>
                _viewEmployeeLoginRepository?
                    .Найти(r =>
                    string.Equals(r.login_name, login, StringComparison.OrdinalIgnoreCase));

        public EMPLOYEE? ПолучитьПользователяПоЛогину(string? login)
        {
            try
            {
                var idUser = string.IsNullOrWhiteSpace(login)
                    ? null
                    : _loginRepository
                        ?.Найти(e => string.Equals(e.name, login, StringComparison.OrdinalIgnoreCase))
                        .id_user;

                var employee = _employeeRepository?.Найти(e => e.id == idUser);
                
                return employee;
            }
            catch (Exception e)
            {
                throw new Exception($"Не могу получить пользователя с login: {login}", e);
            }
            

            // todo: заглушка, исправить после тестирования
            /*return new EMPLOYEE
            {
                id = 999999,
                tnum = 99515,
            };*/
        }

        public EMPLOYEE? ПолучитьПользователяПоИд(int? id) 
            => 
                ПолучитьПользователя(e => e.id == id);

        public EMPLOYEE? ПолучитьПользователя(Func<EMPLOYEE, bool> @where)
        {
            try
            {
                return _employeeRepository?.Найти(where);
            }
            catch (Exception e)
            {
                throw new Exception($"Не могу получить пользователя в методе {nameof(ПолучитьПользователя)}", e);
            }
        }

/*
        public List<EMPLOYEE?>? ПолучитьСотрудниковВПомещении(ROOM помещение) =>
            _userRoomRepository?.GetMany(r => r.id_room == помещение.id)
                .Select(room => room.EMPLOYEE).ToList();
*/

        public IEnumerable<EMPLOYEE>? _ПолучитьСотрудников(Expression<Func<EMPLOYEE, bool>> @where) => _employeeRepository?.GetMany(@where);
        
        public IEnumerable<EMPLOYEE>? ПолучитьВсехСотрудников() => _ПолучитьСотрудников(r => true);
/*
        public List<EMPLOYEE> ПолучитьВсехСотрудниковОтделения(EMPLOYEE руководительОтделения)
        {
            var всеСотрудникиОтделения = new List<EMPLOYEE>();
            foreach (var структура in руководительОтделения.Отделение.ДОЧЕРНИЕ_СТРУКТУРЫ) {
                всеСотрудникиОтделения.AddRange(структура.СОТРУДНИКИ_В_СТРУКТУРЕ_1.Select(r=> r.СОТРУДНИК));
            }
            return всеСотрудникиОтделения.ToList();
        }
*/

        public IEnumerable<VIEW_EMPLOYEE_FIO>? ПолучитьВсехДействующихСотрудниковДляВыпадающегоСписка() =>
            _viewEmployeeFioRepository?.GetContext().ViewEmployeeFios
                .SqlQuery(Запрос.ViewEmployeeFio.Select);

        public List<ORG> ПолучитьСтруктуруОрганизации() 
            =>
                (ПолучитьСтруктуруОрганизации(r=> true) ?? Array.Empty<ORG>()).ToList();
        
        public List<ORG> ПолучитьВсеОтделы() => (ПолучитьСтруктуруОрганизации(r => r.id_parent != null) ?? Array.Empty<ORG>()).ToList();
        
        public List<ORG> ПолучитьВсеОтделения() => (ПолучитьСтруктуруОрганизации(r => r.id_parent == null) ?? Array.Empty<ORG>()).ToList();

/*
        public ORG? ПолучитьМестоРаботыСотрудника(int табельныйНомер) 
            => ПолучитьПользователяВСтруктуре(табельныйНомер)?.ORG;
*/
        
        public ORG? ПолучитьОргСтруктуру(Func<ORG, bool> func) 
            => _orgRepository?.Найти(func);

        public EMPLOYEE_IN_ORG? ПолучитьПользователяВСтруктуре(Func<EMPLOYEE_IN_ORG, bool> @where) 
            => _employeeInOrgRepository?.Найти(@where);

        public EMPLOYEE_IN_ORG? ПолучитьПользователяВСтруктуре(int табельныйНомер) =>
            ПолучитьПользователяВСтруктуре(r => r.id_user == ПолучитьСотрудника(табельныйНомер)!.id);

        public EMPLOYEE? ПолучитьСотрудника(Func<EMPLOYEE, bool> @where) => _employeeRepository?.Найти(@where);
        
        /*public IEnumerable<VIEW_EMPLOYEE_PRD>? ПолучитьСотрудникаИзПредставленияPRD(
            Expression<Func<VIEW_EMPLOYEE_PRD, bool>> @where) 
            => 
                _viewEmployeePrdRepository?.GetMany(@where);*/

        public int ПолучитьТабельныйНомер(string логин) =>
            ПолучитьРасширенныйEMPLOYEE(r =>
                string.Equals(r.login_name, логин, StringComparison.OrdinalIgnoreCase))?.tnum ?? 0;
        
        public VIEW_EMPLOYEE_EXT? ПолучитьРасширенныйEMPLOYEE(Func<VIEW_EMPLOYEE_EXT, bool> @where) 
            =>
            _viewEmployeeExtRepository?.Найти(@where);
        
        public List<JOB>? ПолучитьВсеДолжности() => _jobRepository?.GetAll().ToList();

/*
        public List<EMPLOYEE>? ПолучитьВсехНачальниковОтделений() 
            => 
            _orgRepository?
                .GetMany(x => x.id_parent == null && x.id_user_boss != 0)
                .Select(y => y.БОСС).ToList();
*/
        
        public IEnumerable<VIEW_OWNER>? ПолучитьВсехНачальниковОтделений() => 
            _viewOwnerRepository?.GetAll();

        public IEnumerable<BUILDING>? ПолучитьВсеЗдания() => _buildingRepository?.GetAll().ToList();
        
        public ROOM? ПолучитьПомещениеПоНомеруТелефона(string номерТелефона) => 
            _roomRepository?.Найти(r=> string.Equals(r.wphone, номерТелефона, StringComparison.OrdinalIgnoreCase));

        public ROOM? СоздатьПомещение(ROOM помещение)
        {
            var r= _roomRepository?.Создать(помещение);
            _roomRepository?.Коммитнуть();
            return r;
        }

        public IEnumerable<ROOM>? ПолучитьПомещения(Expression<Func<ROOM, bool>> @where) => _roomRepository?.GetMany(where);
        public List<ROOM> ПолучитьВсеПомещения() => (ПолучитьПомещения(r=> true) ?? Array.Empty<ROOM>()).ToList();

        public USER_ROOM? ПривязатьСотрудникаКПомещению(USER_ROOM сотрудникВПомещении)
        {
            var r = _userRoomRepository?.Создать(сотрудникВПомещении);
            _userRoomRepository?.Коммитнуть();
            return r;
        }

        public IEnumerable<FIO>? ПолучитьВсеФИО() => _fioRepository?.GetAll();
        
        public IEnumerable<VIEW_FIO> ПолучитьСуществующиеФИО(Expression<Func<VIEW_FIO, bool>> @where, DateTime? dateTime) => 
            _linqHelpers?.СуществуетНаДату(_viewFioRepository!.GetMany(@where), dateTime)!;

        public FIO? ПолучитьФИО(Func<FIO, bool> func) => _fioRepository?.Найти(func);

        public LOGIN? СоздатьЛогин(LOGIN логин)
        {
            var r = _loginRepository?.Создать(логин);
            _loginRepository?.Коммитнуть();
            return r;
        }

        public IEnumerable<LOGIN>? ПолучитьВсеЛогины() => _loginRepository?.GetAll();
        
        public IEnumerable<LOGIN>? ПолучитьВсеЛогиныПользователя(int id_user) 
            => 
                _loginRepository?.GetMany(l => l.id_user == id_user);

        public LOGIN? ПолучитьЛогин(Func<LOGIN, bool> func) => _loginRepository?.Найти(func);
        
        public LOGIN? ПолучитьЛогинПоИмениЛогина(string? имяЛогина) 
            => ПолучитьЛогин(login => string.Equals(login.name, имяЛогина, StringComparison.OrdinalIgnoreCase));

        public List<FORM_PERM>? ПолучитьВсеФормыДопуска() => _formPermRepository?.GetAll().ToList();

        public void УдалитьСотрудникаБезКоммита(EMPLOYEE сотрудник) => _employeeRepository?.Удалить(сотрудник);

        public IEnumerable<ORG>? ПолучитьСтруктуруОрганизации(Expression<Func<ORG, bool>> @where) => 
            _orgRepository?.GetMany(@where);
    }
}