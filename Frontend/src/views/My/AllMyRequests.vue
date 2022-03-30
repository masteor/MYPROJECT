<template lang="pug">
  request-table(
    :title="title"
    :headers="headers"
    :items="items"
    :loading="loading"
    :itemKey="headers[0].value"
    showExpand
  )
</template>

<script>
  import { СПИСОК_ЗАЯВОК_БЕЗ_РАЗБИВКИ_ПО_ТИПАМ as Header } from '@/store/header-types'
  import { всеМоиЗаявки as title } from '@/constants/titles'
  import { ПАРАМЕТРЫ_ЗАПРОСА_ДОМЕННЫЙ_ЛОГИН } from '@/store/param-types'
  import { ПОЛУЧИТЬ_ВСЕ_МОИ_ЗАЯВКИ } from '@/store/action-types'
  import RequestTable from '@/components/v-data-table/RequestTable'

  export default {
    name: 'AllMyRequests',
    components: { RequestTable },
    data: () => ({
      headers: [],
      title: title,
      loading: false,
    }),

    computed: {
      items () {
        return this.$store.state.заявки
      },
    },

    mounted () {
      this.headers = new Header()
    },

    created () {
      this.получитьДанныеДляТаблицы()
    },

    methods: {
      async получитьДанныеДляТаблицы () {
        this.loading = true
        const payload = new ПАРАМЕТРЫ_ЗАПРОСА_ДОМЕННЫЙ_ЛОГИН(this.$store.state.userModel.domainAccount)

        await this.$store.dispatch(
          ПОЛУЧИТЬ_ВСЕ_МОИ_ЗАЯВКИ,
          payload,
        )

        this.loading = false
      },
    },
  }
</script>
