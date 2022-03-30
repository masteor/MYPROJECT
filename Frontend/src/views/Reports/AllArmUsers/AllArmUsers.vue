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
  import { переченьСубъектовДоступаДопущенныхКРаботеНаАрм as title } from '@/constants/titles'
  import { ПЕРЕЧЕНЬ_СУБЪЕКТОВ_ДОСТУПА_ДОПУЩЕННЫХ_К_РАБОТЕ_НА_АРМ as Header } from '@/store/header-types'
  import { ПАРАМЕТРЫ_ЗАПРОСА_НА_ДАТУ } from '@/store/param-types'
  import { миксинОтчётНаДату } from '@/mixins/миксинОтчётНаДату'
  import { vuexMixin } from './vuex-mixin'
  import ReportTable from '@/components/v-data-table/ReportTable'

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
        this.ПОЛУЧИТЬ_ПЕРЕЧЕНЬ_СУБЪЕКТОВ_ДОСТУПА_ДОПУЩЕННЫХ_К_РАБОТЕ_НА_АРМ_С_СЕРВЕРА(
          new ПАРАМЕТРЫ_ЗАПРОСА_НА_ДАТУ(this.датаОтчёта),
        )
        this.loading = false
      },
    },
  }
</script>
