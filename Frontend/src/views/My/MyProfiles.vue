<template lang="pug">
  div
    v-card.ma-auto
      v-card-title.headline {{ title }}
        v-spacer
        template
          v-icon.mdi-spin(
            v-if="loading"
            color="secondary"
          ) mdi-semantic-web
          v-icon(
            v-else-if="идПрофиля < 1"
          ) mdi-semantic-web
          v-icon(
            v-else
            color="primary"
          ) mdi-semantic-web
        v-autocomplete(
          :loading="loading"
          :disabled="$disabledCondition(items)"
          :items="$itemsCondition(items)"
          v-model="идПрофиля"
          :label="$disabledCondition(items) ? 'Профилей нет' : label"
          placeholder="Выберите профиль"
          item-text="profile_name"
          item-value="id"
          color="primary"
          item-color="primary"
          clearable
        )
      v-card-text
        v-text-field(
          type="text"
          label='Название фрагмента'
          dense
          color="primary"
          v-model="frag_name"
          disabled
        )
        v-text-field(
          type="text"
          label='Тип сервиса'
          dense
          color="primary"
          v-model="service_type_name"
          disabled
        )
        v-text-field(
          type="text"
          label='Тип ресурса'
          dense
          color="primary"
          v-model="object_type_name"
          disabled
        )
        v-text-field(
          type="text"
          label='Имя ресурса'
          dense
          color="primary"
          v-model="resource_name"
          disabled
        )
        v-text-field(
          type="text"
          label='Секретность ресурса'
          dense
          color="primary"
          v-model="secret_type_name"
          disabled
        )
        v-text-field(
          type="text"
          label='Имя профиля'
          dense
          color="primary"
          v-model="profile_name"
          disabled
        )

        v-row(
          dense
          v-for="(item, index) in _objects"
          :key="item"
        )
          v-col
            v-text-field(
              :value="item.object_name"
              type="text"
              label="Название объекта ресурса"
              dense
              disabled
              color="primary"
              autofocus
            )
          v-col
            v-text-field(
              :value="item.description"
              type="text"
              label="Право"
              dense
              disabled
              color="primary"
              autofocus
            )
          v-col
            v-text-field(
              :value="item.object_type_name"
              type="text"
              label="Тип объекта ресурса"
              dense
              disabled
              color="primary"
              autofocus
            )
</template>

<script>
  import { моиПрофили as title } from '@/constants/titles'
  import {
    ПАРАМЕТРЫ_ЗАПРОСА_ЗАВИСЯЩЕГО_ОТ_ФРАГМЕНТА,
  } from '@/store/param-types'

  import { ПОЛУЧИТЬ_ВСЕ_МОИ_ПРОФИЛИ /* ПОЛУЧИТЬ_ОБЪЕКТЫ_ПРОФИЛЯ */ } from '@/store/action-types'
  import RequestTable from '@/components/v-data-table/RequestTable'
  import { ОБЪЕКТЫ_ПРОФИЛЯ as Header } from '@/store/header-types'
  import { получитьИдФрагмента, получитьМоиПрофили } from '@/store/getter-types'

  export default {
    name: 'MyProfiles',

    components: { RequestTable },
    data: () => ({
      title: title,
      headers: [],
      label: 'Мои профили',
      loading: false,
      profileLoading: false,
      идПрофиля: 0,
      result: {
        _profile: {
          id_profile: '',
          object_type_name: '',
          frag_name: '',
          profile_name: '',
          resource_name: '',
          secret_type_name: '',
          service_type_name: '',
          _objects: [],
        },
      },
    }),

    computed: {
      items () {
        return this.$store.getters[получитьМоиПрофили]
      },

      domainAccount () {
        return this.$store.getters.domainAccount
      },

      frag_name () {
        return this.result._profile.frag_name
      },

      service_type_name () {
        return this.result._profile.service_type_name
      },

      object_type_name () {
        return this.result._profile.object_type_name
      },

      resource_name () {
        return this.result._profile.resource_name
      },

      profile_name () {
        return this.result._profile.profile_name
      },

      _objects () {
        return this.result._profile._objects
      },

      secret_type_name () {
        return this.result._profile.secret_type_name
      },
    },

    watch: {
      async идПрофиля (id) {
        this.result = this.items.find(v => v.id === id)
        /* if (id === null || id < 1 || this.profileLoading) return
        this.profileLoading = true
        // загружаем информацию по профилю из базы и отображаем
        this.result = await this.$store.dispatch(
          ПОЛУЧИТЬ_ОБЪЕКТЫ_ПРОФИЛЯ,
          new ПАРАМЕТРЫ_ЗАПРОСА_ПОЛУЧИТЬ_ОБЪЕКТЫ_ПРОФИЛЯ(
            id,
            this.domainAccount,
          ),
        )

        this.profileLoading = false */
      },
    },

    mounted () {
      this.получитьДанныеДляТаблицы()
      this.headers = new Header()
    },

    methods: {
      async получитьДанныеДляТаблицы () {
        const payload = new ПАРАМЕТРЫ_ЗАПРОСА_ЗАВИСЯЩЕГО_ОТ_ФРАГМЕНТА(
          this.$store.getters[получитьИдФрагмента],
          this.domainAccount,
        )

        this.loading = true
        await this.$store.dispatch(
          ПОЛУЧИТЬ_ВСЕ_МОИ_ПРОФИЛИ,
          payload,
        )

        this.loading = false
      },
    },
  }
</script>
