/*
/!* eslint-disable *!/
// СОЗДАТЬ ИЛИ ПОЛУЧИТЬ - глагол в верхнем регистре

// Что будем получать или создавать - существительное
// например: действующие профили // каждое слово писать через пробел
// Права, предоставляемые профилем
праваПредоставляемыеПрофилем

// --------------------------------------------------------------------------------------------------------------
// getter-types.js
// --------------------------------------------------------------------------------------------------------------
import * as getterTypes from './getter-types'
export const получитьПраваПредоставляемыеПрофилем = 'получитьПраваПредоставляемыеПрофилем'

// --------------------------------------------------------------------------------------------------------------
// mutation-types.js
// --------------------------------------------------------------------------------------------------------------
import * as mutationTypes from './mutation-types'
export const СОХРАНИТЬ_ПРАВА_ПРЕДОСТАВЛЯЕМЫЕ_ПРОФИЛЕМ = 'СОХРАНИТЬ_ПРАВА_ПРЕДОСТАВЛЯЕМЫЕ_ПРОФИЛЕМ'

// --------------------------------------------------------------------------------------------------------------
// actions-types.js
// --------------------------------------------------------------------------------------------------------------
import * as actionTypes from './action-types'
export const СОХРАНИТЬ_ПРАВА_ПРЕДОСТАВЛЯЕМЫЕ_ПРОФИЛЕМ = 'СОХРАНИТЬ_ПРАВА_ПРЕДОСТАВЛЯЕМЫЕ_ПРОФИЛЕМ'

export const СОЗДАТЬ_ПРАВА_ПРЕДОСТАВЛЯЕМЫЕ_ПРОФИЛЕМ_НА_СЕРВЕРЕ = 'СОЗДАТЬ_ПРАВА_ПРЕДОСТАВЛЯЕМЫЕ_ПРОФИЛЕМ_НА_СЕРВЕРЕ'
export const ПОЛУЧИТЬ_ПРАВА_ПРЕДОСТАВЛЯЕМЫЕ_ПРОФИЛЕМ_С_СЕРВЕРА = 'ПОЛУЧИТЬ_ПРАВА_ПРЕДОСТАВЛЯЕМЫЕ_ПРОФИЛЕМ_С_СЕРВЕРА'

// --------------------------------------------------------------------------------------------------------------
// URL-TYPES
// --------------------------------------------------------------------------------------------------------------
import * as urlTypes from './url-types'
export const СОЗДАТЬ_ПРАВА_ПРЕДОСТАВЛЯЕМЫЕ_ПРОФИЛЕМ_НА_СЕРВЕРЕ = '/RequestAjax/GetRightDescr'
export const ПОЛУЧИТЬ_ПРАВА_ПРЕДОСТАВЛЯЕМЫЕ_ПРОФИЛЕМ_С_СЕРВЕРА = '/RequestAjax/GetRightDescr'

// --------------------------------------------------------------------------------------------------------------
// PARAM-TYPES
// --------------------------------------------------------------------------------------------------------------
import * as urlTypes from './params-types'
export class ПАРАМЕТРЫ_ЗАПРОСА_ПРАВА_ПРЕДОСТАВЛЯЕМЫЕ_ПРОФИЛЕМ {
  /!**
   * @param {Number} тип признак группы прав или элементарного права (1 - группа, другое значение - эл.право)
   * @param {Number} типСервиса какому типу сервиса принадлежит право
   * @returns {[Object.<{id: Number, name: String}>]} возвращаемые запросом объекты
   *!/
  constructor (тип, типСервиса) {
    this.type = тип
    this.serviceTypeId = типСервиса
  }
}

// --------------------------------------------------------------------------------------------------------------
// STORE.JS
// --------------------------------------------------------------------------------------------------------------

// state
праваПредоставляемыеПрофилем: [],

// getter
[getterTypes.получитьПраваПредоставляемыеПрофилем]: state => state.праваПредоставляемыеПрофилем,

// mutation
[mutationTypes.СОХРАНИТЬ_ПРАВА_ПРЕДОСТАВЛЯЕМЫЕ_ПРОФИЛЕМ] (state, value) {
  state.праваПредоставляемыеПрофилем = value
},

// Действия
// сохранить
[actionTypes.СОХРАНИТЬ_ПРАВА_ПРЕДОСТАВЛЯЕМЫЕ_ПРОФИЛЕМ] ({ commit }, value) {
  commit(mutationTypes.СОХРАНИТЬ_ПРАВА_ПРЕДОСТАВЛЯЕМЫЕ_ПРОФИЛЕМ, value)
}

// GET
[actionTypes.ПОЛУЧИТЬ_ПРАВА_ПРЕДОСТАВЛЯЕМЫЕ_ПРОФИЛЕМ_С_СЕРВЕРА] ({ dispatch }, модель) {
  return dispatch(
    actionTypes.ВЫПОЛНИТЬ_ЗАПРОС_GET,
    new GetPayloadYesParam(
      urlTypes.ПОЛУЧИТЬ_ПРАВА_ПРЕДОСТАВЛЯЕМЫЕ_ПРОФИЛЕМ_С_СЕРВЕРА,
      модель,
      mutationTypes.СОХРАНИТЬ_ПРАВА_ПРЕДОСТАВЛЯЕМЫЕ_ПРОФИЛЕМ,
      actionTypes.ПОЛУЧИТЬ_ПРАВА_ПРЕДОСТАВЛЯЕМЫЕ_ПРОФИЛЕМ_С_СЕРВЕРА,
    ))
},

// Действия
// POST
[actionTypes.СОЗДАТЬ_ПРАВА_ПРЕДОСТАВЛЯЕМЫЕ_ПРОФИЛЕМ_НА_СЕРВЕРЕ] ({ dispatch }, модель) {
  return dispatch(
    actionTypes.ВЫПОЛНИТЬ_ЗАПРОС_POST,
    new PostPayload(
      urlTypes.СОЗДАТЬ_ПРАВА_ПРЕДОСТАВЛЯЕМЫЕ_ПРОФИЛЕМ_НА_СЕРВЕРЕ,
      модель,
      actionTypes.СОЗДАТЬ_ПРАВА_ПРЕДОСТАВЛЯЕМЫЕ_ПРОФИЛЕМ_НА_СЕРВЕРЕ,
    ))
},

// --------------------------------------------------------------------------------------------------------------
// ДЛЯ КОМПОНЕНТА
// --------------------------------------------------------------------------------------------------------------
<script>
  import { mapActions, mapGetters, mapMutations } from 'vuex'

  import {
    получитьПраваПредоставляемыеПрофилем
  } from '../../store/getter-types'

  import {
    СОЗДАТЬ_ПРАВА_ПРЕДОСТАВЛЯЕМЫЕ_ПРОФИЛЕМ_НА_СЕРВЕРЕ
    ПОЛУЧИТЬ_ПРАВА_ПРЕДОСТАВЛЯЕМЫЕ_ПРОФИЛЕМ_С_СЕРВЕРА
  } from '../../store/action-types'

  import { СОХРАНИТЬ_ПРАВА_ПРЕДОСТАВЛЯЕМЫЕ_ПРОФИЛЕМ } from '../../store/mutation-types'
  import { ПАРАМЕТРЫ_ЗАПРОСА_ПРАВА_ПРЕДОСТАВЛЯЕМЫЕ_ПРОФИЛЕМ } from '../../store/params-types'

  export default {

    data: () => ({
      праваПредоставляемыеПрофилем: null,
    }),

    computed: {
      ...mapGetters([
        получитьПраваПредоставляемыеПрофилем,
      ]),
    },

    methods: {
      СоздатьРесурс () {
        this.$store.dispatch(
            СОЗДАТЬ_ПРАВА_ПРЕДОСТАВЛЯЕМЫЕ_ПРОФИЛЕМ_НА_СЕРВЕРЕ
            ПОЛУЧИТЬ_ПРАВА_ПРЕДОСТАВЛЯЕМЫЕ_ПРОФИЛЕМ_С_СЕРВЕРА,
          new ПАРАМЕТРЫ_ЗАПРОСА_ПРАВА_ПРЕДОСТАВЛЯЕМЫЕ_ПРОФИЛЕМ(
          ))
      },

      ...mapActions([
        СОЗДАТЬ_ПРАВА_ПРЕДОСТАВЛЯЕМЫЕ_ПРОФИЛЕМ_НА_СЕРВЕРЕ
        ПОЛУЧИТЬ_ПРАВА_ПРЕДОСТАВЛЯЕМЫЕ_ПРОФИЛЕМ_С_СЕРВЕРА,
      ]),

      ...mapMutations([
        СОХРАНИТЬ_ПРАВА_ПРЕДОСТАВЛЯЕМЫЕ_ПРОФИЛЕМ
      ]),
    },
  }
</script>
*/
