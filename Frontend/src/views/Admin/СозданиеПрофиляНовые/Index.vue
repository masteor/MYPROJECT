<template lang="pug">
  request-table(
    :title="title"
    :headers="headers"
    :items="items"
    :loading="loading"
    :allowedExecute="true"
    @delete-item-with-id="deleteItemWithId"
    :itemKey="headers[0].value"
    :showExpand="true"
  )
</template>

<script>
  import {
    СПИСОК_ЗАЯВОК_БЕЗ_РАЗБИВКИ_ПО_ТИПАМ as Header,
  } from '@/store/header-types'
  import { миксинОтчётБезДаты } from '@/mixins/миксинОтчётБезДаты'
  import { заявкиНаСозданиеПрофиляНовые } from '@/constants/titles'

  import {
    ПОЛУЧИТЬ_ОЧЕРЕДЬ_ЗАЯВОК_НА_ОБРАБОТКУ,
  } from '@/store/action-types'

  import {
    ПАРАМЕТРЫ_ЗАПРОСА_ДОМЕННЫЙ_ЛОГИН,
  } from '@/store/param-types'

  import RequestTable from '@/components/v-data-table/RequestTable'
  import { УДАЛИТЬ_ЭЛЕМЕНТ_ИЗ_ОЧЕРЕДИ_ЗАЯВОК_НА_ОБРАБОТКУ } from '@/store/mutation-types'
  import { RequestCreatedProfileNew } from '@/constants/path-names'

  export default {
    name: RequestCreatedProfileNew,
    components: { RequestTable },
    mixins: [миксинОтчётБезДаты],

    data: () => ({
      singleExpand: true, // раскрываться будет только одна строка таблицы
      expanded: [],
      title: заявкиНаСозданиеПрофиляНовые,
      // overlooked: '',
      payload: '',
      сущность: [],
      loading: true,
      doc: '',
    }),

    computed: {
      items () {
        return this.$store.getters.получитьОчередьЗаявокНаОбработку
      },
    },

    created () {
      this.headers = new Header()
      this.getDataForTable()
    },

    methods: {
      deleteItemWithId (idRequest) {
        if (idRequest < 1) return
        // передаем в мутацию массив, первый элемент -
        this.$store.commit(
          УДАЛИТЬ_ЭЛЕМЕНТ_ИЗ_ОЧЕРЕДИ_ЗАЯВОК_НА_ОБРАБОТКУ,
          (items) => {
            const findIndex = items.findIndex((i) => i.id_request === idRequest)
            if (findIndex > -1) {
              items.splice(findIndex, 1)
            } else {
              console.log(`deleteItemWithId() item с idRequest=${idRequest} не найден`)
            }
          },
        )
      },

      async getDataForTable () {
        console.log('getDataForTable ()')
        this.loading = true

        await this.$store.dispatch(
          ПОЛУЧИТЬ_ОЧЕРЕДЬ_ЗАЯВОК_НА_ОБРАБОТКУ,
          new ПАРАМЕТРЫ_ЗАПРОСА_ДОМЕННЫЙ_ЛОГИН(this.$store.getters.domainAccount),
        )

        this.loading = false
      },
    },
  }
</script>
