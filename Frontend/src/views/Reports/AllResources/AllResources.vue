<template lang="pug">
  report-table(
    :title="title"
    :headers="headers"
    :items="items"
    :loading="loading"
    :date-picker.sync="датаОтчёта"
  )
</template>

<script>
  import {
    ПАРАМЕТРЫ_ЗАПРОСА_НА_ДАТУ,
  } from '@/store/param-types'

  import { ПЕРЕЧЕНЬ_РЕСУРСОВ_В_АС as Header } from '../../../store/header-types'
  import { переченьРесурсовВАс as title } from '@/constants/titles'
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
      title: title,
    }),

    mounted () {
      this.headers = new Header()
    },

    methods: {
      получитьДанныеДляТаблицы () {
        this.loading = true
        this.ПОЛУЧИТЬ_ПЕРЕЧЕНЬ_РЕСУРСОВ_В_АС_С_СЕРВЕРА(
          new ПАРАМЕТРЫ_ЗАПРОСА_НА_ДАТУ(this.датаОтчёта),
        )
        this.loading = false
      },
    },
  }
</script>
