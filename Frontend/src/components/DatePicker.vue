<template lang="pug">
  v-menu(
    ref="menu"
    v-model="menu"
    :close-on-content-click="false"
    transition="scale-transition"
    offset-y
    min-width="290px"
  )
    template(
      v-slot:activator="{ on, attrs }"
    )
      v-text-field(
        v-model="датаОтчёта"
        label="Дата отчета"
        prepend-inner-icon="mdi-calendar"
        v-bind="attrs"
        v-on="on"
        clearable
      )

    v-date-picker(
      ref="picker"
      v-model="датаОтчёта"
      locale="ru"
      :max="this.текущаяДата"
      min="2010-01-01"
      @change="save"
    )
</template>

<script>
  import { mapGetters } from 'vuex'
  import { текущаяДата } from '@/store/getter-types'

  export default {
    name: 'DatePicker',

    props: {
      datePicker: {
        type: String,
        default: '',
      },
    },

    data: () => ({
      датаОтчёта: '',
      menu: false,
    }),

    computed: {
      ...mapGetters([
        текущаяДата,
      ]),
    },

    watch: {
      menu (val) {
        val && setTimeout(() => (this.$refs.picker.activePicker = 'YEAR'))
      },

      датаОтчёта (newValue) {
        this.$emit('update:date-picker', this.датаОтчёта)
        if (this.датаОтчёта === '') this.menu = false
      },
    },

    mounted () {
      this.датаОтчёта = this.datePicker
    },

    methods: {
      save (date) {
        // this.$emit('update:date-picker', this.датаОтчёта)
        this.датаОтчёта = date
        this.$refs.menu.save(this.датаОтчёта)
      },
    },

  }
</script>
