using System;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using QWERTY.Shared.Db.Services;
using QWERTY.Web.Core;
using QWERTY.Web.Core.Authentication;

using QWERTY.Web.Properties;

namespace QWERTY.Web.Controllers
{
    [Authorize(Roles = ServiceRoles.User)]
    public class HomeController : WebBaseController
    {
        private new readonly ICommonService _commonService;
        public HomeController(ICommonService commonService)
        {
            _commonService = commonService;
        }
        
        public ActionResult Index()
        {
                // получаем идентификатор текущего пользователя, который запустил веб-приложение
                var domainAccount = User.Identity.Name;

                if (string.IsNullOrWhiteSpace(domainAccount)) throw new Exception("Пользователь не авторизован");

                // получаем роли пользователя на основе идентификатора
                var roles = AppRoleProvider.GetRolesForUser(domainAccount: domainAccount);

                var e = _commonService
                    .ПолучитьДанныеПользователяПоСуществующемуЛогинуИзПредставления(
                        ЛогинПользователяСервиса 
                        ?? string.Empty);

                var settingsFragment = (string)Properties.Settings.Default.FRAGMENT;
                Console.WriteLine(settingsFragment);

                var fragment =
                    _commonService
                        .ПолучитьФрагмент(r => r.prefix == settingsFragment)
                    ?? throw new ArgumentException(
                        $"Префикс фрагмента {Properties.Settings.Default.FRAGMENT} не найден в БД," +
                        $" указан ли префикс фрагмента в настройках программы? Указан ли префикс фрагмента в БД?");
                
                Console.WriteLine(fragment?.fname);

                // формируем модель для передачи во фронт-приложение (QWERTY.Frontend)
                object model = JsonConvert.SerializeObject(value: 
                    new {
                        roles, 
                        domainAccount,
                        fio = e?.fio_full,
                        fragment = fragment,
                        idUser = e?.id_user
                        
                    });
                
                Console.WriteLine(model);
                Log?.Info($"В систему заходит пользователь: {model}");
                
                // передаем модель в представление \Views\Home\Index.cshtml и отображаем его в браузере
                return View("Index", model);
        }
    }
}