import * as actionTypes from '@/store/action-types'
import LF from 'localforage'
import * as paramsTypes from '@/store/param-types'
import * as mutationTypes from '@/store/mutation-types'
import * as getterTypes from '@/store/getter-types'
import { get, успешно } from '@/plugins/axios/get'
import * as urlTypes from '@/store/url-types'
import { axPost } from '@/plugins/axios/axios'
import { PostPayload } from '@/store/store'
import ТипАлерта from '@/constants/типАлерта'
import { localeStorageSetItem, localeStorageGetItem, setInstance } from './localforage'
// import * as lsn from '@/constants/localStorage_names'
// eslint-disable-next-line camelcase
// import { $_moment } from '@/plugins/Moment'

let iLocalForage = null

export { iLocalForage }

export default {
  // действия основного приложения

  // ############################################################
  // #### СОХРАНИТЬ СОСТОЯНИЕ ОБЪЕКТА (ВЫЗВАТЬ МУТАЦИЮ) #########
  // ############################################################

  /**
   * Создать новое хранилище с определенным именем
   * или переключиться на старое хранилище, если хранилище уже было создано ранее
   * @param commit
   * @param dispatch
   * @param {String} name
   */
  [actionTypes.CreateInstance] ({ commit, dispatch }, name) {
    iLocalForage = LF.createInstance({ name: name })
    setInstance(iLocalForage)

    /* dispatch(
      actionTypes.АЛЕРТНУТЬ,
      new paramsTypes.ПАРАМЕТРЫ_АЛЕРТА(
        `Хранилище изменено на: ${iLocalForage._config.name}`,
        ТипАлерта.info,
      ),
    ) */
  },

  [actionTypes.ПОЛУЧИТЬ_ВСЕ_СВОЙСТВА_ИЗ_ХРАНИЛИЩА_БРАУЗЕРА] ({ commit }) {
    iLocalForage.iterate((value, key, iterationNumber) => {
      console.log(`#${iterationNumber}: key: ${key}`)
      // если встречаем свойство - загружаем его
      if (key.indexOf('state#') === 0) {
        // убираем префикс из имени свойства и сохраняем свойство через мутацию
        commit(mutationTypes.ВОССТАНОВИТЬ_СВОЙСТВО_ИЗ_ХРАНИЛИЩА_БРАУЗЕРА, {
          key: key.substring('state#'.length),
          value: value,
        })
        console.log(`Мутация на восстановление свойства [${key}] отправлена`)
      }
      console.log()
    }).catch(e => {
      console.log(e)
    })
  },

  /**
   * Сохранить форму в хранилище браузера
   * @param dispatch
   * @param {{key: String, value: Object}} payload
   */
  [actionTypes.СОХРАНИТЬ_ФОРМУ_ВО_ХРАНИЛИЩЕ_БРАУЗЕРА] ({ dispatch }, payload) {
    // патчим имя ключа для формы префиксом 'form#', чтобы отличать от геттеров и других сущностей
    payload.key = `form#${payload.key}`

    // сохраняем форму в хранилище
    localeStorageSetItem(payload.key, payload.value)

    dispatch(
      actionTypes.АЛЕРТНУТЬ,
      new paramsTypes.ПАРАМЕТРЫ_АЛЕРТА(
        'Данные формы сохранены',
        ТипАлерта.info,
      ),
    )
  },

  /**
   * Получить ключ из хранилища браузера
   * @param dispatch
   * @param {String} key - ключ должен быть указан с префиксом, например: 'state#qwertyuio', 'form#xcvbnm'
   */
  async [actionTypes.ПОЛУЧИТЬ_КЛЮЧ_ИЗ_ХРАНИЛИЩА_БРАУЗЕРА] ({ dispatch }, key) {
    console.log(`ПОЛУЧИТЬ_КЛЮЧ_ИЗ_ХРАНИЛИЩА_БРАУЗЕРА, key: ${key}`)

    const v = await localeStorageGetItem(key)
    if (v === undefined || v === null) {
      // dispatch(actionTypes.АЛЕРТНУТЬ_НЕТ_ДАННЫХ_ДЛЯ_ВОССТАНОВЛЕНИЯ)
      return null
    }
    return v
  },

  /**
   * Получить форму из хранилища браузера
   * @param dispatch
   * @param {String} key
   */
  async [actionTypes.ПОЛУЧИТЬ_ФОРМУ_ИЗ_ХРАНИЛИЩА_БРАУЗЕРА] ({ dispatch }, key) {
    console.log(`ПОЛУЧИТЬ_ФОРМУ_ИЗ_ХРАНИЛИЩА_БРАУЗЕРА, key: ${key}`)
    // патчим имя ключа формы, потому что она была сохранена с префиксом 'form#'
    // получаем форму из хранилища
    const v = await localeStorageGetItem(`form#${key}`)
    if (v === undefined || v === null) {
      dispatch(actionTypes.АЛЕРТНУТЬ_НЕТ_ДАННЫХ_ДЛЯ_ВОССТАНОВЛЕНИЯ)
      return null
    }
    return v
  },

  // сущности

  [actionTypes.ВКЛЮЧИТЬ_РЕЖИМ_FAKE_USER] ({ commit }, payload) {
    commit(mutationTypes.СОХРАНИТЬ_МОДЕЛЬ_РЕАЛЬНОГО_ПОЛЬЗОВАТЕЛЯ_СЕРВИСА, this.state.userModel)
    commit(mutationTypes.СОХРАНИТЬ_МОДЕЛЬ_ТЕКУЩЕГО_ПОЛЬЗОВАТЕЛЯ_СЕРВИСА, payload)
    commit(mutationTypes.СОХРАНИТЬ_МОДЕЛЬ_ПОСЛЕДНЕГО_ПОЛЬЗОВАТЕЛЯ_СЕРВИСА, payload)
    commit(mutationTypes.ИЗМЕНИТЬ_СОСТОЯНИЕ_РЕЖИМА_FAKE_USER, true)
    console.log('ВКЛЮЧИТЬ_РЕЖИМ_FAKE_USER')
  },

  [actionTypes.ВЫКЛЮЧИТЬ_РЕЖИМ_FAKE_USER] ({ commit }) {
    // восстанавливаем реального пользователя сервиса
    commit(mutationTypes.СОХРАНИТЬ_МОДЕЛЬ_ТЕКУЩЕГО_ПОЛЬЗОВАТЕЛЯ_СЕРВИСА, this.state.realUserModel)
    commit(mutationTypes.ИЗМЕНИТЬ_СОСТОЯНИЕ_РЕЖИМА_FAKE_USER, false)
    console.log('ВЫКЛЮЧИТЬ_РЕЖИМ_FAKE_USER')
  },

  [actionTypes.СОХРАНИТЬ_ДОСТУПЫ_СУБЪЕКТОВ_К_РЕСУРСАМ] ({ commit }, value) {
    commit(mutationTypes.СОХРАНИТЬ_ДОСТУПЫ_СУБЪЕКТОВ_К_РЕСУРСАМ, value)
  },
  [actionTypes.СОХРАНИТЬ_ОРГ_ЕДИНИЦЫ] ({ commit }, value) {
    commit(mutationTypes.СОХРАНИТЬ_ОРГ_ЕДИНИЦЫ, value)
  },
  [actionTypes.СОХРАНИТЬ_ТАБЕЛЬНЫЙ_НОМЕР] ({ commit }, value) {
    commit(mutationTypes.СОХРАНИТЬ_ТАБЕЛЬНЫЙ_НОМЕР, value)
  },
  // @LABEL:STORE.ACTIONS-COMMIT-ENTITIES@

  // отчеты
  [actionTypes.СОХРАНИТЬ_ПЕРЕЧЕНЬ_СУБЬЕКТОВ_ДОСТУПА_ДОПУЩЕННОГО_К_РАБОТЕ_В_АС] ({ commit }, value) {
    commit(mutationTypes.СОХРАНИТЬ_ПЕРЕЧЕНЬ_СУБЬЕКТОВ_ДОСТУПА_ДОПУЩЕННОГО_К_РАБОТЕ_В_АС, value)
  },
  [actionTypes.СОХРАНИТЬ_ПЕРЕЧЕНЬ_РЕСУРСОВ_В_АС] ({ commit }, value) {
    commit(mutationTypes.СОХРАНИТЬ_ПЕРЕЧЕНЬ_РЕСУРСОВ_В_АС, value)
  },
  [actionTypes.СОХРАНИТЬ_ПЕРЕЧЕНЬ_АРМ_В_АС] ({ commit }, value) {
    commit(mutationTypes.СОХРАНИТЬ_ПЕРЕЧЕНЬ_АРМ_В_АС, value)
  },
  [actionTypes.СОХРАНИТЬ_ПЕРЕЧЕНЬ_СУБЪЕКТОВ_ДОСТУПА_ДОПУЩЕННЫХ_К_РАБОТЕ_НА_АРМ] ({ commit }, value) {
    commit(mutationTypes.СОХРАНИТЬ_ПЕРЕЧЕНЬ_СУБЪЕКТОВ_ДОСТУПА_ДОПУЩЕННЫХ_К_РАБОТЕ_НА_АРМ, value)
  },
  [actionTypes.СОХРАНИТЬ_ПЕРЕЧЕНЬ_РЕСУРСОВ_К_КОТОРЫМ_ПРЕДОСТАВЛЕН_ДОСТУП_СУБЪЕКТАМ] ({ commit }, value) {
    commit(mutationTypes.СОХРАНИТЬ_ПЕРЕЧЕНЬ_РЕСУРСОВ_К_КОТОРЫМ_ПРЕДОСТАВЛЕН_ДОСТУП_СУБЪЕКТАМ, value)
  },
  [actionTypes.СОХРАНИТЬ_РАЗРЕШИТЕЛЬНАЯ_СИСТЕМА_ДОСТУПА_К_РЕСУРСАМ] ({ commit }, value) {
    commit(mutationTypes.СОХРАНИТЬ_РАЗРЕШИТЕЛЬНАЯ_СИСТЕМА_ДОСТУПА_К_РЕСУРСАМ, value)
  },
  // @LABEL:STORE.ACTIONS-COMMIT-REPORTS@

  // ############################################################
  // #### КОМПЛЕКСНЫЕ ЗАПРОСЫ (для заполнения форм) #############
  // ############################################################

  [actionTypes.ЗАПРОСИТЬ_ДАННЫЕ_ДЛЯ_ФОРМЫ_СОЗДАТЬ_РЕСУРС] ({ dispatch, getters }) {
    // dispatch(actionTypes.ПОЛУЧИТЬ_ОТВЕТСТВЕННЫХ_С_СЕРВЕРА)
    // dispatch(actionTypes.ПОЛУЧИТЬ_ВСЕ_ФРАГМЕНТЫ_С_СЕРВЕРА)

    dispatch(
      actionTypes.ПОЛУЧИТЬ_ДЕЙСТВУЮЩИЕ_И_НА_ЭТАПЕ_РЕГИСТРАЦИИ_РЕСУРСЫ_С_СЕРВЕРА,
      new paramsTypes.ПАРАМЕТРЫ_ЗАПРОСА_ДЕЙСТВУЮЩИЕ_И_НА_ЭТАПЕ_РЕГИСТРАЦИИ_РЕСУРСЫ_ВО_ФРАГМЕНТЕ(
        getters[getterTypes.получитьФрагмент].id,
        getters[getterTypes.domainAccount],
      ),
    )

    dispatch(actionTypes.ПОЛУЧИТЬ_ТИПЫ_ОБЪЕКТОВ_СЕРВИСОВ)
    dispatch(actionTypes.ПОЛУЧИТЬ_ГЛАВНЫЕ_ТИПЫ_ОБЪЕКТОВ)
    // dispatch(actionTypes.ПОЛУЧИТЬ_ТИПЫ_СЕРВИСОВ_С_СЕРВЕРА)
    dispatch(actionTypes.ПОЛУЧИТЬ_ТИПЫ_СЕКРЕТНОСТИ_С_СЕРВЕРА)
    dispatch(actionTypes.ПОЛУЧИТЬ_ВЛАДЕЛЬЦЕВ_РЕСУРСОВ_С_СЕРВЕРА)
    dispatch(actionTypes.ПОЛУЧИТЬ_ФИО_ВСЕХ_ДЕЙСТВУЮЩИХ_СОТРУДНИКОВ_С_СЕРВЕРА)
    // dispatch(actionTypes.ПОЛУЧИТЬ_СОТРУДНИКОВ_ДЛЯ_ФЕЙК_ЮЗЕРА)
    dispatch(actionTypes.ПОЛУЧИТЬ_ОРГ_ЕДИНИЦЫ_С_СЕРВЕРА)
  },

  /**
   * ЗАПРОСИТЬ_ДАННЫЕ_ДЛЯ_ФОРМЫ_ДОБАВИТЬ_ОБЪЕКТ_В_ПРОФИЛЬ
   * @param dispatch
   * @param getters
   */
  [actionTypes.ЗАПРОСИТЬ_ДАННЫЕ_ДЛЯ_ФОРМЫ_ДОБАВИТЬ_ОБЪЕКТ_В_ПРОФИЛЬ] ({ dispatch, getters }) {
    throw new Error('метод более не используется')

    // eslint-disable-next-line no-unreachable
    dispatch(actionTypes.ПОЛУЧИТЬ_ПРАВА_ПРЕДОСТАВЛЯЕМЫЕ_ПРОФИЛЕМ_С_СЕРВЕРА)

    dispatch(
      actionTypes.ПОЛУЧИТЬ_ДЕЙСТВУЮЩИЕ_И_НА_ЭТАПЕ_РЕГИСТРАЦИИ_ПРОФИЛИ_ПОЛЬЗОВАТЕЛЯ_С_СЕРВЕРА,
      new paramsTypes.ПАРАМЕТРЫ_ЗАПРОСА_ЗАВИСЯЩЕГО_ОТ_ФРАГМЕНТА(
        getters[getterTypes.получитьФрагмент].id,
        getters[getterTypes.domainAccount],
      ))

    dispatch(
      actionTypes.ПОЛУЧИТЬ_ДЕЙСТВУЮЩИЕ_РЕСУРСЫ_ПОЛЬЗОВАТЕЛЯ_С_СЕРВЕРА,
      new paramsTypes.ПАРАМЕТРЫ_ЗАПРОСА_ДЕЙСТВУЮЩИЕ_РЕСУРСЫ_ПОЛЬЗОВАТЕЛЯ_ВО_ФРАГМЕНТЕ(
        getters[getterTypes.получитьФрагмент].id,
        getters[getterTypes.domainAccount],
      ),
    )

    dispatch(actionTypes.ПОЛУЧИТЬ_ТИПЫ_ОБЪЕКТОВ_СЕРВИСОВ)
    dispatch(actionTypes.ПОЛУЧИТЬ_ГЛАВНЫЕ_ТИПЫ_ОБЪЕКТОВ)
  },
  // @LABEL:STORE.ACTIONS-LOAD-FORMS@

  // ############################################################
  // #### ПОЛУЧИТЬ (GET) ########################################
  // ############################################################

  /**
   * @param dispatch
   * @param getters
   * @param {Object.<ПАРАМЕТРЫ_ЗАПРОСА_ПОЛУЧИТЬ_ОБЪЕКТЫ_ПРОФИЛЯ>} модель
   * @return {*}
   */
  async [actionTypes.ПОЛУЧИТЬ_ОБЪЕКТЫ_ПРОФИЛЯ] ({ commit }, модель) {
    const model = await get(
      urlTypes.ПОЛУЧИТЬ_ОБЪЕКТЫ_ПРОФИЛЯ,
      модель,
    )

    commit(
      mutationTypes.СОХРАНИТЬ_РЕЗУЛЬТАТ_ЗАПРОСА,
      model,
    )

    return model
  },

  /**
   * @param dispatch
   * @param getters
   * @param {Object.<ПАРАМЕТРЫ_ЗАПРОСА_ПОЛУЧИТЬ_СОДЕРЖИМОЕ_ЗАЯВКИ>} модель
   */
  async [actionTypes.ПОЛУЧИТЬ_СОДЕРЖИМОЕ_ЗАЯВКИ_ПО_ТИПУ_ЗАЯВКИ_И_НОМЕРУ_ЗАЯВКИ] ({ commit }, модель) {
    const model = await get(
      urlTypes.ПОЛУЧИТЬ_СОДЕРЖИМОЕ_ЗАЯВКИ_ПО_ТИПУ_ЗАЯВКИ_И_НОМЕРУ_ЗАЯВКИ,
      модель,
    )

    commit(
      mutationTypes.СОХРАНИТЬ_РЕЗУЛЬТАТ_ЗАПРОСА,
      model,
    )

    return model
  },

  async [actionTypes.ПОЛУЧИТЬ_ВСЕ_ФИО_С_СЕРВЕРА] ({ commit }) {
    const model = await get(urlTypes.ПОЛУЧИТЬ_ВСЕ_ФИО_С_СЕРВЕРА)

    commit(
      mutationTypes.СОХРАНИТЬ_ВСЕ_ФИО,
      model,
    )

    return model
  },

  async [actionTypes.ПОЛУЧИТЬ_ФИО_С_СЕРВЕРА] ({ commit }, id) {
    const model = await get(
      urlTypes.ПОЛУЧИТЬ_ФИО_С_СЕРВЕРА,
      { id: id },
    )

    commit(
      mutationTypes.СОХРАНИТЬ_ФИО_И_ИД,
      model,
    )

    return model
  },

  async [actionTypes.ПОЛУЧИТЬ_ВСЕ_ФРАГМЕНТЫ_С_СЕРВЕРА] ({ commit }) {
    // commit(mutationTypes.СОХРАНИТЬ_ВСЕ_ФРАГМЕНТЫ, null)
    const model = await get(urlTypes.ПОЛУЧИТЬ_ВСЕ_ФРАГМЕНТЫ_С_СЕРВЕРА)

    commit(
      mutationTypes.СОХРАНИТЬ_ВСЕ_ФРАГМЕНТЫ,
      model,
    )

    return model
  },

  async [actionTypes.ПОЛУЧИТЬ_ФИО_ВСЕХ_ДЕЙСТВУЮЩИХ_СОТРУДНИКОВ_С_СЕРВЕРА] ({ commit }) {
    // commit(mutationTypes.СОХРАНИТЬ_ВСЕХ_СОТРУДНИКОВ, null)
    const model = await get(urlTypes.ПОЛУЧИТЬ_ФИО_ВСЕХ_ДЕЙСТВУЮЩИХ_СОТРУДНИКОВ_С_СЕРВЕРА)

    commit(
      mutationTypes.СОХРАНИТЬ_ВСЕХ_СОТРУДНИКОВ,
      model,
    )

    return model
  },

  async [actionTypes.ПОЛУЧИТЬ_СОТРУДНИКОВ_ДЛЯ_ФЕЙК_ЮЗЕРА] ({ commit }) {
    // commit(mutationTypes.СОХРАНИТЬ_ВСЕХ_СОТРУДНИКОВ_ДЛЯ_ФЕЙК_ЮЗЕРА, null)
    const model = await get(urlTypes.ПОЛУЧИТЬ_СОТРУДНИКОВ_ДЛЯ_ФЕЙК_ЮЗЕРА)

    commit(
      mutationTypes.СОХРАНИТЬ_ВСЕХ_СОТРУДНИКОВ_ДЛЯ_ФЕЙК_ЮЗЕРА,
      model,
    )

    return model
  },

  /* [actionTypes.ПОЛУЧИТЬ_ВСЕ_РЕСУРСЫ_С_СЕРВЕРА] ({ dispatch, commit }) {
    commit(mutationTypes.СОХРАНИТЬ_ВСЕ_РЕСУРСЫ, null)

    dispatch(
      actionTypes.ВЫПОЛНИТЬ_ЗАПРОС_GET,
      new GetPayloadNoParam(
        urlTypes.ПОЛУЧИТЬ_ВСЕ_РЕСУРСЫ_С_СЕРВЕРА,
        mutationTypes.СОХРАНИТЬ_ВСЕ_РЕСУРСЫ,
        actionTypes.ПОЛУЧИТЬ_ВСЕ_РЕСУРСЫ_С_СЕРВЕРА,
      ))
  }, */

  async [actionTypes.ПОЛУЧИТЬ_ТИПЫ_СЕРВИСОВ_С_СЕРВЕРА] ({ commit }) {
    // commit(mutationTypes.СОХРАНИТЬ_ТИПЫ_СЕРВИСОВ, null)
    const model = await get(urlTypes.ПОЛУЧИТЬ_ТИПЫ_СЕРВИСОВ_С_СЕРВЕРА)

    commit(
      mutationTypes.СОХРАНИТЬ_ТИПЫ_СЕРВИСОВ,
      model,
    )

    return model
  },

  async [actionTypes.ПОЛУЧИТЬ_ТИПЫ_ОБЪЕКТОВ_С_СЕРВЕРА] ({ commit }, модель) {
    // commit(mutationTypes.СОХРАНИТЬ_ТИПЫ_ОБЪЕКТОВ, null)
    const model = await get(urlTypes.ПОЛУЧИТЬ_ТИПЫ_ОБЪЕКТОВ_С_СЕРВЕРА, модель)
    commit(mutationTypes.СОХРАНИТЬ_ТИПЫ_ОБЪЕКТОВ, model)
    return model
  },

  async [actionTypes.ПОЛУЧИТЬ_ГЛАВНЫЕ_ТИПЫ_ОБЪЕКТОВ] ({ commit }) {
    // commit(mutationTypes.СОХРАНИТЬ_ГЛАВНЫЕ_ТИПЫ_ОБЪЕКТОВ, null)

    const model = await get(
      urlTypes.ПОЛУЧИТЬ_ТИПЫ_ОБЪЕКТОВ_С_СЕРВЕРА,
      new paramsTypes.ПАРАМЕТРЫ_ЗАПРОСА_ТИПОВ_ОБЪЕКТОВ(
        null,
        1,
      ),
    )

    commit(
      mutationTypes.СОХРАНИТЬ_ГЛАВНЫЕ_ТИПЫ_ОБЪЕКТОВ,
      model,
    )

    return model
  },

  async [actionTypes.ПОЛУЧИТЬ_ТИПЫ_ОБЪЕКТОВ_СЕРВИСОВ] ({ commit }) {
    // commit(mutationTypes.СОХРАНИТЬ_ТИПЫ_ОБЪЕКТОВ_СЕРВИСОВ, null)
    const model = await get(urlTypes.ПОЛУЧИТЬ_ТИПЫ_ОБЪЕКТОВ_СЕРВИСОВ)

    commit(
      mutationTypes.СОХРАНИТЬ_ТИПЫ_ОБЪЕКТОВ_СЕРВИСОВ,
      model,
    )

    return model
  },

  async [actionTypes.ПОЛУЧИТЬ_ТИПЫ_СЕКРЕТНОСТИ_С_СЕРВЕРА] ({ commit }) {
    // commit(mutationTypes.СОХРАНИТЬ_ТИПЫ_СЕКРЕТНОСТИ, null)
    const model = await get(urlTypes.ПОЛУЧИТЬ_ТИПЫ_СЕКРЕТНОСТИ_С_СЕРВЕРА)

    commit(
      mutationTypes.СОХРАНИТЬ_ТИПЫ_СЕКРЕТНОСТИ,
      model,
    )

    return model
  },

  async [actionTypes.ПОЛУЧИТЬ_ВЛАДЕЛЬЦЕВ_РЕСУРСОВ_С_СЕРВЕРА] ({ commit }) {
    // commit(mutationTypes.СОХРАНИТЬ_ВЛАДЕЛЬЦЕВ_РЕСУРСОВ, null)
    const model = await get(urlTypes.ПОЛУЧИТЬ_ВЛАДЕЛЬЦЕВ_РЕСУРСОВ_С_СЕРВЕРА)

    commit(
      mutationTypes.СОХРАНИТЬ_ВЛАДЕЛЬЦЕВ_РЕСУРСОВ,
      model,
    )

    return model
  },

  /**
   * @param dispatch
   * @param commit
   * @param {paramsTypes.ПАРАМЕТРЫ_ЗАПРОСА_ДЕЙСТВУЮЩИЕ_РЕСУРСЫ} модель
   */
  async [actionTypes.ПОЛУЧИТЬ_ДЕЙСТВУЮЩИЕ_И_НА_ЭТАПЕ_РЕГИСТРАЦИИ_РЕСУРСЫ_С_СЕРВЕРА] ({ commit }, модель) {
    // commit(mutationTypes.СОХРАНИТЬ_ДЕЙСТВУЮЩИЕ_РЕСУРСЫ, null)
    const model = await get(
      urlTypes.ПОЛУЧИТЬ_ДЕЙСТВУЮЩИЕ_И_НА_ЭТАПЕ_РЕГИСТРАЦИИ_РЕСУРСЫ_С_СЕРВЕРА,
      модель,
    )

    commit(
      mutationTypes.СОХРАНИТЬ_ДЕЙСТВУЮЩИЕ_И_НА_ЭТАПЕ_РЕГИСТРАЦИИ_РЕСУРСЫ,
      model,
    )

    return model
  },

  /**
   * @param dispatch
   * @param commit
   * @param модель
   */
  async [actionTypes.ПОЛУЧИТЬ_ДЕЙСТВУЮЩИЕ_РЕСУРСЫ_ПОЛЬЗОВАТЕЛЯ_С_СЕРВЕРА] ({ commit }, модель) {
    const model = await get(urlTypes.ПОЛУЧИТЬ_ДЕЙСТВУЮЩИЕ_РЕСУРСЫ_ПОЛЬЗОВАТЕЛЯ_С_СЕРВЕРА, модель)
    commit(mutationTypes.СОХРАНИТЬ_ДЕЙСТВУЮЩИЕ_РЕСУРСЫ_ПОЛЬЗОВАТЕЛЯ, model)
    return model
  },

  /**
   * @param dispatch
   * @param commit
   * @param {Object.<ПАРАМЕТРЫ_ЗАПРОСА_ЗАВИСЯЩЕГО_ОТ_ФРАГМЕНТА>} модель
   * @returns {*}
   */
  async [actionTypes.ПОЛУЧИТЬ_ДЕЙСТВУЮЩИЕ_ПРОФИЛИ_ПОЛЬЗОВАТЕЛЯ_С_СЕРВЕРА] ({ dispatch, commit }, модель) {
    console.log('actionTypes.ПОЛУЧИТЬ_ДЕЙСТВУЮЩИЕ_ПРОФИЛИ_ПОЛЬЗОВАТЕЛЯ_С_СЕРВЕРА')

    const model = await get(urlTypes.ПОЛУЧИТЬ_ДЕЙСТВУЮЩИЕ_ПРОФИЛИ_ПОЛЬЗОВАТЕЛЯ_С_СЕРВЕРА, модель)
    commit(mutationTypes.СОХРАНИТЬ_ДЕЙСТВУЮЩИЕ_ПРОФИЛИ_ПОЛЬЗОВАТЕЛЯ, model)
    return model
  },

  /**
   * ПОЛУЧИТЬ_ДЕЙСТВУЮЩИЕ_И_НА_ЭТАПЕ_РЕГИСТРАЦИИ_ПРОФИЛИ_ПОЛЬЗОВАТЕЛЯ_С_СЕРВЕРА
   * @param commit
   * @param {Object.<ПАРАМЕТРЫ_ЗАПРОСА_ЗАВИСЯЩЕГО_ОТ_ФРАГМЕНТА>} модель
   */
  async [actionTypes.ПОЛУЧИТЬ_ДЕЙСТВУЮЩИЕ_И_НА_ЭТАПЕ_РЕГИСТРАЦИИ_ПРОФИЛИ_ПОЛЬЗОВАТЕЛЯ_С_СЕРВЕРА] ({ commit }, модель) {
    const model = await get(
      urlTypes.ПОЛУЧИТЬ_ДЕЙСТВУЮЩИЕ_И_НА_ЭТАПЕ_РЕГИСТРАЦИИ_ПРОФИЛИ_ПОЛЬЗОВАТЕЛЯ_С_СЕРВЕРА,
      модель,
    )

    commit(
      mutationTypes.СОХРАНИТЬ_ДЕЙСТВУЮЩИЕ_И_НА_ЭТАПЕ_РЕГИСТРАЦИИ_ПРОФИЛИ,
      model,
    )

    return model
  },

  /**
   * @param dispatch
   * @param commit
   * @param {Object.<ПАРАМЕТРЫ_ЗАПРОСА_ПРОФИЛИ_ПРИВЯЗАННЫЕ_КО_РЕСУРСУ>} модель
   * @returns {*}
   */
  async [actionTypes.ПОЛУЧИТЬ_ПРОФИЛИ_ПРИВЯЗАННЫЕ_КО_РЕСУРСУ_С_СЕРВЕРА] ({ commit }, модель) {
    const model = await get(urlTypes.ПОЛУЧИТЬ_ПРОФИЛИ_ПРИВЯЗАННЫЕ_КО_РЕСУРСУ_С_СЕРВЕРА, модель)
    commit(mutationTypes.СОХРАНИТЬ_ДЕЙСТВУЮЩИЕ_ПРОФИЛИ_ПОЛЬЗОВАТЕЛЯ, model)
    return model
  },

  /**
   * @param dispatch
   * @param commit
   * @param {Object.<ПАРАМЕТРЫ_ЗАПРОСА_ДОПУЩЕННЫЕ_КО_РЕСУРСУ_ЗЛИВС>} модель
   * @returns {*}
   */
  async [actionTypes.ПОЛУЧИТЬ_СОТРУДНИКОВ_ДОПУЩЕННЫХ_КО_РЕСУРСУ_ЗЛИВС] ({ commit }, модель) {
    throw new Error('метод не туда сохраняет данные, переделать')

    // eslint-disable-next-line no-unreachable
    const model = await get(urlTypes.ПОЛУЧИТЬ_СОТРУДНИКОВ_ДОПУЩЕННЫХ_КО_РЕСУРСУ_ЗЛИВС, модель)
    commit(mutationTypes.СОХРАНИТЬ_ВСЕХ_СОТРУДНИКОВ, model)
    return model
  },

  /**
   * @param dispatch
   * @param {Object.<ПАРАМЕТРЫ_ЗАПРОСА_ДОПУЩЕННЫЕ_КО_РЕСУРСУ_ЗЛИВС>} модель
   * @returns {*}
   */
  async [actionTypes.ПОЛУЧИТЬ_ОРГЕДИНИЦЫ_ДОПУЩЕННЫЕ_КО_РЕСУРСУ_ЗЛИВС] ({ commit }, модель) {
    const model = await get(urlTypes.ПОЛУЧИТЬ_ОРГЕДИНИЦЫ_ДОПУЩЕННЫХ_КО_РЕСУРСУ_ЗЛИВС, модель)
    commit(mutationTypes.СОХРАНИТЬ_ОРГ_ЕДИНИЦЫ, model)
    return model
  },

  async [actionTypes.ПОЛУЧИТЬ_ПРАВА_ПРЕДОСТАВЛЯЕМЫЕ_ПРОФИЛЕМ_С_СЕРВЕРА] ({ commit }) {
    const model = await get(urlTypes.ПОЛУЧИТЬ_ПРАВА_ПРЕДОСТАВЛЯЕМЫЕ_ПРОФИЛЕМ_С_СЕРВЕРА)

    commit(
      mutationTypes.СОХРАНИТЬ_ПРАВА_ПРЕДОСТАВЛЯЕМЫЕ_ПРОФИЛЕМ,
      model,
    )

    return model
  },

  async [actionTypes.ПОЛУЧИТЬ_ТИПЫ_ДОБАВЛЯЕМЫХ_ОБЪЕКТОВ_С_СЕРВЕРА] ({ commit }, модель) {
    const model = await get(urlTypes.ПОЛУЧИТЬ_ТИПЫ_ОБЪЕКТОВ_С_СЕРВЕРА, модель)
    commit(mutationTypes.СОХРАНИТЬ_ТИПЫ_ДОБАВЛЯЕМЫХ_ОБЪЕКТОВ, model)
    return model
  },

  async [actionTypes.ПОЛУЧИТЬ_ОРГ_ЕДИНИЦЫ_С_СЕРВЕРА] ({ commit }) {
    // commit(mutationTypes.СОХРАНИТЬ_ОРГ_ЕДИНИЦЫ, null)
    const model = await get(urlTypes.ПОЛУЧИТЬ_ОРГ_ЕДИНИЦЫ_С_СЕРВЕРА)

    commit(
      mutationTypes.СОХРАНИТЬ_ОРГ_ЕДИНИЦЫ,
      model,
    )

    return model
  },

  async [actionTypes.ПОЛУЧИТЬ_ДОЛЖНОСТИ_С_СЕРВЕРА] ({ commit }) {
    const model = await get(urlTypes.ПОЛУЧИТЬ_ДОЛЖНОСТИ_С_СЕРВЕРА)
    commit(mutationTypes.СОХРАНИТЬ_ДОЛЖНОСТИ, model)
    return model
  },

  async [actionTypes.ПОЛУЧИТЬ_ФОРМУ_ДОПУСКА_С_СЕРВЕРА] ({ commit }) {
    const model = await get(urlTypes.ПОЛУЧИТЬ_ФОРМУ_ДОПУСКА_С_СЕРВЕРА)
    commit(mutationTypes.СОХРАНИТЬ_ФОРМУ_ДОПУСКА, model)
    return model
  },

  /**
   * @param dispatch
   * @param {Object.<ПАРАМЕТРЫ_ЗАПРОСА_ПОЛУЧИТЬ_КАРТОЧКУ_СОТРУДНИКА>} модель
   * @return {Promise, Array.<КАРТОЧКА_СОТРУДНИКА>}
   */
  async [actionTypes.ПОЛУЧИТЬ_КАРТОЧКУ_СОТРУДНИКА_С_СЕРВЕРА] ({ commit }, модель) {
    const model = await get(urlTypes.ПОЛУЧИТЬ_КАРТОЧКУ_СОТРУДНИКА_С_СЕРВЕРА, модель)
    commit(mutationTypes.СОХРАНИТЬ_КАРТОЧКУ_СОТРУДНИКА, model)
    return model
  },

  async [actionTypes.ПОЛУЧИТЬ_МОДЕЛЬ_ПОЛЬЗОВАТЕЛЯ_СЕРВИСА_С_СЕРВЕРА] ({ commit }, модель) {
    const model = await get(urlTypes.ПОЛУЧИТЬ_МОДЕЛЬ_ПОЛЬЗОВАТЕЛЯ_СЕРВИСА_С_СЕРВЕРА, модель)
    commit(mutationTypes.СОХРАНИТЬ_МОДЕЛЬ_ПОЛЬЗОВАТЕЛЯ, model)
    return model
  },

  /* [actionTypes.\\\\\\\\\\\\\\\\\\\\] ({ dispatch }, login) {
    dispatch(
      actionTypes.ВЫПОЛНИТЬ_ЗАПРОС_GET,
      new GetPayloadYesParam(
        urlTypes.ПОЛУЧИТЬ_МОДЕЛЬ_ПОЛЬЗОВАТЕЛЯ_СЕРВИСА_С_СЕРВЕРА,
        { login: login },
        mutationTypes.СОХРАНИТЬ_МОДЕЛЬ_ПОЛЬЗОВАТЕЛЯ,
        actionTypes.ПОЛУЧИТЬ_МОДЕЛЬ_ПОЛЬЗОВАТЕЛЯ_СЕРВИСА_С_СЕРВЕРА,
      ))
  }, */

  // @LABEL:STORE.ACTIONS-GET-ENTITIES@

  // ############################################################
  // #### ОТЧЕТЫ               ##################################
  // ############################################################
  /**
   * @param dispatch
   * @param {Object.<ПАРАМЕТРЫ_ЗАПРОСА_НА_ДАТУ>} наДату
   * @return {Promise, Array.<ПЕРЕЧЕНЬ_СУБЬЕКТОВ_ДОСТУПА_ДОПУЩЕННОГО_К_РАБОТЕ_В_АС>}
   */
  async [actionTypes.ПОЛУЧИТЬ_ПЕРЕЧЕНЬ_СУБЬЕКТОВ_ДОСТУПА_ДОПУЩЕННОГО_К_РАБОТЕ_В_АС_С_СЕРВЕРА] ({ commit }, наДату) {
    const model = await get(
      urlTypes.ПОЛУЧИТЬ_ПЕРЕЧЕНЬ_СУБЬЕКТОВ_ДОСТУПА_ДОПУЩЕННОГО_К_РАБОТЕ_В_АС_С_СЕРВЕРА,
      наДату,
    )

    commit(mutationTypes.СОХРАНИТЬ_ПЕРЕЧЕНЬ_СУБЬЕКТОВ_ДОСТУПА_ДОПУЩЕННОГО_К_РАБОТЕ_В_АС, model)
    return model
  },

  /**
   * @function dispatch
   * @param {Object.<ПАРАМЕТРЫ_ЗАПРОСА_НА_ДАТУ>} модель
   * @returns {Promise, Array<ПЕРЕЧЕНЬ_АРМ_В_АС>}
   */
  async [actionTypes.ПОЛУЧИТЬ_ПЕРЕЧЕНЬ_АРМ_В_АС_С_СЕРВЕРА] ({ commit }, наДату) {
    const model = await get(
      urlTypes.ПОЛУЧИТЬ_ПЕРЕЧЕНЬ_АРМ_В_АС_С_СЕРВЕРА,
      наДату,
    )

    commit(mutationTypes.СОХРАНИТЬ_ПЕРЕЧЕНЬ_АРМ_В_АС, model)
    return model
  },

  /**
   * @param dispatch
   * @param {Object.<ПАРАМЕТРЫ_ЗАПРОСА_НА_ДАТУ>} наДату
   * @returns {Promise, Array<ПЕРЕЧЕНЬ_РЕСУРСОВ_В_АС>}
   */
  async [actionTypes.ПОЛУЧИТЬ_ПЕРЕЧЕНЬ_РЕСУРСОВ_В_АС_С_СЕРВЕРА] ({ commit }, наДату) {
    const model = await get(
      urlTypes.ПОЛУЧИТЬ_ПЕРЕЧЕНЬ_РЕСУРСОВ_В_АС_С_СЕРВЕРА,
      наДату,
    )

    commit(mutationTypes.СОХРАНИТЬ_ПЕРЕЧЕНЬ_РЕСУРСОВ_В_АС, model)
    return model
  },

  /**
   * @param dispatch
   * @param {Object.<ПАРАМЕТРЫ_ЗАПРОСА_НА_ДАТУ>} наДату
   * @returns {Promise, Array<ПЕРЕЧЕНЬ_РЕСУРСОВ_В_АС>}
   */
  async [actionTypes.ПОЛУЧИТЬ_ПЕРЕЧЕНЬ_РЕСУРСОВ_В_АС_С_СЕРВЕРА_ИЗ_ПРД] ({ commit }, наДату) {
    const model = await get(
      urlTypes.ПОЛУЧИТЬ_ПЕРЕЧЕНЬ_РЕСУРСОВ_В_АС_С_СЕРВЕРА_ИЗ_PRD,
      наДату,
    )

    commit(mutationTypes.СОХРАНИТЬ_ПЕРЕЧЕНЬ_РЕСУРСОВ_В_АС, model)
    return model
  },

  /**
   * @param dispatch
   * @param {Object.<ПАРАМЕТРЫ_ЗАПРОСА_НА_ДАТУ>} наДату
   * @returns {Promise, Array<ПЕРЕЧЕНЬ_СУБЪЕКТОВ_ДОСТУПА_ДОПУЩЕННЫХ_К_РАБОТЕ_НА_АРМ>}
   */
  async [actionTypes.ПОЛУЧИТЬ_ПЕРЕЧЕНЬ_СУБЪЕКТОВ_ДОСТУПА_ДОПУЩЕННЫХ_К_РАБОТЕ_НА_АРМ_С_СЕРВЕРА] ({ commit }, наДату) {
    const model = await get(
      urlTypes.ПОЛУЧИТЬ_ПЕРЕЧЕНЬ_СУБЪЕКТОВ_ДОСТУПА_ДОПУЩЕННЫХ_К_РАБОТЕ_НА_АРМ_С_СЕРВЕРА,
      наДату,
    )

    commit(mutationTypes.СОХРАНИТЬ_ПЕРЕЧЕНЬ_СУБЪЕКТОВ_ДОСТУПА_ДОПУЩЕННЫХ_К_РАБОТЕ_НА_АРМ, model)
    return model
  },
  /**
   * @function dispatch
   * @returns {Promise, Array<ПЕРЕЧЕНЬ_РЕСУРСОВ_К_КОТОРЫМ_ПРЕДОСТАВЛЕН_ДОСТУП_СУБЪЕКТАМ>}
   * @param наДату
   */
  async [actionTypes.ПОЛУЧИТЬ_ПЕРЕЧЕНЬ_РЕСУРСОВ_К_КОТОРЫМ_ПРЕДОСТАВЛЕН_ДОСТУП_СУБЪЕКТАМ_С_СЕРВЕРА] ({ commit }, наДату) {
    const model = await get(
      urlTypes.ПОЛУЧИТЬ_ПЕРЕЧЕНЬ_РЕСУРСОВ_К_КОТОРЫМ_ПРЕДОСТАВЛЕН_ДОСТУП_СУБЪЕКТАМ_С_СЕРВЕРА,
      наДату,
    )

    commit(mutationTypes.СОХРАНИТЬ_ПЕРЕЧЕНЬ_РЕСУРСОВ_К_КОТОРЫМ_ПРЕДОСТАВЛЕН_ДОСТУП_СУБЪЕКТАМ, model)
    return model
  },
  /**
   * @function dispatch
   * @param {Object.<ПАРАМЕТРЫ_ЗАПРОСА_НА_ДАТУ>} модель
   * @returns {Promise, Array<РАЗРЕШИТЕЛЬНАЯ_СИСТЕМА_ДОСТУПА_К_РЕСУРСАМ>}
   */
  async [actionTypes.ПОЛУЧИТЬ_РАЗРЕШИТЕЛЬНАЯ_СИСТЕМА_ДОСТУПА_К_РЕСУРСАМ_С_СЕРВЕРА] ({ commit }, наДату) {
    const model = await get(
      urlTypes.ПОЛУЧИТЬ_РАЗРЕШИТЕЛЬНАЯ_СИСТЕМА_ДОСТУПА_К_РЕСУРСАМ_С_СЕРВЕРА,
      наДату,
    )

    commit(mutationTypes.СОХРАНИТЬ_РАЗРЕШИТЕЛЬНАЯ_СИСТЕМА_ДОСТУПА_К_РЕСУРСАМ, model)
    return model
  },

  /**
   * @param dispatch
   * @param {Object.<ПАРАМЕТРЫ_ЗАПРОСА_НА_ДАТУ>} наДату
   * @returns {Promise, Array<РАЗРЕШИТЕЛЬНАЯ_СИСТЕМА_ДОСТУПА_К_РЕСУРСАМ>}
   */
  async [actionTypes.ПОЛУЧИТЬ_РАЗРЕШИТЕЛЬНАЯ_СИСТЕМА_ДОСТУПА_К_РЕСУРСАМ_С_СЕРВЕРА_ИЗ_ПРД] ({ commit }, наДату) {
    const model = await get(
      urlTypes.ПОЛУЧИТЬ_РАЗРЕШИТЕЛЬНАЯ_СИСТЕМА_ДОСТУПА_К_РЕСУРСАМ_С_СЕРВЕРА_ИЗ_PRD,
      наДату,
    )

    commit(mutationTypes.СОХРАНИТЬ_РАЗРЕШИТЕЛЬНАЯ_СИСТЕМА_ДОСТУПА_К_РЕСУРСАМ, model)
    return model
  },
  // @LABEL:STORE.ACTIONS-GET-REPORTS@

  /**
   * @param dispatch
   * @param commit
   * @param {Object.<ПАРАМЕТРЫ_ЗАПРОСА_ДОМЕННЫЙ_ЛОГИН>} domainAccount
   */
  async [actionTypes.ПОЛУЧИТЬ_ОЧЕРЕДЬ_ЗАЯВОК_НА_ОБРАБОТКУ] ({ commit }, domainAccount) {
    const model = await get(
      urlTypes.ПОЛУЧИТЬ_ОЧЕРЕДЬ_ЗАЯВОК_НА_ОБРАБОТКУ,
      domainAccount,
    )

    commit(mutationTypes.СОХРАНИТЬ_ОЧЕРЕДЬ_ЗАЯВОК_НА_ОБРАБОТКУ, model)
    return model
  },

  /**
   * @param dispatch
   * @param {Object.<ПАРАМЕТРЫ_ЗАПРОСА_ДОМЕННЫЙ_ЛОГИН>} domainAccount
   */
  async [actionTypes.ПОЛУЧИТЬ_ВЫПОЛНЕННЫЕ_ЗАЯВКИ] ({ commit }, domainAccount) {
    const model = await get(
      urlTypes.ПОЛУЧИТЬ_ВЫПОЛНЕННЫЕ_ЗАЯВКИ,
      domainAccount,
    )

    commit(mutationTypes.СОХРАНИТЬ_ВЫПОЛНЕННЫЕ_ЗАЯВКИ, model)
    return model
  },

  /**
   * @param dispatch
   * @param {Object.<ПАРАМЕТРЫ_ЗАПРОСА_ДОМЕННЫЙ_ЛОГИН>} domainAccount
   */
  async [actionTypes.ПОЛУЧИТЬ_ВСЕ_МОИ_ЗАЯВКИ] ({ commit }, domainAccount) {
    const model = await get(
      urlTypes.ПОЛУЧИТЬ_ВСЕ_МОИ_ЗАЯВКИ,
      domainAccount,
    )

    commit(mutationTypes.СОХРАНИТЬ_ЗАЯВКИ, model)
    return model
  },

  /**
   * @param dispatch
   * @param commit
   * @param {Object.<ПАРАМЕТРЫ_ЗАПРОСА_ДОМЕННЫЙ_ЛОГИН>} domainAccount
   */
  async [actionTypes.ПОЛУЧИТЬ_СУЩЕСТВУЮЩИЕ_ПРОФИЛИ_ДЛЯ_АДМИНА] ({ commit }, domainAccount) {
    const model = await get(
      urlTypes.ПОЛУЧИТЬ_СУЩЕСТВУЮЩИЕ_ПРОФИЛИ_ДЛЯ_АДМИНА,
      domainAccount,
    )

    commit(mutationTypes.СОХРАНИТЬ_СУЩЕСТВУЮЩИЕ_ПРОФИЛИ_ДЛЯ_АДМИНА, model)
    return model
  },

  /**
   * @param dispatch
   * @param commit
   * @param {Object.<ПАРАМЕТРЫ_ЗАПРОСА_ДОМЕННЫЙ_ЛОГИН>} domainAccount
   */
  async [actionTypes.ПОЛУЧИТЬ_ВСЕ_МОИ_ПРОФИЛИ] ({ commit }, domainAccount) {
    const model = await get(
      urlTypes.ПОЛУЧИТЬ_ВСЕ_МОИ_ПРОФИЛИ,
      domainAccount,
    )

    commit(mutationTypes.СОХРАНИТЬ_МОИ_ПРОФИЛИ, model)
    return model
  },

  /**
   * @param dispatch
   * @param {Object.<ПАРАМЕТРЫ_ЗАПРОСА_НА_ДАТУ_И_ДОМЕННЫЙ_ЛОГИН>} модель
   */
  async [actionTypes.ПОЛУЧИТЬ_РЕСУРСЫ_ГДЕ_ПОЛЬЗОВАТЕЛЬ_ЯВЛСЯ_ОТВЕТСТВЕННЫМ] ({ commit }, модель) {
    const model = await get(
      urlTypes.ПОЛУЧИТЬ_РЕСУРСЫ_ГДЕ_ПОЛЬЗОВАТЕЛЬ_ЯВЛСЯ_ОТВЕТСТВЕННЫМ,
      модель,
    )

    commit(mutationTypes.СОХРАНИТЬ_ДЕЙСТВУЮЩИЕ_РЕСУРСЫ, model)
    return model
  },

  /**
   * @param dispatch
   * @param {Object.<ПАРАМЕТРЫ_ЗАПРОСА_НА_ДАТУ_И_ДОМЕННЫЙ_ЛОГИН>} модель
   */
  async [actionTypes.ПОЛУЧИТЬ_РЕСУРСЫ_ГДЕ_ПОЛЬЗОВАТЕЛЬ_ЯВЛСЯ_ВЛАДЕЛЬЦЕМ] ({ commit }, модель) {
    const model = await get(
      urlTypes.ПОЛУЧИТЬ_РЕСУРСЫ_ГДЕ_ПОЛЬЗОВАТЕЛЬ_ЯВЛСЯ_ВЛАДЕЛЬЦЕМ,
      модель,
    )

    commit(mutationTypes.СОХРАНИТЬ_ДЕЙСТВУЮЩИЕ_РЕСУРСЫ, model)
    return model
  },

  // ############################################################
  // #### ВЫПОЛНИТЬ ЗАПРОС GET ##################################
  // ############################################################

  /**
   * @param commit
   * @param dispatch
   * @param {Object.<>} params
   * @returns {Promise<void>}
   */
  async [actionTypes.ВЫПОЛНИТЬ_ЗАПРОС_GET] ({ commit, dispatch }, params) {
    throw new Error('метод более не используется')

    // eslint-disable-next-line no-unreachable
    return await get(params.url, params.params)

    /* .then((response) => {
      if (успешно(response.status) && response.data.result?.code === 200) {
        // если среди параметров была передана мутация,
        if (params.commit !== null) {
          const model = response.data.model
          // проверяем, является ли входящая модель массивом объектов,
          // если да, тогда проверяем есть ли у объектов поле "*date*" в любом виде,
          // если есть, тогда преобразуем это поле в нормальный
          // формат даты

          // модель массив?
          if (Array.isArray(model)) {
            // в массиве есть элементы?
            if (model.length > 0) {
              // если элемент массива является объектом, тогда
              if (model[0] !== null && typeof model[0] === 'object') {
                // перебираем все свойства массива
                for (const key in model[0]) {
                  // если свойство содержит "date" тогда
                  if (key.search('date') > -1) {
                    // проходим по всему массиву и в каждом объекте меняем формат даты
                      model.forEach(v => {
                        // если дата не null, тогда преобразуем
                        if (v[key] !== null) {
                          v[key] = $_moment(v[key]).format('YYYY-MM-DD HH:MM')
                        }
                      })
                  }
                }
              }
            }
          }

          // сохраняем входящие данные через эту мутацию
          commit(params.commit, model)
        }
      } else {
        dispatch(
          actionTypes.АЛЕРТНУТЬ,
          new paramsTypes.ПАРАМЕТРЫ_АЛЕРТА(`Код ошибки: ${response.data.result?.code}, Сообщение: ${response.data.result?.msg}`, ТипАлерта.error),
        )
      }
    })
    .catch(error => {
      dispatch(
        actionTypes.АЛЕРТНУТЬ,
        new paramsTypes.ПАРАМЕТРЫ_АЛЕРТА(error.message, ТипАлерта.error),
      )
      console.log(`ошибка в действии [${params.parentDispatcher}]:  ${error}`)
      }) */
  },

  // ############################################################
  // #### ВЫПОЛНИТЬ ЗАПРОС POST #################################
  // ############################################################

  async [actionTypes.ВЫПОЛНИТЬ_ЗАПРОС_POST] ({ dispatch, commit }, модель) {
    return await axPost(модель.url, модель.params)
      .then((response) => {
        if (успешно(response.status) && успешно(response.data.result?.code)) {
          commit(mutationTypes.СОХРАНИТЬ_РЕЗУЛЬТАТ_ЗАПРОСА, response)

          dispatch(
            actionTypes.АЛЕРТНУТЬ,
            new paramsTypes.ПАРАМЕТРЫ_АЛЕРТА(response.data.result.msg, 'success'))

          return response.data
        } else {
          dispatch(
            actionTypes.АЛЕРТНУТЬ,
            new paramsTypes.ПАРАМЕТРЫ_АЛЕРТА(
              `Код ошибки: ${response.data.result?.code},
                Сообщение: ${response.data.result?.msg}`, ТипАлерта.error),
          )
        }
      })
      .catch((error) => {
        dispatch(
          actionTypes.АЛЕРТНУТЬ,
          new paramsTypes.ПАРАМЕТРЫ_АЛЕРТА('Невозможно выполнить запрос', 'error'),
        )
        console.log(`ошибка в действии ${модель.parentDispatcher}:  ${error}`)
      })
  },

  // ############################################################
  // #### ОБНОВИТЬ, СОЗДАТЬ (POST ЗАПРОСЫ) ##############################
  // ############################################################

  /**
   * @function dispatch
   * @param {Object.<ПАРАМЕТРЫ_ЗАПРОСА_СОЗДАТЬ_ЛОГИН_ПОЛЬЗОВАТЕЛЯ>} модель
   * @returns {Promise}
   */
  [actionTypes.ОБНОВИТЬ_ФИО_НА_СЕРВЕРЕ] ({ dispatch }, модель) {
    return dispatch(
      actionTypes.ВЫПОЛНИТЬ_ЗАПРОС_POST,
      new PostPayload(
        urlTypes.ОБНОВИТЬ_ФИО_НА_СЕРВЕРЕ,
        модель,
        actionTypes.ОБНОВИТЬ_ФИО_НА_СЕРВЕРЕ,
      ))
  },

  /**
   * @param dispatch
   * @param {Object.<ПАРАМЕТРЫ_ЗАПРОСА_СОЗДАТЬ_ФИО_НА_СЕРВЕРЕ>} модель
   */
  [actionTypes.СОЗДАТЬ_ФИО_ПОЛЬЗОВАТЕЛЯ_НА_СЕРВЕРЕ] ({ dispatch }, модель) {
    dispatch(
      actionTypes.ВЫПОЛНИТЬ_ЗАПРОС_POST,
      new PostPayload(
        urlTypes.СОЗДАТЬ_ФИО_ПОЛЬЗОВАТЕЛЯ_НА_СЕРВЕРЕ,
        модель,
        actionTypes.СОЗДАТЬ_ФИО_ПОЛЬЗОВАТЕЛЯ_НА_СЕРВЕРЕ,
      ))
  },

  /**
   * @function dispatch
   * @param {Object.<ПАРАМЕТРЫ_ЗАПРОСА_СОЗДАТЬ_ЛОГИН_ПОЛЬЗОВАТЕЛЯ>} модель
   * @returns {Promise}
   */
  [actionTypes.СОЗДАТЬ_ЛОГИН_ПОЛЬЗОВАТЕЛЯ_НА_СЕРВЕРЕ] ({ dispatch }, модель) {
    return dispatch(
      actionTypes.ВЫПОЛНИТЬ_ЗАПРОС_POST,
      new PostPayload(
        urlTypes.СОЗДАТЬ_ЛОГИН_ПОЛЬЗОВАТЕЛЯ_НА_СЕРВЕРЕ,
        модель,
        actionTypes.СОЗДАТЬ_ЛОГИН_ПОЛЬЗОВАТЕЛЯ_НА_СЕРВЕРЕ,
      ))
  },

  [actionTypes.ЧЕКНУТЬ_ЛОГИН_НА_СЕРВЕРЕ] ({ dispatch }, логин) {
    dispatch(
      actionTypes.ВЫПОЛНИТЬ_ЗАПРОС_POST,
      new PostPayload(
        urlTypes.ЧЕКНУТЬ_ЛОГИН_НА_СЕРВЕРЕ,
        new paramsTypes.ПАРАМЕТРЫ_ЗАПРОСА_ЧЕКНУТЬ_ЛОГИН_НА_СЕРВЕРЕ(логин),
        actionTypes.ЧЕКНУТЬ_ЛОГИН_НА_СЕРВЕРЕ,
      ))
  },

  async [actionTypes.СОЗДАТЬ_РЕСУРС_НА_СЕРВЕРЕ] ({ dispatch }, модель) {
    await dispatch(
      actionTypes.ВЫПОЛНИТЬ_ЗАПРОС_POST,
      new PostPayload(
        urlTypes.СОЗДАТЬ_РЕСУРС_НА_СЕРВЕРЕ,
        модель,
        actionTypes.СОЗДАТЬ_РЕСУРС_НА_СЕРВЕРЕ,
      ))
  },

  /**
   * @param dispatch
   * @param {Object.<ПАРАМЕТРЫ_ЗАПРОСА_СОЗДАТЬ_РЕСУРС_ЗЛИВС>} модель
   */
  async [actionTypes.СОЗДАТЬ_РЕСУРС_ЗЛИВС_НА_СЕРВЕРЕ] ({ dispatch }, модель) {
    await dispatch(
      actionTypes.ВЫПОЛНИТЬ_ЗАПРОС_POST,
      new PostPayload(
        urlTypes.СОЗДАТЬ_РЕСУРС_ЗЛИВС_НА_СЕРВЕРЕ,
        модель,
        actionTypes.СОЗДАТЬ_РЕСУРС_ЗЛИВС_НА_СЕРВЕРЕ,
      ))
  },

  [actionTypes.СОЗДАТЬ_ИМЯ_ПРОФИЛЯ_НА_СЕРВЕРЕ] ({ dispatch }, модель) {
    return dispatch(
      actionTypes.ВЫПОЛНИТЬ_ЗАПРОС_POST,
      new PostPayload(
        urlTypes.СОЗДАТЬ_ИМЯ_ПРОФИЛЯ_НА_СЕРВЕРЕ,
        модель,
        actionTypes.СОЗДАТЬ_ИМЯ_ПРОФИЛЯ_НА_СЕРВЕРЕ,
      ))
  },

  async [actionTypes.ДОБАВИТЬ_ОБЪЕКТЫ_В_ПРОФИЛЬ_НА_СЕРВЕРЕ] ({ dispatch }, модель) {
    return await dispatch(
      actionTypes.ВЫПОЛНИТЬ_ЗАПРОС_POST,
      new PostPayload(
        urlTypes.ДОБАВИТЬ_ОБЪЕКТЫ_В_ПРОФИЛЬ_НА_СЕРВЕРЕ,
        модель,
        actionTypes.ДОБАВИТЬ_ОБЪЕКТЫ_В_ПРОФИЛЬ_НА_СЕРВЕРЕ,
      ))
  },

  /**
   * @param dispatch
   * @param {Object.<ПАРАМЕТРЫ_ЗАПРОСА_СОЗДАТЬ_ДОСТУПЫ_СУБЪЕКТОВ_К_РЕСУРСАМ>} модель
   * @returns {Promise}
   */
  [actionTypes.СОЗДАТЬ_ДОСТУПЫ_СУБЪЕКТОВ_К_РЕСУРСАМ_НА_СЕРВЕРЕ] ({ dispatch }, модель) {
    return dispatch(
      actionTypes.ВЫПОЛНИТЬ_ЗАПРОС_POST,
      new PostPayload(
        urlTypes.СОЗДАТЬ_ДОСТУПЫ_СУБЪЕКТОВ_К_РЕСУРСАМ_НА_СЕРВЕРЕ,
        модель,
        actionTypes.СОЗДАТЬ_ДОСТУПЫ_СУБЪЕКТОВ_К_РЕСУРСАМ_НА_СЕРВЕРЕ,
      ))
  },

  /**
   * @param dispatch
   * @param {Object.<ПАРАМЕТРЫ_ЗАПРОСА_СОЗДАТЬ_ПОЛЬЗОВАТЕЛЯ>} модель
   * @returns {Promise}
   */
  [actionTypes.СОЗДАТЬ_ПОЛЬЗОВАТЕЛЯ_НА_СЕРВЕРЕ] ({ dispatch }, модель) {
    return dispatch(
      actionTypes.ВЫПОЛНИТЬ_ЗАПРОС_POST,
      new PostPayload(
        urlTypes.СОЗДАТЬ_ПОЛЬЗОВАТЕЛЯ_НА_СЕРВЕРЕ,
        модель,
        actionTypes.СОЗДАТЬ_ПОЛЬЗОВАТЕЛЯ_НА_СЕРВЕРЕ,
      ))
  },

  /**
   * @param dispatch
   * @param getters
   * @param {Object.<ПАРАМЕТРЫ_ЗАПРОСА_ВЫПОЛНИТЬ_ЗАЯВКУ>} модель
   * @returns {Promise}
   */
  async [actionTypes.ВЫПОЛНИТЬ_ЗАЯВКУ_С_ОПРЕДЕЛЕННЫМ_СТАТУСОМ] ({ dispatch, getters }, модель) {
    await dispatch(
      actionTypes.ВЫПОЛНИТЬ_ЗАПРОС_POST,
      new PostPayload(
        urlTypes.ВЫПОЛНИТЬ_ЗАЯВКУ_С_ОПРЕДЕЛЕННЫМ_СТАТУСОМ,
        модель,
        actionTypes.ВЫПОЛНИТЬ_ЗАЯВКУ_С_ОПРЕДЕЛЕННЫМ_СТАТУСОМ,
      ))

    return getters[getterTypes.получитьРезультатЗапроса]
  },

  // @LABEL:STORE.ACTIONS-POST@

//= =======================================================================================================

  async [actionTypes.АЛЕРТНУТЬ] ({ state, commit }, alert) {
    alert.статус = true
    commit(mutationTypes.СОХРАНИТЬ_АЛЕРТ, alert)

    const alertObj = {
      id: Date.now(),
      alert: alert,
      datetime: new Date().toLocaleString(),
    }

    try {
      // получаем все алерты пользователя из хранилища браузера
      /** @type {[]} */
      // const alerts = await localeStorageGetItem(lsn.алерты)
      const alerts = Array.from(state.алерты)

      // если алерты еще не сохранялись
      if (alerts === null || alerts === undefined) {
        const arr = []
        arr.push(alertObj)
        commit(mutationTypes.СОХРАНИТЬ_АЛЕРТЫ, arr)
        return
      }

      // проверяем не достиг ли предела массив алертов
      if (alerts.length > 30) {
        // удаляем первый элемент
        alerts.shift()
      }
      // запихиваем новый алерт в конец массива
      alerts.push(alertObj)
      // отправляем обновленный массив
      commit(mutationTypes.СОХРАНИТЬ_АЛЕРТЫ, alerts)
    } catch (e) {
      console.log(`Error: ${e}`)
    }

    /* setTimeout(() => {
      commit(mutationTypes.СОХРАНИТЬ_СТАТУС_АЛЕРТА, false)
    }, 60000) */
  },

  async [actionTypes.АЛЕРТНУТЬ_ДАННЫЕ_ФОРМЫ_ВОССТАНОВЛЕНЫ] ({ dispatch }) {
    await dispatch(
      actionTypes.АЛЕРТНУТЬ,
      new paramsTypes.ПАРАМЕТРЫ_АЛЕРТА(
        'Данные формы восстановлены',
        ТипАлерта.info,
      ),
    )
  },

  [actionTypes.АЛЕРТНУТЬ_НЕТ_ДАННЫХ_ДЛЯ_ВОССТАНОВЛЕНИЯ] ({ dispatch }) {
    dispatch(
      actionTypes.АЛЕРТНУТЬ,
      new paramsTypes.ПАРАМЕТРЫ_АЛЕРТА(
        'Нет данных для восстановления',
        ТипАлерта.warning,
      ),
    )
  },
}
