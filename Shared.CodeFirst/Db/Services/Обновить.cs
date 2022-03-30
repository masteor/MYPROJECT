using System;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Shared.Db.Services
{
    public partial class Common_Service
    {
        public void Обновить<T>(T entity)
        {
            if (typeof(T) == typeof(DIC)) { _dicRepository?.Обновить(entity as DIC); return; }
            if (typeof(T) == typeof(AC_ACCESS)) { _acAccessRepository?.Обновить(entity as AC_ACCESS); return; }
            if (typeof(T) == typeof(AC_FRAGMENT)) { _acFragmentRepository?.Обновить(entity as AC_FRAGMENT); return; }
            if (typeof(T) == typeof(ARM_DEVICE)) { _armDeviceRepository?.Обновить(entity as ARM_DEVICE); return; }
            if (typeof(T) == typeof(ARM)) { _armRepository?.Обновить(entity as ARM); return; }
            if (typeof(T) == typeof(ARM_USER)) { _armUserRepository?.Обновить(entity as ARM_USER); return; }
            if (typeof(T) == typeof(ARM_USER_ROLE)) { _armUserRoleRepository?.Обновить(entity as ARM_USER_ROLE); return; }
            if (typeof(T) == typeof(BUILDING)) { _buildingRepository?.Обновить(entity as BUILDING); return; }
            if (typeof(T) == typeof(DEVICE_PERM)) { _devicePermRepository?.Обновить(entity as DEVICE_PERM); return; }
            if (typeof(T) == typeof(DEVICE)) { _deviceRepository?.Обновить(entity as DEVICE); return; }
            if (typeof(T) == typeof(DEVICE_TYPE)) { _deviceTypeRepository?.Обновить(entity as DEVICE_TYPE); return; }
            if (typeof(T) == typeof(DOC)) { _docRepository?.Обновить(entity as DOC); return; }
            if (typeof(T) == typeof(DOC_TYPE)) { _docTypeRepository?.Обновить(entity as DOC_TYPE); return; }
            if (typeof(T) == typeof(EMPLOYEE_IN_ORG)) { _employeeInOrgRepository?.Обновить(entity as EMPLOYEE_IN_ORG); return; }
            if (typeof(T) == typeof(EMPLOYEE)) { _employeeRepository?.Обновить(entity as EMPLOYEE); return; }
            if (typeof(T) == typeof(EXECUTION)) { _executionRepository?.Обновить(entity as EXECUTION); return; }
            if (typeof(T) == typeof(FIO)) { _fioRepository?.Обновить(entity as FIO); return; }
            if (typeof(T) == typeof(FORM_PERM)) { _formPermRepository?.Обновить(entity as FORM_PERM); return; }
            if (typeof(T) == typeof(JOB)) { _jobRepository?.Обновить(entity as JOB); return; }
            if (typeof(T) == typeof(LOGIN)) { _loginRepository?.Обновить(entity as LOGIN); return; }
            if (typeof(T) == typeof(MEMBER)) { _memberRepository?.Обновить(entity as MEMBER); return; }
            if (typeof(T) == typeof(NOTIFY_REQUEST)) { _notifyRequestRepository?.Обновить(entity as NOTIFY_REQUEST); return; }
            if (typeof(T) == typeof(NOTIFY_SUB)) { _notifySubRepository?.Обновить(entity as NOTIFY_SUB); return; }
            if (typeof(T) == typeof(OBJECT)) { _objectRepository?.Обновить(entity as OBJECT); return; }
            if (typeof(T) == typeof(OBJECT_TYPE)) { _objectTypeRepository?.Обновить(entity as OBJECT_TYPE); return; }
            if (typeof(T) == typeof(ORG)) { _orgRepository?.Обновить(entity as ORG); return; }
            if (typeof(T) == typeof(ORG_UNIT_TYPE)) { _orgUnitTypeRepository?.Обновить(entity as ORG_UNIT_TYPE); return; }
            if (typeof(T) == typeof(PROFILE)) { _profileRepository?.Обновить(entity as PROFILE); return; }
            if (typeof(T) == typeof(PROM_AREA)) { _promAreaRepository?.Обновить(entity as PROM_AREA); return; }
            if (typeof(T) == typeof(REQUEST)) { _requestRepository?.Обновить(entity as REQUEST); return; }
            if (typeof(T) == typeof(REQUEST_STATE)) { _requestStateRepository?.Обновить(entity as REQUEST_STATE); return; }
            if (typeof(T) == typeof(REQUEST_TYPE)) { _requestTypeRepository?.Обновить(entity as REQUEST_TYPE); return; }
            if (typeof(T) == typeof(REQUEST_TYPE_STAFF)) { _requestTypeStaffRepository?.Обновить(entity as REQUEST_TYPE_STAFF); return; }
            if (typeof(T) == typeof(RESOURCE)) { _resourceRepository?.Обновить(entity as RESOURCE); return; }
            if (typeof(T) == typeof(RESOURCE_RESP)) { _resourceRespRepository?.Обновить(entity as RESOURCE_RESP); return; }
            if (typeof(T) == typeof(RESOURCE_UCA)) { _resourceUcaRepository?.Обновить(entity as RESOURCE_UCA); return; }
            if (typeof(T) == typeof(RIGHT_DESCR)) { _rightDescriptionRepository?.Обновить(entity as RIGHT_DESCR); return; }
            if (typeof(T) == typeof(RIGHT_GROUP)) { _rightGroupRepository?.Обновить(entity as RIGHT_GROUP); return; }
            if (typeof(T) == typeof(RIGHT_OBJECT_TYPE)) { _rightObjectTypeRepository?.Обновить(entity as RIGHT_OBJECT_TYPE); return; }
            if (typeof(T) == typeof(RIGHT)) { _rightRepository?.Обновить(entity as RIGHT); return; }
            if (typeof(T) == typeof(ROOM)) { _roomRepository?.Обновить(entity as ROOM); return; }
            if (typeof(T) == typeof(RSO)) { _rsoRepository?.Обновить(entity as RSO); return; }
            if (typeof(T) == typeof(SECRET_TYPE)) { _secretTypeRepository?.Обновить(entity as SECRET_TYPE); return; }
            if (typeof(T) == typeof(SERVICE)) { _serviceRepository?.Обновить(entity as SERVICE); return; }
            if (typeof(T) == typeof(SERVICE_TYPE)) { _serviceTypeRepository?.Обновить(entity as SERVICE_TYPE); return; }
            if (typeof(T) == typeof(STAFF)) { _staffRepository?.Обновить(entity as STAFF); return; }
            if (typeof(T) == typeof(STAFF_UNIT)) { _staffUnitRepository?.Обновить(entity as STAFF_UNIT); return; }
            if (typeof(T) == typeof(UCA_LIST)) { _ucaListRepository?.Обновить(entity as UCA_LIST); return; }
            if (typeof(T) == typeof(USER_ROOM)) { _userRoomRepository?.Обновить(entity as USER_ROOM); return; }

            throw new Exception($"не написан код для обработки типа {typeof(T)}");
        }
    }
}