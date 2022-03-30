using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using QWERTY.Shared.Db.Entities.Представления;
using QWERTY.Shared.Db.Repositories;
using QWERTY.Shared.Helpers;

namespace QWERTY.Shared.Db.Services
{
    public partial interface ICommonService
    {
        IVIEW_REPORT_ALL_RESOURCES_Repository? GET_VIEW_REPORT_ALL_RESOURCES_Repository();
        void Обновить<T>(T entity);
        void Коммитнуть(Type type);
        T? Создать<T>(T entity) where T : class;
        void Удалить<T>(T entity);
        
        IEnumerable<T>? ПолучитьДействующие<T>(IEnumerable<T>? enumerable, DateTime? dateTime) where T : Requested;
    }

    public partial class Common_Service : ICommonService
    {
        #region Fields
        //--------------------------------------------------------------------------------------------------------------
        private readonly IDIC_Repository? _dicRepository;
        private readonly IAC_ACCESS_Repository? _acAccessRepository;
        private readonly IAC_FRAGMENT_Repository? _acFragmentRepository;
        private readonly IARM_DEVICE_Repository? _armDeviceRepository;
        private readonly IARM_Repository? _armRepository;
        private readonly IARM_USER_Repository? _armUserRepository;
        private readonly IARM_USER_ROLE_Repository? _armUserRoleRepository;
        private readonly IBUILDING_Repository? _buildingRepository;
        private readonly IDEVICE_PERM_Repository? _devicePermRepository;
        private readonly IDEVICE_Repository? _deviceRepository;
        private readonly IDEVICE_TYPE_Repository? _deviceTypeRepository;
        private readonly IDOC_Repository? _docRepository;
        private readonly IDOC_TYPE_Repository? _docTypeRepository;
        private readonly IEMPLOYEE_IN_ORG_Repository? _employeeInOrgRepository;
        private readonly IEMPLOYEE_Repository? _employeeRepository;
        private readonly IEXECUTION_Repository? _executionRepository;
        private readonly IFIO_Repository? _fioRepository;
        private readonly IFORM_PERM_Repository? _formPermRepository;
        private readonly IJOB_Repository? _jobRepository;
        private readonly ILOGIN_Repository? _loginRepository;
        private readonly IMEMBER_Repository? _memberRepository;
        private readonly INOTIFY_REQUEST_Repository? _notifyRequestRepository;
        private readonly INOTIFY_SUB_Repository? _notifySubRepository;
        private readonly IOBJECT_Repository? _objectRepository;
        private readonly IOBJECT_TYPE_Repository? _objectTypeRepository;
        private readonly IORG_Repository? _orgRepository;
        private readonly IORG_UNIT_TYPE_Repository? _orgUnitTypeRepository;
        private readonly IPROFILE_Repository? _profileRepository;
        private readonly IPROM_AREA_Repository? _promAreaRepository;
        private readonly IREQUEST_Repository? _requestRepository;
        private readonly IREQUEST_STATE_Repository? _requestStateRepository;
        private readonly IREQUEST_TYPE_Repository? _requestTypeRepository;
        private readonly IREQUEST_TYPE_STAFF_Repository? _requestTypeStaffRepository;
        private readonly IRESOURCE_Repository? _resourceRepository;
        private readonly IRESOURCE_MEMBERS_Repository? _resourceMembersRepository;
        private readonly IRESOURCE_RESP_Repository? _resourceRespRepository;
        private readonly IRESOURCE_UCA_Repository? _resourceUcaRepository;
        private readonly IRIGHT_DESCRIPTION_Repository? _rightDescriptionRepository;
        private readonly IRIGHT_GROUP_Repository? _rightGroupRepository;
        private readonly IRIGHT_OBJECT_TYPE_Repository? _rightObjectTypeRepository;
        private readonly IRIGHT_Repository? _rightRepository;
        private readonly IROOM_Repository? _roomRepository;
        private readonly IRSO_Repository? _rsoRepository;
        private readonly ISECRET_TYPE_Repository? _secretTypeRepository;
        private readonly ISERVICE_Repository? _serviceRepository;
        private readonly ISERVICE_TYPE_Repository? _serviceTypeRepository;
        private readonly ISTAFF_Repository? _staffRepository;
        private readonly ISTAFF_UNIT_Repository? _staffUnitRepository;
        private readonly IUCA_LIST_Repository? _ucaListRepository;
        private readonly IUSER_ROOM_Repository? _userRoomRepository;
        private readonly IVIEW_AC_ACCESS_ORG_Repository? _viewAcAccessOrgRepository;
        private readonly IVIEW_ARM_ROOM_USER_Repository? _viewArmRoomUserRepository;
        private readonly IVIEW_EMPLOYEE_EXT_Repository? _viewEmployeeExtRepository;
        private readonly IVIEW_OBJECT_USER_RIGHTS_DISTINCTED_Repository? _viewObjectUserRightsDistinctedRepository;
        private readonly IVIEW_OBJECT_USER_RIGHTS_Repository? _viewObjectUserRightsRepository;
        private readonly IVIEW_RESOURCE_USER_RIGHT_Repository? _viewResourceUserRightRepository;
        private readonly IVIEW_RESOURCE_EXT_Repository? _viewResourceExtRepository;
        private readonly IVIEW_REPORT_AC_ACCESS_Repository? _viewReportAcAccessRepository;
        private readonly IVIEW_REPORT_ALL_RESOURCES_Repository? _viewReportAllResourcesRepository;
        private readonly IVIEW_ARM_USER_Repository? _viewArmUserRepository;
        private readonly IVIEW_REPORT_RSD_Repository? _viewReportRsdRepository;
        private readonly IVIEW_EMPLOYEE_FIO_Repository? _viewEmployeeFioRepository;
        private readonly IVIEW_OWNER_Repository? _viewOwnerRepository;
        private readonly IVIEW_PROFILE_Repository? _viewProfileRepository;
        private readonly IVIEW_RESOURCES_BY_OT_ST_Repository? _viewResourcesByOtStRepository;
        private readonly IVIEW_FIO_Repository? _viewFioRepository;
        private readonly IVIEW_REPORT_ALL_REQUESTS_Repository? _viewReportAllRequestsRepository;
        private readonly IVIEW_STAFF_UNIT_LOGINS_Repository? _viewStaffUnitLoginsRepository;
        private readonly IVIEW_EMPLOYEE_LOGIN_Repository? _viewEmployeeLoginRepository;
        private readonly IVIEW_EMPLOYEE_Repository? _viewEmployeeRepository;
        private readonly IVIEW_RESOURCE_Repository? _viewResourceRepository;
        private readonly IVIEW_RESOURCE_MEMBER_EMPLOYEE_Repository? _iviewResourceMemberEmployeeRepository;
        private readonly IVIEW_RESOURCE_MEMBER_ORG_Repository? _viewResourceMemberOrgRepository;
        private readonly IVIEW_REPORT_RESOURCES_WHERE_AM_I_Repository? _viewReportResourcesWhereAmIRepository;
        private readonly IVIEW_PROFILE_OBJECT_RIGHT_Repository? _viewProfileObjectRightRepository;
        private readonly IVIEW_REPORT_ALL_PROFILES_Repository? _viewReportAllProfilesRepository;
        private readonly IVIEW_RIGHT_DESCR_Repository? _viewRightDescrRepository;
        private readonly IVIEW_MEMBER_USER_Repository? _viewMemberUserRepository;
        private readonly IVIEW_MEMBER_ORG_Repository? _viewMemberOrgRepository;

        // test
        public readonly ITest_Repository? _testRepository;
        
        //
        private readonly ILinqHelpers? _linqHelpers;
        
        // PRD
        /*private readonly IVIEW_REPORT_ALL_RESOURCES_FROM_PRD_Repository? _viewReportAllResourcesFromPrdRepository;
        private readonly IVIEW_REPORT_RSD_FROM_PRD_Repository? _viewReportRsdFromPrdRepository;
        private readonly IVIEW_EMPLOYEE_LOGIN_PRD__Repository? _viewEmployeeLoginPrdRepository;
        private readonly IVIEW_EMPLOYEE_PRD__Repository? _viewEmployeePrdRepository;*/
        
        //--------------------------------------------------------------------------------------------------------------
        #endregion

        #region Конструктор
        //--------------------------------------------------------------------------------------------------------------
        public Common_Service(
            IDIC_Repository dicRepository,
            IAC_ACCESS_Repository acAccessRepository,
            IAC_FRAGMENT_Repository acFragmentRepository,
            IARM_DEVICE_Repository armDeviceRepository,
            IARM_Repository armRepository,
            IARM_USER_Repository armUserRepository,
            IARM_USER_ROLE_Repository armUserRoleRepository,
            IBUILDING_Repository buildingRepository,
            IDEVICE_PERM_Repository devicePermRepository,
            IDEVICE_Repository deviceRepository,
            IDEVICE_TYPE_Repository deviceTypeRepository,
            IDOC_Repository docRepository,
            IDOC_TYPE_Repository docTypeRepository,
            IEMPLOYEE_IN_ORG_Repository employeeInOrgRepository,
            IEMPLOYEE_Repository employeeRepository,
            IEXECUTION_Repository executionRepository,
            IFIO_Repository fioRepository,
            IFORM_PERM_Repository formPermRepository,
            IJOB_Repository jobRepository,
            ILOGIN_Repository loginRepository,
            IMEMBER_Repository memberRepository,
            INOTIFY_REQUEST_Repository notifyRequestRepository,
            INOTIFY_SUB_Repository notifySubRepository,
            IOBJECT_Repository objectRepository,
            IOBJECT_TYPE_Repository objectTypeRepository,
            IORG_Repository orgRepository,
            IORG_UNIT_TYPE_Repository orgUnitTypeRepository,
            IPROFILE_Repository profileRepository,
            IPROM_AREA_Repository promAreaRepository,
            IREQUEST_Repository requestRepository,
            IREQUEST_STATE_Repository requestStateRepository,
            IREQUEST_TYPE_Repository requestTypeRepository,
            IREQUEST_TYPE_STAFF_Repository requestTypeStaffRepository,
            IRESOURCE_Repository resourceRepository,
            IRESOURCE_MEMBERS_Repository? resourceMembersRepository,
            IRESOURCE_RESP_Repository resourceRespRepository,
            IRESOURCE_UCA_Repository resourceUcaRepository,
            IRIGHT_DESCRIPTION_Repository rightDescriptionRepository,
            IRIGHT_GROUP_Repository rightGroupRepository,
            IRIGHT_OBJECT_TYPE_Repository rightObjectTypeRepository,
            IRIGHT_Repository rightRepository,
            IROOM_Repository roomRepository,
            IRSO_Repository rsoRepository,
            ISECRET_TYPE_Repository secretTypeRepository,
            ISERVICE_Repository serviceRepository,
            ISERVICE_TYPE_Repository serviceTypeRepository,
            ISTAFF_Repository staffRepository,
            ISTAFF_UNIT_Repository staffUnitRepository,
            IUCA_LIST_Repository ucaListRepository,
            IUSER_ROOM_Repository userRoomRepository,
            IVIEW_AC_ACCESS_ORG_Repository viewAcAccessOrgRepository,
            IVIEW_ARM_ROOM_USER_Repository viewArmRoomUserRepository,
            IVIEW_EMPLOYEE_EXT_Repository viewEmployeeExtRepository,
            IVIEW_OBJECT_USER_RIGHTS_DISTINCTED_Repository viewObjectUserRightsDistinctedRepository,
            IVIEW_OBJECT_USER_RIGHTS_Repository viewObjectUserRightsRepository,
            IVIEW_RESOURCE_USER_RIGHT_Repository viewResourceUserRightRepository,
            IVIEW_RESOURCE_EXT_Repository viewResourceExtRepository,
            IVIEW_REPORT_AC_ACCESS_Repository viewReportAcAccessRepository,
            IVIEW_REPORT_ALL_RESOURCES_Repository viewReportAllResourcesRepository, 
            IVIEW_ARM_USER_Repository viewArmUserRepository, 
            IVIEW_REPORT_RSD_Repository viewReportRSDRepository,
            IVIEW_EMPLOYEE_FIO_Repository viewEmployeeFioRepository,
            IVIEW_OWNER_Repository viewOwnerRepository,
            IVIEW_PROFILE_Repository viewProfileRepository,
            IVIEW_RESOURCES_BY_OT_ST_Repository viewResourcesByOtStRepository,
            IVIEW_FIO_Repository viewFioRepository,
            IVIEW_REPORT_ALL_REQUESTS_Repository viewReportAllRequestsRepository,
            IVIEW_STAFF_UNIT_LOGINS_Repository viewStaffUnitLoginsRepository,
            IVIEW_EMPLOYEE_LOGIN_Repository viewEmployeeLoginRepository,
            IVIEW_EMPLOYEE_Repository viewEmployeeRepository,
            IVIEW_RESOURCE_Repository viewResourceRepository,
            IVIEW_RESOURCE_MEMBER_EMPLOYEE_Repository iviewResourceMemberEmployeeRepository,
            IVIEW_RESOURCE_MEMBER_ORG_Repository viewResourceMemberOrgRepository,
            IVIEW_REPORT_RESOURCES_WHERE_AM_I_Repository viewReportResourcesWhereAmIRepository,
            IVIEW_PROFILE_OBJECT_RIGHT_Repository viewProfileObjectRightRepository,
            IVIEW_REPORT_ALL_PROFILES_Repository viewReportAllProfilesRepository,
            IVIEW_RIGHT_DESCR_Repository viewRightDescrRepository,
            IVIEW_MEMBER_USER_Repository viewMemberUserRepository,
            IVIEW_MEMBER_ORG_Repository viewMemberOrgRepository,
            
            ITest_Repository testRepository 
            
            // хелперы
            // ILinqHelpers linqHelpers          
            
            // PRD
            /*IVIEW_REPORT_ALL_RESOURCES_FROM_PRD_Repository viewReportAllResourcesFromPrdRepository,
            IVIEW_REPORT_RSD_FROM_PRD_Repository viewReportRsdFromPrdRepository,
            IVIEW_EMPLOYEE_LOGIN_PRD__Repository viewEmployeeLoginPrdRepository,
            IVIEW_EMPLOYEE_PRD__Repository viewEmployeePrdRepository,*/
            
        )
        {
            _dicRepository = dicRepository;
            _acAccessRepository = acAccessRepository;
            _acFragmentRepository = acFragmentRepository;
            _armDeviceRepository = armDeviceRepository;
            _armRepository = armRepository;
            _armUserRepository = armUserRepository;
            _armUserRoleRepository = armUserRoleRepository;
            _buildingRepository = buildingRepository;
            _devicePermRepository = devicePermRepository;
            _deviceRepository = deviceRepository;
            _deviceTypeRepository = deviceTypeRepository;
            _docRepository = docRepository;
            _docTypeRepository = docTypeRepository;
            _employeeInOrgRepository = employeeInOrgRepository;
            _employeeRepository = employeeRepository;
            _executionRepository = executionRepository;
            _fioRepository = fioRepository;
            _formPermRepository = formPermRepository;
            _jobRepository = jobRepository;
            _loginRepository = loginRepository;
            _memberRepository = memberRepository;
            _notifyRequestRepository = notifyRequestRepository;
            _notifySubRepository = notifySubRepository;
            _objectRepository = objectRepository;
            _objectTypeRepository = objectTypeRepository;
            _orgRepository = orgRepository;
            _orgUnitTypeRepository = orgUnitTypeRepository;
            _profileRepository = profileRepository;
            _promAreaRepository = promAreaRepository;
            _requestRepository = requestRepository;
            _requestStateRepository = requestStateRepository;
            _requestTypeRepository = requestTypeRepository;
            _requestTypeStaffRepository = requestTypeStaffRepository;
            _resourceRepository = resourceRepository;
            _resourceMembersRepository = resourceMembersRepository;
            _resourceRespRepository = resourceRespRepository;
            _resourceUcaRepository = resourceUcaRepository;
            _rightDescriptionRepository = rightDescriptionRepository;
            _rightGroupRepository = rightGroupRepository;
            _rightObjectTypeRepository = rightObjectTypeRepository;
            _rightRepository = rightRepository;
            _roomRepository = roomRepository;
            _rsoRepository = rsoRepository;
            _secretTypeRepository = secretTypeRepository;
            _serviceRepository = serviceRepository;
            _serviceTypeRepository = serviceTypeRepository;
            _staffRepository = staffRepository;
            _staffUnitRepository = staffUnitRepository;
            _ucaListRepository = ucaListRepository;
            _userRoomRepository = userRoomRepository;
            _viewAcAccessOrgRepository = viewAcAccessOrgRepository;
            _viewArmRoomUserRepository = viewArmRoomUserRepository;
            _viewEmployeeExtRepository = viewEmployeeExtRepository;
            _viewObjectUserRightsDistinctedRepository = viewObjectUserRightsDistinctedRepository;
            _viewObjectUserRightsRepository = viewObjectUserRightsRepository;
            _viewResourceUserRightRepository = viewResourceUserRightRepository;
            _viewResourceExtRepository = viewResourceExtRepository;
            _viewReportAcAccessRepository = viewReportAcAccessRepository;
            _viewReportAllResourcesRepository = viewReportAllResourcesRepository;
            _viewArmUserRepository = viewArmUserRepository;
            _viewReportRsdRepository = viewReportRSDRepository;
            _viewEmployeeFioRepository = viewEmployeeFioRepository;
            _viewOwnerRepository = viewOwnerRepository;
            _viewProfileRepository = viewProfileRepository;
            _viewResourcesByOtStRepository = viewResourcesByOtStRepository;
            _viewFioRepository = viewFioRepository;
            _viewReportAllRequestsRepository = viewReportAllRequestsRepository;
            _viewStaffUnitLoginsRepository = viewStaffUnitLoginsRepository;
            _viewEmployeeLoginRepository = viewEmployeeLoginRepository;
            _viewEmployeeRepository = viewEmployeeRepository;
            _viewResourceRepository = viewResourceRepository;
            _iviewResourceMemberEmployeeRepository = iviewResourceMemberEmployeeRepository;
            _viewResourceMemberOrgRepository = viewResourceMemberOrgRepository;
            _viewReportResourcesWhereAmIRepository = viewReportResourcesWhereAmIRepository;
            _viewProfileObjectRightRepository = viewProfileObjectRightRepository;
            _viewReportAllProfilesRepository = viewReportAllProfilesRepository;
            _viewRightDescrRepository = viewRightDescrRepository;
            _viewMemberUserRepository = viewMemberUserRepository;
            _viewMemberOrgRepository = viewMemberOrgRepository;
            _testRepository = testRepository;
            _linqHelpers = new LinqHelpers(); 
            
            // PRD
            
            /*_viewEmployeePrdRepository = viewEmployeePrdRepository;
            _viewEmployeeLoginPrdRepository = viewEmployeeLoginPrdRepository;
            _viewReportAllResourcesFromPrdRepository = viewReportAllResourcesFromPrdRepository;
            _viewReportRsdFromPrdRepository = viewReportRsdFromPrdRepository;*/
        }

        public Common_Service(IVIEW_FIO_Repository viewFioRepository)
        {
            _viewFioRepository = viewFioRepository;
            throw new NotImplementedException();
        }

        public Common_Service(IVIEW_RESOURCES_BY_OT_ST_Repository viewResourcesByOtStRepository,
            ILinqHelpers linqHelpers)
        {
            _viewResourcesByOtStRepository = viewResourcesByOtStRepository;
            _linqHelpers = linqHelpers;
        }

        public Common_Service(IVIEW_EMPLOYEE_LOGIN_Repository viewEmployeeLoginRepository)
        {
            _viewEmployeeLoginRepository = viewEmployeeLoginRepository;
        }

        public Common_Service(ITest_Repository repository)
        {
            _testRepository = repository;
        }
        //--------------------------------------------------------------------------------------------------------------
        #endregion

        public IEnumerable<T>? ПолучитьДействующие<T>(IEnumerable<T>? enumerable, DateTime? dateTime) where T : Requested 
            => 
                _linqHelpers?.СуществуетНаДату(enumerable, dateTime);

        public IVIEW_REPORT_ALL_RESOURCES_Repository? GET_VIEW_REPORT_ALL_RESOURCES_Repository() 
            => _viewReportAllResourcesRepository;
    }
}
