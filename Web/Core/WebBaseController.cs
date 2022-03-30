using System;
using System.Web.Mvc;
using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Db.Services;
using QWERTY.Shared.Enums;
using QWERTY.Shared.Log;
using QWERTY.Shared.Models;
using QWERTY.Web.Core.Authentication;
using log4net;
using Resources = QWERTY.Web.Properties.Resources;
using QWERTY.Shared.Doc;
using QWERTY.Web.Properties;
using static QWERTY.Shared.Log.HelpLogger;

namespace QWERTY.Web.Core
{
    /// <summary>
    /// Базовый контроллер приложения.
    /// Общие поля и методы:
    ///     - ...
    /// </summary>
    public abstract class WebBaseController : Controller
    {
        protected readonly БуквенныеКодыТиповЗаявок БуквенныеКодыТиповЗаявок = new БуквенныеКодыТиповЗаявок();
        private protected readonly ICommonService CommonService;
        
        protected UserAccount? CurrentUserAccount
        {
            get
            {
                try
                {
                    return new UserAccount(User?.Identity?.Name);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        protected string? ЛогинПользователяСервиса => CurrentUserAccount?.Login;
        // private SessionHelper _sessionHelper;
        
        
        
        
        protected readonly ILog? Log;
        protected readonly ILogger? Logger;
        private readonly string AppDataPath;
        protected readonly AppRoleProvider AppRoleProvider;
        protected readonly DocPaths DocPaths;

        protected WebBaseController()
        {
            var r = Resolver;
            CommonService = (ICommonService) r.GetService(typeof(ICommonService));
            
            AppRoleProvider = new AppRoleProvider();
            AppDataPath = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();
            DocPaths = new DocPaths(AppDataPath, Settings.Default.templatesPath, Settings.Default.docsPath);
            
            Log = LogManager.GetLogger(GetType().Name) ?? throw new ArgumentNullException(nameof(Log), Resources.WebBaseController_WebBaseController_Log_не_зарегистрирован);
            Log.Info($"Log зарегистрирован в {GetType().Name}");
            Logger = new Logger(Log) ?? throw new ArgumentNullException(nameof(Logger), Resources.WebBaseController_WebBaseController_Logger_не_зарегистрирован);
        }

        /*protected override JsonResult Json(object data, string contentType, System.Text.Encoding contentEncoding,
            JsonRequestBehavior behavior)
        {
            return new FormattedJsonResult
            {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                JsonRequestBehavior = behavior
            };
        }*/

        protected JsonResult ExceptionJson(Exception ex, string name)
        {
            try
            {
                Log?.Error($"Ошибка в методе {name}", ex);
                return ExceptionJson(ex, name, null);
            }
            catch (Exception e)
            {
                Log?.Error($"Ошибка в методе {nameof(ExceptionJson)}", e);
            }

            return Json(null, JsonRequestBehavior.AllowGet);
        }
        
        protected JsonResult ExceptionJson(Exception exception, string name, string? msg)
        {
            try
            {
                return Json(
                    JsonModel.СоздатьСообщениеОбОшибке(
                        null,
                        $"Ошибка в методе {name}: {msg ?? СобратьВсеПодчиненныеОшибки(exception)}"
                    ), JsonRequestBehavior.AllowGet
                );
            }
            catch (Exception e)
            {
                Log?.Error($"Ошибка в методе {nameof(ExceptionJson)}", e);
            }

            return Json(null, JsonRequestBehavior.AllowGet);
        }
        
        protected JsonResult JsonSuccess(object? data)
        {
            var jsonResult = Json
            (JsonModel.СоздатьУспешноеСообщение(data),
                JsonRequestBehavior.AllowGet);
            
            jsonResult.MaxJsonLength = Int32.MaxValue;

            return jsonResult;
        }

        /** Storongly-typed session access */
        // protected SessionHelper SessionHelper => _sessionHelper ??= new SessionHelper(Session);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="domainAccount"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        private string ПолучитьЛогинПользователяПоДоменнойУчетке(string? domainAccount) 
            =>
            new UserAccount(domainAccount).Login?.ToLower()
            ??
            throw new ArgumentNullException(nameof(domainAccount));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commonService"></param>
        /// <param name="log"></param>
        /// <param name="domainAccount"></param>
        /// <returns></returns>
        private EMPLOYEE? ПолучитьПользователяПоДоменнойУчетке(ICommonService? commonService, ILog? log, string? domainAccount)
        {
            var login = ПолучитьЛогинПользователяПоДоменнойУчетке(domainAccount);
            return ПользовательСервиса(commonService, log, login);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commonService"></param>
        /// <param name="log"></param>
        /// <param name="domainAccount"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        protected EMPLOYEE ПолучитьПользователяПоДоменнойУчеткеСоПроверкойThrow(ICommonService? commonService, ILog? log,
            string? domainAccount)
        {
            var employee = ПолучитьПользователяПоДоменнойУчетке(commonService, log, domainAccount) 
                           ?? throw new ArgumentNullException($"Не найден пользователь для доменной учётки {domainAccount}");

            if (employee.id < 1) throw new ArgumentOutOfRangeException(nameof(employee), @"id пользователя < 1");

            return employee;
        }


        private protected void ПроверитьПараметрИдЕслиНадоКинутьИсключение(int? значение, string? имяПараметра)
        {
            if (значение == null) throw new ArgumentNullException(имяПараметра);
            if (значение < 1) throw new ArgumentOutOfRangeException(имяПараметра + "должен быть > 0");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commonService"></param>
        /// <param name="log"></param>
        /// <param name="login"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        protected EMPLOYEE? ПользовательСервиса(ICommonService? commonService, ILog? log, string? login)
        {
            try
            {
                // ServiceRoles.ThrowIfNullOrWhiteSpace(login);

                // ищем действующий логин пользователя
                var viewEmployeeLogin =
                    commonService?.ПолучитьДанныеПользователяПоСуществующемуЛогинуИзПредставления(login);

                return commonService?.ПолучитьПользователя(e => e.id == viewEmployeeLogin?.id_user);
            }
            catch (Exception e)
            {
                log?.Error(e.Message, e);
            }

            return null;
        }

        protected void БроситьИсключениеЕслиАргументНуллИлиМеньшеЕдиницы(int? i, string argName)
        {
            if (i == null) throw new ArgumentNullException(argName);
            if (i < 1) throw new ArgumentOutOfRangeException(nameof(argName), i, @"Аргумент не может быть меньше 1");
        }
    }
}