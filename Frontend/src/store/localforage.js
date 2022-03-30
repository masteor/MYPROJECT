let instanceLocalForage = null

//= =======================================================================================================
//= РАБОТА С ХРАНИЛИЩЕМ БРАУЗЕРА =========================================================================
//= =======================================================================================================

export function setInstance (instance) {
  instanceLocalForage = instance
}

/**
 * Получить свойство из хранилища
 * @param {String} key Имя свойства
 * @return {any|null}
 */
export async function localeStorageGetItem (key) {
  try {
    return await instanceLocalForage.getItem(key)
  } catch (e) {
    console.log(e)
  }
}

/* function localeStorageGetItem (key, value) {
  if (localStorage.getItem(key)) {
    try {
      // если ключ существует и парсится - тогда отдаем значение ключа
      return JSON.parse(localStorage.getItem(key))
    } catch (e) {
      // иначе если произошла ошибка - ключ удаляется и отдаётся значение из альтернативного источника
      localStorage.removeItem(key)
      return value
    }
  }
} */

/**
 * Сохранить свойство в хранилище
 * @param {string} key Имя свойства
 * @param {any} value Сохраняемое значение
 */
export function localeStorageSetItem (key, value) {
  // если в хранилище передают значение null или undefined,
  // тогда Не сохраняем его в хранилище
  // if (value === undefined || value === null) return value
  // localStorage.setItem(key, JSON.stringify(value))

  instanceLocalForage.setItem(key, value)
    .catch(err => {
      // we got an error
      console.log(`Ошибка при установке значения ключа: ${key} в хранилище. Error: ${err}`)
    })
}
