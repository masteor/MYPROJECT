<template lang="pug">
  v-card.mx-auto
    v-card-title.headline {{ title }}
    v-card-text
      table
        tr
          td
            date-picker(:date-picker.sync="датаОтчёта")
          td
            v-text-field(
              clearable
              prepend-inner-icon="mdi-table-search"
              v-model="строкаПоиска"
              label="Поиск"
              single-line
              hide-details
            )
          td
            v-btn-save-pdf(
              :title="title"
              :headers="headers"
              :filtered-items="filteredItems"
            )
      v-data-table(
        :headers="headers"
        :items="items"
        :loading="loading"
        loading-text="Ожидайте, данные загружаются"
        :search="строкаПоиска"
        height="auto"
        single-select
        selectable-key="id"
        show-select
        dense
        @click:row="clickRow"
        :footer-props="{showFirstLastPage: true}"
      )
</template>

<script>
  import VBtnSavePdf from '@/components/VBtnSavePdf/VBtnSavePdf'
  import DatePicker from '@/components/DatePicker'
  export default {
    name: 'ReportTable',
    components: { DatePicker, VBtnSavePdf },

    props: {
      title: {
        type: String,
        default: '',
      },

      headers: {
        type: Array,
        default: () => [],
      },

      items: {
        type: Array,
        default: () => [],
      },

      loading: {
        type: Boolean,
        default: () => [],
      },
    },

    data: () => ({
      датаОтчёта: '',
      строкаПоиска: '',
    }),

    computed: {
      filteredItems () {
        return this.items
      },
    },

    watch: {
      датаОтчёта (newValue) {
        this.$emit('update:date-picker', this.датаОтчёта)
      },
    },

    methods: {
      clickRow (value) {
        this.$emit('click:row', value)
      },
    },
  }
</script>
