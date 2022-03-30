/* eslint-disable camelcase */

// ---------------------------------------------------------------------------------------------------------------------

import ТипАлерта from '@/constants/типАлерта'

export const неОпределено = '<не определено>'

export class ПАРАМЕТРЫ_ЗАПРОСА_НА_ДАТУ {
  /**
   * @param {String} наДату
   */
  constructor (наДату) {
    this.dateTime = наДату
  }
}

export class LOADING {
  /**
   * Класс для хранения ссылки на свойство, которое связано со свойством loading какого-нибудь элемента
   * имея этот класс можно из других функций управлять свойством loading какого-нибудь элемента
   * @param {this} _this ссылка на объект, где находится изменяемое свойство
   * @param {String} имяСвойства которое будет изменяться через ссылку на него
   */
  constructor (_this, имяСвойства) {
    this._this = _this
    this.имяСвойства = имяСвойства
  }
}

export class ПАРАМЕТРЫ_ЗАПРОСА_ДОМЕННЫЙ_ЛОГИН {
  /**
   * @param {String} доменныйЛогин Логин пользователя вида "ДОМЕН\логин", пример: "ZLIVS\kirillovanm"
   */
  constructor (доменныйЛогин) {
    this.domainAccount = доменныйЛогин
  }
}

export class ПАРАМЕТРЫ_ЗАПРОСА_ПОЛУЧИТЬ_СОДЕРЖИМОЕ_ЗАЯВКИ extends ПАРАМЕТРЫ_ЗАПРОСА_ДОМЕННЫЙ_ЛОГИН {
  /**
   * @param идЗаявки
   * @param буквенныйКодТипаЗаявки
   * @param доменныйЛогин
   */
  constructor (идЗаявки, буквенныйКодТипаЗаявки, доменныйЛогин) {
    super(доменныйЛогин)
    this.idRequest = идЗаявки
    this.requestTypeCode = буквенныйКодТипаЗаявки
  }
}

export class ПАРАМЕТРЫ_ЗАПРОСА_ПОЛУЧИТЬ_ОБЪЕКТЫ_ПРОФИЛЯ extends ПАРАМЕТРЫ_ЗАПРОСА_ДОМЕННЫЙ_ЛОГИН {
  /**
   * @param идПрофиля
   * @param доменныйЛогин
   */
  constructor (идПрофиля, доменныйЛогин) {
    super(доменныйЛогин)
    this.idProfile = идПрофиля
  }
}

export class ПАРАМЕТРЫ_ЗАПРОСА_НА_ДАТУ_И_ДОМЕННЫЙ_ЛОГИН extends ПАРАМЕТРЫ_ЗАПРОСА_ДОМЕННЫЙ_ЛОГИН {
  /**
   * @param {Date} наДату
   * @param {String} доменныйЛогин
   */
  constructor (наДату, доменныйЛогин) {
    super(доменныйЛогин)
    this.dateTime = наДату
  }
}

/***********************************************************/
export class ДОПОЛНИТЕЛЬНЫЕ_ПАРАМЕТРЫ_ЗАЯВКИ {
  /**
   * @param {Date} датаСоздания
   * @param {Date} датаЗавершения
   * @param {String} логинПользователяСоздателя
   * @param {String} логинПользователяПолучателя
   * @param {number|null} идСтатусаЗаявки
   * @param {Blob} документ
   * @param {String} регНомер
   */
  constructor (
    датаСоздания = null,
    датаЗавершения = null,
    логинПользователяСоздателя = null,
    логинПользователяПолучателя = null,
    идСтатусаЗаявки = null,
    документ = null,
    регНомер = null,
  ) {
    this.create_date_time = датаСоздания
    this.end_date_time = датаЗавершения
    this.sender_login = логинПользователяСоздателя
    this.recipient_login = логинПользователяПолучателя
    this.request_state_id = идСтатусаЗаявки
    this.doc = документ
    this.reg_number = регНомер
    console.log('конструктор ДОПОЛНИТЕЛЬНЫЕ_ПАРАМЕТРЫ_ЗАЯВКИ отработал')
  }
}

/***********************************************************/
export class ДОПОЛНИТЕЛЬНЫЕ_ПАРАМЕТРЫ_ЗАЯВКИ_ПЕРЕГРУЗКА_1 extends ДОПОЛНИТЕЛЬНЫЕ_ПАРАМЕТРЫ_ЗАЯВКИ {
  /**
   * @param {String} логинПользователяСоздателя
   * @param {String} логинПользователяПолучателя
   * @param идСтатусаЗаявки
   */
  constructor (
    логинПользователяСоздателя,
    логинПользователяПолучателя,
    идСтатусаЗаявки,
  ) {
    super(
      null,
      null,
      логинПользователяСоздателя,
      логинПользователяПолучателя,
      идСтатусаЗаявки,
      null,
      null,
    )
  }
}

/***********************************************************/
export class ДАТА_СОЗДАНИЯ {
  /**
   * @param {String} датаСоздания
   */
  constructor (датаСоздания) {
    this.date_time = датаСоздания
  }
}

// ---------------------------------------------------------------------------------------------------------------------
export class ПАРАМЕТРЫ_ЗАПРОСА_ТИПОВ_ОБЪЕКТОВ {
  /**
   * @param {Number} идТипаСервиса - ид сервиса, которому принадлежит тип объекта
   * @param {Number} главныйОбъект - это признак, выделяющий главный объект ресурса от второстепенных, 1 - главный, 0 - второстепенный
   */
  constructor (идТипаСервиса, главныйОбъект) {
    this.serviceTypeId = идТипаСервиса
    this.mainObject = главныйОбъект
  }
}

// ---------------------------------------------------------------------------------------------------------------------
export class ПАРАМЕТРЫ_ЗАПРОСА_СОЗДАТЬ_ФИО_НА_СЕРВЕРЕ {
  /**
   * @param {String} фамилия
   * @param {String} имя
   * @param {String} отчество
   * @param {ДОПОЛНИТЕЛЬНЫЕ_ПАРАМЕТРЫ_ЗАЯВКИ} параметрыЗаявки
   */
  constructor (фамилия, имя, отчество, параметрыЗаявки) {
    this.family = фамилия
    this.name = имя
    this.patronymic = отчество
    this.request_params = параметрыЗаявки
  }
}

// ---------------------------------------------------------------------------------------------------------------------
export class ПАРАМЕТРЫ_ЗАПРОСА_ОБНОВИТЬ_ФИО_НА_СЕРВЕРЕ extends ПАРАМЕТРЫ_ЗАПРОСА_СОЗДАТЬ_ФИО_НА_СЕРВЕРЕ {
  /**
   * @param {Number} idFio ид ФИО, которое обновляется
   * @param {String} family
   * @param {String} name
   * @param {String} patronymic
   * @param датаОбновления
   */
  constructor (idFio, family, name, patronymic, датаОбновления) {
    super(family, name, patronymic, датаОбновления)
    this.id_fio = idFio
  }
}

// ---------------------------------------------------------------------------------------------------------------------
export class ПАРАМЕТРЫ_ЗАПРОСА_СОЗДАТЬ_ЛОГИН_ПОЛЬЗОВАТЕЛЯ {
  /**
   * @param {String} имяЛогина
   * @param {String} емайл
   * @param {Number} идПользователя
   * @param {Number} идФрагмента
   * @param {Date} датаСозданияЗаявки
   */
  constructor (имяЛогина, емайл, идПользователя, идФрагмента, датаСозданияЗаявки) {
    this.login_name = имяЛогина
    this.email = емайл
    this.id_user = идПользователя
    this.id_domen = идФрагмента
    this.date_time = датаСозданияЗаявки
  }
}

// ---------------------------------------------------------------------------------------------------------------------
export class ПАРАМЕТРЫ_ЗАПРОСА_ЧЕКНУТЬ_ЛОГИН_НА_СЕРВЕРЕ {
  /**
   * @param {String} логин
   */
  constructor (логин) {
    this.логин = логин
  }
}

// ---------------------------------------------------------------------------------------------------------------------
export class ПАРАМЕТРЫ_ЗАПРОСА_СОЗДАТЬ_РЕСУРС {
  /**
   * @param {Number} идРодительскогоОбъекта - есть главные ресурсы, есть подчиненные, у подчиненных есть идРодительского объекта
   * @param {Number} идАктуальногоРесурса
   * @param {String} полныйПутьКоРесурсу
   * @param {String} описание
   * @param {Number} идФрагмента
   * @param {String} названиеОбъектаРесурса Название ресурса
   * @param {Number} идТипаОбъектаРесурса Тип объекта ресурса
   * @param {Number} идТипаСервиса Название сервиса
   * @param {Number} идТипаСекретности Тип секретности
   * @param {Number} идОтветственного Ответственный
   * @param {Number} идВладельца Владелец
   * @param {Object.<ДОПОЛНИТЕЛЬНЫЕ_ПАРАМЕТРЫ_ЗАЯВКИ>} requestParams
   */
  constructor (
    идРодительскогоОбъекта,
    идАктуальногоРесурса,
    полныйПутьКоРесурсу,
    описание,
    названиеОбъектаРесурса,
    идТипаОбъектаРесурса,
    идФрагмента,
    идТипаСервиса,
    идТипаСекретности,
    идОтветственного,
    идВладельца,
    requestParams,
  ) {
    this.ParentObjectId = идРодительскогоОбъекта
    this.NewId = идАктуальногоРесурса
    this.path = полныйПутьКоРесурсу
    this.description = описание
    this.ObjectName = названиеОбъектаРесурса
    this.ObjectTypeId = идТипаОбъектаРесурса
    this.FragmentId = идФрагмента
    this.ServiceTypeId = идТипаСервиса
    this.SecretTypeId = идТипаСекретности
    this.ResponsibleId = идОтветственного
    this.OwnerId = идВладельца
    this.request_params = requestParams
  }
}

// ---------------------------------------------------------------------------------------------------------------------
export class ПЕРЕЧЕНЬ_СУБЪЕКТОВ_ДОСТУПА {
  /**
   * @param {Number[]} сотрудники
   * @param {Number[]} оргЕдиницы
   */
  constructor (сотрудники = [], оргЕдиницы = []) {
    this.UserIds = сотрудники
    this.OrgIds = оргЕдиницы
  }
}

// ---------------------------------------------------------------------------------------------------------------------
export class ПАРАМЕТРЫ_ЗАПРОСА_СОЗДАТЬ_РЕСУРС_ЗЛИВС extends ПЕРЕЧЕНЬ_СУБЪЕКТОВ_ДОСТУПА {
  /**
   * @param {Number} идРодительскогоОбъекта - есть главные ресурсы, есть подчиненные, у подчиненных есть идРодительского объекта
   * @param {Number} идАктуальногоРесурса
   * @param {String} полныйПутьКоРесурсу
   * @param {String} описание
   * @param {Number} идФрагмента
   * @param {String} названиеОбъектаРесурса Название ресурса
   * @param {Number} идТипаОбъектаРесурса Тип объекта ресурса
   * @param {Number} идТипаСервиса Название сервиса
   * @param {Number} идТипаСекретности Тип секретности
   * @param {Number} идОтветственного Ответственный
   * @param {Number} идВладельца Владелец
   * @param {Number[]} сотрудники
   * @param {Number[]} оргЕдиницы
   * @param {Object.<ДОПОЛНИТЕЛЬНЫЕ_ПАРАМЕТРЫ_ЗАЯВКИ>} requestParams
   */
  constructor (
    идРодительскогоОбъекта,
    идАктуальногоРесурса,
    полныйПутьКоРесурсу,
    описание,
    названиеОбъектаРесурса,
    идТипаОбъектаРесурса,
    идФрагмента,
    идТипаСервиса,
    идТипаСекретности,
    идОтветственного,
    идВладельца,
    requestParams,
    сотрудники,
    оргЕдиницы,
  ) {
    super(сотрудники, оргЕдиницы)
    this.ParentObjectId = идРодительскогоОбъекта
    this.NewId = идАктуальногоРесурса
    this.path = полныйПутьКоРесурсу
    this.description = описание
    this.ObjectName = названиеОбъектаРесурса
    this.ObjectTypeId = идТипаОбъектаРесурса
    this.FragmentId = идФрагмента
    this.ServiceTypeId = идТипаСервиса
    this.SecretTypeId = идТипаСекретности
    this.ResponsibleId = идОтветственного
    this.OwnerId = идВладельца
    this.request_params = requestParams
  }
}

// ---------------------------------------------------------------------------------------------------------------------
export class ПАРАМЕТРЫ_ЗАПРОСА_СОЗДАТЬ_ДОСТУПЫ_СУБЪЕКТОВ_К_РЕСУРСАМ extends ПЕРЕЧЕНЬ_СУБЪЕКТОВ_ДОСТУПА {
  /**
   * @param {Number[]} сотрудники
   * @param {Number[]} оргЕдиницы
   * @param {Number} идПрофиля
   * @param {Object.<ДОПОЛНИТЕЛЬНЫЕ_ПАРАМЕТРЫ_ЗАЯВКИ>} requestParams
   */
  constructor (идПрофиля, сотрудники, оргЕдиницы, requestParams) {
    super(сотрудники, оргЕдиницы)
    this.ProfileId = идПрофиля
    this.request_params = requestParams
  }
}

// ---------------------------------------------------------------------------------------------------------------------
export class ПАРАМЕТРЫ_ЗАПРОСА_СОЗДАТЬ_ИМЯ_ПРОФИЛЯ {
  /**
   * @param {String} ProfileName Название ресурса
   */
  constructor (ProfileName) {
    this.ProfileName = ProfileName
  }
}

// ---------------------------------------------------------------------------------------------------------------------
export class ПАРАМЕТРЫ_АЛЕРТА {
  /**
   * @param {String} сообщение
   * @param {String<ТипАлерта>} тип
   * @param {Boolean} статус true - показать алерт, false - скрыть алерт
   */
  constructor (
    сообщение = '',
    тип = ТипАлерта.info,
    статус = 'false',
  ) {
    this.статус = статус
    this.сообщение = сообщение
    this.тип = тип
    console.log(`new ПАРАМЕТРЫ_АЛЕРТА(сообщение: ${сообщение}, тип: ${тип}, статус: ${статус})`)
  }
}

// ---------------------------------------------------------------------------------------------------------------------
export class ПАРАМЕТРЫ_ЗАПРОСА_ДЕЙСТВУЮЩИЕ_РЕСУРСЫ extends ПАРАМЕТРЫ_ЗАПРОСА_ДОМЕННЫЙ_ЛОГИН {
  /**
   * @param {Number} идТипаСервиса Тип сервиса
   * @param {Number} идТипаОбъектаРесурса Тип объекта ресурса
   * @param {String} доменныйЛогин Логин пользователя вида "ДОМЕН\логин", пример: "ZLIVS\kirillovanm"
   * @returns {[Object.<{id: Number, name: String}>]} возвращаемые запросом объекты
   */
  constructor (идТипаСервиса, идТипаОбъектаРесурса, доменныйЛогин = '') {
    super(доменныйЛогин)
    this.serviceTypeId = идТипаСервиса
    this.objectTypeId = идТипаОбъектаРесурса
  }
}

// ---------------------------------------------------------------------------------------------------------------------
export class ПАРАМЕТРЫ_ЗАПРОСА_ДЕЙСТВУЮЩИЕ_И_НА_ЭТАПЕ_РЕГИСТРАЦИИ_РЕСУРСЫ_ВО_ФРАГМЕНТЕ extends ПАРАМЕТРЫ_ЗАПРОСА_ДОМЕННЫЙ_ЛОГИН {
  /**
   * @param {Number} идФрагмента
   * @param {String} доменныйЛогин Логин пользователя вида "ДОМЕН\логин", пример: "ZLIVS\kirillovanm"
   */
  constructor (идФрагмента, доменныйЛогин = '') {
    super(доменныйЛогин)
    this.id_fragment = идФрагмента
  }
}

// ---------------------------------------------------------------------------------------------------------------------
export class ПАРАМЕТРЫ_ЗАПРОСА_ДЕЙСТВУЮЩИЕ_РЕСУРСЫ_ПОЛЬЗОВАТЕЛЯ_ВО_ФРАГМЕНТЕ extends ПАРАМЕТРЫ_ЗАПРОСА_ДЕЙСТВУЮЩИЕ_И_НА_ЭТАПЕ_РЕГИСТРАЦИИ_РЕСУРСЫ_ВО_ФРАГМЕНТЕ {
  /**
   * @param {Number} идФрагмента
   * @param {String} доменныйЛогин Логин пользователя вида "ДОМЕН\логин", пример: "ZLIVS\kirillovanm"
   */
  constructor (идФрагмента, доменныйЛогин = '') {
    super(идФрагмента, доменныйЛогин)
  }
}

// ---------------------------------------------------------------------------------------------------------------------
export class ПАРАМЕТРЫ_ЗАПРОСА_ЗАВИСЯЩЕГО_ОТ_ФРАГМЕНТА extends ПАРАМЕТРЫ_ЗАПРОСА_ДЕЙСТВУЮЩИЕ_И_НА_ЭТАПЕ_РЕГИСТРАЦИИ_РЕСУРСЫ_ВО_ФРАГМЕНТЕ {
  /**
   * @param {Number} идФрагмента
   * @param {String} доменныйЛогин Логин пользователя вида "ДОМЕН\логин", пример: "ZLIVS\kirillovanm"
   */
  constructor (идФрагмента, доменныйЛогин = '') {
    super(идФрагмента, доменныйЛогин)
  }
}

// ---------------------------------------------------------------------------------------------------------------------
export class ПАРАМЕТРЫ_ЗАПРОСА_ПРАВА_ПРЕДОСТАВЛЯЕМЫЕ_ПРОФИЛЕМ {
  /**
   * @param {Number} тип признак группы прав или элементарного права (1 - группа, другое значение - элем.право)
   * @param {Number} типСервиса какому типу сервиса принадлежит право
   * @returns {[Object.<{id: Number, name: String}>]} возвращаемые запросом объекты
   */
  constructor (тип, типСервиса) {
    this.type = тип
    this.serviceTypeId = типСервиса
  }
}

// ---------------------------------------------------------------------------------------------------------------------
export class ПАРАМЕТРЫ_ЗАПРОСА_ДОБАВИТЬ_ОБЪЕКТЫ_В_ПРОФИЛЬ {
  /**
   * @param {String} имяПрофиля
   * @param {Number} идРодительскогоОбъекта
   * @param {[{}]} объектыПрофиля
   * @param {ДОПОЛНИТЕЛЬНЫЕ_ПАРАМЕТРЫ_ЗАЯВКИ} параметрыЗаявки
   */
  constructor (
    имяПрофиля,
    идРодительскогоОбъекта,
    объектыПрофиля,
    параметрыЗаявки,
  ) {
    this.ProfileName = имяПрофиля
    this.ResourceObjectId = идРодительскогоОбъекта
    this.ProfileObjects = объектыПрофиля
    this.request_params = параметрыЗаявки
  }
}

// ---------------------------------------------------------------------------------------------------------------------
export class ПАРАМЕТРЫ_ЗАПРОСА_ВЫПОЛНИТЬ_ЗАЯВКУ {
  /**
   * @param {Number} номерЗаявки
   * @param {ДОПОЛНИТЕЛЬНЫЕ_ПАРАМЕТРЫ_ЗАЯВКИ} параметрыЗаявки
   */
  constructor (
    номерЗаявки,
    параметрыЗаявки,
  ) {
    this.idRequest = номерЗаявки
    this.requestParams = параметрыЗаявки
  }
}

// ---------------------------------------------------------------------------------------------------------------------
export class ОБЪЕКТ_ПРОФИЛЯ {
  /**
   * @param {number} id ид объекта (в массиве)
   * @param {number|null} parent id родительского объекта
   * @param {number|null} root id корневого объекта
   * @param _this

   */
  constructor (
    id,
    parent,
    root,
    _this,
  ) {
    this.id = id
    this.parent = parent
    this.root = root
    this.ObjectName = _this.названиеДобавляемогоОбъекта
    this.ObjectType = _this.ТипДобавляемогоОбъекта
    this.ObjectTypeId = this.ObjectType.id
    this.RightDescriptions = [..._this.праваПредоставляемыеПрофилем]

    this.Valid()
  }

  /** @type {number} */
  id

  /** @type {number|null} */
  parent

  /** @type {number|null} */
  root

  /** @type {string} имяОбъекта */
  ObjectName

  /** @type {ТипОбъектовСервисов} ТипДобавляемогоОбъекта */
  ObjectType

  /** @type {number} */
  ObjectTypeId

  /** @type {number[]} предоставляемыеПрава */
  RightDescriptions

  Valid () {
    if (this.id === undefined || this.id === null || this.id < 1) throw new Error('Конструктор: ОБЪЕКТ_ПРОФИЛЯ.id < 1')
    if (this.ObjectName === undefined || this.ObjectName === null || this.ObjectName?.length < 1) throw new Error('Конструктор: ОБЪЕКТ_ПРОФИЛЯ.ObjectName.length < 1')
    if (this.ObjectType === undefined || this.ObjectType === null) throw new Error('Конструктор: ОБЪЕКТ_ПРОФИЛЯ.ObjectType === null')
    if (this.RightDescriptions === undefined || this.RightDescriptions === null || this.RightDescriptions?.length < 1) throw new Error('Конструктор: ОБЪЕКТ_ПРОФИЛЯ.RightDescriptions < 1')
  }
}

export class ПАРАМЕТРЫ_ЗАПРОСА_СОЗДАТЬ_ПОЛЬЗОВАТЕЛЯ {
  constructor (фамилия, имя, отчество, логин, емайл, идФрагмента, табНомер, идДолжности, идФормыДопуска, датаПриёмаНаРаботу, датаСозданияЗаявки) {
    this.family = фамилия
    this.name = имя
    this.patronymic = отчество
    this.login_name = логин
    this.email = емайл
    this.tnum = табНомер
    this.id_job = идДолжности
    this.id_form_perm = идФормыДопуска
    this.id_domen = идФрагмента
    this.job_begin_date = датаПриёмаНаРаботу
    this.date_time = датаСозданияЗаявки
  }
}

export class ПАРАМЕТРЫ_ЗАПРОСА_ПОЛУЧИТЬ_КАРТОЧКУ_СОТРУДНИКА {
  /**
   * @param {Number} табНомер
   */
  constructor (табНомер) {
    this.tnum = табНомер
  }
}

// ---------------------------------------------------------------------------------------------------------------------
export class ПАРАМЕТРЫ_ЗАПРОСА_ПРОФИЛИ_ПРИВЯЗАННЫЕ_КО_РЕСУРСУ extends ПАРАМЕТРЫ_ЗАПРОСА_ДОМЕННЫЙ_ЛОГИН {
  /**
   * @param идОбъектаРесурса
   * @param доменныйЛогин
   */
  constructor (идОбъектаРесурса, доменныйЛогин = '') {
    super(доменныйЛогин)
    this.idObjectResource = идОбъектаРесурса
  }
}

// ---------------------------------------------------------------------------------------------------------------------
export class ПАРАМЕТРЫ_ЗАПРОСА_РЕСУРС_ПРИВЯЗАННЫЙ_КО_ПРОФИЛЮ extends ПАРАМЕТРЫ_ЗАПРОСА_ДОМЕННЫЙ_ЛОГИН {
  /**
   * @param идПрофиля
   * @param доменныйЛогин
   */
  constructor (идПрофиля, доменныйЛогин = '') {
    super(доменныйЛогин)
    this.idProfile = идПрофиля
  }
}

// ---------------------------------------------------------------------------------------------------------------------
export class ПАРАМЕТРЫ_МОДЕЛИ_С_КОНТРОЛЕМ_ЗАГРУЗКИ {
  /**
   * @param {Object} модель данных, передаваемых в запрос
   * @param _this this свойства, которое будет обновляться
   * @param {String} имяСвойства имя обновляемого свойства
   */
  constructor (модель, _this, имяСвойства) {
    this.модель = модель
    this.loading = new LOADING(_this, имяСвойства)
  }
}

// ---------------------------------------------------------------------------------------------------------------------
export class ПАРАМЕТРЫ_ЗАПРОСА_ДОПУЩЕННЫЕ_КО_РЕСУРСУ_ЗЛИВС extends ПАРАМЕТРЫ_ЗАПРОСА_ДОМЕННЫЙ_ЛОГИН {
  /**
   * @param идОбъектаРесурса
   * @param доменныйЛогин
   */
  constructor (идОбъектаРесурса, доменныйЛогин = '') {
    super(доменныйЛогин)
    this.idObjectResource = идОбъектаРесурса
  }
}

// ---------------------------------------------------------------------------------------------------------------------
export class ТИП_ДЕЙСТВУЮЩИЕ_РЕСУРСЫ_ПОЛЬЗОВАТЕЛЯ {
  /**
   * порядковый номер записи в списке
   * @type {number} */
  id

  /**
   * ид объекта ресурса из таблицы [_OBJECT] БД
   * @type {number} */
  id_object

  /**
   * ид ресурса из таблицы [_RESOURCE] DB
   * @type {number} */
  id_resource

  /**
   * Имя ресурса
   * @type {string}  */
  name

  /**
   * ид типа объекта ресурса
   * @type {number}  */
  id_object_type

  /**
   * ид типа сервиса
   * @type {number}  */
  id_service_type

  /**
   * ид фрагмента
   * type {number}  */
  id_ac_fragment
}

export const VIEW_REPORT_ALL_RESOURCES = {
  id: null,
  resource_name: null,
  service_type_name: null,
  service_name: null,
  frag_name: null,
  path: null,
  description: null,
  secret_type_name: null,
  owner: null,
  responsible: null,
  reg_num: null,
  id_request_1: null,
  create_date_1: null,
  create_date_2: null,
  id_request_2: null,
  create_request_state: null,
  end_date_1: null,
  end_date_2: null,
  end_request_state: null,
  status: null, // поле создается в коде
}

export const VIEW_REPORT_ALL_REQUESTS = {
  id_request: null,
  date_1: null,
  request_type_name: null,
  request_type_code: null,
  sender: null,
  recipient: null,
  request_state_id: null,
  request_state_name: null,
  id_doc: null,
}

// ----------------------------------------------

export class UserModel {
  /**
   * @param {Array.<string>} roles Роли пользователя
   * @param {string} domainAccount Логин пользователя вида "ДОМЕН\логин", пример: "ZLIVS\kirillovanm"
   * @param {string} fio Фио пользователя
   * @param {Fragment} fragment Фрагмент, в котором зарегистрирован пользователь
   * @param {number} idUser ид пользователя в БД в таблице "_EMPLOYEE"
   */
  constructor (
    roles = [неОпределено],
    domainAccount = неОпределено,
    fio = неОпределено,
    fragment = new Fragment(),
    idUser = 0,
  ) {
    this.roles = roles
    this.domainAccount = domainAccount
    this.fio = fio
    this.fragment = fragment
    this.idUser = idUser
  }

  roles
  domainAccount
  fio
  fragment
  idUser
}

// ----------------------------------------------

export class Fragment {
  /**
   * @param {number} id
   * @param {string} name
   * @param {string} fname
   * @param code
   */
  constructor (
    id = 0,
    name = неОпределено,
    fname = неОпределено,
    code = неОпределено,
  ) {
    this.id = id
    this.name = name
    this.fname = fname
    this.code = code
  }

  id
  name
  fname
  code
}

export class ТипСервисов {
  /**
   * @param {number} id
   * @param {string} название
   * @param {string} префикс
   * @param {string} разделитель
   * @param {string} обёртка
   * @param {number} уровень_вложенности
   */
  constructor (
    id = 0,
    название = '',
    префикс = '',
    разделитель = '',
    обёртка = '',
    уровень_вложенности = 0,
  ) {
    this.id = id
    this.название = название
    this.префикс = префикс
    this.разделитель = разделитель
    this.обёртка = обёртка
    this.уровень_вложенности = уровень_вложенности

    this.Valid()
  }

  /** @type {number} */
  id

  /** @type {String} */
  название

  /** @type {string} */
  префикс

  /** @type {string} */
  разделитель

  /** @type {string} */
  обёртка

  /** @type {number} */
  уровень_вложенности

  Valid () {
    if (this.id === undefined || this.id == null || this.id < 1) throw new Error('ТипСервисов.id < 1')
    if (this.название === undefined || this.название === null || this.название?.length < 1) throw new Error('ТипСервисов.название.length < 1')
  }
}

export class ТипОбъектовСервисов {
  /**
   * @param {number} id
   * @param {string} name
   * @param {number} id_service_type
   * @param {number} main_object
   * @param {ТипСервисов} service_type
   * @param {string} code
   * @param {string} icon
   */
  constructor (
    id = 0,
    name = '',
    id_service_type = 0,
    main_object = 0,
    service_type = null,
    code = '',
    icon = '',
    ) {
    this.id = id
    this.name = name
    this.id_service_type = id_service_type
    this.main_object = main_object
    this.service_type = service_type
    this.code = code
    this.icon = icon
    this.ThrowIfNotValid()
  }

  /** @type {number} */
  id

  /** @type {string} */
  name

  /** @type {number} */
  id_service_type

  /** @type {number} */
  main_object

  /** @type {ТипСервисов} */
  service_type

  /** @type {string} */
  code

  /** @type {string} */
  icon

  ThrowIfNotValid () {
    if (this.id === undefined || this.id === null || this.id < 1) throw new Error('ТипОбъектовСервисов.id < 1')
    if (this.name === undefined || this.name === null || this.name?.length < 1) throw new Error('ТипОбъектовСервисов.name.length < 1')
    if (this.id_service_type === undefined || this.id_service_type === null || this.id_service_type < 1) throw new Error('ТипОбъектовСервисов.id_service_type < 1')
    if (this.service_type === undefined || this.service_type === null) throw new Error('ТипОбъектовСервисов.service_type === null')
    if (this.code === undefined || this.code === null || this.code?.length < 1) throw new Error('ТипОбъектовСервисов.code.length < 1')
    if (this.icon === undefined || this.icon === null || this.icon?.length < 1) throw new Error('ТипОбъектовСервисов.icon.length < 1')
  }

  /* ВернутьВалидныйПример () {
    return new ТипОбъектовСервисов(
      1, 'q', 2, 0,
      (new ТипСервисов())
    ) */
}

// ----------------------------------------------

// @LABEL:PARAM@
