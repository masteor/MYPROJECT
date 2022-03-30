using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using QWERTY.Shared.Db.Entities.Представления;

namespace QWERTY.Shared.Db.Services
{
    public partial interface ICommonService
    {
        IEnumerable<VIEW_STAFF_UNIT_LOGINS>? ПолучитьРолиСотрудникаПоЛогину(
            Expression<Func<VIEW_STAFF_UNIT_LOGINS, bool>> @where);
    }

    public partial class Common_Service
    {
        public IEnumerable<VIEW_STAFF_UNIT_LOGINS>? ПолучитьРолиСотрудникаПоЛогину(
            Expression<Func<VIEW_STAFF_UNIT_LOGINS, bool>> @where) 
            => 
                _viewStaffUnitLoginsRepository?.GetMany(@where);
    }
}