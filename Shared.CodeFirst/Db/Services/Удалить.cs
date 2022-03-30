using System;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Shared.Db.Services
{
    public partial class Common_Service
    {
        public void Удалить<T>(T entity)
        {
            if (typeof(T) == typeof(DIC)) { _dicRepository.Удалить(entity as DIC); return; }
            if (typeof(T) == typeof(AC_ACCESS)) { _acAccessRepository.Удалить(entity as AC_ACCESS); return; }
            if (typeof(T) == typeof(AC_FRAGMENT)) { _acFragmentRepository.Удалить(entity as AC_FRAGMENT); return; }
            if (typeof(T) == typeof(ARM_DEVICE)) { _armDeviceRepository.Удалить(entity as ARM_DEVICE); return; }
            if (typeof(T) == typeof(ARM)) { _armRepository.Удалить(entity as ARM); return; }
            if (typeof(T) == typeof(ARM_USER)) { _armUserRepository.Удалить(entity as ARM_USER); return; }
            if (typeof(T) == typeof(ARM_USER_ROLE)) { _armUserRoleRepository.Удалить(entity as ARM_USER_ROLE); return; }
            if (typeof(T) == typeof(BUILDING)) { _buildingRepository.Удалить(entity as BUILDING); return; }
            if (typeof(T) == typeof(DEVICE_PERM)) { _devicePermRepository.Удалить(entity as DEVICE_PERM); return; }
            if (typeof(T) == typeof(DEVICE)) { _deviceRepository.Удалить(entity as DEVICE); return; }
            if (typeof(T) == typeof(DEVICE_TYPE)) { _deviceTypeRepository.Удалить(entity as DEVICE_TYPE); return; }
            if (typeof(T) == typeof(DOC)) { _docRepository.Удалить(entity as DOC); return; }
            if (typeof(T) == typeof(DOC_TYPE)) { _docTypeRepository.Удалить(entity as DOC_TYPE); return; }
            if (typeof(T) == typeof(EMPLOYEE_IN_ORG)) { _employeeInOrgRepository.Удалить(entity as EMPLOYEE_IN_ORG); return; }
            if (typeof(T) == typeof(EMPLOYEE)) { _employeeRepository.Удалить(entity as EMPLOYEE); return; }
            if (typeof(T) == typeof(EXECUTION)) { _executionRepository.Удалить(entity as EXECUTION); return; }
            if (typeof(T) == typeof(FIO)) { _fioRepository.Удалить(entity as FIO); return; }
            if (typeof(T) == typeof(FORM_PERM)) { _formPermRepository.Удалить(entity as FORM_PERM); return; }
            if (typeof(T) == typeof(JOB)) { _jobRepository.Удалить(entity as JOB); return; }
            if (typeof(T) == typeof(LOGIN)) { _loginRepository.Удалить(entity as LOGIN); return; }
            if (typeof(T) == typeof(MEMBER)) { _memberRepository.Удалить(entity as MEMBER); return; }
            if (typeof(T) == typeof(NOTIFY_REQUEST)) { _notifyRequestRepository.Удалить(entity as NOTIFY_REQUEST); return; }
            if (typeof(T) == typeof(NOTIFY_SUB)) { _notifySubRepository.Удалить(entity as NOTIFY_SUB); return; }
            if (typeof(T) == typeof(OBJECT)) { _objectRepository.Удалить(entity as OBJECT); return; }
            if (typeof(T) == typeof(OBJECT_TYPE)) { _objectTypeRepository.Удалить(entity as OBJECT_TYPE); return; }
            if (typeof(T) == typeof(ORG)) { _orgRepository.Удалить(entity as ORG); return; }
            if (typeof(T) == typeof(ORG_UNIT_TYPE)) { _orgUnitTypeRepository.Удалить(entity as ORG_UNIT_TYPE); return; }
            if (typeof(T) == typeof(PROFILE)) { _profileRepository.Удалить(entity as PROFILE); return; }
            if (typeof(T) == typeof(PROM_AREA)) { _promAreaRepository.Удалить(entity as PROM_AREA); return; }
            if (typeof(T) == typeof(REQUEST)) { _requestRepository.Удалить(entity as REQUEST); return; }
            if (typeof(T) == typeof(REQUEST_STATE)) { _requestStateRepository.Удалить(entity as REQUEST_STATE); return; }
            if (typeof(T) == typeof(REQUEST_TYPE)) { _requestTypeRepository.Удалить(entity as REQUEST_TYPE); return; }
            if (typeof(T) == typeof(REQUEST_TYPE_STAFF)) { _requestTypeStaffRepository.Удалить(entity as REQUEST_TYPE_STAFF); return; }
            if (typeof(T) == typeof(RESOURCE)) { _resourceRepository.Удалить(entity as RESOURCE); return; }
            if (typeof(T) == typeof(RESOURCE_RESP)) { _resourceRespRepository.Удалить(entity as RESOURCE_RESP); return; }
            if (typeof(T) == typeof(RESOURCE_UCA)) { _resourceUcaRepository.Удалить(entity as RESOURCE_UCA); return; }
            if (typeof(T) == typeof(RIGHT_DESCR)) { _rightDescriptionRepository.Удалить(entity as RIGHT_DESCR); return; }
            if (typeof(T) == typeof(RIGHT_GROUP)) { _rightGroupRepository.Удалить(entity as RIGHT_GROUP); return; }
            if (typeof(T) == typeof(RIGHT_OBJECT_TYPE)) { _rightObjectTypeRepository.Удалить(entity as RIGHT_OBJECT_TYPE); return; }
            if (typeof(T) == typeof(RIGHT)) { _rightRepository.Удалить(entity as RIGHT); return; }
            if (typeof(T) == typeof(ROOM)) { _roomRepository.Удалить(entity as ROOM); return; }
            if (typeof(T) == typeof(RSO)) { _rsoRepository.Удалить(entity as RSO); return; }
            if (typeof(T) == typeof(SECRET_TYPE)) { _secretTypeRepository.Удалить(entity as SECRET_TYPE); return; }
            if (typeof(T) == typeof(SERVICE)) { _serviceRepository.Удалить(entity as SERVICE); return; }
            if (typeof(T) == typeof(SERVICE_TYPE)) { _serviceTypeRepository.Удалить(entity as SERVICE_TYPE); return; }
            if (typeof(T) == typeof(STAFF)) { _staffRepository.Удалить(entity as STAFF); return; }
            if (typeof(T) == typeof(STAFF_UNIT)) { _staffUnitRepository.Удалить(entity as STAFF_UNIT); return; }
            if (typeof(T) == typeof(UCA_LIST)) { _ucaListRepository.Удалить(entity as UCA_LIST); return; }
            if (typeof(T) == typeof(USER_ROOM)) { _userRoomRepository.Удалить(entity as USER_ROOM); return; }

            throw new Exception($"не написан код для обработки типа {typeof(T)}");
        }
    }
}