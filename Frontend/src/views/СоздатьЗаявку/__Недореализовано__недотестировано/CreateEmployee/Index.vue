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

        v-text-field(
          type="text"
          label='Табельный номер'
          outlined
          dense
          clearable
          counter
          color="blue"
          v-model="табельныйНомер"
          autofocus
          placeholder="5 или 6 знаков"
          :rules="[v => !!(v.length >= 5 && v.length <= 6) || 'Введите табельный номер']"
        )

        v-autocomplete(
          :loading="получитьДолжности.length < 1"
          :disabled="получитьДолжности.length < 1"
          v-model="идДолжности"
          :items="получитьДолжности"
          label="Должность"
          placeholder="Выберите должность"
          item-text="name"
          item-value="id"
          color="primary"
          item-color="primary"
          :rules="[v => !!v || 'Выберите должность']"
        )

        v-text-field(
          type="text"
          label='Имя логина'
          outlined
          dense
          clearable
          counter
          color="blue"
          v-model="имяЛогина"
          autofocus
          :rules="[v => !!(v.length > 0) || 'Введите имя логина']"
        )

        v-text-field(
          type="text"
          label='Емайл'
          outlined
          dense
          clearable
          counter
          color="blue"
          v-model="емайл"
          autofocus
          :rules="[v => !!(v.length > 0) || 'Введите емайл в виде буквы@sils.local']"
        )

        v-autocomplete(
          :loading="получитьФормуДопуска.length < 1"
          :disabled="получитьФормуДопуска.length < 1"
          v-model="идФормыДопуска"
          :items="получитьФормуДопуска"
          label="Форма допуска"
          placeholder="Выберите форму допуска"
          item-text="name"
          item-value="id"
          color="primary"
          item-color="primary"
          :rules="[v => !!v || 'Выберите форму допуска']"
        )

        v-text-field(
          type="text"
          label="Дата приёма на работу"
          outlined
          dense
          clearable
          counter
          color="blue"
          v-model="датаПриёмаНаРаботу"
          placeholder="ГГГГ-ММ-ДД"
          autofocus
          :rules="[v => !!(v.length > 0) || 'Введите дату приёма на работу']"
        )

        v-autocomplete(
          :loading="получитьВсеФрагменты.length < 1"
          :disabled="получитьВсеФрагменты.length < 1"
          v-model="идФрагмента"
          :items="получитьВсеФрагменты"
          label="Фрагмент"
          placeholder="Выберите фрагмент"
          item-text="name"
          item-value="id"
          color="primary"
          item-color="primary"
          :rules="[v => !!v || 'Выберите фрагмент']"
        )

    v-card-actions
      template(v-if="true")
        v-btn(
          :disabled="!valid"
          color="primary"
          shaped
          rounded
          @click="CreateEmployee"
        ) Создать пользователя
</template>

<script>
  import { формаСозданияПользователя } from '@/constants/titles'
  import {
    mapActions,
    mapGetters,
    mapMutations,
  } from 'vuex'

  import {
    получитьИмя,
    получитьОтчество,
    получитьТабельныйНомер,
    получитьФамилию,
    получитьДолжности,
    получитьФормуДопуска,
    получитьВсеФрагменты,
    текущаяДата,
  } from '@/store/getter-types'

  import {
    ПОЛУЧИТЬ_ДОЛЖНОСТИ_С_СЕРВЕРА,
    ПОЛУЧИТЬ_ФОРМУ_ДОПУСКА_С_СЕРВЕРА,
    СОЗДАТЬ_ПОЛЬЗОВАТЕЛЯ_НА_СЕРВЕРЕ,
    ПОЛУЧИТЬ_ВСЕ_ФРАГМЕНТЫ_С_СЕРВЕРА,
  } from '@/store/action-types'

  import {
    СОХРАНИТЬ_ИМЯ,
    СОХРАНИТЬ_ОТЧЕСТВО,
    СОХРАНИТЬ_ФАМИЛИЮ,
    СОХРАНИТЬ_ТАБЕЛЬНЫЙ_НОМЕР,
  } from '@/store/mutation-types'

  import { ПАРАМЕТРЫ_ЗАПРОСА_СОЗДАТЬ_ПОЛЬЗОВАТЕЛЯ } from '@/store/param-types'

  export default {
    name: 'CreateEmployee',

    data: () => ({
      title: формаСозданияПользователя,
      идДолжности: 0,
      идФормыДопуска: 0,
      headers: [],
      строкаПоиска: '',
      датаОтчёта: this.текущаяДата,
      датаПриёмаНаРаботу: '',
      valid: false,
      имяЛогина: '',
      емайл: '',
      идФрагмента: 0,
    }),

    computed: {
      ...mapGetters([
        получитьФамилию,
        получитьИмя,
        получитьОтчество,
        получитьТабельныйНомер,
        получитьДолжности,
        получитьФормуДопуска,
        получитьВсеФрагменты,
        текущаяДата,
      ]),

      фамилия: {
        get () { return this.получитьФамилию },
        set (value) { this.СОХРАНИТЬ_ФАМИЛИЮ(value) },
      },
      имя: {
        get () { return this.получитьИмя },
        set (value) { this.СОХРАНИТЬ_ИМЯ(value) },
      },
      отчество: {
        get () { return this.получитьОтчество },
        set (value) { this.СОХРАНИТЬ_ОТЧЕСТВО(value) },
      },
      табельныйНомер: {
        get () { return this.получитьТабельныйНомер.toString() },
        set (value) { this.СОХРАНИТЬ_ТАБЕЛЬНЫЙ_НОМЕР(parseInt(value)) },
      },
    },

    methods: {

      ОчиститьПоляФормы () {
        this.фамилия = ''
        this.отчество = ''
        this.имя = ''
        this.табельныйНомер = 0
      },

      CreateEmployee () {
        this.СОЗДАТЬ_ПОЛЬЗОВАТЕЛЯ_НА_СЕРВЕРЕ(
          new ПАРАМЕТРЫ_ЗАПРОСА_СОЗДАТЬ_ПОЛЬЗОВАТЕЛЯ(
            this.фамилия,
            this.имя,
            this.отчество,
            this.имяЛогина,
            this.емайл,
            this.идФрагмента,
            this.табельныйНомер,
            this.идДолжности,
            this.идФормыДопуска,
            this.датаПриёмаНаРаботу,
            this.датаОтчёта,
          ))
      },

      ...mapMutations([
        СОХРАНИТЬ_ФАМИЛИЮ,
        СОХРАНИТЬ_ИМЯ,
        СОХРАНИТЬ_ОТЧЕСТВО,
        СОХРАНИТЬ_ТАБЕЛЬНЫЙ_НОМЕР,
      ]),

      ...mapActions([
        ПОЛУЧИТЬ_ДОЛЖНОСТИ_С_СЕРВЕРА,
        ПОЛУЧИТЬ_ФОРМУ_ДОПУСКА_С_СЕРВЕРА,
        ПОЛУЧИТЬ_ВСЕ_ФРАГМЕНТЫ_С_СЕРВЕРА,
        СОЗДАТЬ_ПОЛЬЗОВАТЕЛЯ_НА_СЕРВЕРЕ,
      ]),
    },

    created () {
      this.ОчиститьПоляФормы()

      this.ПОЛУЧИТЬ_ВСЕ_ФРАГМЕНТЫ_С_СЕРВЕРА()
      this.ПОЛУЧИТЬ_ДОЛЖНОСТИ_С_СЕРВЕРА()
      this.ПОЛУЧИТЬ_ФОРМУ_ДОПУСКА_С_СЕРВЕРА()
    },
  }
</script>
