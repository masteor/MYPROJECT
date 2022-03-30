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
  import { переченьРесурсовВАсPRD as title } from '@/constants/titles'
  import { ПЕРЕЧЕНЬ_РЕСУРСОВ_В_АС as Header } from '@/store/header-types'
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
      loading: false,
    }),

    mounted () {
      this.headers = new Header()
    },

    methods: {
      async получитьДанныеДляТаблицы () {
        this.loading = true
        const параметрызапросанадату = new ПАРАМЕТРЫ_ЗАПРОСА_НА_ДАТУ(this.датаОтчёта)
        await this.ПОЛУЧИТЬ_ПЕРЕЧЕНЬ_РЕСУРСОВ_В_АС_С_СЕРВЕРА_ИЗ_ПРД(параметрызапросанадату)
        this.loading = false
      },
    },
  }
</script>
