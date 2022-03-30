import { создатьОбъектПрофиляИДобавитьВоМассив } from './создатьОбъектПрофиляИДобавитьВоМассив'

/**
 * добавляем объект в профиль
 * @param {Param} _
 */
export function _addObjectToProfile (_) {
  ThrowIfNotValid(_)

  console.log(`addObjectToProfile (${_.active})`)

  if (_.active === undefined) return
  if (ЕслиОбъектПрофиляСуществует(_)) return

  // добавляется корневой объект (root)
  if (_.active == null) {
    //
    ДобавитьКорневойОбъект(_)
    //
  } else if (_.direction === 'child') {
    // направление добавления объекта - дочерний
    ДобавитьДочернийОбъект(_)
    //
  } /* else if (_.direction === 'parent') {
    // направление добавления объекта - родитель
    ДобавитьРодительскийОбъект(_)
  } */
}

/**
 * @param _
 */
function ThrowIfNotValid (_) {
  if (_ === undefined) throw new Error('_addObjectToProfile(undefined)')
  if (_ === null) throw new Error('_addObjectToProfile(null)')
}

/**
 * @param {Param} _
 * @return {boolean} true - объект существует, false - объект не существует
 */
function ЕслиОбъектПрофиляСуществует (_) {
  // не добавлять объект если существует объект с таким же именем, типом и родителем
  if (_._this.объектыПрофиля?.some(v =>
    v.ObjectName === _._this.названиеДобавляемогоОбъекта &&
    v.ObjectType.id === _._this.ТипДобавляемогоОбъекта.id &&
    v.parent === _.active
  )) {
    console.log('Объект профиля уже существует')
    return true
  }
  return false
}

/**
 * @param {Param} _
 */
function ДобавитьКорневойОбъект (_) {
  const id = ++(_._this.treeCounter)
  // сначала прибавляем, потом сохраняем
  // создаём объект профиля
  // root = id - из этого поля в дальнейшем будет передаваться ид корневого элемента
  console.log(`создатьОбъектПрофиляИДобавитьВоМассив(${id}, ${null}, ${id})`)

  создатьОбъектПрофиляИДобавитьВоМассив(id, null, id, _)
}

/**
 * @param {Param} _
 */
function ДобавитьДочернийОбъект (_) {
  /** @type {ОБЪЕКТ_ПРОФИЛЯ[]} */
  const arr = _._this.объектыПрофиля

  // ищем текущий выделенный элемент в массиве - он будет родителем добавляемого элемента
  const parentObject = arr.find(v => v.id === _.active)
  console.log(`parentObject: ${parentObject}`)

  // создаем новый ид для добавляемого объекта
  const id = ++(_._this.treeCounter)
  console.log(`создатьОбъектПрофиляИДобавитьВоМассив(${id}, ${_.active}, ${parentObject?.root})`)

  создатьОбъектПрофиляИДобавитьВоМассив(
    id, _.active, parentObject?.root,
    _,
  )
}
