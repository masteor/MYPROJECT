/*
// СОЗДАТЬ ИЛИ ПОЛУЧИТЬ - глагол в верхнем регистре

// Что будем получать или создавать - существительное
// например: действующие профили // каждое слово писать через пробел
// Перечень АРМ в АС
переченьАрмВАс

// --------------------------------------------------------------------------------------------------------------
// getter-types.js
// --------------------------------------------------------------------------------------------------------------
import * as getterTypes from './getter-types'
export const получитьПереченьАрмВАс = 'получитьПереченьАрмВАс'

// --------------------------------------------------------------------------------------------------------------
// mutation-types.js
// --------------------------------------------------------------------------------------------------------------
import * as mutationTypes from './mutation-types'
export const СОХРАНИТЬ_ПЕРЕЧЕНЬ_АРМ_В_АС = 'СОХРАНИТЬ_ПЕРЕЧЕНЬ_АРМ_В_АС'

// --------------------------------------------------------------------------------------------------------------
// actions-types.js
// --------------------------------------------------------------------------------------------------------------
import * as actionTypes from './action-types'
export const СОХРАНИТЬ_ПЕРЕЧЕНЬ_АРМ_В_АС = 'СОХРАНИТЬ_ПЕРЕЧЕНЬ_АРМ_В_АС'

export const СОЗДАТЬ_ПЕРЕЧЕНЬ_АРМ_В_АС_НА_СЕРВЕРЕ = 'СОЗДАТЬ_ПЕРЕЧЕНЬ_АРМ_В_АС_НА_СЕРВЕРЕ'
export const ПОЛУЧИТЬ_ПЕРЕЧЕНЬ_АРМ_В_АС_С_СЕРВЕРА = 'ПОЛУЧИТЬ_ПЕРЕЧЕНЬ_АРМ_В_АС_С_СЕРВЕРА'

// --------------------------------------------------------------------------------------------------------------
// URL-TYPES
// --------------------------------------------------------------------------------------------------------------
import * as urlTypes from './url-types'
// сущности
export const СОЗДАТЬ_ПЕРЕЧЕНЬ_АРМ_В_АС_НА_СЕРВЕРЕ = '/RequestAjax/all-arms'
export const ПОЛУЧИТЬ_ПЕРЕЧЕНЬ_АРМ_В_АС_С_СЕРВЕРА = '/RequestAjax/all-arms'
// отчеты
export const ПОЛУЧИТЬ_ПЕРЕЧЕНЬ_АРМ_В_АС_С_СЕРВЕРА = '/ReportAjax/all-arms'

// --------------------------------------------------------------------------------------------------------------
// Header-types | для отчетов
// --------------------------------------------------------------------------------------------------------------
import * as urlTypes from './header-types'
export class ПЕРЕЧЕНЬ_АРМ_В_АС {
  constructor () {
    return [
      {
        text: 'id',
        align: 'start',
        value: 'id',
      },
      {
        text: '',
        value: '',
      },
    ]
  }
}

// --------------------------------------------------------------------------------------------------------------
// PARAM-TYPES
// --------------------------------------------------------------------------------------------------------------
import * as urlTypes from './params-types'
export class ПАРАМЕТРЫ_ЗАПРОСА_ПЕРЕЧЕНЬ_АРМ_В_АС {
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
// constants/route-paths.js
// --------------------------------------------------------------------------------------------------------------
// all-arms
// routePathConstName: AllArms // пример: AcAccess
// routePathConstName2: all-arms

export const AllArms  = {
  route: {
    path: 'all-arms',
    name: pathNames.AllArms,
    components: {
      mainContent: () => import('../views/Report/AllArms'),
    },
  },
  menuItem: {
    title: titles.переченьАрмВАс,
    to: { name: pathNames.AllArms },
  },
}

// --------------------------------------------------------------------------------------------------------------
// constants/path-names.js
// --------------------------------------------------------------------------------------------------------------
export const AllArms = 'AllArms'

// --------------------------------------------------------------------------------------------------------------
// constants/titles.js
// --------------------------------------------------------------------------------------------------------------
// пример: export const переченьРесурсовВАс = 'Перечень ресурсов в АС'
export const переченьАрмВАс = 'Перечень АРМ в АС'

// --------------------------------------------------------------------------------------------------------------
// STORE.JS
// --------------------------------------------------------------------------------------------------------------

// state
переченьАрмВАс: [],

// getter
[getterTypes.получитьПереченьАрмВАс]: state => state.переченьАрмВАс,

// mutation
[mutationTypes.СОХРАНИТЬ_ПЕРЕЧЕНЬ_АРМ_В_АС] (state, value) {
  state.переченьАрмВАс = value
},

// Действия
// сохранить
[actionTypes.СОХРАНИТЬ_ПЕРЕЧЕНЬ_АРМ_В_АС] ({ commit }, value) {
  commit(mutationTypes.СОХРАНИТЬ_ПЕРЕЧЕНЬ_АРМ_В_АС, value)
},

// GET
// модель, наДату, null: наДату - надо ввести слово,
/!**
 * @function dispatch
 * @param {Object.<ПАРАМЕТРЫ_ЗАПРОСА_ПЕРЕЧЕНЬ_АРМ_В_АС>} модель
 * @returns {Promise, Array<ПЕРЕЧЕНЬ_АРМ_В_АС>}
 *!/
[actionTypes.ПОЛУЧИТЬ_ПЕРЕЧЕНЬ_АРМ_В_АС_С_СЕРВЕРА] ({ dispatch }, наДату) {
  return dispatch(
    actionTypes.ВЫПОЛНИТЬ_ЗАПРОС_GET,
    new GetPayloadYesParam(
      urlTypes.ПОЛУЧИТЬ_ПЕРЕЧЕНЬ_АРМ_В_АС_С_СЕРВЕРА,
      наДату,
      mutationTypes.СОХРАНИТЬ_ПЕРЕЧЕНЬ_АРМ_В_АС,
      actionTypes.ПОЛУЧИТЬ_ПЕРЕЧЕНЬ_АРМ_В_АС_С_СЕРВЕРА,
    ))
},

// Действия
// POST
/!**
 * @function dispatch
 * @param {Object.<ПАРАМЕТРЫ_ЗАПРОСА_ПЕРЕЧЕНЬ_АРМ_В_АС>} модель
 * @returns {Promise}
 *!/
[actionTypes.СОЗДАТЬ_ПЕРЕЧЕНЬ_АРМ_В_АС_НА_СЕРВЕРЕ] ({ dispatch }, наДату) {
  return dispatch(
    actionTypes.ВЫПОЛНИТЬ_ЗАПРОС_POST,
    new PostPayload(
      urlTypes.СОЗДАТЬ_ПЕРЕЧЕНЬ_АРМ_В_АС_НА_СЕРВЕРЕ,
      наДату,
      actionTypes.СОЗДАТЬ_ПЕРЕЧЕНЬ_АРМ_В_АС_НА_СЕРВЕРЕ,
    ))
},

// --------------------------------------------------------------------------------------------------------------
// ДЛЯ КОМПОНЕНТА
// --------------------------------------------------------------------------------------------------------------
<script>
  import { mapActions, mapGetters, mapMutations } from 'vuex'

  import {
    получитьПереченьАрмВАс
  } from '../../store/getter-types'

  import {
    СОЗДАТЬ_ПЕРЕЧЕНЬ_АРМ_В_АС_НА_СЕРВЕРЕ
    ПОЛУЧИТЬ_ПЕРЕЧЕНЬ_АРМ_В_АС_С_СЕРВЕРА
  } from '../../store/action-types'

  import { СОХРАНИТЬ_ПЕРЕЧЕНЬ_АРМ_В_АС } from '../../store/mutation-types'
  import { ПАРАМЕТРЫ_ЗАПРОСА_ПЕРЕЧЕНЬ_АРМ_В_АС } from '../../store/params-types'

  export default {

    data: () => ({
      выбранныйПереченьАрмВАс: null,
    }),

    computed: {
      ...mapGetters([
        получитьПереченьАрмВАс,
      ]),
    },

    methods: {
      save (date) {
        this.$refs.menu.save(date)
      },

      ...mapActions([
        СОЗДАТЬ_ПЕРЕЧЕНЬ_АРМ_В_АС_НА_СЕРВЕРЕ
        ПОЛУЧИТЬ_ПЕРЕЧЕНЬ_АРМ_В_АС_С_СЕРВЕРА,
      ]),

      ...mapMutations([
        СОХРАНИТЬ_ПЕРЕЧЕНЬ_АРМ_В_АС
      ]),
    },
  }
</script>
*/
