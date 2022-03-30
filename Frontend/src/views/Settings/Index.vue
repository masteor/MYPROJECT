<template lang="pug">
  v-card.mx-auto
    v-card-text
      template
        v-icon.mdi-spin(
          v-if="progressCircular"
          color="secondary"
        ) mdi-ninja
        v-icon(
          v-else
          color="primary"
        ) mdi-ninja

      v-autocomplete.mx-auto(
        :loading="$loadingCondition(получитьВсеФрагменты)"
        :disabled="$disabledCondition(получитьВсеФрагменты)"
        :items="$itemsCondition(получитьВсеФрагменты)"
        v-model="идФрагмента"
        label="Фрагменты"
        placeholder="Выберите фрагмент"
        item-text="fname"
        item-value="id"
        color="primary"
        item-color="primary"
        clearable
        :rules="[v => !!v || '']"
      )
</template>

<script>
  import {
    ПОЛУЧИТЬ_ВСЕ_ФРАГМЕНТЫ_С_СЕРВЕРА,
  } from '@/store/action-types'

  import { mapGetters } from 'vuex'

  import {
    получитьВсеФрагменты,
  } from '@/store/getter-types'
  import { СОХРАНИТЬ_ФРАГМЕНТ } from '@/store/mutation-types'

  export default {
    name: 'Settings',

    data: () => ({
      progressCircular: false,
      идФрагмента: null,
      фрагмент: null,
    }),

    computed: {
      ...mapGetters([
        получитьВсеФрагменты,
      ]),
    },

    watch: {
      идФрагмента (newValue) {
        this.фрагмент = this.получитьВсеФрагменты.find(v => v.id === newValue)

        this.$store.commit(
          СОХРАНИТЬ_ФРАГМЕНТ,
          this.фрагмент,
        )
      },
    },

    mounted () {
      // получаем фрагменты с сервера, чтобы выбрать тот, под которым хотим войти в систему
      this.$store.dispatch(ПОЛУЧИТЬ_ВСЕ_ФРАГМЕНТЫ_С_СЕРВЕРА)
    },
  }

</script>
