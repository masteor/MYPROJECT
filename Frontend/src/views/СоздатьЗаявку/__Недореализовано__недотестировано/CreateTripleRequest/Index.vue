<template lang="pug">
  v-card.mx-auto
    v-card-title.headline {{ title }}
    v-divider
    v-card-text
      v-form(
        v-model="valid"
      )
        v-stepper(
          v-model="steppy"
        )
          v-stepper-header
            v-stepper-step(
              :complete="steppy > 1"
              step="1"
            ) Шаг1

            v-stepper-step(
              :complete="steppy > 2"
              step="2"
            ) Шаг2

            v-stepper-step(
              step="3"
            ) Шаг3

          v-stepper-items
            v-stepper-content(
              step="1"
            )
              create-resource

              v-btn(
                color="primary"
                @click="steppy = 2"
              ) След

            v-stepper-content(
              step="2"
            )
              create-profile-name(
                :profileId="profileId"
                :setProfileId="getProfileId"
              )

              add-profile-objects(
                :profileId="profileId"
              )

              v-btn(
                color="primary"
                @click="steppy = 1"
              ) Пред

              v-btn(
                color="primary"
                @click="steppy = 3"
              ) след

            v-stepper-content(
              step="3"
            )

              create-member

              v-btn(
                color="primary"
                @click="steppy = 1"
              ) Пред

</template>

<script>
  import {
    формаЗаявкиНаСозданиеРесурса,
    формаЗаявкиПредоставленияСубьектамДоступаКРесурсу,
    формаСозданияПрофиля,
    формаСозданияТройнойЗаявки,
  } from '@/constants/titles'

  import CreateProfileName from '@/views/СоздатьЗаявку/__Недореализовано__недотестировано/CreateProfileName/Index'
  import AddProfileObjects from '@/views/СоздатьЗаявку/СоздатьПрофиль_СИЛС_ЗЛИВС/Index'
  import CreateMember from '@/views/СоздатьЗаявку/ПредоставлениеДоступаКоРесурсу_СИЛС/Index'
  import CreateResource from '@/views/СоздатьЗаявку/СоздатьРесурс_СИЛС/Index'

  export default {
    name: 'CreateTripleRequest',
    components: { CreateResource, CreateMember, AddProfileObjects, CreateProfileName },
    data: () => ({
      profileId: 0,
      title: формаСозданияТройнойЗаявки,
      title1: формаЗаявкиНаСозданиеРесурса,
      title2: формаСозданияПрофиля,
      title3: формаЗаявкиПредоставленияСубьектамДоступаКРесурсу,
      valid: false,
      steppy: 1,
    }),

    methods: {
      getProfileId (value) {
        this.profileId = value
      },
    },
  }
</script>
