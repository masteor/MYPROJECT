<template lang="pug">
  div
    v-text-field(
      type="text"
      label='Ид главной заявки'
      dense
      color="primary"
      v-model="model._resource.id_request_1_parent"
      disabled
    )
    v-text-field(
      type="text"
      label='Ид заявки'
      dense
      color="primary"
      v-model="model._resource.id_request_1"
      disabled
    )
    v-text-field(
      type="text"
      label='Ид ресурса'
      dense
      color="primary"
      v-model="model._resource.id_resource"
      disabled
    )
    v-text-field(
      type="text"
      label='Название фрагмента'
      dense
      color="primary"
      v-model="model._resource.frag_name"
      disabled
    )
    v-text-field(
      type="text"
      label='Тип сервиса'
      dense
      color="primary"
      v-model="model._resource.service_type_name"
      disabled
    )
    v-text-field(
      type="text"
      label='Тип ресурса'
      dense
      color="primary"
      v-model="model._resource.object_type_name"
      disabled
    )
    v-text-field(
      type="text"
      label='Имя ресурса'
      dense
      color="primary"
      v-model="model._resource.resource_name"
      disabled
    )
    v-text-field(
      type="text"
      label='Секретность ресурса'
      dense
      color="primary"
      v-model="model._resource.secret_type_name"
      disabled
    )
    v-text-field(
      type="text"
      label='Путь'
      dense
      color="primary"
      v-model="model._resource.path"
      disabled
    )
    v-text-field(
      type="text"
      label='Описание'
      dense
      color="primary"
      v-model="model._resource.description"
      disabled
    )
    v-text-field(
      type="text"
      label='Владелец'
      dense
      color="primary"
      v-model="model._resource.owner"
      disabled
    )
    v-text-field(
      type="text"
      label='Ответственный'
      dense
      color="primary"
      v-model="model._resource.responsible"
      disabled
    )
    //-- выводим допущенных сотрудников
    v-text-field(
      value="Допущенные сотрудники:"
      type="text"
      dense
    )
    v-row(
      dense
      v-for="(item, index) in model._resource.resource_members"
      :key="item"
    )
        v-text-field(
          :value="item.name"
          type="text"
          dense
          disabled
          color="primary"
        )
    //-- выводим допущенные орг единицы
    v-text-field(
      value="Допущенные орг. единицы:"
      type="text"
      dense
    )

    v-row(
      dense
      v-for="(item, index) in model._resource.resource_orgs"
      :key="item"
    )

      v-col
        v-text-field(
          :value="item.name"
          type="text"
          label="Субъект допуска (орг.ед.)"
          dense
          disabled
          color="primary"
        )
</template>

<script>
  export default {
    name: 'PreviewResourceZlivs',
    props: {
      model: {
        type: Object,
        default: () => ({
          _resource: {
            id_request_1: '',
            id_request_1_parent: '',
            id_resource: '',
            resource_name: '',
            object_type_name: '',
            service_type_name: '',
            service_name: '',
            frag_name: '',
            secret_type_name: '',
            path: '',
            description: '',
            owner: '',
            responsible: '',

            resource_members: [],
            resource_orgs: [],
          },
        }),
        required: true,
      },
    },
  }
</script>
