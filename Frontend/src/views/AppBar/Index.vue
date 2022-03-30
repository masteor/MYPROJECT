<template lang="pug">
    v-app-bar(
      app
      color="primary"
      absolute
      elevation="10"
    )
      template
        drop-down-menu(
          v-if="менюОтчётовРазрешено && reportsMenuItems !== null"
          name="Отчёты"
          :items="reportsMenuItems"
        )

        drop-down-menu(
          v-if="менюСозданияЗаявокРазрешено && createRequestsMenuItems !== null"
          name="Создать заявку"
          :items="createRequestsMenuItems"
        )

        drop-down-menu(
          v-if="менюМоиЗаявкиРазрешено"
          name="Мои заявки"
          :items="myRequestsMenuItems"
        )

      template(
        v-if="менюИсполнителяРазрешено"
      )
        drop-down-menu(
          name="Исполнить"
          :items="executeMenuItems"
        )
        drop-down-menu(
          name="Справочники"
          :items="handBookItems"
        )

      v-spacer
      v-btn(
        text
        dark
        :href="this.$store.state.host"
      )
        h1 МОЙ ПРОЕКТ

      template
        v-icon(
          v-if="this.$store.state.алерты !== null && this.$store.state.алерты.length > 0"
          @click="alertList"
        ) mdi-alert-decagram-outline

        v-icon(
          @click="coolReloadPage"
        ) mdi-reload

        template(
          v-if="зашелАдмин || включенРежимFakeUser"
        )
          v-icon(
            @click="openSettings"
          ) mdi-cog-outline

          v-icon(
            @click="changeUser"
          ) mdi-account-cowboy-hat

          v-icon(
            v-if="выключенРежимFakeUser && this.$store.state.lastUserModel.domainAccount !== null"
            @click="setLastFakeUser"
          ) mdi-skull-outline
          v-icon.mdi-spin(
            v-else
            @click="exitFakeUser"
          ) mdi-skull-outline
</template>

<script>
/* eslint-disable camelcase */
  import { ReportsMenuItems } from '@/views/AppBar/js/ReportsMenuItems'
  import CreateRequestsMenuItems_ZLIVS from '@/views/AppBar/js/CreateRequestsMenuItems_ZLIVS'
  import CreateRequestsMenuItems_SILS from '@/views/AppBar/js/CreateRequestsMenuItems_SILS'
  import { ExecuteMenuItems } from '@/views/AppBar/js/ExecuteMenuItems'
  import { MyRequestsMenuItems } from '@/views/AppBar/js/MyRequestsMenuItems'
  import { HandBookItems } from '@/views/AppBar/js/HandBookItems'

  import DropDownMenu from '@/components/DropDownMenu'
  import * as _ from '@/allServiceRoles'

  import {
    AlertList,
    CoolReloadPage,
    FakeUser,
    Settings,
  } from '@/constants/path-names'

  import { SAVE_LAST_PAGE } from '@/store/mutation-types'

  import {
    ВКЛЮЧИТЬ_РЕЖИМ_FAKE_USER,
    ВЫКЛЮЧИТЬ_РЕЖИМ_FAKE_USER,
  } from '@/store/action-types'

  import { getLastUserModel, получитьРолиПользователяСервиса } from '@/store/getter-types'
  /* import { ВКЛЮЧИТЬ_РЕЖИМ_FAKE_USER } from '@/store/action-types' */

  import * as сеть from '@/constants/типыСетей'

  export default {
    name: 'AppBar',
    components: { DropDownMenu },

    /* props: {
      userRoles: {
        type: Array,
        default: () => [''],
      },
    }, */

    data: () => ({
      // reportsMenuItems: ReportsMenuItems,
      // createRequestsMenuItems: CreateRequestsMenuItems,
      myRequestsMenuItems: MyRequestsMenuItems,
      executeMenuItems: ExecuteMenuItems,
      handBookItems: HandBookItems,

      allServiceRoles: _.allServiceRoles,
    }),

    computed: {
      фрагмент () {
        return this.$store.state.фрагмент
      },

      reportsMenuItems () {
        const code = this.фрагмент?.code
        return code === сеть.zlivs
          ? ReportsMenuItems
          : null
      },

      createRequestsMenuItems () {
        const code = this.фрагмент?.code
        return code !== сеть.zlivs && code !== сеть.sils
          ? null
          : (
            code === сеть.zlivs
              ? CreateRequestsMenuItems_ZLIVS
              : CreateRequestsMenuItems_SILS
          )
      },

      userRoles () {
        return this.$store.getters[получитьРолиПользователяСервиса]
      },

      менюОтчётовРазрешено () {
        return this.userRoles.some(v => _.отчёты.some(w => w === v))
      },

      менюСозданияЗаявокРазрешено () {
        return this.userRoles.some(v => _.создатьЗаявки.some(w => w === v))
      },

      менюМоиЗаявкиРазрешено () {
        return this.userRoles.some(v => _.моиЗаявки.some(w => w === v))
      },

      менюИсполнителяРазрешено () {
        return this.userRoles.some(v => _.исполнители.some(w => w === v))
      },

      зашелАдмин () {
        return this.userRoles.some(v => _.Админы.some(w => w === v))
      },

      включенРежимFakeUser () {
        return this.$store.state.fakeUserState
      },

      выключенРежимFakeUser () {
        return !this.$store.state.fakeUserState
      },
    },

    methods: {
      changeUser () {
        // перенаправляемся на другой путь
        this.$router.push({ name: FakeUser, query: { ...this.$route.query, t: Date.now() } })
      },

      exitFakeUser () {
        this.$store.dispatch(ВЫКЛЮЧИТЬ_РЕЖИМ_FAKE_USER)
      },

      setLastFakeUser () {
        this.$store.dispatch(
          ВКЛЮЧИТЬ_РЕЖИМ_FAKE_USER,
          this.$store.getters[getLastUserModel],
        )
      },

      coolReloadPage () {
        // todo: доделать холодную перезагрузку страниц
        this.$store.commit(SAVE_LAST_PAGE, this.$router.currentRoute.name)
        this.$router.push({ name: CoolReloadPage })
      },

      openSettings () {
        // перенаправляемся на другой путь
        this.$router.push({ name: Settings, query: { ...this.$route.query, t: Date.now() } })
      },

      alertList () {
        this.$router.push({ name: AlertList, query: { ...this.$route.query, t: Date.now() } })
      },
    },
  }
</script>
