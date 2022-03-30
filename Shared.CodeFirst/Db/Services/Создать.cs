using System;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Shared.Db.Services
{
    public partial class Common_Service
    {
        public T? Создать<T>(T entity) where T : class {
            if (typeof(T) == typeof(DIC)) { return _dicRepository?.Создать(entity as DIC) as T; }
            if (typeof(T) == typeof(FIO)) { return _fioRepository?.Создать(entity as FIO) as T; }
            if (typeof(T) == typeof(REQUEST)) { return _requestRepository?.Создать(entity as REQUEST) as T; }
            if (typeof(T) == typeof(EMPLOYEE)) { return _employeeRepository?.Создать(entity as EMPLOYEE) as T; }
            if (typeof(T) == typeof(AC_ACCESS)) { return _acAccessRepository?.Создать(entity as AC_ACCESS) as T; }
            if (typeof(T) == typeof(EMPLOYEE_IN_ORG)) { return _employeeInOrgRepository?.Создать(entity as EMPLOYEE_IN_ORG) as T; }
            if (typeof(T) == typeof(OBJECT)) { return _objectRepository?.Создать(entity as OBJECT) as T; }
            if (typeof(T) == typeof(RESOURCE)) { return _resourceRepository?.Создать(entity as RESOURCE) as T; }
            if (typeof(T) == typeof(PROFILE)) { return _profileRepository?.Создать(entity as PROFILE) as T; }
            if (typeof(T) == typeof(RIGHT)) { return _rightRepository?.Создать(entity as RIGHT) as T; }
            if (typeof(T) == typeof(MEMBER)) { return _memberRepository?.Создать(entity as MEMBER) as T; }
            if (typeof(T) == typeof(LOGIN)) { return _loginRepository?.Создать(entity as LOGIN) as T; }
            if (typeof(T) == typeof(RESOURCE_MEMBER)) { return _resourceMembersRepository?.Создать(entity as RESOURCE_MEMBER) as T; }
            if (typeof(T) == typeof(DOC)) { return _docRepository?.Создать(entity as DOC) as T; }
            
            throw new Exception($"не написан код для обработки типа {typeof(T)}");
        }
    }
}