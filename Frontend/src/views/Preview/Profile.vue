<template lang="pug">
  div
    v-text-field(
      type="text"
      label='Ид заявки'
      dense
      color="primary"
      v-model="model._profile.id_request_parent"
      disabled
    )
    v-text-field(
      type="text"
      label='Ид профиля'
      dense
      color="primary"
      v-model="model._profile.id_profile"
      disabled
    )
    v-text-field(
      type="text"
      label='Название фрагмента'
      dense
      color="primary"
      v-model="model._profile.frag_name"
      disabled
    )
    v-text-field(
      type="text"
      label='Тип сервиса'
      dense
      color="primary"
      v-model="model._profile.service_type_name"
      disabled
    )
    v-text-field(
      type="text"
      label='Тип ресурса'
      dense
      color="primary"
      v-model="model._profile.object_type_name"
      disabled
    )
    v-text-field(
      type="text"
      label='Имя ресурса'
      dense
      color="primary"
      v-model="model._profile.resource_name"
      disabled
    )
    v-text-field(
      type="text"
      label='Секретность ресурса'
      dense
      color="primary"
      v-model="model._profile.secret_type_name"
      disabled
    )
    v-text-field(
      type="text"
      label='Имя профиля'
      dense
      color="primary"
      v-model="model._profile.profile_name"
      disabled
    )

    v-row(
      dense
      v-for="(item, index) in model._profile._objects"
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
        )
      v-col
        v-text-field(
          :value="item.description"
          type="text"
          label="Право"
          dense
          disabled
          color="primary"
        )
      v-col
        v-text-field(
          :value="item.object_type_name"
          type="text"
          label="Тип объекта ресурса"
          dense
          disabled
          color="primary"
        )
</template>

<script>
  export default {
    name: 'PreviewProfile',
    props: {
      model: {
        type: Object,
        default: () => ({
          _profile: {
            id_request_parent: '',
            id_profile: '',
            object_type_name: '',
            frag_name: '',
            profile_name: '',
            resource_name: '',
            secret_type_name: '',
            service_type_name: '',
            _objects: [],
          },
        }),
        required: true,
      },
    },
  }
</script>
