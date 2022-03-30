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
  import { разрешительнаяСистемаДоступаКРесурсам2 as title } from '@/constants/titles'
  import { РАЗРЕШИТЕЛЬНАЯ_СИСТЕМА_ДОСТУПА_К_РЕСУРСАМ as Header } from '../../../store/header-types'
  import { ПАРАМЕТРЫ_ЗАПРОСА_НА_ДАТУ } from '@/store/param-types'
  import ReportTable from '@/components/v-data-table/ReportTable'
  import { vuexMixin } from './vuex-mixin'
  import { миксинОтчётНаДату } from '@/mixins/миксинОтчётНаДату'

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
        this.ПОЛУЧИТЬ_РАЗРЕШИТЕЛЬНАЯ_СИСТЕМА_ДОСТУПА_К_РЕСУРСАМ_С_СЕРВЕРА_ИЗ_ПРД(
          new ПАРАМЕТРЫ_ЗАПРОСА_НА_ДАТУ(this.датаОтчёта),
        )
        this.loading = false
      },
    },
  }
</script>
// @LABEL:VUE-COMPONENT@
