using System.Web.Mvc;
using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Db.Services;
using QWERTY.Web.Core.Authentication;
using QWERTY.Web.Core.Utils;

namespace QWERTY.Web.Core.ActionFilters
{
    public class SetupSessionValuesFilter : ActionFilterAttribute
    {
        /*private IEMPLOYEE_Service _employeeService = null;
        protected IEMPLOYEE_Service EMPLOYEE_SERVICE => _employeeService ?? (_employeeService = DependencyResolver.Current
                                                          .GetService<_EmployeeService>());*/
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var employeeService = DependencyResolver.Current.GetService<ICommonService>();
            base.OnActionExecuting(filterContext: filterContext);
            var curLogin = AuthUtils.GetCurrentUserLogin();
            
            var sessionHelper = new HttpSessionHelper(sessionState: filterContext.HttpContext.Session);
            sessionHelper.Action = filterContext.ActionDescriptor.ActionName;
            sessionHelper.Controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            
            // todo: пользователь не проверяется по базе, исправить в продакшн  
            // sessionHelper.CurrentUser = employeeService.ПолучитьПользователяПоЛогину(curLogin);
            sessionHelper.AddItem(name: "Login", value: new LOGIN { name = curLogin });
            sessionHelper.Login = curLogin;
            sessionHelper.CurrentUser = new EMPLOYEE
            {
                id = 1234567890,
                tnum = 1234567890
            };
            
            /*if (sessionHelper.CurrentUser == null)
                filterContext.Result = new HttpNotFoundResult(statusDescription: $"Пользователь '{curLogin}' не зарегистрирован!");
            else if (sessionHelper.CurrentUser.Удален)
                filterContext.Result = new HttpNotFoundResult(statusDescription: $"Пользователь '{curLogin}' удален!");*/
        }
    }
}