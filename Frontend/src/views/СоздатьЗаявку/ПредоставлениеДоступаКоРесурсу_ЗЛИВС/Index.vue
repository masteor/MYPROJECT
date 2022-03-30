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
          :loading="$loadingCondition(получитьТипыСервисов)"
          :disabled="$disabledCondition(получитьТипыСервисов)"
          :items="$itemsCondition(получитьТипыСервисов)"
          label="Тип сервиса"
          placeholder="Выберите тип сервиса"
          item-text="name"
          item-value="id"
          color="primary"
          item-color="primary"
          v-model="идТипаСервиса"
          required
          clearable
          :rules="[v => !!v || '']"
        )

        v-autocomplete(
          :loading="$loadingCondition(получитьТипыОбъектов)"
          :disabled="$disabledCondition(получитьТипыОбъектов)"
          :items="$itemsCondition(получитьТипыОбъектов)"
          v-model="идТипаОбъекта"
          value="идТипаОбъекта"
          label="Тип ресурса"
          placeholder="Выберите тип ресурса"
          item-text="name"
          item-value="id"
          color="primary"
          item-color="primary"
          required
          clearable
          :rules="[v => !!v || '']"
        )

        v-autocomplete(
          :loading="$loadingCondition(получитьДействующиеРесурсы)"
          :disabled="$disabledCondition(получитьДействующиеРесурсы)"
          :items="$itemsCondition(получитьДействующиеРесурсы)"
          v-model="идОбъектаРесурса"
          placeholder="Выберите ресурс, к которому добавляется объект"
          item-text="name"
          item-value="id_object"
          color="primary"
          item-color="primary"
          required
          clearable
          :rules="[v => !!v || '']"
        )

        v-autocomplete(
          :loading="$loadingCondition(получитьДействующиеПрофилиПользователя)"
          :disabled="$disabledCondition(получитьДействующиеПрофилиПользователя)"
          :items="$itemsCondition(получитьДействующиеПрофилиПользователя)"
          v-model="идПрофиля"
          label="Профиль"
          placeholder="Выберите профиль, к которому будет предоставлен доступ"
          item-text="profile_name"
          item-value="id_profile"
          color="primary"
          item-color="primary"
          required
          clearable
          :rules="[v => !!v || 'Выберите профиль, к которому будет предоставлен доступ']"
        )

        v-autocomplete(
          :loading="$loadingCondition(получитьВсехСотрудников)"
          :disabled="$disabledCondition(получитьВсехСотрудников)"
          :items="$itemsCondition(получитьВсехСотрудников)"
          v-model="выбранныеСотрудники"
          label="Сотрудники"
          placeholder="Выберите сотрудника"
          item-text="fio_full"
          item-value="id_user"
          color="primary"
          item-color="primary"
          multiple
          chips
          clearable
          deletable-chips
        )

        v-autocomplete(
          :loading="$loadingCondition(получитьОргЕдиницы)"
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
          clearable
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
/* eslint-disable no-constant-condition */
  import { mapGetters } from 'vuex'

  import {
    получитьДействующиеПрофилиПользователя,
    получитьВсехСотрудников,
    получитьОргЕдиницы,
    получитьТипыСервисов,
    получитьТипыОбъектов,
    получитьДействующиеРесурсы, получитьЛогинПользователяСервиса,
  } from '@/store/getter-types'

  import {
    ПОЛУЧИТЬ_ДЕЙСТВУЮЩИЕ_И_НА_ЭТАПЕ_РЕГИСТРАЦИИ_РЕСУРСЫ_С_СЕРВЕРА, ПОЛУЧИТЬ_ОРГЕДИНИЦЫ_ДОПУЩЕННЫЕ_КО_РЕСУРСУ_ЗЛИВС,
    ПОЛУЧИТЬ_ПРОФИЛИ_ПРИВЯЗАННЫЕ_КО_РЕСУРСУ_С_СЕРВЕРА, ПОЛУЧИТЬ_СОТРУДНИКОВ_ДОПУЩЕННЫХ_КО_РЕСУРСУ_ЗЛИВС,
    ПОЛУЧИТЬ_ТИПЫ_ОБЪЕКТОВ_С_СЕРВЕРА,
    ПОЛУЧИТЬ_ТИПЫ_СЕРВИСОВ_С_СЕРВЕРА,
    СОЗДАТЬ_ДОСТУПЫ_СУБЪЕКТОВ_К_РЕСУРСАМ_НА_СЕРВЕРЕ,
    // ПОЛУЧИТЬ_ФИО_ВСЕХ_ДЕЙСТВУЮЩИХ_СОТРУДНИКОВ_С_СЕРВЕРА,
    // ПОЛУЧИТЬ_ОРГ_ЕДИНИЦЫ_С_СЕРВЕРА,
    // ПОЛУЧИТЬ_ДЕЙСТВУЮЩИЕ_ПРОФИЛИ_ПОЛЬЗОВАТЕЛЯ_С_СЕРВЕРА,
    /* СОЗДАТЬ_ДОСТУПЫ_СУБЪЕКТОВ_К_РЕСУРСАМ_НА_СЕРВЕРЕ,
    ПОЛУЧИТЬ_ТИПЫ_СЕРВИСОВ_С_СЕРВЕРА,
    ПОЛУЧИТЬ_ДЕЙСТВУЮЩИЕ_И_НА_ЭТАПЕ_РЕГИСТРАЦИИ_РЕСУРСЫ_С_СЕРВЕРА,
    ПОЛУЧИТЬ_ТИПЫ_ОБЪЕКТОВ_С_СЕРВЕРА, */
  } from '@/store/action-types'

  import {
    ПАРАМЕТРЫ_ЗАПРОСА_ДЕЙСТВУЮЩИЕ_РЕСУРСЫ, ПАРАМЕТРЫ_ЗАПРОСА_ПРОФИЛИ_ПРИВЯЗАННЫЕ_КО_РЕСУРСУ,
    ПАРАМЕТРЫ_ЗАПРОСА_СОЗДАТЬ_ДОСТУПЫ_СУБЪЕКТОВ_К_РЕСУРСАМ, ПАРАМЕТРЫ_ЗАПРОСА_ДОПУЩЕННЫЕ_КО_РЕСУРСУ_ЗЛИВС,
    ПАРАМЕТРЫ_ЗАПРОСА_ТИПОВ_ОБЪЕКТОВ, ДОПОЛНИТЕЛЬНЫЕ_ПАРАМЕТРЫ_ЗАЯВКИ,
  } from '@/store/param-types'

  import {
    формаЗаявкиПредоставленияСубьектамДоступаКРесурсуЗЛИВС,
  } from '@/constants/titles'
  import { Зарегистрирована } from '@/constants/идСтатусаЗаявки'

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
      loadingMemberLogins: false,
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

      идТипаОбъекта (id) {
        if (id < 1) { return }
        if (this.идТипаСервиса < 1) { return }
        // обнуляем список ресурсов
        // this.$store.commit(СОХРАНИТЬ_ДЕЙСТВУЮЩИЕ_РЕСУРСЫ, [])

        // this.loadingResources = true
        this.$store.dispatch(
          ПОЛУЧИТЬ_ДЕЙСТВУЮЩИЕ_И_НА_ЭТАПЕ_РЕГИСТРАЦИИ_РЕСУРСЫ_С_СЕРВЕРА,
          new ПАРАМЕТРЫ_ЗАПРОСА_ДЕЙСТВУЮЩИЕ_РЕСУРСЫ(
            this.идТипаСервиса,
            id,
            this.$store.getters.domainAccount, // 'ZLIVS\\kirillovanm', // ,
          ),
        )
        // this.loadingResources = false
      },

      // выбран ресурс из списка - подгружаем соответствующие ему профили
      идОбъектаРесурса (id) {
        if (id < 1) return

        this.$store.dispatch(
          ПОЛУЧИТЬ_ПРОФИЛИ_ПРИВЯЗАННЫЕ_КО_РЕСУРСУ_С_СЕРВЕРА,
          new ПАРАМЕТРЫ_ЗАПРОСА_ПРОФИЛИ_ПРИВЯЗАННЫЕ_КО_РЕСУРСУ(
            this.идОбъектаРесурса,
            this.$store.getters.domainAccount,
          ),
        )

        this.$store.dispatch(
          ПОЛУЧИТЬ_СОТРУДНИКОВ_ДОПУЩЕННЫХ_КО_РЕСУРСУ_ЗЛИВС,
          new ПАРАМЕТРЫ_ЗАПРОСА_ДОПУЩЕННЫЕ_КО_РЕСУРСУ_ЗЛИВС(
            this.идОбъектаРесурса,
            this.$store.getters.domainAccount,
          ),
        )

        this.$store.dispatch(
          ПОЛУЧИТЬ_ОРГЕДИНИЦЫ_ДОПУЩЕННЫЕ_КО_РЕСУРСУ_ЗЛИВС,
          new ПАРАМЕТРЫ_ЗАПРОСА_ДОПУЩЕННЫЕ_КО_РЕСУРСУ_ЗЛИВС(
            this.идОбъектаРесурса,
            this.$store.getters.domainAccount,
          ),
        )
      },
    },

    created () {
      this.ПолучитьТипыСервисовСоСервера()
    },

    methods: {
      CreateMember () {
        this.$store.dispatch(
          СОЗДАТЬ_ДОСТУПЫ_СУБЪЕКТОВ_К_РЕСУРСАМ_НА_СЕРВЕРЕ,
          new ПАРАМЕТРЫ_ЗАПРОСА_СОЗДАТЬ_ДОСТУПЫ_СУБЪЕКТОВ_К_РЕСУРСАМ(
            this.идПрофиля,
            this.выбранныеСотрудники,
            this.выбранныеОргЕдиницы,
            new ДОПОЛНИТЕЛЬНЫЕ_ПАРАМЕТРЫ_ЗАЯВКИ(
              null,
              null,
              this.$store.getters[получитьЛогинПользователяСервиса],
              this.$store.getters[получитьЛогинПользователяСервиса],
              Зарегистрирована,
              null,
              null,
            ),
          ),
        )
      },

      ПолучитьТипыСервисовСоСервера () {
        this.$store.dispatch(ПОЛУЧИТЬ_ТИПЫ_СЕРВИСОВ_С_СЕРВЕРА)
      },
    },
  }
</script>
