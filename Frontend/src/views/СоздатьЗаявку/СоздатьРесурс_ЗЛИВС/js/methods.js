import { ДОПОЛНИТЕЛЬНЫЕ_ПАРАМЕТРЫ_ЗАЯВКИ, ПАРАМЕТРЫ_ЗАПРОСА_СОЗДАТЬ_РЕСУРС_ЗЛИВС } from '@/store/param-types'
import { Зарегистрирована } from '@/constants/идСтатусаЗаявки'
import * as paramsTypes from '@/store/param-types'
import ТипАлерта from '@/constants/типАлерта'
import {
  АЛЕРТНУТЬ_ДАННЫЕ_ФОРМЫ_ВОССТАНОВЛЕНЫ,
  АЛЕРТНУТЬ_НЕТ_ДАННЫХ_ДЛЯ_ВОССТАНОВЛЕНИЯ,
  ПОЛУЧИТЬ_ФОРМУ_ИЗ_ХРАНИЛИЩА_БРАУЗЕРА,
  СОХРАНИТЬ_ФОРМУ_ВО_ХРАНИЛИЩЕ_БРАУЗЕРА,
} from '@/store/action-types'
import { имяФормы } from './const'

export default {
  methods: {
    async CreateResourceZlivs () {
      console.log('СоздатьРесурсЗЛИВС')

      this.loading = true

      await this.СОЗДАТЬ_РЕСУРС_ЗЛИВС_НА_СЕРВЕРЕ(
        new ПАРАМЕТРЫ_ЗАПРОСА_СОЗДАТЬ_РЕСУРС_ЗЛИВС(
          null,
          null,
          null,
          this.описаниеРесурса,
          this.названиеРесурса,
          this.идТипаОбъектаРесурса,
          this.идФрагмента,
          this.идТипаСервиса,
          this.идТипСекретности,
          this.идОтветственный,
          this.идВладелецРесурса,
          new ДОПОЛНИТЕЛЬНЫЕ_ПАРАМЕТРЫ_ЗАЯВКИ(
            null,
            null,
            this.получитьЛогинПользователяСервиса,
            this.получитьЛогинПользователяСервиса,
            Зарегистрирована,
            null,
            null,
          ),
          this.выбранныеСотрудники,
          this.выбранныеОргЕдиницы,
        ))

      this.loading = false
    },

    проверитьСуществованиеРесурса () {
      if (
        this.идФрагмента > 0 &&
        this.идТипаОбъектаРесурса > 0 &&
        this.идТипаСервиса > 0
      ) {
        this.действующиеРесурсы = this.отфильтроватьРесурсы(
          this.получитьДействующиеРесурсы,
          this.идФрагмента,
          this.идТипаОбъектаРесурса,
          this.идТипаСервиса,
        )

        this.resourceExist = this.действующиеРесурсы.some(
          value => value.name === this.названиеРесурса,
        )

        if (this.resourceExist) {
          this.АЛЕРТНУТЬ(
            new paramsTypes.ПАРАМЕТРЫ_АЛЕРТА(
              `Ресурс с именем: '${this.названиеРесурса}' уже существует в БД`,
              ТипАлерта.error,
            ),
          )
        }
      }
    },

    saveContent () {
      this.$store.dispatch(
        СОХРАНИТЬ_ФОРМУ_ВО_ХРАНИЛИЩЕ_БРАУЗЕРА,
        {
          key: имяФормы,
          value: {
            названиеРесурса: this.названиеРесурса,
            описаниеРесурса: this.описаниеРесурса,
            идТипаОбъектаРесурса: this.идТипаОбъектаРесурса,
            идТипСекретности: this.идТипСекретности,
            идОтветственный: this.идОтветственный,
            идВладелецРесурса: this.идВладелецРесурса,
            выбранныеСотрудники: Array.from(this.выбранныеСотрудники),
            выбранныеОргЕдиницы: Array.from(this.выбранныеОргЕдиницы),
          },
        })
    },

    clearContent () {
      this.названиеРесурса = ''
      this.описаниеРесурса = ''
      this.идТипаОбъектаРесурса = 0
      this.идТипСекретности = 0
      this.идОтветственный = 0
      this.идВладелецРесурса = 0
      this.выбранныеСотрудники = []
      this.выбранныеОргЕдиницы = []
    },

    async loadContent () {
      const v = await this.$store.dispatch(
        ПОЛУЧИТЬ_ФОРМУ_ИЗ_ХРАНИЛИЩА_БРАУЗЕРА,
        имяФормы,
      )

      if (v === undefined || v === null) {
        this.$store.dispatch(АЛЕРТНУТЬ_НЕТ_ДАННЫХ_ДЛЯ_ВОССТАНОВЛЕНИЯ)
        return
      }

      this.данныеФормыИзЛокальногоХранилища = { ...v }

      this.названиеРесурса = v.названиеРесурса
      this.описаниеРесурса = v.описаниеРесурса
      this.идТипаОбъектаРесурса = v.идТипаОбъектаРесурса
      this.идТипСекретности = v.идТипСекретности
      this.идОтветственный = v.идОтветственный
      this.идВладелецРесурса = v.идВладелецРесурса

      this.выбранныеСотрудники = Array.from(v.выбранныеСотрудники)
      this.выбранныеОргЕдиницы = Array.from(v.выбранныеОргЕдиницы)

      this.$store.dispatch(АЛЕРТНУТЬ_ДАННЫЕ_ФОРМЫ_ВОССТАНОВЛЕНЫ)
    },

    blur () {
      if (this.названиеРесурса.length < 1) return
      this.проверитьСуществованиеРесурса()
    },
  },
}
