using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DBPSA.Shared.Db.Entities;
using DBPSA.Shared.Db.Entities.Представления;

namespace DBPSA.Web.Core.Db
{
    /// <summary>
    /// IemployeeService
    /// </summary>
    public partial class ОбщиеСервисы
    {
    //--------------------------------------------------------------------------------------------------------------
        #region EMPLOYEE
        protected List<EMPLOYEE> ПолучитьВсехНачальниковОтделений() => _EmployeeService.ПолучитьВсехНачальниковОтделений().ToList();
        protected IEnumerable<EMPLOYEE>ПолучитьСотрудников(Expression<Func<EMPLOYEE, bool>> where) => _EmployeeService.ПолучитьСотрудников(where);
        protected List<EMPLOYEE> ПолучитьВсехСотрудников() => ПолучитьСотрудников(r => true).ToList();
        protected List<EMPLOYEE> ПолучитьВсехСотрудниковДляВыпадающегоСписка() => 
            ПолучитьВсехСотрудников().OrderBy(m=> m.Фамилия + " " + m.Имя + " " + m.Отчество).ToList();
        
        protected List<EMPLOYEE> ПолучитьВсехСотрудниковОтделения(EMPLOYEE руководительОтделения)
        {
            var всеСотрудникиОтделения = new List<EMPLOYEE>();
            foreach (var структура in руководительОтделения.Отделение.ДочерниеСтруктуры)
            {
                всеСотрудникиОтделения.AddRange(структура.СотрудникиВСтруктуре1.Select(r=> r.Сотрудник));
            }

            return всеСотрудникиОтделения.ToList();
        }

        protected EMPLOYEE ПолучитьНачальникаОтделенияСотрудника(int табельныйНомерСотрудника)
        {
            var местоРаботыСотрудника = ПолучитьМестоРаботыСотрудника(табельныйНомерСотрудника);
            return ПолучитьНачальникаОтделенияСотрудника(местоРаботыСотрудника);
        }

        protected EMPLOYEE ПолучитьНачальникаОтделенияСотрудника(ORG местоРаботыСотрудника)
        {
            var место = местоРаботыСотрудника;
            while (место.ID_PARENT != null)
            {
                место = место.ORG_PARENT;
            }

            return место.БОСС;
        }

        protected EMPLOYEE ПолучитьНачальникаСотрудника(int табельныйНомерСотрудника) => 
            ПолучитьПользователяВСтруктуре(табельныйНомерСотрудника)?.ORG?.БОСС;

        protected EMPLOYEE ПолучитьСотрудникаПоИд(int ид) => _ПолучитьСотрудника(r => r.ID == ид);

        protected EMPLOYEE ПолучитьСотрудника(int табельныйНомер) =>
            _ПолучитьСотрудника(r => r.ТабельныйНомер == табельныйНомер);

        protected EMPLOYEE _ПолучитьСотрудника(Func<EMPLOYEE, bool> where) => _EmployeeService.ПолучитьСотрудника(@where);


        protected int ПолучитьТабельныйНомер(string логин)
        {
            var расширенныйEmployee = _ПолучитьРасширенныйEMPLOYEE(r => r.LOGIN_NAME == логин);
            return расширенныйEmployee?.TNUM ?? 0;
        }

        protected VIEW_EMPLOYEE_EXT _ПолучитьРасширенныйEMPLOYEE(Func<VIEW_EMPLOYEE_EXT, bool> where) => 
            _EmployeeService.ПолучитьРасширенныйEMPLOYEE(@where);

        protected void УдалитьСотрудника(EMPLOYEE сотрудник) => _EmployeeService.УдалитьСотрудникаБезКоммита(сотрудник);
        
        #endregion
        //--------------------------------------------------------------------------------------------------------------

        #region EMPLOYEE_IN_ORG

        protected EMPLOYEE_IN_ORG ПолучитьПользователяВСтруктуре(int табельныйНомерСотрудника)
        {
            var сотрудник = ПолучитьСотрудника(табельныйНомерСотрудника);
            return _ПолучитьПользователяВСтруктуре(r => r.ID_USER == сотрудник.ID);
        }

        protected EMPLOYEE_IN_ORG _ПолучитьПользователяВСтруктуре(Func<EMPLOYEE_IN_ORG, bool> where) =>
            _EmployeeService.ПолучитьПользователяВСтруктуре(where);

        #endregion

        //--------------------------------------------------------------------------------------------------------------
        #region ROOM
        protected List<ROOM> ПолучитьВсеПомещения() => _EmployeeService.ПолучитьПомещения(r=> true).ToList();
        #endregion
    //--------------------------------------------------------------------------------------------------------------
        #region LOGIN
        protected IEnumerable<LOGIN> ПолучитьВсеЛогины() => _EmployeeService.ПолучитьВсеЛогины().ToList();    
        #endregion
    //--------------------------------------------------------------------------------------------------------------
        #region ORG
        protected List<ORG> ПолучитьСтруктуруОрганизации() => _EmployeeService.ПолучитьСтруктуруОрганизации(r=> true).ToList();

        protected ORG ПолучитьМестоРаботыСотрудника(int табельныйНомер) => ПолучитьПользователяВСтруктуре(табельныйНомер).ORG;

        #endregion
    //--------------------------------------------------------------------------------------------------------------
    }
}