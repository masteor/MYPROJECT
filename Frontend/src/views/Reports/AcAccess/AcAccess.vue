<template lang="pug">
  v-card
    report-table(
      :title="title"
      :headers="headers"
      :items="items"
      :loading="loading"
      :date-picker.sync="датаОтчёта"
      @click:row="clickRow"
    )

    v-overlay(
      :value="overlay"
      absolute="absolute"
    )
      v-card(
        light
        flat
        tile
      )
        v-card-title
          H1 Карточка пользователя
        v-card(
          light
          flat
          tile
        ).d-flex.flex-wrap
          v-card(
            v-for="n in this.получитьКарточкуСотрудника"
            :key="n"
            outlined
            tile
          ).pa-2
            h1 {{  }}
        v-card-actions
          v-progress-linear(
            striped
            :indeterminate="indeterminate"
          )
          v-btn(
            @click="overlay = !overlay"
            color="primary"
            rounded
          ) Закрыть
</template>

<script>
  import {
    ПАРАМЕТРЫ_ЗАПРОСА_НА_ДАТУ, ПАРАМЕТРЫ_ЗАПРОСА_ПОЛУЧИТЬ_КАРТОЧКУ_СОТРУДНИКА,
  } from '@/store/param-types'

  import {
    ПЕРЕЧЕНЬ_СУБЬЕКТОВ_ДОСТУПА_ДОПУЩЕННОГО_К_РАБОТЕ_В_АС as Header,
    КАРТОЧКА_СОТРУДНИКА,
  } from '@/store/header-types'
  import { переченьСубъектовДоступаДопущенногоКРаботеВАс as title } from '@/constants/titles'
  import { миксинОтчётНаДату } from '@/mixins/миксинОтчётНаДату'
  import ReportTable from '@/components/v-data-table/ReportTable'
  import { vuexMixin } from './vuex-mixin'

  export default {
    components: { ReportTable },
    mixins: [
      миксинОтчётНаДату,
      vuexMixin,
    ],

    data: () => ({
      indeterminate: true,
      title: title,
      payload: '',
      overlay: false,
      описаниеКарточкиСотрудника: [],
    }),

    watch: {
      payload (value) {
        this.получитьКарточкуСотрудникаСоСервера(value.tnum)
        this.overlay = true
      },
    },

    mounted () {
      this.headers = new Header()
      this.описаниеКарточкиСотрудника = new КАРТОЧКА_СОТРУДНИКА()
    },

    methods: {
      получитьДанныеДляТаблицы () {
        this.loading = true
        this.ПОЛУЧИТЬ_ПЕРЕЧЕНЬ_СУБЬЕКТОВ_ДОСТУПА_ДОПУЩЕННОГО_К_РАБОТЕ_В_АС_С_СЕРВЕРА(
          new ПАРАМЕТРЫ_ЗАПРОСА_НА_ДАТУ(this.датаОтчёта),
        )
        this.loading = false
      },

      получитьКарточкуСотрудникаСоСервера (tnum) {
        this.overlay = false
        this.ПОЛУЧИТЬ_КАРТОЧКУ_СОТРУДНИКА_С_СЕРВЕРА(
          new ПАРАМЕТРЫ_ЗАПРОСА_ПОЛУЧИТЬ_КАРТОЧКУ_СОТРУДНИКА(tnum),
        )
      },

      clickRow (value) {
        this.payload = value
      },
    },
  }
</script>

<style scoped lang="sass">
.overlay
  background-color: #00cae3
</style>
