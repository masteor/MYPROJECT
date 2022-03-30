<template lang="pug">
  v-card.mx-auto
    v-card-title.headline {{ title }}
    v-divider
    v-card-text
      v-form(
        ref="form"
        v-model="valid"
      )
        v-autocomplete(
          :loading='this.получитьТипыСервисов.length < 1'
          :disabled='this.получитьТипыСервисов.length < 1'
          :items="this.получитьТипыСервисов"
          label="Тип сервиса"
          placeholder="Выберите тип сервиса"
          item-text="name"
          item-value="id"
          color="primary"
          item-color="primary"
          v-model="идТипаСервиса"
          required
          :rules="[v => !!v || '']"
        )

        v-autocomplete(
          :loading="this.получитьТипыОбъектов.length < 1 && идТипаСервиса > 0"
          :disabled="идТипаСервиса < 1"
          v-model="идТипаОбъекта"
          value="идТипаОбъекта"
          :items="this.получитьТипыОбъектов"
          label="Тип ресурса"
          placeholder="Выберите тип ресурса"
          item-text="name"
          item-value="id"
          color="primary"
          item-color="primary"
          required
          :rules="[v => !!v || '']"
        )

        v-autocomplete(
          :loading="loadingResources"
          :disabled="false"
          v-model="идОбъектаРесурса"
          :items="получитьДействующиеРесурсы"
          label="Ресурс, к которому добавляется объект"
          placeholder="Выберите ресурс, к которому добавляется объект"
          item-text="name"
          item-value="id_object"
          color="primary"
          item-color="primary"
          :rules="[v => !!v || '']"
          @focus="FocusEventResource"
        )

        v-autocomplete(
          :loading="loadingProfiles"
          :disabled="false"
          v-model="идПрофиля"
          :items="получитьДействующиеПрофилиПользователя"
          label="Профиль"
          placeholder="Выберите профиль, к которому будет предоставлен доступ"
          item-text="profile_name"
          item-value="id"
          color="primary"
          item-color="primary"
          required
          :rules="[v => !!v || 'Выберите профиль, к которому будет предоставлен доступ']"
          @focus="FocusEventProfile"
        )

        v-autocomplete(
          :loading="получитьВсехСотрудников.length < 1"
          :disabled="получитьВсехСотрудников.length < 1"
          v-model="выбранныеСотрудники"
          :items="получитьВсехСотрудников"
          label="Сотрудники"
          placeholder="Выберите сотрудника"
          item-text="fio_full"
          item-value="id_user"
          color="primary"
          item-color="primary"
          multiple
          chips
          deletable-chips
        )

        v-autocomplete(
          :loading="получитьОргЕдиницы.length < 1"
          :disabled="получитьОргЕдиницы.length < 1"
          v-model="выбранныеОргЕдиницы"
          :items="получитьОргЕдиницы"
          label="Орг единицы"
          placeholder="Выберите орг единицу"
          item-text="name"
          item-value="id"
          color="primary"
          item-color="primary"
          multiple
          chips
          deletable-chips
        )

    v-card-actions
      template(v-if="true")
        v-btn(
          :disabled="!valid"
          color="primary"
          shaped
          rounded
          @click="CreateMember"
        ) Добавить объект в профиль

</template>

<script>
  import { mapGetters } from 'vuex'

  import {
    получитьДействующиеПрофилиПользователя,
    получитьВсехСотрудников,
    получитьОргЕдиницы,
    получитьТипыСервисов,
    получитьТипыОбъектов,
    получитьДействующиеРесурсы,
  } from '@/store/getter-types'

  import {
    ПОЛУЧИТЬ_ДЕЙСТВУЮЩИЕ_ПРОФИЛИ_ПОЛЬЗОВАТЕЛЯ_С_СЕРВЕРА,
    ПОЛУЧИТЬ_ДЕЙСТВУЮЩИЕ_И_НА_ЭТАПЕ_РЕГИСТРАЦИИ_РЕСУРСЫ_С_СЕРВЕРА,
    ПОЛУЧИТЬ_ПРОФИЛИ_ПРИВЯЗАННЫЕ_КО_РЕСУРСУ_С_СЕРВЕРА, ПОЛУЧИТЬ_РЕСУРС_ПРИВЯЗАННЫЙ_КО_ПРОФИЛЮ_С_СЕРВЕРА,
    ПОЛУЧИТЬ_СОТРУДНИКОВ_ДОПУЩЕННЫХ_КО_РЕСУРСУ_ЗЛИВС,
    ПОЛУЧИТЬ_ТИПЫ_ОБЪЕКТОВ_С_СЕРВЕРА,
    ПОЛУЧИТЬ_ТИПЫ_СЕРВИСОВ_С_СЕРВЕРА,
    СОЗДАТЬ_ДОСТУПЫ_СУБЪЕКТОВ_К_РЕСУРСАМ_НА_СЕРВЕРЕ,
  } from '@/store/action-types'

  import {
    ПАРАМЕТРЫ_ЗАПРОСА_ДЕЙСТВУЮЩИЕ_РЕСУРСЫ,
    ПАРАМЕТРЫ_ЗАПРОСА_ДОМЕННЫЙ_ЛОГИН,
    ПАРАМЕТРЫ_ЗАПРОСА_ПРОФИЛИ_ПРИВЯЗАННЫЕ_КО_РЕСУРСУ,
    ПАРАМЕТРЫ_ЗАПРОСА_РЕСУРС_ПРИВЯЗАННЫЙ_КО_ПРОФИЛЮ,
    ПАРАМЕТРЫ_ЗАПРОСА_СОЗДАТЬ_ДОСТУПЫ_СУБЪЕКТОВ_К_РЕСУРСАМ,
    ПАРАМЕТРЫ_ЗАПРОСА_ДОПУЩЕННЫЕ_КО_РЕСУРСУ_ЗЛИВС,
    ПАРАМЕТРЫ_ЗАПРОСА_ТИПОВ_ОБЪЕКТОВ,
  } from '@/store/param-types'

  import {
    формаЗаявкиПредоставленияСубьектамДоступаКРесурсуЗЛИВС,
  } from '@/constants/titles'

  import {
    СОХРАНИТЬ_ВСЕХ_СОТРУДНИКОВ,
  } from '@/store/mutation-types'

  export default {
    name: 'CreateMemberZlivs',
    data: () => ({
      title: формаЗаявкиПредоставленияСубьектамДоступаКРесурсуЗЛИВС,
      valid: false,
      идПрофиля: 0,
      выбранныеСотрудники: 0,
      выбранныеОргЕдиницы: 0,
      идТипаСервиса: 0,
      идТипаОбъекта: 0,
      идОбъектаРесурса: 0,
      loadingResources: false,
      loadingProfiles: false,
    }),

    computed: {
      ...mapGetters([
        получитьДействующиеПрофилиПользователя,
        получитьВсехСотрудников,
        получитьОргЕдиницы,
        получитьТипыСервисов,
        получитьТипыОбъектов,
        получитьДействующиеРесурсы,
      ]),

    },

    watch: {
      идТипаСервиса (id) {
        if (id < 1) { return }
        this.идТипаОбъекта = 0
        this.$store.dispatch(
          ПОЛУЧИТЬ_ТИПЫ_ОБЪЕКТОВ_С_СЕРВЕРА,
          new ПАРАМЕТРЫ_ЗАПРОСА_ТИПОВ_ОБЪЕКТОВ(id, 1),
        )
      },

      async идТипаОбъекта (id) {
        if (id < 1) { return }
        if (this.идТипаСервиса < 1) { return }
        // обнуляем список ресурсов
        // this.$store.commit(СОХРАНИТЬ_ДЕЙСТВУЮЩИЕ_РЕСУРСЫ, [])

        this.loadingResources = true
        await this.$store.dispatch(
          ПОЛУЧИТЬ_ДЕЙСТВУЮЩИЕ_И_НА_ЭТАПЕ_РЕГИСТРАЦИИ_РЕСУРСЫ_С_СЕРВЕРА,
          new ПАРАМЕТРЫ_ЗАПРОСА_ДЕЙСТВУЮЩИЕ_РЕСУРСЫ(
            this.идТипаСервиса,
            id,
            this.$store.getters.domainAccount, // 'ZLIVS\\kirillovanm', // ,
          ),
        )
        this.loadingResources = false
      },

      // выбран ресурс из списка - подгружаем соответствующие ему профили
      идОбъектаРесурса (id) {
        if (id < 1) return

        this.GetProfiles()

        // обнуляем список сотрудников
        this.$store.commit(СОХРАНИТЬ_ВСЕХ_СОТРУДНИКОВ, [])

        this.$store.dispatch(
          ПОЛУЧИТЬ_СОТРУДНИКОВ_ДОПУЩЕННЫХ_КО_РЕСУРСУ_ЗЛИВС,
          new ПАРАМЕТРЫ_ЗАПРОСА_ДОПУЩЕННЫЕ_КО_РЕСУРСУ_ЗЛИВС(
            this.идОбъектаРесурса,
            this.$store.getters.domainAccount,
          ),
        )
      },

      идПрофиля (id) {
        // если элемент профиля удален, просто выходим
        if (id < 1) return
        //
        // если профиль выбран а ресурс не выбран - грузим соответствующий ресурс
        if (this.идОбъектаРесурса < 1) {

        } // загрузить ресурс связанный с выбранным профилем
      },
    },

    created () {
      // this.ПОЛУЧИТЬ_ФИО_ВСЕХ_ДЕЙСТВУЮЩИХ_СОТРУДНИКОВ_С_СЕРВЕРА()
      // this.ПОЛУЧИТЬ_ОРГ_ЕДИНИЦЫ_С_СЕРВЕРА()
      // this.$store.dispatch(ПОЛУЧИТЬ_ТИПЫ_СЕРВИСОВ_С_СЕРВЕРА)
    },

    methods: {
      CreateMember () {
        this.$store.dispatch(
          СОЗДАТЬ_ДОСТУПЫ_СУБЪЕКТОВ_К_РЕСУРСАМ_НА_СЕРВЕРЕ,
          new ПАРАМЕТРЫ_ЗАПРОСА_СОЗДАТЬ_ДОСТУПЫ_СУБЪЕКТОВ_К_РЕСУРСАМ(
            this.идПрофиля,
            this.выбранныеСотрудники,
            this.выбранныеОргЕдиницы,
          ),
        )
      },

      unused () {
        this.$store.dispatch(ПОЛУЧИТЬ_ТИПЫ_СЕРВИСОВ_С_СЕРВЕРА)
      },

      async GetProfiles (idResource) {
        this.loadingProfiles = true

        if (idResource > 0) {
          // если ресурс выбран - грузим для него соответствующий профиль

          console.log('ПОЛУЧИТЬ_ПРОФИЛИ_ПРИВЯЗАННЫЕ_КО_РЕСУРСУ_С_СЕРВЕРА,')

          await this.$store.dispatch(
            ПОЛУЧИТЬ_ПРОФИЛИ_ПРИВЯЗАННЫЕ_КО_РЕСУРСУ_С_СЕРВЕРА,
            new ПАРАМЕТРЫ_ЗАПРОСА_ПРОФИЛИ_ПРИВЯЗАННЫЕ_КО_РЕСУРСУ(
              idResource,
              this.$store.getters.domainAccount,
            ),
          )
        } else {
          // если ресурс не выбран - грузим все профили пользователя

          await this.$store.dispatch(
            ПОЛУЧИТЬ_ДЕЙСТВУЮЩИЕ_ПРОФИЛИ_ПОЛЬЗОВАТЕЛЯ_С_СЕРВЕРА,
            new ПАРАМЕТРЫ_ЗАПРОСА_ДОМЕННЫЙ_ЛОГИН(this.$store.getters.domainAccount),
          )
        }

        this.loadingProfiles = false
      },

      GetResources (idProfile) {
        this.loadingResources = true
        // 1. профиль уже выбран - загружаем для него ресурс,
        // для одного профиля возможен один ресурс
        // 2. профиль не выбран - грузим все ресурсы пользователя
        this.$store.dispatch(
          ПОЛУЧИТЬ_РЕСУРС_ПРИВЯЗАННЫЙ_КО_ПРОФИЛЮ_С_СЕРВЕРА,
          new ПАРАМЕТРЫ_ЗАПРОСА_РЕСУРС_ПРИВЯЗАННЫЙ_КО_ПРОФИЛЮ(
            idProfile,
            this.$store.getters.domainAccount,
          ),
        )
        this.loadingResources = false
      },

      // пользователь находится в фокусе списка профилей
      FocusEventProfile () {
        // если профили грузятся - выходим
        if (this.loadingProfiles) return

        // если профили не загружены - грузим
        if (this.получитьДействующиеПрофилиПользователя.length < 1) this.GetProfiles(null)
      },

      // пользователь находится в фокусе списка ресурсов
      FocusEventResource () {
        // если ресурсы грузятся - выходим
        if (this.loadingResources) return

        // если ресурсы не загружены - грузим
        if (this.получитьДействующиеРесурсы.length < 1) this.GetResources(null)
      },
    },

  }
</script>
