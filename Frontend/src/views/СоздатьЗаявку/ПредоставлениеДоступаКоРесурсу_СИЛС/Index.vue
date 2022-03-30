<template lang="pug">
  div.d-inline-flex
    v-card
      v-card-title.headline {{ }}
      v-card-text
        resource-profile-tree(
          :items="treeFromArray"
          :loading="loading.tree"
          activatable
          @updateActive="updateActive($event[0])"
        )

    v-card
      v-card-title.headline {{ title }}
      v-divider
      v-card-text
        v-form(
          ref="form"
          v-model="valid"
        )
          v-text-field(
            type="text"
            label='Профиль'
            color="primary"
            :value="имяПрофиля"
            required
            disabled
            :rules="[v => !!(v && v.length > 0) || '']"
          )
          //--
              v-autocomplete(
                :loading="loading.profile"
                :disabled="$disabledCondition(получитьДействующиеПрофилиПользователя)"
                :items="$itemsCondition(получитьДействующиеПрофилиПользователя)"
                v-model="идПрофиля"
                label="Профиль"
                placeholder="Выберите профиль, к которому будет предоставлен доступ"
                item-text="profile_name"
                item-value="id"
                color="primary"
                item-color="primary"
                required
                :rules="[v => !!v || 'Выберите профиль, к которому будет предоставлен доступ']"
              )

          v-autocomplete(
            :loading="loading.employee"
            :disabled="$disabledCondition(получитьВсехСотрудников)"
            :items="$itemsCondition(получитьВсехСотрудников)"
            v-model="выбранныеСотрудники"
            label="Сотрудники"
            placeholder="Выберите сотрудника"
            item-text="fio_full_fname"
            item-value="id_user"
            color="primary"
            item-color="primary"
            multiple
            chips
            deletable-chips
            clearable
          )

          v-autocomplete(
            :loading="loading.org"
            :disabled="$disabledCondition(получитьОргЕдиницы)"
            :items="$itemsCondition(получитьОргЕдиницы)"
            v-model="выбранныеОргЕдиницы"
            label="Орг единицы"
            placeholder="Выберите орг единицу"
            item-text="name"
            item-value="id"
            color="primary"
            item-color="primary"
            multiple
            chips
            deletable-chips
            clearable
          )

      v-card-actions
        v-btn(
          :disabled="отправлятьНеРазрешено"
          color="primary"
          @click="CreateMember"
          shaped
          rounded
          :loading="loading.createMember"
        ) Предоставить доступ субъектам

        user-tools(
          @saveContent="saveContent"
          @clearContent="clearContent"
          @loadContent="loadContent"
          )

</template>

<script>
  // константы
  import { формаЗаявкиПредоставленияСубьектамДоступаКРесурсу } from '@/constants/titles'

  // методы
  import Methods, { ОбъектФормы } from './js/methods'

  // computed
  import Computed from './js/computed'

  // действия
  import {
    ПОЛУЧИТЬ_КЛЮЧ_ИЗ_ХРАНИЛИЩА_БРАУЗЕРА,
  } from '@/store/action-types'

  // компоненты
  import UserTools from '@/components/UserTools'
  import ResourceProfileTree from '@/components/v-treeview/ResourceProfileTree'
  import { деревоРесурсов } from '@/constants/localStorage_names'

  export default {
    name: 'CreateMember',

    components: { ResourceProfileTree, UserTools },

    mixins: [
      Methods,
      Computed,
    ],

    data: () => ({
      // ----------------------------------------------
      //  Сохраняемые свойства в хранилище браузера
      // ----------------------------------------------
      /** @type {ОбъектФормы} */
      v: new ОбъектФормы(),

      title: формаЗаявкиПредоставленияСубьектамДоступаКРесурсу,
      stopWatching: false,
      valid: false,

      treeItems: [],
      selected: null,
      active: [],

      loading: {
        profile: false,
        employee: false,
        org: false,
        createMember: false,
        tree: false,
      },
    }),

    async mounted () {
      // попробуем загрузить дерево ресурсов из хранилища браузера
      this.treeItems = await this.$store.dispatch(
        ПОЛУЧИТЬ_КЛЮЧ_ИЗ_ХРАНИЛИЩА_БРАУЗЕРА,
        деревоРесурсов,
      ) ?? []
    },

    created () {
      this.ПолучитьПрофили()

      this.ПолучитьФио()

      this.ПолучитьОрг()

      this.получитьСуществующиеРесурсы()
    },
  }
</script>
