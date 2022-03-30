import { ОБЪЕКТ_ПРОФИЛЯ } from '@/store/param-types'

/**
 * @param {number} id
 * @param {number|null} parent
 * @param {number} root
 * @param {Param} _
 */
export function создатьОбъектПрофиляИДобавитьВоМассив (id, parent, root, _) {
  const объектпрофиля = new ОБЪЕКТ_ПРОФИЛЯ(
    id,
    parent,
    root, // копируем ид корневого элемента на дочерний элемент
    _._this,
  )

  // заталкиваем в массив объект профиля
  _._this.объектыПрофиля.push(объектпрофиля)
}
