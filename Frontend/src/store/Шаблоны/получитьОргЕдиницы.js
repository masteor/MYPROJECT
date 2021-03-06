/*
// СОЗДАТЬ ИЛИ ПОЛУЧИТЬ - глагол в верхнем регистре

// Что будем получать или создавать - существительное
// например: действующие профили // каждое слово писать через пробел
// орг единицы
оргЕдиницы

// --------------------------------------------------------------------------------------------------------------
// getter-types.js
// --------------------------------------------------------------------------------------------------------------
import * as getterTypes from './getter-types'
export const получитьОргЕдиницы = 'получитьОргЕдиницы'

// --------------------------------------------------------------------------------------------------------------
// mutation-types.js
// --------------------------------------------------------------------------------------------------------------
import * as mutationTypes from './mutation-types'
export const СОХРАНИТЬ_ОРГ_ЕДИНИЦЫ = 'СОХРАНИТЬ_ОРГ_ЕДИНИЦЫ'

// --------------------------------------------------------------------------------------------------------------
// actions-types.js
// --------------------------------------------------------------------------------------------------------------
import * as actionTypes from './action-types'
export const СОХРАНИТЬ_ОРГ_ЕДИНИЦЫ = 'СОХРАНИТЬ_ОРГ_ЕДИНИЦЫ'

export const СОЗДАТЬ_ОРГ_ЕДИНИЦЫ_НА_СЕРВЕРЕ = 'СОЗДАТЬ_ОРГ_ЕДИНИЦЫ_НА_СЕРВЕРЕ'
export const ПОЛУЧИТЬ_ОРГ_ЕДИНИЦЫ_С_СЕРВЕРА = 'ПОЛУЧИТЬ_ОРГ_ЕДИНИЦЫ_С_СЕРВЕРА'

// --------------------------------------------------------------------------------------------------------------
// URL-TYPES
// --------------------------------------------------------------------------------------------------------------
import * as urlTypes from './url-types'
export const СОЗДАТЬ_ОРГ_ЕДИНИЦЫ_НА_СЕРВЕРЕ = '/RequestAjax//RequestAjax/GetOrgEntities'
export const ПОЛУЧИТЬ_ОРГ_ЕДИНИЦЫ_С_СЕРВЕРА = '/RequestAjax/GetOrgEntities'

// --------------------------------------------------------------------------------------------------------------
// PARAM-TYPES
// --------------------------------------------------------------------------------------------------------------
import * as urlTypes from './params-types'
export class ПАРАМЕТРЫ_ЗАПРОСА_ОРГ_ЕДИНИЦЫ {
  /!**
   * @param {String}
   * @param {Number}
   * @param {Number}
   * @param {Number}
   * @param {Number}
   * @param {Number}
   *!/
  constructor (, , , , ) {
    this. =
    this. =
    this. =
    this. =
    this. =
  }
}

// --------------------------------------------------------------------------------------------------------------
// STORE.JS
// --------------------------------------------------------------------------------------------------------------

// state
оргЕдиницы: [],

// getter
[getterTypes.получитьОргЕдиницы]: state => state.оргЕдиницы,

// mutation
[mutationTypes.СОХРАНИТЬ_ОРГ_ЕДИНИЦЫ] (state, value) {
  state.оргЕдиницы = value
},

// Действия
// сохранить
[actionTypes.СОХРАНИТЬ_ОРГ_ЕДИНИЦЫ] ({ commit }, value) {
  commit(mutationTypes.СОХРАНИТЬ_ОРГ_ЕДИНИЦЫ, value)
}

// GET
[actionTypes.ПОЛУЧИТЬ_ОРГ_ЕДИНИЦЫ_С_СЕРВЕРА] ({ dispatch }, модель) {
  return dispatch(
    actionTypes.ВЫПОЛНИТЬ_ЗАПРОС_GET,
    new GetPayloadYesParam(
      urlTypes.ПОЛУЧИТЬ_ОРГ_ЕДИНИЦЫ_С_СЕРВЕРА,
      модель,
      mutationTypes.СОХРАНИТЬ_ОРГ_ЕДИНИЦЫ,
      actionTypes.ПОЛУЧИТЬ_ОРГ_ЕДИНИЦЫ_С_СЕРВЕРА,
    ))
},

// Действия
// POST
[actionTypes.СОЗДАТЬ_ОРГ_ЕДИНИЦЫ_НА_СЕРВЕРЕ] ({ dispatch }, модель) {
  return dispatch(
    actionTypes.ВЫПОЛНИТЬ_ЗАПРОС_POST,
    new PostPayload(
      urlTypes.СОЗДАТЬ_ОРГ_ЕДИНИЦЫ_НА_СЕРВЕРЕ,
      модель,
      actionTypes.СОЗДАТЬ_ОРГ_ЕДИНИЦЫ_НА_СЕРВЕРЕ,
    ))
},

// --------------------------------------------------------------------------------------------------------------
// ДЛЯ КОМПОНЕНТА
// --------------------------------------------------------------------------------------------------------------
<script>
  import { mapActions, mapGetters, mapMutations } from 'vuex'

  import {
    получитьОргЕдиницы
  } from '../../store/getter-types'

  import {
    СОЗДАТЬ_ОРГ_ЕДИНИЦЫ_НА_СЕРВЕРЕ
    ПОЛУЧИТЬ_ОРГ_ЕДИНИЦЫ_С_СЕРВЕРА
  } from '../../store/action-types'

  import { СОХРАНИТЬ_ОРГ_ЕДИНИЦЫ } from '../../store/mutation-types'
  import { ПАРАМЕТРЫ_ЗАПРОСА_ОРГ_ЕДИНИЦЫ } from '../../store/params-types'

  export default {

    data: () => ({
      выбранныйОргЕдиницы: null,
    }),

    computed: {
      ...mapGetters([
        получитьОргЕдиницы,
      ]),
    },

    methods: {
      СоздатьРесурс () {
        this.$store.dispatch(
            СОЗДАТЬ_ОРГ_ЕДИНИЦЫ_НА_СЕРВЕРЕ
            ПОЛУЧИТЬ_ОРГ_ЕДИНИЦЫ_С_СЕРВЕРА,
          new ПАРАМЕТРЫ_ЗАПРОСА_ОРГ_ЕДИНИЦЫ(
          ))
      },

      ...mapActions([
        СОЗДАТЬ_ОРГ_ЕДИНИЦЫ_НА_СЕРВЕРЕ
        ПОЛУЧИТЬ_ОРГ_ЕДИНИЦЫ_С_СЕРВЕРА,
      ]),

      ...mapMutations([
        СОХРАНИТЬ_ОРГ_ЕДИНИЦЫ
      ]),
    },
  }
</script>
*/
