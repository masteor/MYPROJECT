/*
// СОЗДАТЬ ИЛИ ПОЛУЧИТЬ - глагол в верхнем регистре

// Что будем получать или создавать - существительное
// например: действующие профили // каждое слово писать через пробел
// доступы субъектов к ресурсам
доступыСубъектовКРесурсам

// --------------------------------------------------------------------------------------------------------------
// getter-types.js
// --------------------------------------------------------------------------------------------------------------
import * as getterTypes from './getter-types'
export const получитьДоступыСубъектовКРесурсам = 'получитьДоступыСубъектовКРесурсам'

// --------------------------------------------------------------------------------------------------------------
// mutation-types.js
// --------------------------------------------------------------------------------------------------------------
import * as mutationTypes from './mutation-types'
export const СОХРАНИТЬ_ДОСТУПЫ_СУБЪЕКТОВ_К_РЕСУРСАМ = 'СОХРАНИТЬ_ДОСТУПЫ_СУБЪЕКТОВ_К_РЕСУРСАМ'

// --------------------------------------------------------------------------------------------------------------
// actions-types.js
// --------------------------------------------------------------------------------------------------------------
import * as actionTypes from './action-types'
export const СОХРАНИТЬ_ДОСТУПЫ_СУБЪЕКТОВ_К_РЕСУРСАМ = 'СОХРАНИТЬ_ДОСТУПЫ_СУБЪЕКТОВ_К_РЕСУРСАМ'

export const СОЗДАТЬ_ДОСТУПЫ_СУБЪЕКТОВ_К_РЕСУРСАМ_НА_СЕРВЕРЕ = 'СОЗДАТЬ_ДОСТУПЫ_СУБЪЕКТОВ_К_РЕСУРСАМ_НА_СЕРВЕРЕ'
export const ПОЛУЧИТЬ_ДОСТУПЫ_СУБЪЕКТОВ_К_РЕСУРСАМ_С_СЕРВЕРА = 'ПОЛУЧИТЬ_ДОСТУПЫ_СУБЪЕКТОВ_К_РЕСУРСАМ_С_СЕРВЕРА'

// --------------------------------------------------------------------------------------------------------------
// URL-TYPES
// --------------------------------------------------------------------------------------------------------------
import * as urlTypes from './url-types'
export const СОЗДАТЬ_ДОСТУПЫ_СУБЪЕКТОВ_К_РЕСУРСАМ_НА_СЕРВЕРЕ = '/RequestAjax/CreateMember'
export const ПОЛУЧИТЬ_ДОСТУПЫ_СУБЪЕКТОВ_К_РЕСУРСАМ_С_СЕРВЕРА = '/RequestAjax/CreateMember'

// --------------------------------------------------------------------------------------------------------------
// PARAM-TYPES
// --------------------------------------------------------------------------------------------------------------
import * as urlTypes from './params-types'
export class ПАРАМЕТРЫ_ЗАПРОСА_СОЗДАТЬ_ДОСТУПЫ_СУБЪЕКТОВ_К_РЕСУРСАМ {
  /!**
   * @param {Number} идПрофиля
   * @param {Number[]} сотрудники
   * @param {Number[]} оргЕдиницы
   *!/
  constructor (идПрофиля, сотрудники, оргЕдиницы) {
    this.ProfileId = идПрофиля
    this.Employees = сотрудники
    this.Orgs = оргЕдиницы
  }
}

// --------------------------------------------------------------------------------------------------------------
// STORE.JS
// --------------------------------------------------------------------------------------------------------------

// state
доступыСубъектовКРесурсам: [],

// getter
[getterTypes.получитьДоступыСубъектовКРесурсам]: state => state.доступыСубъектовКРесурсам,

// mutation
[mutationTypes.СОХРАНИТЬ_ДОСТУПЫ_СУБЪЕКТОВ_К_РЕСУРСАМ] (state, value) {
  state.доступыСубъектовКРесурсам = value
},

// Действия
// сохранить
[actionTypes.СОХРАНИТЬ_ДОСТУПЫ_СУБЪЕКТОВ_К_РЕСУРСАМ] ({ commit }, value) {
  commit(mutationTypes.СОХРАНИТЬ_ДОСТУПЫ_СУБЪЕКТОВ_К_РЕСУРСАМ, value)
}

// GET
[actionTypes.ПОЛУЧИТЬ_ДОСТУПЫ_СУБЪЕКТОВ_К_РЕСУРСАМ_С_СЕРВЕРА] ({ dispatch }, модель) {
  return dispatch(
    actionTypes.ВЫПОЛНИТЬ_ЗАПРОС_GET,
    new GetPayloadYesParam(
      urlTypes.ПОЛУЧИТЬ_ДОСТУПЫ_СУБЪЕКТОВ_К_РЕСУРСАМ_С_СЕРВЕРА,
      модель,
      mutationTypes.СОХРАНИТЬ_ДОСТУПЫ_СУБЪЕКТОВ_К_РЕСУРСАМ,
      actionTypes.ПОЛУЧИТЬ_ДОСТУПЫ_СУБЪЕКТОВ_К_РЕСУРСАМ_С_СЕРВЕРА,
    ))
},

// Действия
// POST
[actionTypes.СОЗДАТЬ_ДОСТУПЫ_СУБЪЕКТОВ_К_РЕСУРСАМ_НА_СЕРВЕРЕ] ({ dispatch }, модель) {
  return dispatch(
    actionTypes.ВЫПОЛНИТЬ_ЗАПРОС_POST,
    new PostPayload(
      urlTypes.СОЗДАТЬ_ДОСТУПЫ_СУБЪЕКТОВ_К_РЕСУРСАМ_НА_СЕРВЕРЕ,
      модель,
      actionTypes.СОЗДАТЬ_ДОСТУПЫ_СУБЪЕКТОВ_К_РЕСУРСАМ_НА_СЕРВЕРЕ,
    ))
},

// --------------------------------------------------------------------------------------------------------------
// ДЛЯ КОМПОНЕНТА
// --------------------------------------------------------------------------------------------------------------
<script>
  import { mapActions, mapGetters, mapMutations } from 'vuex'

  import {
    получитьДоступыСубъектовКРесурсам
  } from '../../store/getter-types'

  import {
    СОЗДАТЬ_ДОСТУПЫ_СУБЪЕКТОВ_К_РЕСУРСАМ_НА_СЕРВЕРЕ
    ПОЛУЧИТЬ_ДОСТУПЫ_СУБЪЕКТОВ_К_РЕСУРСАМ_С_СЕРВЕРА
  } from '../../store/action-types'

  import { СОХРАНИТЬ_ДОСТУПЫ_СУБЪЕКТОВ_К_РЕСУРСАМ } from '../../store/mutation-types'
  import { ПАРАМЕТРЫ_ЗАПРОСА_СОЗДАТЬ_ДОСТУПЫ_СУБЪЕКТОВ_К_РЕСУРСАМ } from '../../store/params-types'

  export default {

    data: () => ({
      выбранныйДоступыСубъектовКРесурсам: null,
    }),

    computed: {
      ...mapGetters([
        получитьДоступыСубъектовКРесурсам,
      ]),
    },

    methods: {
      СоздатьРесурс () {
        this.$store.dispatch(
            СОЗДАТЬ_ДОСТУПЫ_СУБЪЕКТОВ_К_РЕСУРСАМ_НА_СЕРВЕРЕ
            ПОЛУЧИТЬ_ДОСТУПЫ_СУБЪЕКТОВ_К_РЕСУРСАМ_С_СЕРВЕРА,
          new ПАРАМЕТРЫ_ЗАПРОСА_СОЗДАТЬ_ДОСТУПЫ_СУБЪЕКТОВ_К_РЕСУРСАМ(
          ))
      },

      ...mapActions([
        СОЗДАТЬ_ДОСТУПЫ_СУБЪЕКТОВ_К_РЕСУРСАМ_НА_СЕРВЕРЕ
        ПОЛУЧИТЬ_ДОСТУПЫ_СУБЪЕКТОВ_К_РЕСУРСАМ_С_СЕРВЕРА,
      ]),

      ...mapMutations([
        СОХРАНИТЬ_ДОСТУПЫ_СУБЪЕКТОВ_К_РЕСУРСАМ
      ]),
    },
  }
</script>
*/
