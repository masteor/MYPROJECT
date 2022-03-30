<template lang="pug">
  div
    template(v-if="true")
      v-snackbar(
        :value="status"
        :color="color"
        text
        multi-line
        dismissible
        timeout=-1
        shaped
        transition="scale-transition"
        centered
        app
        outlined
      ) {{ message }}
        template(v-slot:action)
          v-icon(
            @click="removeAlert"
          ) mdi-close
</template>

<script>
  import { получитьАлерт } from '@/store/getter-types'
  import { СТЕРЕТЬ_АЛЕРТ } from '@/store/mutation-types'
  export default {
    name: 'Alert',
    snackbar: true,
    computed: {
      color () {
        return this.$store.getters[получитьАлерт]?.тип ?? ''
      },

      status () {
        return this.$store.getters[получитьАлерт]?.статус
      },

      message () {
        return this.$store.getters[получитьАлерт]?.сообщение ?? ''
      },
    },

    watch: {
      status (value) {
        console.log(`alert.status:${value}`)
      },
    },

    beforeCreate () {
      // todo: никак не мог убрать окно алерта при запуске приложения, пришлось сделать такой костыль
      // если убрать следующую строку, ты вы увидите это пустое окно алерта
      this.$store.commit(СТЕРЕТЬ_АЛЕРТ)
    },

    methods: {
      removeAlert () {
        this.$store.commit(СТЕРЕТЬ_АЛЕРТ)
      },
    },
  }
</script>
