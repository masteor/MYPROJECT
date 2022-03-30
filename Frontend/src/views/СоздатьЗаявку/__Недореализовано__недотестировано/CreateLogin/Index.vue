<template lang="pug">
  v-card.mx-auto
    v-card-title.headline {{ title }}
    v-divider
    v-card-text
      v-form(v-model="valid")
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
          :rules="[v => !!(v.length > 0) || 'Введите логин']"
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
          :rules="[v => !!(v.length >= 5) || 'Введите емайл в виде буквы@sils.local']"
        )

        v-autocomplete(
          :loading="this.получитьВсехСотрудников.length < 1"
          :disabled="this.получитьВсехСотрудников.length < 1"
          v-model="идСотрудника"
          :items="this.получитьВсехСотрудников"
          label="Сотрудник"
          placeholder="Выберите сотрудника"
          item-text="name"
          item-value="id"
          color="primary"
          item-color="primary"
          :rules="[v => !!v || 'Выберите сотрудника']"
        )

        v-autocomplete(
          :loading="this.получитьВсеФрагменты.length < 1"
          :disabled="this.получитьВсеФрагменты.length < 1"
          v-model="this.идФрагмента"
          :items="this.получитьВсеФрагменты"
          label="Фрагмент"
          placeholder="Выберите фрагмент"
          item-text="name"
          item-value="id"
          color="primary"
          item-color="primary"
          :rules="[v => !!v || 'Выберите фрагмент']"
        )

    v-card-actions
      v-btn(
        :disabled="!valid"
        color="primary"
        shaped
        rounded
        @click="CreateLogin"
      ) Создать логин

</template>

<script>
  import { mapActions, mapGetters } from 'vuex'
  import {
    ПОЛУЧИТЬ_ВСЕ_ФРАГМЕНТЫ_С_СЕРВЕРА,
    ПОЛУЧИТЬ_ФИО_ВСЕХ_ДЕЙСТВУЮЩИХ_СОТРУДНИКОВ_С_СЕРВЕРА,
    СОЗДАТЬ_ЛОГИН_ПОЛЬЗОВАТЕЛЯ_НА_СЕРВЕРЕ,
  } from '@/store/action-types'
  import { ПАРАМЕТРЫ_ЗАПРОСА_СОЗДАТЬ_ЛОГИН_ПОЛЬЗОВАТЕЛЯ } from '@/store/param-types'
  import { формаСозданияЛогинаПользователя } from '@/constants/titles'
  import { получитьВсеФрагменты, получитьВсехСотрудников, текущаяДата } from '@/store/getter-types'

  export default {
    name: 'CreateLogin',
    inheritAttrs: false,

    data: () => ({
      valid: false,
      title: формаСозданияЛогинаПользователя,
      выбранныйФрагмент: null,
      выбранныйСотрудник: null,
      емайл: '',
      имяЛогина: '',
      идСотрудника: 0,
      идФрагмента: 0,
      датаОтчёта: '',
    }),

    mounted () {
      this.датаОтчёта = this.текущаяДата
    },

    created: function () {
      this.ПОЛУЧИТЬ_ВСЕ_ФРАГМЕНТЫ_С_СЕРВЕРА()
      this.ПОЛУЧИТЬ_ФИО_ВСЕХ_ДЕЙСТВУЮЩИХ_СОТРУДНИКОВ_С_СЕРВЕРА()
      /* this.SetClearWarnMsgDebounceTime(5000) */
    },

    computed: {
      ...mapGetters([
        получитьВсеФрагменты,
        получитьВсехСотрудников,
        текущаяДата,
      ]),
    },

    methods: {
      CreateLogin () {
        this.СОЗДАТЬ_ЛОГИН_ПОЛЬЗОВАТЕЛЯ_НА_СЕРВЕРЕ(
          new ПАРАМЕТРЫ_ЗАПРОСА_СОЗДАТЬ_ЛОГИН_ПОЛЬЗОВАТЕЛЯ(
            this.имяЛогина,
            this.емайл,
            this.идСотрудника,
            this.идФрагмента,
            this.датаОтчёта,
          ))
      },

      ...mapActions([
        ПОЛУЧИТЬ_ВСЕ_ФРАГМЕНТЫ_С_СЕРВЕРА,
        ПОЛУЧИТЬ_ФИО_ВСЕХ_ДЕЙСТВУЮЩИХ_СОТРУДНИКОВ_С_СЕРВЕРА,
        СОЗДАТЬ_ЛОГИН_ПОЛЬЗОВАТЕЛЯ_НА_СЕРВЕРЕ,
      ]),
    },
  }
</script>
