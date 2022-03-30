import {
  ДОПОЛНИТЕЛЬНЫЕ_ПАРАМЕТРЫ_ЗАЯВКИ,
  ПАРАМЕТРЫ_ЗАПРОСА_ДОБАВИТЬ_ОБЪЕКТЫ_В_ПРОФИЛЬ,
} from '@/store/param-types'

import { Зарегистрирована } from '@/constants/идСтатусаЗаявки'
import * as actionTypes from '@/store/action-types'
import * as paramsTypes from '@/store/param-types'
import * as getterTypes from '@/store/getter-types'

export default {
  methods: {
      // отправляем на сервер форму
      async SendRequestCreateProfile () {
        this.loadingSendRequest = true

        /** @type {ОБЪЕКТ_ПРОФИЛЯ[]} */
        const arrIn = [...this.объектыПрофиля]
        const arrOut = arrIn.map(v =>
        ({
          id: v.id,
          parent: v.parent,
          /* root: v.root, */
          ObjectName: v.ObjectName,
          ObjectTypeId: v.ObjectType.id,
          RightDescriptions: [...v.RightDescriptions],
        }))

        const o = JSON.stringify(
          new ПАРАМЕТРЫ_ЗАПРОСА_ДОБАВИТЬ_ОБЪЕКТЫ_В_ПРОФИЛЬ(
            this.имяПрофиля,
            this.идДействующегоОбъектаРесурса,
            arrOut,
            new ДОПОЛНИТЕЛЬНЫЕ_ПАРАМЕТРЫ_ЗАЯВКИ(
              null,
              null,
              this.получитьЛогинПользователяСервиса,
              this.получитьЛогинПользователяСервиса,
              Зарегистрирована,
              null,
              null,
            ),
          ),
        )

        await this.ДОБАВИТЬ_ОБЪЕКТЫ_В_ПРОФИЛЬ_НА_СЕРВЕРЕ(o)
        this.loadingSendRequest = false
      },

    // очистка формы после выбора ресурса
    /**
     * @param {number} id ид действующего объекта ресурса который надо восстановить после очистки формы
     */
    clearContentAfterSelectingResource (id) {
      this.clearContent()
      this.ДействующийОбъектРесурса = this.получитьДействующиеРесурсыПользователя.find(v => v.id_object === id)
    },

    ЗАПРОСИТЬ_ДАННЫЕ_ДЛЯ_ФОРМЫ_ДОБАВИТЬ_ОБЪЕКТ_В_ПРОФИЛЬ () {
      this.ПОЛУЧИТЬ_ПРАВА_ПРЕДОСТАВЛЯЕМЫЕ_ПРОФИЛЕМ_С_СЕРВЕРА()
      this.ПОЛУЧИТЬ_ДЕЙСТВУЮЩИЕ_И_НА_ЭТАПЕ_РЕГИСТРАЦИИ_ПРОФИЛИ_ПОЛЬЗОВАТЕЛЯ_С_СЕРВЕРА()
      this.ПОЛУЧИТЬ_ДЕЙСТВУЮЩИЕ_РЕСУРСЫ_ПОЛЬЗОВАТЕЛЯ_С_СЕРВЕРА()
      this.ПОЛУЧИТЬ_ТИПЫ_ОБЪЕКТОВ_СЕРВИСОВ()
      this.ПОЛУЧИТЬ_ГЛАВНЫЕ_ТИПЫ_ОБЪЕКТОВ()
    },

    async ПОЛУЧИТЬ_ПРАВА_ПРЕДОСТАВЛЯЕМЫЕ_ПРОФИЛЕМ_С_СЕРВЕРА () {
      await this.$store.dispatch(actionTypes.ПОЛУЧИТЬ_ПРАВА_ПРЕДОСТАВЛЯЕМЫЕ_ПРОФИЛЕМ_С_СЕРВЕРА)
    },

    async ПОЛУЧИТЬ_ДЕЙСТВУЮЩИЕ_И_НА_ЭТАПЕ_РЕГИСТРАЦИИ_ПРОФИЛИ_ПОЛЬЗОВАТЕЛЯ_С_СЕРВЕРА () {
      await this.$store.dispatch(
        actionTypes.ПОЛУЧИТЬ_ДЕЙСТВУЮЩИЕ_И_НА_ЭТАПЕ_РЕГИСТРАЦИИ_ПРОФИЛИ_ПОЛЬЗОВАТЕЛЯ_С_СЕРВЕРА,
        new paramsTypes.ПАРАМЕТРЫ_ЗАПРОСА_ЗАВИСЯЩЕГО_ОТ_ФРАГМЕНТА(
          this.$store.getters[getterTypes.получитьФрагмент].id,
          this.$store.getters[getterTypes.domainAccount],
        ))
    },

    async ПОЛУЧИТЬ_ДЕЙСТВУЮЩИЕ_РЕСУРСЫ_ПОЛЬЗОВАТЕЛЯ_С_СЕРВЕРА () {
      await this.$store.dispatch(
        actionTypes.ПОЛУЧИТЬ_ДЕЙСТВУЮЩИЕ_РЕСУРСЫ_ПОЛЬЗОВАТЕЛЯ_С_СЕРВЕРА,
        new paramsTypes.ПАРАМЕТРЫ_ЗАПРОСА_ДЕЙСТВУЮЩИЕ_РЕСУРСЫ_ПОЛЬЗОВАТЕЛЯ_ВО_ФРАГМЕНТЕ(
          this.$store.getters[getterTypes.получитьФрагмент].id,
          this.$store.getters[getterTypes.domainAccount],
        ),
      )
    },

    async ПОЛУЧИТЬ_ТИПЫ_ОБЪЕКТОВ_СЕРВИСОВ () {
      await this.$store.dispatch(actionTypes.ПОЛУЧИТЬ_ТИПЫ_ОБЪЕКТОВ_СЕРВИСОВ)
    },

    async ПОЛУЧИТЬ_ГЛАВНЫЕ_ТИПЫ_ОБЪЕКТОВ () {
      await this.$store.dispatch(actionTypes.ПОЛУЧИТЬ_ГЛАВНЫЕ_ТИПЫ_ОБЪЕКТОВ)
    },
  },
}
