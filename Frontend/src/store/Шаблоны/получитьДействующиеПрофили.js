/*
/!* eslint-disable *!/
// СОЗДАТЬ ИЛИ ПОЛУЧИТЬ - глагол в верхнем регистре

// Что будем получать или создавать - существительное
// например: действующие профили // каждое слово писать через пробел
// действующие профили
действующиеПрофили

// --------------------------------------------------------------------------------------------------------------
// getter-types.js
// --------------------------------------------------------------------------------------------------------------
import * as getterTypes from '../getter-types'
export const получитьДействующиеПрофили = 'получитьДействующиеПрофили'

// --------------------------------------------------------------------------------------------------------------
// mutation-types.js
// --------------------------------------------------------------------------------------------------------------
import * as mutationTypes from '../mutation-types'
export const СОХРАНИТЬ_ДЕЙСТВУЮЩИЕ_ПРОФИЛИ = 'СОХРАНИТЬ_ДЕЙСТВУЮЩИЕ_ПРОФИЛИ'

// --------------------------------------------------------------------------------------------------------------
// actions-types.js
// --------------------------------------------------------------------------------------------------------------
import * as actionTypes from '../action-types'
export const СОХРАНИТЬ_ДЕЙСТВУЮЩИЕ_ПРОФИЛИ = 'СОХРАНИТЬ_ДЕЙСТВУЮЩИЕ_ПРОФИЛИ'

export const СОЗДАТЬ_ДЕЙСТВУЮЩИЕ_ПРОФИЛИ_НА_СЕРВЕРЕ = 'СОЗДАТЬ_ДЕЙСТВУЮЩИЕ_ПРОФИЛИ_НА_СЕРВЕРЕ'
export const ПОЛУЧИТЬ_ДЕЙСТВУЮЩИЕ_ПРОФИЛИ_ПОЛЬЗОВАТЕЛЯ_С_СЕРВЕРА = 'ПОЛУЧИТЬ_ДЕЙСТВУЮЩИЕ_ПРОФИЛИ_ПОЛЬЗОВАТЕЛЯ_С_СЕРВЕРА'

// --------------------------------------------------------------------------------------------------------------
// URL-TYPES
// --------------------------------------------------------------------------------------------------------------
import * as urlTypes from '../url-types'
export const СОЗДАТЬ_ДЕЙСТВУЮЩИЕ_ПРОФИЛИ_НА_СЕРВЕРЕ = '/RequestAjax/GetProfiles'
export const ПОЛУЧИТЬ_ДЕЙСТВУЮЩИЕ_ПРОФИЛИ_ПОЛЬЗОВАТЕЛЯ_С_СЕРВЕРА = '/RequestAjax/GetProfiles'

// --------------------------------------------------------------------------------------------------------------
// PARAM-TYPES
// --------------------------------------------------------------------------------------------------------------
import * as urlTypes from '../params-types'
export class ПАРАМЕТРЫ_ЗАПРОСА_ДЕЙСТВУЮЩИЕ_ПРОФИЛИ {
  /!**
   *!/
  constructor () {
  }
}

// --------------------------------------------------------------------------------------------------------------
// STORE.JS
// --------------------------------------------------------------------------------------------------------------
// state
действующиеПрофили: [],

// --------------------------------------------------------------------------------------------------------------
// getter
[getterTypes.получитьДействующиеПрофили]: state => state.действующиеПрофили,

// --------------------------------------------------------------------------------------------------------------
// mutation
[mutationTypes.СОХРАНИТЬ_ДЕЙСТВУЮЩИЕ_ПРОФИЛИ] (state, value) {
  state.действующиеПрофили = value
},

// --------------------------------------------------------------------------------------------------------------
// Действи
// сохранить
[actionTypes.СОХРАНИТЬ_ДЕЙСТВУЮЩИЕ_ПРОФИЛИ] ({ commit }, value) {
  commit(mutationTypes.СОХРАНИТЬ_ДЕЙСТВУЮЩИЕ_ПРОФИЛИ, value)
}

// GET
[actionTypes.ПОЛУЧИТЬ_ДЕЙСТВУЮЩИЕ_ПРОФИЛИ_ПОЛЬЗОВАТЕЛЯ_С_СЕРВЕРА] ({ dispatch }, модель) {
  return dispatch(
    actionTypes.ВЫПОЛНИТЬ_ЗАПРОС_GET,
    new GetPayloadYesParam(
      urlTypes.ПОЛУЧИТЬ_ДЕЙСТВУЮЩИЕ_ПРОФИЛИ_ПОЛЬЗОВАТЕЛЯ_С_СЕРВЕРА,
      модель,
      mutationTypes.СОХРАНИТЬ_ДЕЙСТВУЮЩИЕ_ПРОФИЛИ,
      actionTypes.ПОЛУЧИТЬ_ДЕЙСТВУЮЩИЕ_ПРОФИЛИ_ПОЛЬЗОВАТЕЛЯ_С_СЕРВЕРА,
    ))
},

// Действия
// POST
[actionTypes.СОЗДАТЬ_ДЕЙСТВУЮЩИЕ_ПРОФИЛИ_НА_СЕРВЕРЕ] ({ dispatch }, модель) {
  return dispatch(
    actionTypes.ВЫПОЛНИТЬ_ЗАПРОС_POST,
    new PostPayload(
      urlTypes.СОЗДАТЬ_ДЕЙСТВУЮЩИЕ_ПРОФИЛИ_НА_СЕРВЕРЕ,
      модель,
      actionTypes.СОЗДАТЬ_ДЕЙСТВУЮЩИЕ_ПРОФИЛИ_НА_СЕРВЕРЕ,
    ))
},

// --------------------------------------------------------------------------------------------------------------
// ДЛЯ КОМПОНЕНТА
// --------------------------------------------------------------------------------------------------------------
<script>
  import { mapActions, mapGetters, mapMutations } from 'vuex'

  import {
    получитьДействующиеПрофили
  } from '../../store/getter-types'

  import {
    СОЗДАТЬ_ДЕЙСТВУЮЩИЕ_ПРОФИЛИ_НА_СЕРВЕРЕ
    ПОЛУЧИТЬ_ДЕЙСТВУЮЩИЕ_ПРОФИЛИ_ПОЛЬЗОВАТЕЛЯ_С_СЕРВЕРА
  } from '../../store/action-types'

  import { СОХРАНИТЬ_ДЕЙСТВУЮЩИЕ_ПРОФИЛИ } from '../../store/mutation-types'
  import { ПАРАМЕТРЫ_ЗАПРОСА_ДЕЙСТВУЮЩИЕ_ПРОФИЛИ } from '../../store/params-types'

  export default {

    data: () => ({
      выбранныйДействующийПрофиль: null,
    }),

    computed: {
      ...mapGetters([
        получитьДействующиеПрофили,
      ]),
    },

    methods: {
      СоздатьРесурс () {
        this.$store.dispatch(
            СОЗДАТЬ_ДЕЙСТВУЮЩИЕ_ПРОФИЛИ_НА_СЕРВЕРЕ
            ПОЛУЧИТЬ_ДЕЙСТВУЮЩИЕ_ПРОФИЛИ_ПОЛЬЗОВАТЕЛЯ_С_СЕРВЕРА,
          new ПАРАМЕТРЫ_ЗАПРОСА_ДЕЙСТВУЮЩИЕ_ПРОФИЛИ(
          ))
      },

      ...mapActions([
        СОЗДАТЬ_ДЕЙСТВУЮЩИЕ_ПРОФИЛИ_НА_СЕРВЕРЕ
        ПОЛУЧИТЬ_ДЕЙСТВУЮЩИЕ_ПРОФИЛИ_ПОЛЬЗОВАТЕЛЯ_С_СЕРВЕРА,
      ]),

      ...mapMutations([
        СОХРАНИТЬ_ДЕЙСТВУЮЩИЕ_ПРОФИЛИ
      ]),
    },
  }
</script>
*/
