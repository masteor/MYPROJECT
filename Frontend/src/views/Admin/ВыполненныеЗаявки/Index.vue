<template lang="pug">
  request-table(
    :title="title"
    :headers="headers"
    :items="items"
    :loading="loading"
    :allowedExecute="true"
    showExpand
  )
</template>

<script>
  import {
    СПИСОК_ЗАЯВОК_БЕЗ_РАЗБИВКИ_ПО_ТИПАМ as Header,
  } from '@/store/header-types'

  import { миксинОтчётБезДаты } from '@/mixins/миксинОтчётБезДаты'
  import { выполненныеЗаявки as title } from '@/constants/titles'
  import { FinishedRequests } from '@/constants/path-names'

  import {
    ПОЛУЧИТЬ_ВЫПОЛНЕННЫЕ_ЗАЯВКИ,
  } from '@/store/action-types'

  import {
    ПАРАМЕТРЫ_ЗАПРОСА_ДОМЕННЫЙ_ЛОГИН,
  } from '@/store/param-types'

  import RequestTable from '@/components/v-data-table/RequestTable'

  export default {
    name: FinishedRequests,
    components: { RequestTable },
    mixins: [миксинОтчётБезДаты],

    data: () => ({
      singleExpand: true, // раскрываться будет только одна строка таблицы
      expanded: [],
      title: title,
      // overlooked: '',
      payload: '',
      сущность: [],
      loading: true,
      doc: '',
    }),

    computed: {
      items () {
        return this.$store.getters.получитьВыполненныеЗаявки
      },
    },

    created () {
      this.headers = new Header()
      this.getDataForTable()
    },

    methods: {
      async getDataForTable () {
        this.loading = true

        await this.$store.dispatch(
          ПОЛУЧИТЬ_ВЫПОЛНЕННЫЕ_ЗАЯВКИ,
          new ПАРАМЕТРЫ_ЗАПРОСА_ДОМЕННЫЙ_ЛОГИН(this.$store.getters.domainAccount),
        )

        this.loading = false
      },
    },
  }
</script>
