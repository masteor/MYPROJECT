import {
  АЛЕРТНУТЬ_ДАННЫЕ_ФОРМЫ_ВОССТАНОВЛЕНЫ,
  ПОЛУЧИТЬ_ДЕЙСТВУЮЩИЕ_ПРОФИЛИ_ПОЛЬЗОВАТЕЛЯ_С_СЕРВЕРА,
  ПОЛУЧИТЬ_ОРГ_ЕДИНИЦЫ_С_СЕРВЕРА,
  ПОЛУЧИТЬ_ФИО_ВСЕХ_ДЕЙСТВУЮЩИХ_СОТРУДНИКОВ_С_СЕРВЕРА,
  ПОЛУЧИТЬ_ФОРМУ_ИЗ_ХРАНИЛИЩА_БРАУЗЕРА,
  СОЗДАТЬ_ДОСТУПЫ_СУБЪЕКТОВ_К_РЕСУРСАМ_НА_СЕРВЕРЕ,
  СОХРАНИТЬ_ФОРМУ_ВО_ХРАНИЛИЩЕ_БРАУЗЕРА,
} from '@/store/action-types'

import {
  ДОПОЛНИТЕЛЬНЫЕ_ПАРАМЕТРЫ_ЗАЯВКИ_ПЕРЕГРУЗКА_1,
  ПАРАМЕТРЫ_ЗАПРОСА_ЗАВИСЯЩЕГО_ОТ_ФРАГМЕНТА,
  ПАРАМЕТРЫ_ЗАПРОСА_СОЗДАТЬ_ДОСТУПЫ_СУБЪЕКТОВ_К_РЕСУРСАМ,
} from '@/store/param-types'

import {
  domainAccount,
  получитьИдФрагмента,
  получитьЛогинПользователяСервиса,
} from '@/store/getter-types'

import { Зарегистрирована } from '@/constants/идСтатусаЗаявки'
import { имяФормы } from './const'
import { ПОЛУЧИТЬ_ДЕРЕВО_СУЩЕСТВУЮЩИХ_РЕСУРСОВ } from '@/store/url-types'
import { СОХРАНИТЬ_ДЕРЕВО_РЕСУРСОВ } from '@/store/mutation-types'
import * as _ from '@/constants/типыОбъектовДерева'

export default {
  methods: {

    // метод вызывается когда выбирается какая-нибудь нода в дереве ресурсов
    /**
     * @param {{}} event
     */
    updateActive (event) {
      if (event.type === _.ПРОФИЛЬ) {
        this.имяПрофиля = event.name
        this.идПрофиля = event.id_profile
        return
      }

      this.имяПрофиля = ''
      this.идПрофиля = 0
    },

    async CreateMember () {
        // this.saveContent()
        this.loading.createMember = true

        await this.$store.dispatch(
          СОЗДАТЬ_ДОСТУПЫ_СУБЪЕКТОВ_К_РЕСУРСАМ_НА_СЕРВЕРЕ,
          new ПАРАМЕТРЫ_ЗАПРОСА_СОЗДАТЬ_ДОСТУПЫ_СУБЪЕКТОВ_К_РЕСУРСАМ(
            this.идПрофиля,
            this.выбранныеСотрудники,
            this.выбранныеОргЕдиницы,
            new ДОПОЛНИТЕЛЬНЫЕ_ПАРАМЕТРЫ_ЗАЯВКИ_ПЕРЕГРУЗКА_1(
              this.$store.getters[получитьЛогинПользователяСервиса],
              this.$store.getters[получитьЛогинПользователяСервиса],
              Зарегистрирована,
            ),
        ))

        this.loading.createMember = false
    },

    async ПолучитьПрофили () {
      this.loading.profile = true

      await this.$store.dispatch(
        ПОЛУЧИТЬ_ДЕЙСТВУЮЩИЕ_ПРОФИЛИ_ПОЛЬЗОВАТЕЛЯ_С_СЕРВЕРА,
        new ПАРАМЕТРЫ_ЗАПРОСА_ЗАВИСЯЩЕГО_ОТ_ФРАГМЕНТА(
          this.$store.getters[получитьИдФрагмента],
          this.$store.getters[domainAccount],
        ))

      this.loading.profile = false
    },

    async ПолучитьФио () {
      this.loading.employee = true

      await this.$store.dispatch(ПОЛУЧИТЬ_ФИО_ВСЕХ_ДЕЙСТВУЮЩИХ_СОТРУДНИКОВ_С_СЕРВЕРА)

      this.loading.employee = false
    },

    async ПолучитьОрг () {
      this.loading.org = true

      await this.$store.dispatch(ПОЛУЧИТЬ_ОРГ_ЕДИНИЦЫ_С_СЕРВЕРА)

      this.loading.org = false
    },

    async получитьСуществующиеРесурсы () {
      this.loading.tree = true

      const результат = await this.$get(
        ПОЛУЧИТЬ_ДЕРЕВО_СУЩЕСТВУЮЩИХ_РЕСУРСОВ,
        new ПАРАМЕТРЫ_ЗАПРОСА_ЗАВИСЯЩЕГО_ОТ_ФРАГМЕНТА(
          this.$store.getters[получитьИдФрагмента],
          this.$store.getters[domainAccount],
        ),
      )

      this.$store.commit(СОХРАНИТЬ_ДЕРЕВО_РЕСУРСОВ, результат)
      this.treeItems = результат

      this.loading.tree = false
    },

    async saveContent () {
      await this.$store.dispatch(
        СОХРАНИТЬ_ФОРМУ_ВО_ХРАНИЛИЩЕ_БРАУЗЕРА,
        {
          key: имяФормы,
          value: JSON.parse(JSON.stringify(this.v)), // переводим сложный объект в строку и обратно в объект, долго, но надежно
          // ранее использовал _.cloneDeep(this.v),
          // но он отрабатывает неверно, если у меня есть массив объектов,
          // которые содержат массив, в этом случае массив не копировался
        })
    },

    clearContent () {
      this.stopWatching = true
      this.v = new ОбъектФормы()
      this.stopWatching = false
    },

    async loadContent () {
      // ставим флаг, что идёт восстановление формы и надо остановить наблюдение
      this.stopWatching = true

      const v = await this.$store.dispatch(
        ПОЛУЧИТЬ_ФОРМУ_ИЗ_ХРАНИЛИЩА_БРАУЗЕРА,
        имяФормы,
      )

      if (v === null) { return }

      // сохраняем полученный объект, используется для отладки
      this.i = v
      // клонируем полученный объект
      this.v = JSON.parse(JSON.stringify(v))

      await this.$store.dispatch(АЛЕРТНУТЬ_ДАННЫЕ_ФОРМЫ_ВОССТАНОВЛЕНЫ)

      // ставим флаг, что восстановление формы завершено и можно опять включить наблюдение
      this.stopWatching = false
    },
  },
}

export class ОбъектФормы {
  идПрофиля = 0

  имяПрофиля = ''

  /** @type {number[]} */
  выбранныеСотрудники = 0

  /** @type {number[]} */
  выбранныеОргЕдиницы = 0
}
