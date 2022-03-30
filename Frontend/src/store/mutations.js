import * as mutationTypes from '@/store/mutation-types'
import * as paramsTypes from '@/store/param-types'
import * as lsn from '@/constants/localStorage_names'
import { /* localeStorageGetItem */ localeStorageSetItem } from './localforage'

export default {
  // мутации основного приложения
  // сущности

  /**
   * @param state
   * @param {{key: String, value: Object}} payload
   */
  [mutationTypes.ВОССТАНОВИТЬ_СВОЙСТВО_ИЗ_ХРАНИЛИЩА_БРАУЗЕРА] (state, payload) {
    // патчим ключ свойства и сохраняем
    if (state[payload.key] !== undefined) {
      state[payload.key] = payload.value
    }
  },

  /**
   * @param state
   * @param {Response.data.model} payload
   */
  [mutationTypes.СОХРАНИТЬ_РЕЗУЛЬТАТ_ЗАПРОСА] (state, payload) {
    state.requestData = payload
  },

  [mutationTypes.SAVE_LAST_PAGE] (state, payload) {
    state.lastPageName = payload
  },

  [mutationTypes.ИЗМЕНИТЬ_СОСТОЯНИЕ_РЕЖИМА_FAKE_USER] (state, payload) {
    state.fakeUserState = payload
  },

  [mutationTypes.СОХРАНИТЬ_АДРЕС_ХОСТА] (state, payload) {
    state.host = payload
  },
  [mutationTypes.СОХРАНИТЬ_РОЛИ_ПОЛЬЗОВАТЕЛЯ_СЕРВИСА] (state, payload) {
    state.userModel.roles = Array.from(payload)
  },

  [mutationTypes.СОХРАНИТЬ_МОДЕЛЬ_ПОЛЬЗОВАТЕЛЯ] (state, payload) {
    state.tempUserModel = { ...payload }
  },

  [mutationTypes.СОХРАНИТЬ_МОДЕЛЬ_ТЕКУЩЕГО_ПОЛЬЗОВАТЕЛЯ_СЕРВИСА] (state, payload) {
    state.userModel = { ...payload }
  },

  [mutationTypes.СОХРАНИТЬ_ФРАГМЕНТ] (state, payload) {
    state.фрагмент = { ...payload }
  },

  [mutationTypes.СОХРАНИТЬ_МОДЕЛЬ_ПОСЛЕДНЕГО_ПОЛЬЗОВАТЕЛЯ_СЕРВИСА] (state, payload) {
    state.lastUserModel = { ...payload }
  },

  [mutationTypes.СОХРАНИТЬ_МОДЕЛЬ_РЕАЛЬНОГО_ПОЛЬЗОВАТЕЛЯ_СЕРВИСА] (state, payload) {
    state.realUserModel = { ...payload }
  },

  [mutationTypes.СОХРАНИТЬ_ФИО_И_ИД] (state, value) {
    state.ФИО.family = value.family
    state.ФИО.name = value.name
    state.ФИО.patronymic = value.patronymic
    state.ФИО.id = value.id
  },
  [mutationTypes.СОХРАНИТЬ_ВСЕ_ФИО] (state, value) {
    state.всеФИО = value
  },

  [mutationTypes.СОХРАНИТЬ_АЛЕРТ] (state, alert) {
    state.алерт = { ...alert }
  },

  /**
   * @param state
   * @param {[]} alerts
   */
  [mutationTypes.СОХРАНИТЬ_АЛЕРТЫ] (state, alerts) {
    state.алерты = Array.from(alerts)
    localeStorageSetItem(lsn.алерты, alerts)
  },

  [mutationTypes.СТЕРЕТЬ_АЛЕРТ] (state) {
    state.алерт = new paramsTypes.ПАРАМЕТРЫ_АЛЕРТА(
      '',
      undefined,
      false,
    )
  },

  [mutationTypes.СОХРАНИТЬ_НАЗВАНИЕ_РЕСУРСА] (state, value) {
    state.названиеРесурса = value
  },

  [mutationTypes.СОХРАНИТЬ_ДЕРЕВО_РЕСУРСОВ] (state, value) {
    state.деревоРесурсов = value
    localeStorageSetItem(lsn.деревоРесурсов, value)
  },

  [mutationTypes.СОХРАНИТЬ_ВСЕ_ФРАГМЕНТЫ] (state, value) {
    state.всеФрагменты = value
    localeStorageSetItem(lsn.всеФрагменты, value)
  },

  [mutationTypes.СОХРАНИТЬ_ВСЕХ_СОТРУДНИКОВ_ДЛЯ_ФЕЙК_ЮЗЕРА] (state, value) {
    state.всеСотрудникиДляФейкЮзера = value
    localeStorageSetItem(lsn.всеСотрудникиДляФейкЮзера, value)
  },

  [mutationTypes.СОХРАНИТЬ_ВСЕХ_СОТРУДНИКОВ] (state, value) {
    state.всеСотрудники = value
    localeStorageSetItem(lsn.всеСотрудники, value)
  },

  [mutationTypes.СОХРАНИТЬ_ИМЯ_ЛОГИНА] (state, login) {
    state.имяЛогина = login
  },

  [mutationTypes.СОХРАНИТЬ_ЕМАЙЛ] (state, email) {
    state.емайл = email
  },

  [mutationTypes.СОХРАНИТЬ_ТИПЫ_СЕРВИСОВ] (state, value) {
    state.типыСервисов = value
    localeStorageSetItem(lsn.типыСервисов, value)
  },

  [mutationTypes.СОХРАНИТЬ_ТИПЫ_ОБЪЕКТОВ] (state, value) {
    state.типыОбъектов = value
    localeStorageSetItem(lsn.типыОбъектов, value)
  },

  [mutationTypes.СОХРАНИТЬ_ГЛАВНЫЕ_ТИПЫ_ОБЪЕКТОВ] (state, value) {
    state.главныеТипыОбъектов = value
    localeStorageSetItem(lsn.главныеТипыОбъектов, value)
  },

  [mutationTypes.СОХРАНИТЬ_ТИПЫ_ОБЪЕКТОВ_СЕРВИСОВ] (state, value) {
    state.типыОбъектовСервисов = value
    localeStorageSetItem(lsn.типыОбъектовСервисов, value)
  },

  [mutationTypes.СОХРАНИТЬ_ТИПЫ_СЕКРЕТНОСТИ] (state, value) {
    state.типыСекретности = value
    localeStorageSetItem(lsn.типыСекретности, value)
  },

  [mutationTypes.СОХРАНИТЬ_ОТВЕТСТВЕННЫХ] (state, value) {
    state.ответственные = value
  },

  [mutationTypes.СОХРАНИТЬ_ВЛАДЕЛЬЦЕВ_РЕСУРСОВ] (state, value) {
    state.владельцыРесурсов = value
    localeStorageSetItem(lsn.владельцыРесурсов, value)
  },
  [mutationTypes.СОХРАНИТЬ_ИМЯ_ПРОФИЛЯ] (state, value) {
    state.имяПрофиля = value
  },

  [mutationTypes.СОХРАНИТЬ_ДЕЙСТВУЮЩИЕ_РЕСУРСЫ] (state, value) {
    state.действующиеРесурсы = value
    localeStorageSetItem(lsn.действующиеРесурсы, value)
  },

  [mutationTypes.СОХРАНИТЬ_ДЕЙСТВУЮЩИЕ_РЕСУРСЫ_ПОЛЬЗОВАТЕЛЯ] (state, value) {
    state.действующиеРесурсыПользователя = value
    localeStorageSetItem(lsn.действующиеРесурсыПользователя, value)
  },

  [mutationTypes.СОХРАНИТЬ_ДЕЙСТВУЮЩИЕ_И_НА_ЭТАПЕ_РЕГИСТРАЦИИ_РЕСУРСЫ] (state, value) {
    state.действующиеИНаЭтапеРегистрацииРесурсы = value
    localeStorageSetItem(lsn.действующиеИНаЭтапеРегистрацииРесурсы, value)
  },

  [mutationTypes.СОХРАНИТЬ_ДЕЙСТВУЮЩИЕ_ПРОФИЛИ_ПОЛЬЗОВАТЕЛЯ] (state, value) {
    state.действующиеПрофилиПользователя = value
    localeStorageSetItem(lsn.действующиеПрофилиПользователя, value)
  },

  [mutationTypes.СОХРАНИТЬ_ДЕЙСТВУЮЩИЕ_И_НА_ЭТАПЕ_РЕГИСТРАЦИИ_ПРОФИЛИ] (state, value) {
    state.действующиеИНаЭтапеРегистрацииПрофили = value
    localeStorageSetItem(lsn.действующиеИНаЭтапеРегистрацииПрофили, value)
  },

  [mutationTypes.СОХРАНИТЬ_ПРАВА_ПРЕДОСТАВЛЯЕМЫЕ_ПРОФИЛЕМ] (state, value) {
    state.праваПредоставляемыеПрофилем = value
    localeStorageSetItem(lsn.праваПредоставляемыеПрофилем, value)
  },

  [mutationTypes.СОХРАНИТЬ_ТИПЫ_ДОБАВЛЯЕМЫХ_ОБЪЕКТОВ] (state, value) {
    state.типыДобавляемыхОбъектов = value
  },
  [mutationTypes.СОХРАНИТЬ_ДОСТУПЫ_СУБЪЕКТОВ_К_РЕСУРСАМ] (state, value) {
    state.доступыСубъектовКРесурсам = value
  },
  [mutationTypes.СОХРАНИТЬ_ОРГ_ЕДИНИЦЫ] (state, value) {
    state.оргЕдиницы = value
    localeStorageSetItem(lsn.оргЕдиницы, value)
  },
  [mutationTypes.СОХРАНИТЬ_ТАБЕЛЬНЫЙ_НОМЕР] (state, value) {
    state.табельныйНомер = value
  },
  [mutationTypes.СОХРАНИТЬ_ДОЛЖНОСТИ] (state, value) {
    state.должности = value
  },
  [mutationTypes.СОХРАНИТЬ_ФОРМУ_ДОПУСКА] (state, value) {
    state.формуДопуска = value
  },
  [mutationTypes.СОХРАНИТЬ_КАРТОЧКУ_СОТРУДНИКА] (state, value) {
    state.карточкаСотрудника = value
  },

  // @LABEL:STORE.MUTATION-ENTITIES@

  // отчеты
  [mutationTypes.СОХРАНИТЬ_ПЕРЕЧЕНЬ_СУБЬЕКТОВ_ДОСТУПА_ДОПУЩЕННОГО_К_РАБОТЕ_В_АС] (state, value) {
    state.переченьСубьектовДоступаДопущенногоКРаботеВАс = value
    localeStorageSetItem(lsn.переченьСубьектовДоступаДопущенногоКРаботеВАс, value)
  },

  [mutationTypes.СОХРАНИТЬ_ПЕРЕЧЕНЬ_РЕСУРСОВ_В_АС] (state, value) {
    state.переченьРесурсовВАс = value
    localeStorageSetItem(lsn.переченьРесурсовВАс, value)
  },

  [mutationTypes.СОХРАНИТЬ_ПЕРЕЧЕНЬ_АРМ_В_АС] (state, value) {
    state.переченьАрмВАс = value
    localeStorageSetItem(lsn.переченьАрмВАс, value)
  },

  [mutationTypes.СОХРАНИТЬ_ПЕРЕЧЕНЬ_СУБЪЕКТОВ_ДОСТУПА_ДОПУЩЕННЫХ_К_РАБОТЕ_НА_АРМ] (state, value) {
    state.переченьСубъектовДоступаДопущенныхКРаботеНаАрм = value
    localeStorageSetItem(lsn.переченьСубъектовДоступаДопущенныхКРаботеНаАрм, value)
  },
  [mutationTypes.СОХРАНИТЬ_ПЕРЕЧЕНЬ_РЕСУРСОВ_К_КОТОРЫМ_ПРЕДОСТАВЛЕН_ДОСТУП_СУБЪЕКТАМ] (state, value) {
    state.переченьРесурсовККоторымПредоставленДоступСубъектам = value
  },

  [mutationTypes.СОХРАНИТЬ_РАЗРЕШИТЕЛЬНАЯ_СИСТЕМА_ДОСТУПА_К_РЕСУРСАМ] (state, value) {
    state.разрешительнаяСистемаДоступаКРесурсам = value
    localeStorageSetItem(lsn.разрешительнаяСистемаДоступаКРесурсам, value)
  },
  // @LABEL:STORE.MUTATION-REPORTS@

  // для админов
  [mutationTypes.СОХРАНИТЬ_ОЧЕРЕДЬ_ЗАЯВОК_НА_ОБРАБОТКУ] (state, value) {
    state.заявкиНаОбработку = value
    localeStorageSetItem(lsn.заявкиНаОбработку, value)
  },

  [mutationTypes.СОХРАНИТЬ_ВЫПОЛНЕННЫЕ_ЗАЯВКИ] (state, value) {
    state.заявкиВыполненные = value
    localeStorageSetItem(lsn.заявкиВыполненные, value)
  },

  [mutationTypes.СОХРАНИТЬ_СУЩЕСТВУЮЩИЕ_ПРОФИЛИ_ДЛЯ_АДМИНА] (state, value) {
    state.существующиеПрофилиДляАдмина = value
    localeStorageSetItem(lsn.существующиеПрофилиДляАдмина, value)
  },

  /**
   * Удаление элемента массива таблицы через функцию,
   * которую необходимо передать в мутацию,
   * функция принимает массив элементов для обработки
   * @param state
   * @param commit
   * @param {Function} _func
   */
  [mutationTypes.УДАЛИТЬ_ЭЛЕМЕНТ_ИЗ_ОЧЕРЕДИ_ЗАЯВОК_НА_ОБРАБОТКУ] ({ state, commit }, _func) {
    _func(state.заявкиНаОбработку)
    // т.к. манипулируем списком напрямую, без мутации,
    // то в localStorage остаётся неактуальная информация,
    // поэтому, обновляем localStorage
    /* commit(
      mutationTypes.СОХРАНИТЬ_ОЧЕРЕДЬ_ЗАЯВОК_НА_ОБРАБОТКУ,
      state.заявкиНаОбработку,
    ) */
  },

  // для пользователей
  [mutationTypes.СОХРАНИТЬ_ЗАЯВКИ] (state, value) {
    state.заявки = value
  },

  [mutationTypes.СОХРАНИТЬ_МОИ_ПРОФИЛИ] (state, value) {
    state.моиПрофили = value
    localeStorageSetItem(lsn.моиПрофили, value)
  },
}
