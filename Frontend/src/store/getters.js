/* eslint-disable camelcase */
import * as getterTypes from '@/store/getter-types'
import { успешно } from '@/plugins/axios/get'
import * as _ from '@/allServiceRoles'

export default {
  // геттеры основного приложения

  [getterTypes.получитьРезультатЗапроса]: state => state.requestData,

  [getterTypes.запросУспешен]: state => {
    if (state.requestData === null) return false

    return успешно(state.requestData.status) &&
      успешно(state.requestData.data.result?.code)
  },

  [getterTypes.текущаяДата]: () => new Date().toISOString().substr(0, 10),

  [getterTypes.получитьДеревоРесурсов]: state => state.деревоРесурсов,

    // определяем правильное начальное имя пути для текущей роли
  /* [getterTypes.authedPathName]: (state, getters) => {
    // return root.Root.name
    // имя пути по умолчанию, если ни одна роль не присвоена

    // eslint-disable-next-line no-unreachable
    let pathName = root.UnAuthorized.name

    /!* if (state.userRoles.some(v => v === allServiceRoles.Operator)) {
      pathName = root.Operator.name
    } *!/

    if (getters.getUserRoles.some(v => v === allServiceRoles.User)) {
      pathName = root.User.name
    }

    if (getters.getUserRoles.some(v => v === allServiceRoles.Admin)) {
      pathName = root.Admin.name
    }

    return pathName
  }, */

  /* [getterTypes.authedComponent]: state => {
    let component = root.Login.component // компонент по умолчанию, если ни одна роль не присвоена
    if (state.userRoles.some(v => v === Operator)) {
      component = root.Operator.component
    }
    if (state.userRoles.some(v => v === User)) {
      component = root.User.component
    }
    if (state.userRoles.some(v => v === Admin)) {
      component = root.Admin.component
    }
    return component
  }, */

  // вычисляем в зависимости от роли по какому маршруту отправить пользователя сервиса
  /* [getterTypes.getRouterViewName]: state => {
    let name = 'login'
    if (state.userRoles.some(v => v === Operator)) {
      name = 'operator'
    }
    if (state.userRoles.some(v => v === User)) {
      name = 'user'
    }
    if (state.userRoles.some(v => v === Admin)) {
      name = 'admin'
    }
    return name
  }, */

  // возвращает true если роль является допустимой
  /* [getterTypes.authed]: state =>
    state.userRoles === allServiceRoles.Operator ||
    state.userRoles === allServiceRoles.User ||
    state.userRoles === allServiceRoles.Admin, */

  // сущности
  [getterTypes.включенРежимFakeUser]: state => state.fakeUserState,
  [getterTypes.выключенРежимFakeUser]: state => !state.fakeUserState,

  [getterTypes.зашелАдмин]: (state, getters) =>
    getters[getterTypes.получитьРолиПользователяСервиса]
      .some(v => _.Админы.some(w => w === v)),

  [getterTypes.getTempUserModel]: state => state.tempUserModel,
  [getterTypes.getRealUserModel]: (state) => state.realUserModel,
  [getterTypes.getLastUserModel]: state => state.lastUserModel,
  [getterTypes.getUserModel]: state => state.userModel,

  [getterTypes.getUserRoles]: state => state.userModel.roles,
  [getterTypes.domainAccount]: state => state.userModel.domainAccount,

  [getterTypes.получитьМодельПользователяСервиса]: state => state.userModel,
  [getterTypes.получитьФиоПользователяСервиса]: state => state.userModel.fio,
  [getterTypes.получитьРолиПользователяСервиса]: state => state.userModel.roles,
  [getterTypes.получитьАккаунтПользователяСервиса]: state => state.userModel.domainAccount,
  [getterTypes.получитьДоменПользователяСервиса]: state => state.userModel.domainAccount.split('\\', 3)[0],
  [getterTypes.получитьЛогинПользователяСервиса]: state => state.userModel.domainAccount.split('\\', 3)[1],

  /* [getterTypes.полноеФИО]: state => state.ФИО.family + ' ' + state.ФИО.name + ' ' + state.ФИО.patronymic, */

  /* [getterTypes.получитьФамилию]: state => state.ФИО.family, */
  /* [getterTypes.получитьИмя]: state => state.ФИО.name, */
  /* [getterTypes.получитьОтчество]: state => state.ФИО.patronymic, */
  [getterTypes.получитьАлерт]: state => state.алерт,
  [getterTypes.получитьФрагмент]: state => state.фрагмент,
  [getterTypes.получитьИдФрагмента]: state => state.фрагмент.id,

  [getterTypes.получитьМоиПрофили]: state => state.моиПрофили,
  [getterTypes.получитьНазваниеРесурса]: state => state.названиеРесурса,
  [getterTypes.получитьВсеФрагменты]: state => state.всеФрагменты,
  [getterTypes.получитьВсехСотрудников]: state => state.всеСотрудники,
  [getterTypes.получитьВсехСотрудниковДляФейкЮзера]: state => state.всеСотрудникиДляФейкЮзера,
  [getterTypes.получитьИмяЛогина]: state => state.имяЛогина,
  [getterTypes.получитьЕмайл]: state => state.емайл,
  [getterTypes.получитьМодельСоздатьЛогин]: state => state.МодельСоздатьЛогин,
  [getterTypes.получитьТипыСервисов]: state => state.типыСервисов,
  [getterTypes.получитьТипыОбъектов]: state => state.типыОбъектов,

  [getterTypes.получитьТипыОбъектовФильтр]: state => (id_service_type, main_object) => {
    if (id_service_type < 1 || main_object < 0) return null
    return state.типыОбъектов
      .filter(v => v.id_service_type === id_service_type && v.main_object === main_object)
  },

  [getterTypes.получитьГлавныеТипыОбъектов]: state =>
    state.главныеТипыОбъектов?.filter(v => v.main_object === 1),

  [getterTypes.получитьПраваПредоставляемыеПрофилемПоТипуОбъектаИтипуСервиса]: (state, getters) =>
    /**
     * Отфильтровываем права по типу объекта и по типу сервиса
     * @param {number} id_service_type
     * @param {number} id_object_type
     * @return {null|*}
     */
      (id_service_type, id_object_type) => {
      console.log(`id_service_type: ${id_service_type}`)
      console.log(`id_object_type: ${id_object_type}`)

      /** @type {Array.<{id_service_type: number, id_object_type: number }>} */
      var t = getters[getterTypes.получитьПраваПредоставляемыеПрофилем]

      if (t?.length < 1 || id_service_type === undefined || id_service_type === null || id_service_type < 1 ||
        id_object_type === undefined || id_object_type === null || id_object_type < 1) return null

      return t.filter(v => v.id_service_type === id_service_type && v.id_object_type === id_object_type)
    },

  [getterTypes.получитьТипСервисаПоТипуОбъекту]:
  // (state, getters) надо писать так, иначе приложение ломается
    (state, getters) =>
      /**
       * @param {number} идТипаОбъекта
       * @return {null|ТипСервисов}
       */
        (идТипаОбъекта) => {
        if (идТипаОбъекта === undefined || идТипаОбъекта === null || идТипаОбъекта < 1) return null
        console.log(`идТипаОбъекта: ${идТипаОбъекта}`)

        /** @type {paramsTypes.ТипОбъектовСервисов[]} */
        var t = getters[getterTypes.получитьТипыОбъектовСервисов]
        console.log(`t: ${t}`)
        if (t?.length < 1 || идТипаОбъекта < 1) return ''
        return t.find(v => v.id === идТипаОбъекта).service_type
      },

  [getterTypes.получитьТипыОбъектовСервисов]:
    state =>
      /** @type {Array.<paramsTypes.ТипОбъектовСервисов>} */
      state.типыОбъектовСервисов,

  [getterTypes.получитьТипыДобавляемыхОбъектов]: state => state.типыДобавляемыхОбъектов,
  [getterTypes.получитьТипыСекретности]: state => state.типыСекретности,
  [getterTypes.получитьВсеФИО]: state => state.всеФИО,
  /* [getterTypes.получитьОбъектФИО]: state => state.ФИО, */
  [getterTypes.получитьОтветственных]: state => state.ответственные,
  [getterTypes.получитьВладельцевРесурсов]: state => state.владельцыРесурсов,
  [getterTypes.получитьИмяПрофиля]: state => state.имяПрофиля,

  [getterTypes.получитьДействующиеРесурсы]: state =>
    state.действующиеРесурсы,

  [getterTypes.получитьДействующиеРесурсыПользователя]: state =>
    state.действующиеРесурсыПользователя,

  [getterTypes.отфильтроватьРесурсы]: (state) =>
    (массивРесурсов, идФрагмента, идТипаОбъекта, идТипаСервиса) =>
      массивРесурсов.filter(v =>
        v.id_object_type === идТипаОбъекта &&
        v.id_service_type === идТипаСервиса &&
        v.id_ac_fragment === идФрагмента,
      ),

  [getterTypes.отфильтроватьПрофили]: (state) =>
    (массивПрофилей, идФрагмента) =>
      массивПрофилей.filter(v => v.id_ac_fragment === идФрагмента),

  [getterTypes.получитьДействующиеПрофилиПользователя]: state =>
    state.действующиеПрофилиПользователя,

  [getterTypes.получитьдействующиеИНаЭтапеРегистрацииПрофили]: state =>
    state.действующиеИНаЭтапеРегистрацииПрофили,

  /**
   * @param state
   * @return {Array.<{id_service_type: number, id_object_type: number }>}
   */
  [getterTypes.получитьПраваПредоставляемыеПрофилем]: state => state.праваПредоставляемыеПрофилем,
  [getterTypes.получитьДоступыСубъектовКРесурсам]: state => state.доступыСубъектовКРесурсам,

  [getterTypes.получитьОргЕдиницы]: state => state.оргЕдиницы,
  [getterTypes.получитьТабельныйНомер]: state => state.табельныйНомер,
  [getterTypes.получитьДолжности]: state => state.должности,
  [getterTypes.получитьФормуДопуска]: state => state.формуДопуска,
  [getterTypes.получитьКарточкуСотрудника]: state => state.карточкаСотрудника,
  // @LABEL:STORE.GETTERS-ENTITIES@

  // отчеты
  [getterTypes.получитьПереченьСубьектовДоступаДопущенногоКРаботеВАс]: state =>
    state.переченьСубьектовДоступаДопущенногоКРаботеВАс,

  [getterTypes.получитьПереченьРесурсовВАс]: state => state.переченьРесурсовВАс,

  [getterTypes.получитьПереченьАрмВАс]: state => state.переченьАрмВАс,

  [getterTypes.получитьПереченьСубъектовДоступаДопущенныхКРаботеНаАрм]: state =>
    state.переченьСубъектовДоступаДопущенныхКРаботеНаАрм,

  [getterTypes.получитьПереченьРесурсовККоторымПредоставленДоступСубъектам]: state =>
    state.переченьРесурсовККоторымПредоставленДоступСубъектам,

  [getterTypes.получитьРазрешительнаяСистемаДоступаКРесурсам]: state =>
    state.разрешительнаяСистемаДоступаКРесурсам,

  // @LABEL:STORE.GETTERS-REPORTS@

  // для админов
  [getterTypes.получитьОчередьЗаявокНаОбработку]: state => state.заявкиНаОбработку,

  [getterTypes.получитьВыполненныеЗаявки]: state => state.заявкиВыполненные,

  [getterTypes.получитьСуществующиеПрофилиДляАдмина]: state => state.существующиеПрофилиДляАдмина,

  // для пользователей
  [getterTypes.получитьЗаявки]: state => state.заявки,

}
