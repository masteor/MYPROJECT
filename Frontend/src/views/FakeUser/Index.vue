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
          :loading="$loadingCondition(получитьВсехСотрудниковДляФейкЮзера)"
          :disabled="$disabledCondition(получитьВсехСотрудниковДляФейкЮзера)"
          :items="$itemsCondition(получитьВсехСотрудниковДляФейкЮзера)"
          v-model="логинСотрудника"
          label="Сотрудник"
          placeholder="Выберите сотрудника"
          item-text="fio_full_login"
          item-value="login_name"
          color="primary"
          item-color="primary"
          clearable
          :rules="[v => !!v || 'Выберите сотрудника']"
        )
</template>

<script>
  import {
    ПОЛУЧИТЬ_СОТРУДНИКОВ_ДЛЯ_ФЕЙК_ЮЗЕРА,
    ВКЛЮЧИТЬ_РЕЖИМ_FAKE_USER,
    ВЫКЛЮЧИТЬ_РЕЖИМ_FAKE_USER,
    ПОЛУЧИТЬ_МОДЕЛЬ_ПОЛЬЗОВАТЕЛЯ_СЕРВИСА_С_СЕРВЕРА,
  } from '@/store/action-types'

  import { mapGetters } from 'vuex'

  import {
    getRealUserModel,
    getTempUserModel,
    getUserModel,
    включенРежимFakeUser,
    получитьВсехСотрудниковДляФейкЮзера,
  } from '@/store/getter-types'

  export default {
    name: 'FakeUser',

    data: () => ({
      drawer: false,
      progressCircular: false,
      логинСотрудника: '',
    }),

    computed: {
      ...mapGetters([getTempUserModel, получитьВсехСотрудниковДляФейкЮзера]),
    },

    watch: {
      getTempUserModel (newValue) {
        // когда подгрузится с сервера модель пользователя,
        // заходим под ним в систему

        // если режим FakeUser включен - выключаем,
        if (this.$store.state.fakeUserState === true) {
          this.$store.dispatch(ВЫКЛЮЧИТЬ_РЕЖИМ_FAKE_USER)
        }

        // и включаем с новой моделью пользователя
        this.$store.dispatch(ВКЛЮЧИТЬ_РЕЖИМ_FAKE_USER, newValue)
        this.progressCircular = false
      },

      логинСотрудника (newValue) {
        // запрашиваем роли сотрудника и ждем выполнения запроса
        if (newValue === null || this.progressCircular) return
        this.progressCircular = true
        this.$store.dispatch(ПОЛУЧИТЬ_МОДЕЛЬ_ПОЛЬЗОВАТЕЛЯ_СЕРВИСА_С_СЕРВЕРА, {
          login: newValue,
          domainAccount: this.$store.getters[включенРежимFakeUser]
            ? this.$store.getters[getRealUserModel].domainAccount
            : this.$store.getters[getUserModel].domainAccount,
        })
      },
    },

    mounted () {
      // получаем логины сотрудников с сервера, чтобы выбрать того, под которым хотим войти в систему
      this.$store.dispatch(ПОЛУЧИТЬ_СОТРУДНИКОВ_ДЛЯ_ФЕЙК_ЮЗЕРА)
    },
  }

</script>
