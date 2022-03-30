<template lang="pug">
  v-autocomplete(
    :loading="$loadingCondition(existentResources)"
    :disabled="$disabledCondition(existentResources)"
    :items="$itemsCondition(existentResources)"
    :value="value"
    return-object
    label="Ресурс, к которому добавляется объект"
    placeholder="Выберите ресурс, к которому добавляется объект"
    item-text="name"
    item-value="id_object"
    color="primary"
    item-color="primary"
    clearable
    :prepend-inner-icon="value !== null ? value.icon : ''"
    :rules="[v => !!v || '']"
    @input="$emit('input', $event)"
  )
    template(v-slot:item="{item}")
      v-icon {{item.icon}}
      span {{item.name}}
</template>

<script>
  export default {
    name: 'ExistentResourcesOfUser', // действующие ресурсы пользователя
    props: {
      /** Действующие ресурсы */ existentResources: { type: Array, default: null, required: true },
                                 value: { type: null, default: null, required: true },
    },
  }
</script>
