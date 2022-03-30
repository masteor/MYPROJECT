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
        v-autocomplete(
          :loading="получитьВсеФИО.length < 1"
          :disabled="получитьВсеФИО.length < 1"
          v-model="идВыбранногоФио"
          :items="получитьВсеФИО"
          label="Обновляемый пользователь"
          placeholder="Выберите пользователя"
          item-text="name"
          item-value="id"
          color="primary"
          item-color="primary"
          :rules="[v => !!v || 'Выберите пользователя']"
        )

        template(v-if="true")
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
          color='primary'
          shaped
          rounded
          @click="UpdateFio"
        ) Обновить ФИО пользователя
</template>

<script>
  import { mapActions, mapMutations, mapGetters } from 'vuex'

  import {
    получитьВсеФИО,
    получитьИмя,
    получитьОбъектФИО,
    получитьОтчество,
    получитьФамилию,
    текущаяДата,
  } from '@/store/getter-types'

  import { СОХРАНИТЬ_ИМЯ, СОХРАНИТЬ_ОТЧЕСТВО, СОХРАНИТЬ_ФАМИЛИЮ } from '@/store/mutation-types'
  import { ОБНОВИТЬ_ФИО_НА_СЕРВЕРЕ, ПОЛУЧИТЬ_ВСЕ_ФИО_С_СЕРВЕРА, ПОЛУЧИТЬ_ФИО_С_СЕРВЕРА } from '@/store/action-types'

  import {
    ПАРАМЕТРЫ_ЗАПРОСА_ОБНОВИТЬ_ФИО_НА_СЕРВЕРЕ,
  } from '@/store/param-types'
  import { формаОбновленияФиоПользователя } from '@/constants/titles'

  export default {
    name: 'FormUpdateFIO',
    data: () => ({
      title: формаОбновленияФиоПользователя,
      valid: false,
      идВыбранногоФио: 0,
    }),

    computed: {

      ...mapGetters(
        [
          получитьВсеФИО,
          получитьФамилию,
          получитьИмя,
          получитьОтчество,
          получитьОбъектФИО,
          текущаяДата,
        ]),

      fioGotten () {
        return this.идВыбранногоФио !== null
      },
      имя: {
        get () { return this.получитьИмя },
        set (value) { this.СОХРАНИТЬ_ИМЯ(value) },
      },
      отчество: {
        get () { return this.получитьОтчество },
        set (value) { this.СОХРАНИТЬ_ОТЧЕСТВО(value) },
      },

      фамилия: {
        get () { return this.получитьФамилию },
        set (value) { this.СОХРАНИТЬ_ФАМИЛИЮ(value) },
      },
    },

    watch: {
      идВыбранногоФио (newValue) {
        console.log(`идВыбранногоФио: ${newValue}`)
        this.ПОЛУЧИТЬ_ФИО_С_СЕРВЕРА(newValue)
      },
    },

    created () {
      this.ОчиститьПоляФормы()
      this.ПОЛУЧИТЬ_ВСЕ_ФИО_С_СЕРВЕРА()
    },

    methods: {
      UpdateFio () {
        this.ОБНОВИТЬ_ФИО_НА_СЕРВЕРЕ(
          new ПАРАМЕТРЫ_ЗАПРОСА_ОБНОВИТЬ_ФИО_НА_СЕРВЕРЕ(
            this.идВыбранногоФио,
            this.фамилия,
            this.имя,
            this.отчество,
            this.текущаяДата,
          ),
        ).then(value => {
          this.ПОЛУЧИТЬ_ВСЕ_ФИО_С_СЕРВЕРА()
        })
      },
      ...mapMutations(
        [
          СОХРАНИТЬ_ФАМИЛИЮ,
          СОХРАНИТЬ_ИМЯ,
          СОХРАНИТЬ_ОТЧЕСТВО,
        ]),

      ...mapActions(
        [
          ПОЛУЧИТЬ_ВСЕ_ФИО_С_СЕРВЕРА,
          ОБНОВИТЬ_ФИО_НА_СЕРВЕРЕ,
          ПОЛУЧИТЬ_ФИО_С_СЕРВЕРА,
        ]),

      ОчиститьПоляФормы () {
        this.фамилия = ''
        this.отчество = ''
        this.имя = ''
      },
    },
  }
</script>
