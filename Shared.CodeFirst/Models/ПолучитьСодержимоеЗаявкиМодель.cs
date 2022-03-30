using QWERTY.Shared.Db.Entities.Таблицы;
using log4net;

namespace QWERTY.Shared.Models
{
    public class ПолучитьСодержимоеЗаявкиМодель
    {
        /// <summary>
        /// Ид родительской заявки
        /// </summary>
        internal readonly int? idRequest;
        internal readonly string? requestTypeCode;
        internal readonly string? domainAccount;
        internal readonly EMPLOYEE employee;
        internal readonly bool isPrivileged;
        internal readonly ILog? log;

        public ПолучитьСодержимоеЗаявкиМодель(
            int? idRequest,
            string? requestTypeCode,
            string? domainAccount,
            EMPLOYEE employee,
            bool isPrivileged,
            ILog? log
        )
        {
            this.idRequest = idRequest;
            this.requestTypeCode = requestTypeCode;
            this.domainAccount = domainAccount;
            this.employee = employee;
            this.isPrivileged = isPrivileged;
            this.log = log;
        }
    }
}