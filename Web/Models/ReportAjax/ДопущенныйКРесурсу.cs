using System;
using QWERTY.Shared.Db.Entities.Представления;
using QWERTY.Shared.Extensions;
using QWERTY.Shared.Атрибуты;

namespace QWERTY.Web.Models.ReportAjax
{
/*
    public class ДопущенныйКРесурсу
    {
        [DataTableColumn(name: "Ид ресурса")] public string id_resource { get; }
        [DataTableColumn(name: "Структурная единица")] public string org_name { get; set; }
        [DataTableColumn(name: "ФИО")] public string fio_full { get; }
        [DataTableColumn(name: "Табельный номер")] public string tnum { get; }
        [DataTableColumn(name: "Должность")] public string job_name { get; }
        [DataTableColumn(name: "Логин")] public string login { get; }
        [DataTableColumn(name: "Форма допуска")] public string form_perm { get; }


        public ДопущенныйКРесурсу(VIEW_OBJECT_USER_RIGHTS_DISTINCTED r)
        {
            if (r.id_login.IsNotNullZeroOrLess())
            {
                org_name = r.СТРУКТУРНАЯ_ЕДИНИЦА_ПОЛЬЗОВАТЕЛЯ?.fname.IfNullReturnStringEmpty();
                id_resource = r.id_resource.IfNullReturnStringEmpty();
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
                id_resource = r.id_resource.IfNullReturnStringEmpty();
                fio_full = string.Empty;
                tnum = string.Empty;
                job_name = string.Empty;
                login = string.Empty;
                form_perm = string.Empty;
                return;
            }
            throw new ArgumentNullException(paramName: $"ошибочное значение параметров: {nameof(r.id_login)} = {r.id_login}, {nameof(r.id_org)} = {r.id_org}");
        }



        public override string ToString()
        {
            return $"{{ id = {id_resource}, fio_full = {fio_full}, job_name = {job_name}, login = {login}, form_perm = {form_perm} }}";
        }
    }
*/
}
