<template lang="pug">
  request-table(
    :title="title"
    :headers="headers"
    :items="items"
    :loading="loading"
  )
</template>

<script>
  import { РЕСУРСЫ_ГДЕ_ПОЛЬЗОВАТЕЛЬ_ОТВЕТСТВЕННЫЙ_ИЛИ_ВЛАДЕЛЕЦ as Header } from '@/store/header-types'
  import { яВладелецРесурса as title } from '@/constants/titles'
  import { ПАРАМЕТРЫ_ЗАПРОСА_НА_ДАТУ_И_ДОМЕННЫЙ_ЛОГИН } from '@/store/param-types'
  import {
    ПОЛУЧИТЬ_РЕСУРСЫ_ГДЕ_ПОЛЬЗОВАТЕЛЬ_ЯВЛСЯ_ВЛАДЕЛЬЦЕМ,
  } from '@/store/action-types'
  import RequestTable from '@/components/v-data-table/RequestTable'

  export default {
    name: 'IAmOwner',
    components: { RequestTable },
    data: () => ({
      headers: [],
      title: title,
      loading: false,
    }),

    computed: {
      items () {
        return this.$store.state.действующиеРесурсы
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
        const payload = new ПАРАМЕТРЫ_ЗАПРОСА_НА_ДАТУ_И_ДОМЕННЫЙ_ЛОГИН(
          null,
          this.$store.state.userModel.domainAccount,
        )

        await this.$store.dispatch(
          ПОЛУЧИТЬ_РЕСУРСЫ_ГДЕ_ПОЛЬЗОВАТЕЛЬ_ЯВЛСЯ_ВЛАДЕЛЬЦЕМ,
          payload,
        )

        this.loading = false
      },
    },
  }
</script>
