/* eslint-disable camelcase */
import Vue from 'vue'
import Vuex from 'vuex'
import Getters from './getters'
import Mutations from './mutations'
import Actions from './actions'
import State from './state'

// Подключаем к Vue хранилище Vuex
Vue.use(Vuex)

// наполняем хранилище Vuex свойствами и методами
export const store = new Vuex.Store({
  strict: process.env.NODE_ENV !== 'production',
  plugins: [/* this.subscribe((mutation, state) => {
    console.log(`mutation: ${mutation}, state: ${state}`)
  }) */],
  state: State,
  getters: Getters,
  actions: Actions,
  mutations: Mutations,
})

/* {
  strict: process.env.NODE_ENV !== 'production',
  state: State,
  getters: Getters,
  mutations: Mutations,
  actions: Actions,
} */
//= =======================================================================================================
/**
 * @param {String} url урл на который уйдет запрос
 * @param {Object} params - параметры запроса
 * @param {String} parentDispatch имя родительского действия, инициировавшее действие "ВЫПОЛНИТЬ_ЗАПРОС_GET (или PUT)", используется для отладки
 * @return {Object}
 */
export class PostPayload {
  /**
   * @param {String} url урл на который уйдет запрос
   * @param {Object} params - параметры запроса
   * @param {String} parentDispatcher имя родительского действия, инициировавшее действие "ВЫПОЛНИТЬ_ЗАПРОС_GET (или PUT)", используется для отладки
   */
  constructor (url, params, parentDispatcher = '<Имя действия не указано>') {
    this.url = url
    this.parentDispatcher = parentDispatcher
    this.params = params
  }
}

/**
 * @param {Object} obj
 * @returns {String}
 */
// eslint-disable-next-line no-unused-vars
function nameof (obj) {
  return Object.keys(obj)[0]
}
