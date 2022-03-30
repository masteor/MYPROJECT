<template lang="pug">
  v-card
    v-card-title.headline {{ title }}
    v-divider
    v-card-text
      v-form(
        ref="form"
        v-model="valid"
        :lazy-validation="lazy"
      )
        v-text-field(
          type="text"
          label='Название профиля'
          dense
          clearable
          counter
          color="primary"
          v-model="имяПрофиля"
          autofocus
          placeholder="Введите название профиля"
          :loading="loading1"
          required
          :rules="[v => !!(v && v.length > 0) || 'Введите название профиля']"
        )

    v-card-actions
      template(v-if="true")
        v-btn(
          :disabled="!valid"
          color="primary"
          shaped
          rounded
          @click="CreateProfileName"
        ) Создать имя профиля

</template>

<script>
  import { получитьИмяПрофиля } from '@/store/getter-types'
  import { mapActions, mapGetters, mapMutations } from 'vuex'
  import { СОХРАНИТЬ_ИМЯ_ПРОФИЛЯ } from '@/store/mutation-types'

  import {
    СОЗДАТЬ_ИМЯ_ПРОФИЛЯ_НА_СЕРВЕРЕ,
  } from '@/store/action-types'

  import { ПАРАМЕТРЫ_ЗАПРОСА_СОЗДАТЬ_ИМЯ_ПРОФИЛЯ } from '@/store/param-types'
  import { формаЗаявкиНаСозданиеИмениПрофиля } from '@/constants/titles'

  export default {
    name: 'CreateProfileName',
    props: {
      profileId: {
        default: 0,
        type: Number,
      },
      setProfileId: { type: Function },
    },
    data: () => ({
      title: формаЗаявкиНаСозданиеИмениПрофиля,
      loading1: false,
      valid: false,
    }),

    methods: {
      CreateProfileName () {
        this.loading1 = true

        this.СОЗДАТЬ_ИМЯ_ПРОФИЛЯ_НА_СЕРВЕРЕ(
          new ПАРАМЕТРЫ_ЗАПРОСА_СОЗДАТЬ_ИМЯ_ПРОФИЛЯ(this.получитьИмяПрофиля),
        ).then((value) => {
          this.setProfileId(value.model.profileId)
          console.log(value)
        })
          .finally((value) => {
            console.log(value)
            this.loading1 = false
          })

        console.log('end')
      },

      ...mapMutations([
        СОХРАНИТЬ_ИМЯ_ПРОФИЛЯ,
      ]),

      ...mapActions([
        СОЗДАТЬ_ИМЯ_ПРОФИЛЯ_НА_СЕРВЕРЕ,
      ]),

    },

    computed: {
      имяПрофиля: {
        get () {
          return this.получитьИмяПрофиля
        },
        set (value) {
          this.СОХРАНИТЬ_ИМЯ_ПРОФИЛЯ(value)
        },
      },

      ...mapGetters([
        получитьИмяПрофиля,
      ]),
    },
  }
</script>
