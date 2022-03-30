<template lang="pug">
  v-app
    alert
    app-bar
    v-divider
    v-main
      //-- .ma-0.pa-1
      v-container(fluid)
        router-view(
          name="mainContent"
        )
    v-footer(
      v-if="включенРежимFakeUser || зашелАдмин"
    )
        ul
          li Фрагмент: id={{ this.$store.getters.получитьФрагмент.id }} | name='{{ this.$store.getters.получитьФрагмент.name }}' | code={{this.$store.getters.получитьФрагмент.code}}
          li Вы вошли в систему как: {{ получитьМодельПользователяСервиса.fio }} | логин: {{ получитьМодельПользователяСервиса.domainAccount }} | роли: {{ получитьМодельПользователяСервиса.roles }} || id: {{ получитьМодельПользователяСервиса.idUser }}
        //--
          ul Реальный пользователь: {{this.$store.getters.getRealUserModel.fio}} | логин: {{ this.$store.getters.getRealUserModel.domainAccount }} | роли: {{ this.$store.getters.getRealUserModel.roles }} || id: {{ this.$store.getters.getRealUserModel.idUser }}
          ul Последний пользователь: {{this.lastUserModel.fio}} | логин: {{ this.lastUserModel.domainAccount }} | роли: {{ this.lastUserModel.roles }} || id: {{ this.lastUserModel.idUser }}

</template>

<script>
  import Vue from 'vue'
  import { mapMutations, mapGetters } from 'vuex'

  import {
    getLastUserModel, включенРежимFakeUser, зашелАдмин,
    получитьАлерт,
    получитьМодельПользователяСервиса, получитьФрагмент,
  } from '@/store/getter-types'

  import Alert from '@/views/Alert'
  import AppBar from '@/views/AppBar/Index'

  import {
    СОХРАНИТЬ_МОДЕЛЬ_ТЕКУЩЕГО_ПОЛЬЗОВАТЕЛЯ_СЕРВИСА, СОХРАНИТЬ_РОЛИ_ПОЛЬЗОВАТЕЛЯ_СЕРВИСА,
    СОХРАНИТЬ_ФРАГМЕНТ,
  } from '@/store/mutation-types'
  import { CreateInstance, ПОЛУЧИТЬ_ВСЕ_СВОЙСТВА_ИЗ_ХРАНИЛИЩА_БРАУЗЕРА } from '@/store/action-types'

  export default Vue.extend({
    name: 'Application',
    components: { AppBar, Alert },
    props: {
      model: {
        type: Object,
        default: () => ({
          roles: ['<не определено>'],
          domainAccount: '<не определено>',
          fio: '<не определено>',
          fragment: {
            id: 0,
            name: 'Неизвестный фрагмент',
            fname: '',
            code: '',
          },
        }),
      },
    },

    data: () => ({
      // drawer: false,
    }),

    computed: {
      включенРежимFakeUser () {
        return this.$store.getters[включенРежимFakeUser]
      },

      зашелАдмин () {
        return this.$store.getters[зашелАдмин]
      },

      фрагмент () {
        return this.$store.getters[получитьФрагмент]
      },

      domainAccount () {
        return this.$store.getters[получитьМодельПользователяСервиса].domainAccount
      },
      ...mapGetters([
        получитьАлерт,
        получитьМодельПользователяСервиса,
      ]),

      lastUserModel () {
        return this.$store.getters[getLastUserModel]
      },
    },

    watch: {
      domainAccount (value) {
        if (value === undefined || value === null || value.length < 1) return
        this.createInstance(value)
      },
    },

    created () {
      // сохраняем модель пользователя сервиса
      // если не включен режим FakeUser,
      // а этот режим по умолчанию не включен,
      // когда запускается приложение
      if (this.$store.state.fakeUserState === false) {
        this.$store.commit(
          СОХРАНИТЬ_МОДЕЛЬ_ТЕКУЩЕГО_ПОЛЬЗОВАТЕЛЯ_СЕРВИСА,
          this.model,
        )

        this.$store.commit(
          СОХРАНИТЬ_ФРАГМЕНТ,
          this.model.fragment,
        )
      }
    },

    mounted () {
      console.log(`process.env.MODE_ENV: ${process.env.MODE_ENV}`)
      // инициализируем хранилище
      // this.$store.dispatch(InitLocaleForage)
    },

    methods: {
      ...mapMutations({
        saveUserRoles: СОХРАНИТЬ_РОЛИ_ПОЛЬЗОВАТЕЛЯ_СЕРВИСА,
      }),

      createInstance (value) {
        // меняем хранилище на хранилище текущего пользователя
        console.log(`изменился акк на: ${value}`)

        this.$store.dispatch(
          CreateInstance,
          value,
        )

        this.$store.dispatch(ПОЛУЧИТЬ_ВСЕ_СВОЙСТВА_ИЗ_ХРАНИЛИЩА_БРАУЗЕРА)
      },
    },
  })
</script>

<!--
<style lang="scss">
  #app {
    font-family: Avenir, Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #2c3e50;
  }

  #nav {
    padding: 30px;

    a {
      font-weight: bold;
      color: #2c3e50;

      &.router-link-exact-active {
        color: #42b983;
      }
    }
  }
</style>
-->
