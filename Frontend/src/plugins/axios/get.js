// eslint-disable-next-line camelcase
// import { $_moment } from '@/plugins/Moment'
import { axGet } from '@/plugins/axios/axios'
import Vue from '@/main'
import { АЛЕРТНУТЬ } from '@/store/action-types'
import { ПАРАМЕТРЫ_АЛЕРТА } from '@/store/param-types'
import ТипАлерта from '@/constants/типАлерта'

export const успешно = (response) => response === 200

// запихиваем GET в this Vue
export default {
  install (Vue) {
    Vue.prototype.$get = get
  },
}

/**
 * Обработчик запроса GET
 * @param {string} url
 * @param {{}} params
 * @return {{}} model
 */
async function get (url, params = null) {
  console.log(`get(url: ${url}, params: ${params} )`)
  // дожидаемся выполнения запроса
  const response = await axGet(url, params)

  // если запрос не успешен либо неуспешный код в результате запроса выводим сообщение
  if (!успешно(response.status) || !успешно(response.data.result?.code)) {
    Vue.$store.dispatch(
      АЛЕРТНУТЬ,
      new ПАРАМЕТРЫ_АЛЕРТА(`Код ошибки: ${response.data.result?.code}, Сообщение: ${response.data.result?.msg}`, ТипАлерта.error),
    )
  }

  // если успешный запрос и успешный код в результате запроса

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
                // todo: ПАТЧИНГ ДАТЫ НЕ РАБОТАЕТ
                // v[key] = $_moment(v[key]).format('YYYY-MM-DD HH:MM:SS')
              }
            })
          }
        }
      }
    }
  }

  return model
}

export { get }
