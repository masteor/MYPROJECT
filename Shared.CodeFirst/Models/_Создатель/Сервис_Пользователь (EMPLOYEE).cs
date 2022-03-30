using System;
using QWERTY.Shared.Db.Services;

namespace QWERTY.Shared.Models._Создатель
{
    public partial class Создатель<T> where T : ДанныеИзФормы
    {
        private protected void ПроверитьСуществованиеПользователя(ICommonService commonService, int id)
        {
            if (commonService.ПолучитьПользователя(e => e.id == id) == null)
            {
                throw new ArgumentNullException($"Пользователь с id={id} не существует");
            }
        }
    }
}