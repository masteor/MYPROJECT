<template lang="pug">
    v-card.mx-auto
      v-card-title.headline {{ title }}
      v-divider
      v-card-text
          v-form(
            v-model="valid"
          )
            v-text-field(
              type="text"
              label='Название ресурса'
              dense
              clearable
              counter
              color="primary"
              v-model="названиеРесурса"
              autofocus
              :placeholder="placeholderResource"
              required
              :rules="[v => !!(v && v.length > 0 && v.length <= 255) || '']"
              @blur="blur"
            )

            v-text-field(
              type="text"
              label='Описание ресурса'
              dense
              clearable
              counter
              color="primary"
              v-model="описаниеРесурса"
              autofocus
              placeholder="Введите краткое описание ресурса"
              required
              :rules="[v => !!(v && v.length > 0 && v.length <= 255) || '']"
            )

            v-text-field(
              type="text"
              label='Фрагмент'
              dense
              color="primary"
              v-model="получитьФрагмент.fname"
              required
              disabled
              :rules="[v => !!(v && v.length > 0) || '']"
            )

            v-autocomplete(
              :loading="$loadingCondition(получитьГлавныеТипыОбъектов)"
              :disabled="$disabledCondition(получитьГлавныеТипыОбъектов)"
              :items="$itemsCondition(получитьГлавныеТипыОбъектов)"
              v-model="идТипаОбъектаРесурса"
              label="Тип ресурса"
              placeholder="Выберите тип ресурса"
              item-text="name"
              item-value="id"
              color="primary"
              item-color="primary"
              required
              :rules="[v => !!v || 'Выберите тип ресурса']"
            )

            v-text-field(
              type="text"
              label='Тип сервиса'
              dense
              color="primary"
              :value="типСервисаНазвание"
              required
              disabled
              :rules="[v => !!(v && v.length > 0) || '']"
            )

            v-autocomplete(
              :loading="$loadingCondition(получитьТипыСекретности)"
              :disabled="$disabledCondition(получитьТипыСекретности)"
              :items="$itemsCondition(получитьТипыСекретности)"
              v-model="идТипСекретности"
              label="Тип секретности"
              placeholder="Выберите тип секретности"
              item-text="name"
              item-value="id"
              color="primary"
              item-color="primary"
              required
              :rules="[v => !!v || 'Выберите тип секретности']"
            )

            v-autocomplete(
              :loading="$loadingCondition(получитьВсехСотрудников)"
              :disabled="$disabledCondition(получитьВсехСотрудников)"
              :items="$itemsCondition(получитьВсехСотрудников)"
              v-model="идОтветственный"
              label="Ответственный"
              placeholder="Выберите ответственного"
              item-text="fio_full"
              item-value="id_user"
              color="primary"
              item-color="primary"
              required
              :rules="[v => !!v || 'Выберите ответственного']"
            )

            v-autocomplete(
              :loading="$loadingCondition(получитьВладельцевРесурсов)"
              :disabled="$disabledCondition(получитьВладельцевРесурсов)"
              :items="$itemsCondition(получитьВладельцевРесурсов)"
              v-model="идВладелецРесурса"
              label="Владелец ресурса"
              placeholder="Выберите владельца ресурса"
              item-text="name"
              item-value="id"
              color="primary"
              item-color="primary"
              required
              :rules="[v => !!v || '']"
            )

      v-card-actions
        v-btn(
          :disabled="!valid || resourceExist"
          color="primary"
          shaped
          rounded
          :loading="loading"
          width="auto"
          @click="CreateResource"
        ) Создать ресурс

        user-tools(
          @saveContent="saveContent"
          @clearContent="clearContent"
          @loadContent="loadContent"
        )
</template>

<script>
  import {
    ДОПОЛНИТЕЛЬНЫЕ_ПАРАМЕТРЫ_ЗАЯВКИ,
    ПАРАМЕТРЫ_ЗАПРОСА_СОЗДАТЬ_РЕСУРС,
  } from '@/store/param-types'

  import { формаЗаявкиНаСозданиеРесурса } from '@/constants/titles'
  import { Зарегистрирована } from '@/constants/идСтатусаЗаявки'
  import * as paramsTypes from '@/store/param-types'
  import ТипАлерта from '@/constants/типАлерта'
  import { vuexMixin } from './vuex-mixin'
  import UserTools from '@/components/UserTools'

  import {
    АЛЕРТНУТЬ_ДАННЫЕ_ФОРМЫ_ВОССТАНОВЛЕНЫ,
    АЛЕРТНУТЬ_НЕТ_ДАННЫХ_ДЛЯ_ВОССТАНОВЛЕНИЯ,
    ПОЛУЧИТЬ_ФОРМУ_ИЗ_ХРАНИЛИЩА_БРАУЗЕРА,
    СОХРАНИТЬ_ФОРМУ_ВО_ХРАНИЛИЩЕ_БРАУЗЕРА,
  } from '@/store/action-types'

  import {
    получитьТипСервисаПоТипуОбъекту,
    получитьТипыСекретности,
  } from '@/store/getter-types'

  import * as сеть from '@/constants/типыСетей'

  const введитеНазваниеРесурса = 'Введите название ресурса'
  const имяФормы = 'формаСоздатьРесурс'

  export default {
    name: 'CreateResource',
    components: { UserTools },
    mixins: [
      vuexMixin,
    ],

    data: () => ({
      title: формаЗаявкиНаСозданиеРесурса,
      valid: false,
      идТипаСервиса: 0,
      идФрагмента: 0,
      loading: false,
      resourceExist: false,
      placeholderResource: введитеНазваниеРесурса,
      действующиеРесурсы: [],
      данныеФормыИзЛокальногоХранилища: null,
      названиеРесурса: '',
      описаниеРесурса: '',

      /** @type {number} */
      идТипаОбъектаРесурса: 0,
      идТипСекретности: 0,
      идОтветственный: 0,
      идВладелецРесурса: 0,
      v: {},
      получитьВладельцев: null,
    }),

    computed: {
      фрагмент () {
        return this.$store.state.фрагмент
      },

      получитьТипыСекретности () {
        const code = this.фрагмент?.code
        /** @type {[]} */
        const типыСекретности = this.$store.getters[получитьТипыСекретности]
        return code === сеть.sils
          ? типыСекретности?.filter(r => r.code !== сеть.zlivs)
          : типыСекретности
      },

      /** @return {Array.<paramsTypes.ТипОбъектовСервисов>} */
      типСервиса () {
        return this.$store.getters[получитьТипСервисаПоТипуОбъекту](
          this.идТипаОбъектаРесурса,
        )
      },

      типСервисаНазвание () {
        return this.типСервиса !== null ? this.типСервиса.название : ''
      },
    },

    watch: {
      // изменяется когда пользователь выбрал из списка тип ресурса
      идТипаОбъектаРесурса () {
        this.идТипаСервиса = this.типСервиса.id
        // теперь можно проверить, существует ресурс с текущими идТипаОбъектаРесурса и идТипаСервиса или нет
        // если существует - выдаем предупреждение для пользователя
        this.проверитьСуществованиеРесурса()
      },
    },

    async mounted () {
      this.ЗАПРОСИТЬ_ДАННЫЕ_ДЛЯ_ФОРМЫ_СОЗДАТЬ_РЕСУРС()
      this.идФрагмента = this.получитьФрагмент.id
    },

    methods: {
      async CreateResource () {
        console.log('CreateResource')

        // this.saveContent()

        this.loading = true

        await this.СОЗДАТЬ_РЕСУРС_НА_СЕРВЕРЕ(
          new ПАРАМЕТРЫ_ЗАПРОСА_СОЗДАТЬ_РЕСУРС(
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
          ),
        )

        this.loading = false
      },

      проверитьСуществованиеРесурса () {
        if (
          this.идФрагмента > 0 &&
          this.идТипаОбъектаРесурса > 0 &&
          this.идТипаСервиса > 0
        ) {
          this.действующиеРесурсы =
            this.отфильтроватьРесурсы(
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

      blur () {
        if (this.названиеРесурса.length < 1) return
        this.проверитьСуществованиеРесурса()
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
            },
          })
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

        this.названиеРесурса = v.названиеРесурса
        this.описаниеРесурса = v.описаниеРесурса
        this.идТипаОбъектаРесурса = v.идТипаОбъектаРесурса
        this.идТипСекретности = v.идТипСекретности
        this.идОтветственный = v.идОтветственный
        this.идВладелецРесурса = v.идВладелецРесурса
        this.$store.dispatch(АЛЕРТНУТЬ_ДАННЫЕ_ФОРМЫ_ВОССТАНОВЛЕНЫ)
      },

      clearContent () {
        this.названиеРесурса = ''
        this.описаниеРесурса = ''
        this.идТипаОбъектаРесурса = 0
        this.идТипСекретности = 0
        this.идОтветственный = 0
        this.идВладелецРесурса = 0
      },
    },
  }
</script>
