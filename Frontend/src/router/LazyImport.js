export const AlertList = () => import('@/views/AlertList')
export const CoolReloadPage = () => import('@/views/CoolReloadPage')
export const FakeUser = () => import('@/views/FakeUser/Index')

export const App = () => import('@/views/App.vue')
export const Menu = () => import('@/views/AppBar/Index.vue')
export const Login = () => import('@/views/Login.vue')

// Reports
export const CreateResource = () =>
  import('@/views/СоздатьЗаявку/СоздатьРесурс_СИЛС/Index')

export const CreateResourceZLIVS = () =>
  import('@/views/СоздатьЗаявку/СоздатьРесурс_ЗЛИВС/Index')

export const CreateProfileName = () =>
  import('@/views/СоздатьЗаявку/__Недореализовано__недотестировано/CreateProfileName/Index')

export const CreateProfile = () =>
  import('@/views/СоздатьЗаявку/СоздатьПрофиль_СИЛС_ЗЛИВС/Index')

export const CreateMember = () =>
  import('@/views/СоздатьЗаявку/ПредоставлениеДоступаКоРесурсу_СИЛС/Index')

export const CreateMemberZLIVS = () =>
  import('@/views/СоздатьЗаявку/ПредоставлениеДоступаКоРесурсу_ЗЛИВС/Index')

export const CreateTripleRequest = () =>
  import('@/views/СоздатьЗаявку/__Недореализовано__недотестировано/CreateTripleRequest/Index')

export const CreateFIO = () =>
  import('@/views/СоздатьЗаявку/__Недореализовано__недотестировано/CreateFIO/Index')

export const UpdateFIO = () =>
  import('@/views/СоздатьЗаявку/__Недореализовано__недотестировано/UpdateFIO/Index')

export const CreateEmployee = () =>
  import('@/views/СоздатьЗаявку/__Недореализовано__недотестировано/CreateEmployee/Index')

export const CreateLogin = () =>
  import('@/views/СоздатьЗаявку/__Недореализовано__недотестировано/CreateLogin/Index')

// Requests
export const AllResources = () =>
  import('@/views/Reports/AllResources/AllResources')

export const AcAccess = () => import('@/views/Reports/AcAccess/AcAccess')
export const AllResourcesFromPrd = () => import('@/views/Reports/AllResourcesFromPrd/AllResourcesFromPrd')
export const AllArmUsers = () => import('@/views/Reports/AllArmUsers/AllArmUsers')
export const AllArms = () => import('@/views/Reports/AllArms/AllArms')
export const AllResourcesWithMembers = () => import('@/views/Reports/AllResourcesWithMembers/AllResourcesWithMembers')
export const RSD = () => import('@/views/Reports/RSD/RSD')
export const RsdToPrd = () => import('@/views/Reports/RsdToPrd/RsdToPrd')
export const Execute = () => import('@/views/Admin/НовыеЗаявки/Index')
export const FinishedRequests = () => import('@/views/Admin/ВыполненныеЗаявки/Index')
export const RequestCreatedProfileNew = () => import('@/views/Admin/СозданиеПрофиляНовые/Index')
export const RequestCreatedProfileFinished = () => import('@/views/Admin/СозданиеПрофиляВыполненные/Index')

export const MyUnConsRequests = () => import('@/views/My/MyUnConsRequests')
export const MyExecutedRequests = () => import('@/views/My/MyExecutedRequests')
export const AllMyRequests = () => import('@/views/My/AllMyRequests')
export const IamResponsible = () => import('@/views/My/IAmResponsible')
export const IamOwner = () => import('@/views/My/IAmOwner')
export const MyProfiles = () => import('@/views/My/MyProfiles')

// справочники
export const CreatedResources = () => import('@/views/HandBook/СуществующиеРесурсы/Index')
export const CreatedProfiles = () => import('@/views/HandBook/СуществующиеПрофили/Index')

// настройки
export const Settings = () => import('@/views/Settings/Index')
