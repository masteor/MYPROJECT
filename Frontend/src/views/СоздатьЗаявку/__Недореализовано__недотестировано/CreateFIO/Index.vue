<template lang="pug">
  v-card.mx-auto
    v-card-title.headline {{ title }}
    v-divider
    v-card-text
      v-form(
        ref="form"
        v-model="valid"
        :lazy-validation="lazy"
      )
        v-text-field(
          type="text"
          label='Фамилия'
          outlined
          dense
          clearable
          counter
          color="blue"
          v-model="фамилия"
          autofocus
          :rules="[v => !!(v.length > 0) || 'Введите фамилию']"
        )

        v-text-field(
          type="text"
          label='Имя'
          outlined
          dense
          clearable
          counter
          color="blue"
          v-model="имя"
          autofocus
          :rules="[v => !!(v.length > 0) || 'Введите имя']"
        )

        v-text-field(
          type="text"
          label='Отчество'
          outlined
          dense
          clearable
          counter
          color="blue"
          v-model="отчество"
          autofocus
          :rules="[v => !!(v.length > 0) || 'Введите отчество']"
        )

    v-card-actions
      template(v-if="true")
        v-btn(
          :disabled="!valid"
          color="primary"
          shaped
          rounded
          @click="CreateFIO"
        ) Создать ФИО пользователя
</template>

<script>
  import { mapActions, mapGetters, mapMutations } from 'vuex'

  import {
    СОХРАНИТЬ_ИМЯ,
    СОХРАНИТЬ_ОТЧЕСТВО,
    СОХРАНИТЬ_ФАМИЛИЮ,
  } from '@/store/mutation-types'

  import { СОЗДАТЬ_ФИО_ПОЛЬЗОВАТЕЛЯ_НА_СЕРВЕРЕ } from '@/store/action-types'

  import {
    получитьИмя, получитьЛогинПользователяСервиса,
    получитьОтчество,
    получитьФамилию,
    текущаяДата,
  } from '@/store/getter-types'

  import { ДОПОЛНИТЕЛЬНЫЕ_ПАРАМЕТРЫ_ЗАЯВКИ, ПАРАМЕТРЫ_ЗАПРОСА_СОЗДАТЬ_ФИО_НА_СЕРВЕРЕ } from '@/store/param-types'
  import { формаСозданияФиоПользователя } from '@/constants/titles'
  import { Зарегистрирована } from '@/constants/идСтатусаЗаявки'

  export default {
    name: 'CreateFIO',

    data: () => ({
      valid: false,
      title: формаСозданияФиоПользователя,
      параметрыЗапроса: {},
    }),

    computed: {
      имя: {
        get () { return this.получитьИмя },
        set (value) { this.СОХРАНИТЬ_ИМЯ(value) },
      },
      отчество: {
        get () { return this.получитьОтчество },
        set (value) { this.СОХРАНИТЬ_ОТЧЕСТВО(value) },
      },
      ...mapGetters([
        получитьФамилию,
        получитьИмя,
        получитьОтчество,
        текущаяДата,
      ]),

      фамилия: {
        get () { return this.получитьФамилию },
        set (value) { this.СОХРАНИТЬ_ФАМИЛИЮ(value) },
      },
    },

    methods: {
      ...mapMutations([
        СОХРАНИТЬ_ФАМИЛИЮ,
        СОХРАНИТЬ_ИМЯ,
        СОХРАНИТЬ_ОТЧЕСТВО,
      ]),

      ...mapActions([
        СОЗДАТЬ_ФИО_ПОЛЬЗОВАТЕЛЯ_НА_СЕРВЕРЕ,
      ]),

      CreateFIO () {
        const m = new ПАРАМЕТРЫ_ЗАПРОСА_СОЗДАТЬ_ФИО_НА_СЕРВЕРЕ(
          this.фамилия,
          this.имя,
          this.отчество,
          new ДОПОЛНИТЕЛЬНЫЕ_ПАРАМЕТРЫ_ЗАЯВКИ(
            null,
            null,
            this.$store.getters[получитьЛогинПользователяСервиса],
            this.$store.getters[получитьЛогинПользователяСервиса],
            Зарегистрирована,
            null,
            null,
          ),
        )

        this.параметрыЗапроса = m
        this.СОЗДАТЬ_ФИО_ПОЛЬЗОВАТЕЛЯ_НА_СЕРВЕРЕ(m)
      },

      ОчиститьПоляФормы () {
        this.фамилия = ''
        this.отчество = ''
        this.имя = ''
      },
    },

    created () {
      this.ОчиститьПоляФормы()
    },

  }
</script>
