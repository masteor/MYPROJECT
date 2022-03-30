<template lang="pug">
  div.d-inline-flex
    v-card
      v-card-title.headline {{ title }}
      v-divider
      v-card-text
        resource-profile-tree(
          :items="treeFromArray"
          :loading="loading"
          item-text="name"
          item-key="id"
          @updateActive="updateActive($event[0])"
          @updateOpen="updateOpen"
        )

    v-card(v-if="showEmployee")
      v-card-text
        span просто текст
</template>

<script>
  import { созданныеРесурсы as title } from '@/constants/titles'
  import { config } from '@/constants/treeConfig'
  import { CreatedResources } from '@/constants/path-names'
  import { ПОЛУЧИТЬ_ДЕРЕВО_СУЩЕСТВУЮЩИХ_РЕСУРСОВ } from '@/store/url-types'
  import * as _ from '@/constants/типыОбъектовДерева'

  import {
    domainAccount,
    получитьИдФрагмента,
  } from '@/store/getter-types'

  import { ПАРАМЕТРЫ_ЗАПРОСА_ЗАВИСЯЩЕГО_ОТ_ФРАГМЕНТА } from '@/store/param-types'
  import { arrayToTree } from 'performant-array-to-tree'
  import { СОХРАНИТЬ_ДЕРЕВО_РЕСУРСОВ } from '@/store/mutation-types'
  import { ПОЛУЧИТЬ_КЛЮЧ_ИЗ_ХРАНИЛИЩА_БРАУЗЕРА } from '@/store/action-types'
  import { деревоРесурсов } from '@/constants/localStorage_names'
  import ResourceProfileTree from '@/components/v-treeview/ResourceProfileTree'

  export default {
    name: CreatedResources,
    components: { ResourceProfileTree },
    data: () => ({
      title: title,
      ресурсы: [{}],
      value: null,
      event: null,
      showEmployee: false,
      loading: false,
    }),

    computed: {
      treeFromArray () {
        const result = arrayToTree(this.ресурсы, config)
        return result ?? []
      },
    },
    watch: {},

    async mounted () {
      this.ресурсы = await this.$store.dispatch(
        ПОЛУЧИТЬ_КЛЮЧ_ИЗ_ХРАНИЛИЩА_БРАУЗЕРА,
        деревоРесурсов,
      ) ?? [{}]

      await this.получитьСуществующиеРесурсы()
    },

    methods: {
      async получитьСуществующиеРесурсы () {
        this.loading = true

        const результат = await this.$get(
          ПОЛУЧИТЬ_ДЕРЕВО_СУЩЕСТВУЮЩИХ_РЕСУРСОВ,
          new ПАРАМЕТРЫ_ЗАПРОСА_ЗАВИСЯЩЕГО_ОТ_ФРАГМЕНТА(
            this.$store.getters[получитьИдФрагмента],
            this.$store.getters[domainAccount],
          ),
        )

        this.$store.commit(СОХРАНИТЬ_ДЕРЕВО_РЕСУРСОВ, результат)
        this.ресурсы = результат

        this.loading = false
      },

      updateActive (value) {
        this.event = value

        if (value.type === _.СОТРУДНИК) {
          this.showEmployee = true
          return
        }

        this.showEmployee = false
      },

      updateOpen () {
        this.event = null
        this.showEmployee = false
      },
    },
  }
</script>
