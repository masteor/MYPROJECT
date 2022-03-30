// export const ПОЛУЧИТЬ_ВСЕ_РЕСУРСЫ_С_СЕРВЕРА = '/RequestAjax/GetResources'

// GET сущности
export const ПОЛУЧИТЬ_ТИПЫ_ОБЪЕКТОВ_С_СЕРВЕРА = '/RequestAjax/GetObjectType'
export const ПОЛУЧИТЬ_ТИПЫ_СЕРВИСОВ_С_СЕРВЕРА = '/RequestAjax/GetServiceType'
export const ПОЛУЧИТЬ_ФИО_ВСЕХ_ДЕЙСТВУЮЩИХ_СОТРУДНИКОВ_С_СЕРВЕРА = '/RequestAjax/GetEmployees'
export const ПОЛУЧИТЬ_СОТРУДНИКОВ_ДЛЯ_ФЕЙК_ЮЗЕРА = '/RequestAjax/GetViewEmployeeLogins'

export const ПОЛУЧИТЬ_ВСЕХ_СОТРУДНИКОВ_ДОПУЩЕННЫХ_ДО_РЕСУРСА_ЗЛИВС_С_СЕРВЕРА =
  '/RequestAjax/GetResourceMember'

export const ПОЛУЧИТЬ_ФИО_С_СЕРВЕРА = '/RequestAjax/GetFIO'
export const ПОЛУЧИТЬ_ВСЕ_ФИО_С_СЕРВЕРА = '/RequestAjax/GetFIOs'
export const ПОЛУЧИТЬ_ВСЕ_ФРАГМЕНТЫ_С_СЕРВЕРА = '/RequestAjax/GetFragments'
export const ПОЛУЧИТЬ_ТИПЫ_СЕКРЕТНОСТИ_С_СЕРВЕРА = '/RequestAjax/GetSecretType'
export const ПОЛУЧИТЬ_ОТВЕТСТВЕННЫХ_С_СЕРВЕРА = '/RequestAjax/GetResponsible'
export const ПОЛУЧИТЬ_ВЛАДЕЛЬЦЕВ_РЕСУРСОВ_С_СЕРВЕРА = '/RequestAjax/GetOwners'
export const ПОЛУЧИТЬ_ДЕЙСТВУЮЩИЕ_И_НА_ЭТАПЕ_РЕГИСТРАЦИИ_РЕСУРСЫ_С_СЕРВЕРА = '/RequestAjax/GetExistentAndRegisteredResources'
export const ПОЛУЧИТЬ_ДЕЙСТВУЮЩИЕ_РЕСУРСЫ_ПОЛЬЗОВАТЕЛЯ_С_СЕРВЕРА = '/RequestAjax/GetExistentResources'
export const ПОЛУЧИТЬ_ДЕЙСТВУЮЩИЕ_И_НА_ЭТАПЕ_РЕГИСТРАЦИИ_ПРОФИЛИ_ПОЛЬЗОВАТЕЛЯ_С_СЕРВЕРА = '/RequestAjax/GetExistentAndRegisteredProfiles'
export const ПОЛУЧИТЬ_ДЕЙСТВУЮЩИЕ_ПРОФИЛИ_ПОЛЬЗОВАТЕЛЯ_С_СЕРВЕРА = '/RequestAjax/GetExistentProfiles'
export const ПОЛУЧИТЬ_ПРОФИЛИ_ПРИВЯЗАННЫЕ_КО_РЕСУРСУ_С_СЕРВЕРА = '/RequestAjax/GetProfilesByResource'
export const ПОЛУЧИТЬ_РЕСУРС_ПРИВЯЗАННЫЙ_КО_ПРОФИЛЮ_С_СЕРВЕРА = '/RequestAjax/GetResourceByProfile'
export const ПОЛУЧИТЬ_ПРАВА_ПРЕДОСТАВЛЯЕМЫЕ_ПРОФИЛЕМ_С_СЕРВЕРА = '/RequestAjax/GetRightDescr'
export const ПОЛУЧИТЬ_ОРГ_ЕДИНИЦЫ_С_СЕРВЕРА = '/RequestAjax/GetOrgEntities'
export const ПОЛУЧИТЬ_ДОЛЖНОСТИ_С_СЕРВЕРА = '/RequestAjax/GetJobs'
export const ПОЛУЧИТЬ_ФОРМУ_ДОПУСКА_С_СЕРВЕРА = '/RequestAjax/GetFormPerms'
export const ПОЛУЧИТЬ_КАРТОЧКУ_СОТРУДНИКА_С_СЕРВЕРА = '/RequestAjax/GetEmployee'
export const ПОЛУЧИТЬ_СОДЕРЖИМОЕ_ДОКУМЕНТА_ПО_ИД = '/RequestAjax/GetBinaryDocument'
export const ПОЛУЧИТЬ_МОДЕЛЬ_ПОЛЬЗОВАТЕЛЯ_СЕРВИСА_С_СЕРВЕРА = '/RequestAjax/GetUserModel'
export const ПОЛУЧИТЬ_СОТРУДНИКОВ_ДОПУЩЕННЫХ_КО_РЕСУРСУ_ЗЛИВС = '/RequestAjax/GetResourceMemberLoginZLIVS'
export const ПОЛУЧИТЬ_ОРГЕДИНИЦЫ_ДОПУЩЕННЫХ_КО_РЕСУРСУ_ЗЛИВС = '/RequestAjax/GetResourceMemberOrgZLIVS'
export const ПОЛУЧИТЬ_СОДЕРЖИМОЕ_ЗАЯВКИ_ПО_ТИПУ_ЗАЯВКИ_И_НОМЕРУ_ЗАЯВКИ = '/RequestAjax/GetRequestContent'
// @LABEL:URL.GET-ENTITIES@

// GET отчеты
export const ПОЛУЧИТЬ_ПЕРЕЧЕНЬ_СУБЬЕКТОВ_ДОСТУПА_ДОПУЩЕННОГО_К_РАБОТЕ_В_АС_С_СЕРВЕРА = '/ReportAjax/GetAcAccess'
export const ПОЛУЧИТЬ_ПЕРЕЧЕНЬ_РЕСУРСОВ_В_АС_С_СЕРВЕРА = '/ReportAjax/GetAllResources'
export const ПОЛУЧИТЬ_ПЕРЕЧЕНЬ_РЕСУРСОВ_В_АС_С_СЕРВЕРА_ИЗ_PRD = '/ReportAjax/GetAllResourcesFromPrd'
export const ПОЛУЧИТЬ_ПЕРЕЧЕНЬ_АРМ_В_АС_С_СЕРВЕРА = '/ReportAjax/GetAllArms'
export const ПОЛУЧИТЬ_ПЕРЕЧЕНЬ_СУБЪЕКТОВ_ДОСТУПА_ДОПУЩЕННЫХ_К_РАБОТЕ_НА_АРМ_С_СЕРВЕРА = '/ReportAjax/GetAllArmUsers'
export const ПОЛУЧИТЬ_ПЕРЕЧЕНЬ_РЕСУРСОВ_К_КОТОРЫМ_ПРЕДОСТАВЛЕН_ДОСТУП_СУБЪЕКТАМ_С_СЕРВЕРА = '/ReportAjax/GetAllResourcesWithMembers'
export const ПОЛУЧИТЬ_РАЗРЕШИТЕЛЬНАЯ_СИСТЕМА_ДОСТУПА_К_РЕСУРСАМ_С_СЕРВЕРА = '/ReportAjax/GetRsd'
export const ПОЛУЧИТЬ_РАЗРЕШИТЕЛЬНАЯ_СИСТЕМА_ДОСТУПА_К_РЕСУРСАМ_С_СЕРВЕРА_ИЗ_PRD = '/ReportAjax/GetRsdFromPrd'
// @LABEL:URL.GET-REPORTS@

// GET для админов
export const ПОЛУЧИТЬ_ОЧЕРЕДЬ_ЗАЯВОК_НА_ОБРАБОТКУ = '/ReportAjax/ActiveRequests'
export const ПОЛУЧИТЬ_ВЫПОЛНЕННЫЕ_ЗАЯВКИ = '/ReportAjax/FinishedRequests'
export const ПОЛУЧИТЬ_СУЩЕСТВУЮЩИЕ_ПРОФИЛИ_ДЛЯ_АДМИНА = '/RequestAjax/GetAllProfileInfos'

// GET для пользователей
export const ПОЛУЧИТЬ_ВСЕ_МОИ_ЗАЯВКИ = '/RequestAjax/AllMyRequests'
export const ПОЛУЧИТЬ_РЕСУРСЫ_ГДЕ_ПОЛЬЗОВАТЕЛЬ_ЯВЛСЯ_ОТВЕТСТВЕННЫМ = '/RequestAjax/GetResourcesWhereUserIsResponsible'
export const ПОЛУЧИТЬ_РЕСУРСЫ_ГДЕ_ПОЛЬЗОВАТЕЛЬ_ЯВЛСЯ_ВЛАДЕЛЬЦЕМ = '/RequestAjax/GetResourcesWhereUserIsOwner'
export const ПОЛУЧИТЬ_ВСЕ_МОИ_ПРОФИЛИ = '/RequestAjax/MyProfiles'
export const ПОЛУЧИТЬ_ОБЪЕКТЫ_ПРОФИЛЯ = '/RequestAjax/GetProfileObjects'
export const ПОЛУЧИТЬ_ТИПЫ_ОБЪЕКТОВ_СЕРВИСОВ = '/RequestAjax/GetObjectServiceTypes'
export const ПОЛУЧИТЬ_ДЕРЕВО_СУЩЕСТВУЮЩИХ_РЕСУРСОВ = '/RequestAjax/GetTreeOfResources'

// POST
export const ОБНОВИТЬ_ФИО_НА_СЕРВЕРЕ = '/RequestAjax/UpdateFIO'
export const СОЗДАТЬ_ФИО_ПОЛЬЗОВАТЕЛЯ_НА_СЕРВЕРЕ = '/RequestAjax/CreateFIO'
export const СОЗДАТЬ_ЛОГИН_ПОЛЬЗОВАТЕЛЯ_НА_СЕРВЕРЕ = '/RequestAjax/CreateLogin'
export const ЧЕКНУТЬ_ЛОГИН_НА_СЕРВЕРЕ = '/RequestAjax/CheckLogin'
export const СОЗДАТЬ_РЕСУРС_НА_СЕРВЕРЕ = '/RequestAjax/CreateResource'
export const СОЗДАТЬ_РЕСУРС_ЗЛИВС_НА_СЕРВЕРЕ = '/RequestAjax/CreateResourceZLIVS'
export const СОЗДАТЬ_ИМЯ_ПРОФИЛЯ_НА_СЕРВЕРЕ = '/RequestAjax/CreateProfileName'
export const ДОБАВИТЬ_ОБЪЕКТЫ_В_ПРОФИЛЬ_НА_СЕРВЕРЕ = '/RequestAjax/AddProfileObjects'
export const СОЗДАТЬ_ДОСТУПЫ_СУБЪЕКТОВ_К_РЕСУРСАМ_НА_СЕРВЕРЕ = '/RequestAjax/CreateMember'
export const СОЗДАТЬ_ПОЛЬЗОВАТЕЛЯ_НА_СЕРВЕРЕ = '/RequestAjax/CreateEmployee'
export const ВЫПОЛНИТЬ_ЗАЯВКУ_С_ОПРЕДЕЛЕННЫМ_СТАТУСОМ = '/RequestAjax/ExecuteRequest'

// @LABEL:URL.POST@
