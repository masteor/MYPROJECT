using System;
using System.Diagnostics;
using QWERTY.Shared.Db.Entities.Представления;
using QWERTY.Shared.Extensions;
using QWERTY.Shared.Атрибуты;

namespace QWERTY.Web.Models.ReportAjax
{
/*
    public class РесурсС_СубьектамиДоступа
    {
        [DataTableColumn(name: "№")] public int id { get; }
        [DataTableColumn(name: "Имя объекта ресурса")] public string resource_name { get; }
        [DataTableColumn(name: "Тип объекта")] public string object_type { get; set; }
        [DataTableColumn(name: "Имя профиля")] public string profile_name { get; set; }
        [DataTableColumn(name: "Структурная единица")] public string org_name { get; set; }
        [DataTableColumn(name: "ФИО")] public string fio_full { get; }
        [DataTableColumn(name: "Табельный номер")] public string tnum { get; }
        [DataTableColumn(name: "Должность")] public string job_name { get; }
        [DataTableColumn(name: "Логин")] public string login { get; set; }
        [DataTableColumn(name: "Форма допуска")] public string form_perm { get; }
        [DataTableColumn(name: "Дата предоставления доступа")] public string request_allow_date { get; set; }
        [DataTableColumn(name: "Дата прекращения доступа")] public string request_deny_date { get; set; }

        public РесурсС_СубьектамиДоступа(VIEW_OBJECT_USER_RIGHTS_DISTINCTED r)
        {
            try
            {
                id = r.id_object;

                resource_name = r.object_name.IfNullReturnStringEmpty();
                object_type = r.ТИП_ОБЪЕКТА?.name.IfNullReturnStringEmpty();
                profile_name = r.profile_name.IfNullReturnStringEmpty();
                request_allow_date = r.ЗАЯВКА_ПРЕДОСТАВЛЕНИЯ_ДОСТУПА_СУБЪЕКТУ_К_ПРОФИЛЮ?.дата_завершения.IfNullReturnStringEmpty();
                request_deny_date = r.ЗАЯВКА_ПРЕКРАЩЕНИЯ_ДОСТУПА_СУБЪЕКТУ_К_ПРОФИЛЮ?.дата_завершения.IfNullReturnStringEmpty();

                if (r.id_login.IsNotNullZeroOrLess())
                {
                    org_name = r.СТРУКТУРНАЯ_ЕДИНИЦА_ПОЛЬЗОВАТЕЛЯ?.fname.IfNullReturnStringEmpty();
                    fio_full = (r.name_1 + " " +  r.name_2 + " " + r.name_3).IfNullReturnStringEmpty();
                    tnum = r.tnum.IfNullReturnStringEmpty();
                    job_name = r.ДОЛЖНОСТЬ?.name.IfNullReturnStringEmpty();
                    login = r.login_name.IfNullReturnStringEmpty();
                    form_perm = r.ФОРМА_ДОПУСКА?.description.IfNullReturnStringEmpty();

                    return;
                }

                if (r.id_org.IsNotNullZeroOrLess())
                {
                    org_name = r.СТРУКТУРНАЯ_ЕДИНИЦА_С_ДОСТУПОМ?.fname.IfNullReturnStringEmpty();
                    fio_full = string.Empty;
                    tnum = string.Empty;
                    job_name = string.Empty;
                    login = string.Empty;
                    form_perm = string.Empty;
                    return;
                }

                throw new ArgumentNullException(paramName: $"ошибочное значение параметров: {nameof(r.id_login)} = {r.id_login}, {nameof(r.id_org)} = {r.id_org}");
            }
            catch (Exception e)
            {
                Debug.WriteLine(message: e.Message);
                throw;
            }
        }
    }
*/
}
