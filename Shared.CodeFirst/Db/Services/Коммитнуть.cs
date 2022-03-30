using System;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Shared.Db.Services
{
    public partial class Common_Service
    {
        public void Коммитнуть(Type type)
        {
            if (type == typeof(DIC)) { _dicRepository?.Коммитнуть(); return; }
            if (type == typeof(AC_ACCESS)) { _acAccessRepository?.Коммитнуть(); return; }
            if (type == typeof(AC_FRAGMENT)) { _acFragmentRepository?.Коммитнуть(); return; }
            if (type == typeof(ARM_DEVICE)) { _armDeviceRepository?.Коммитнуть(); return; }
            if (type == typeof(ARM)) { _armRepository?.Коммитнуть(); return; }
            if (type == typeof(ARM_USER)) { _armUserRepository?.Коммитнуть(); return; }
            if (type == typeof(ARM_USER_ROLE)) { _armUserRoleRepository?.Коммитнуть(); return; }
            if (type == typeof(BUILDING)) { _buildingRepository?.Коммитнуть(); return; }
            if (type == typeof(DEVICE_PERM)) { _devicePermRepository?.Коммитнуть(); return; }
            if (type == typeof(DEVICE)) { _deviceRepository?.Коммитнуть(); return; }
            if (type == typeof(DEVICE_TYPE)) { _deviceTypeRepository?.Коммитнуть(); return; }
            if (type == typeof(DOC)) { _docRepository?.Коммитнуть(); return; }
            if (type == typeof(DOC_TYPE)) { _docTypeRepository?.Коммитнуть(); return; }
            if (type == typeof(EMPLOYEE_IN_ORG)) { _employeeInOrgRepository?.Коммитнуть(); return; }
            if (type == typeof(EMPLOYEE)) { _employeeRepository?.Коммитнуть(); return; }
            if (type == typeof(EXECUTION)) { _executionRepository?.Коммитнуть(); return; }
            if (type == typeof(FIO)) { _fioRepository?.Коммитнуть(); return; }
            if (type == typeof(FORM_PERM)) { _formPermRepository?.Коммитнуть(); return; }
            if (type == typeof(JOB)) { _jobRepository?.Коммитнуть(); return; }
            if (type == typeof(LOGIN)) { _loginRepository?.Коммитнуть(); return; }
            if (type == typeof(MEMBER)) { _memberRepository?.Коммитнуть(); return; }
            if (type == typeof(NOTIFY_REQUEST)) { _notifyRequestRepository?.Коммитнуть(); return; }
            if (type == typeof(NOTIFY_SUB)) { _notifySubRepository?.Коммитнуть(); return; }
            if (type == typeof(OBJECT)) { _objectRepository?.Коммитнуть(); return; }
            if (type == typeof(OBJECT_TYPE)) { _objectTypeRepository?.Коммитнуть(); return; }
            if (type == typeof(ORG)) { _orgRepository?.Коммитнуть(); return; }
            if (type == typeof(ORG_UNIT_TYPE)) { _orgUnitTypeRepository?.Коммитнуть(); return; }
            if (type == typeof(PROFILE)) { _profileRepository?.Коммитнуть(); return; }
            if (type == typeof(PROM_AREA)) { _promAreaRepository?.Коммитнуть(); return; }
            if (type == typeof(REQUEST)) { _requestRepository?.Коммитнуть(); return; }
            if (type == typeof(REQUEST_STATE)) { _requestStateRepository?.Коммитнуть(); return; }
            if (type == typeof(REQUEST_TYPE)) { _requestTypeRepository?.Коммитнуть(); return; }
            if (type == typeof(REQUEST_TYPE_STAFF)) { _requestTypeStaffRepository?.Коммитнуть(); return; }
            if (type == typeof(RESOURCE)) { _resourceRepository?.Коммитнуть(); return; }
            if (type == typeof(RESOURCE_MEMBER)) { _resourceMembersRepository?.Коммитнуть(); return; }
            if (type == typeof(RESOURCE_RESP)) { _resourceRespRepository?.Коммитнуть(); return; }
            if (type == typeof(RESOURCE_UCA)) { _resourceUcaRepository?.Коммитнуть(); return; }
            if (type == typeof(RIGHT_DESCR)) { _rightDescriptionRepository?.Коммитнуть(); return; }
            if (type == typeof(RIGHT_GROUP)) { _rightGroupRepository?.Коммитнуть(); return; }
            if (type == typeof(RIGHT_OBJECT_TYPE)) { _rightObjectTypeRepository?.Коммитнуть(); return; }
            if (type == typeof(RIGHT)) { _rightRepository?.Коммитнуть(); return; }
            if (type == typeof(ROOM)) { _roomRepository?.Коммитнуть(); return; }
            if (type == typeof(RSO)) { _rsoRepository?.Коммитнуть(); return; }
            if (type == typeof(SECRET_TYPE)) { _secretTypeRepository?.Коммитнуть(); return; }
            if (type == typeof(SERVICE)) { _serviceRepository?.Коммитнуть(); return; }
            if (type == typeof(SERVICE_TYPE)) { _serviceTypeRepository?.Коммитнуть(); return; }
            if (type == typeof(STAFF)) { _staffRepository?.Коммитнуть(); return; }
            if (type == typeof(STAFF_UNIT)) { _staffUnitRepository?.Коммитнуть(); return; }
            if (type == typeof(UCA_LIST)) { _ucaListRepository?.Коммитнуть(); return; }
            if (type == typeof(USER_ROOM)) { _userRoomRepository?.Коммитнуть(); return; }

            throw new Exception($"не написан код для обработки типа {type}");
        }
    }
}