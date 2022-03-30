import { Param } from './Param'
import { _addObjectToProfile } from './_addObjectToProfile'

export default {
  methods: {
    /**
     * добавляем объект в профиль когда пришло сообщение от подчиненного компонента ProfileTree
     * @param {{active: Number, direction: 'child'|'parent'}|null} _ ид родительского объекта
     */
    addObjectToProfile (_) {
      // _ === null если добавляется объект базы данных
      if (_ === undefined) throw new Error('addObjectToProfile(undefined)')
      _ = _ ?? { active: null, direction: null }

      _addObjectToProfile(
        new Param(
          _.active,
          _.direction,
          this,
        ))

      this.названиеДобавляемогоОбъекта = ''
      this.праваПредоставляемыеПрофилем = []
    },

    // удаление корневого объекта
    removeObjectFromProfile (id) {
      console.log(`removeObjectFromProfile(id: ${id})`)

      // ищем индекс удаляемого элемента в массиве объектыПрофиля
      const index = this.объектыПрофиля.findIndex(v => v.id === id)
      console.log(`индекс удаляемого элемента в массиве объектыПрофиля:${index}`)
      // удаляем корневой объект из массива
      this.объектыПрофиля.splice(index, 1)

      // удаляем все объекты, которые являются дочерними объектами корневого элемента
      const дочерние = this.объектыПрофиля.filter(v => v.root === id)
      console.log(`дочерние: ${дочерние.length}`)
      // если дочерних нет - выходим
      дочерние.forEach(v1 => {
        // находим индекс очередного объекта на удаление
        const index = this.объектыПрофиля.findIndex(v2 => v2.id === v1.id)
        this.объектыПрофиля.splice(index, 1)
        console.log(`удален объект [index, id, parent, root]=[${index}, ${v1.id}, ${v1.parent}, ${v1.root}]`)
      })
    },
  },
}
