<template lang="pug">
  v-autocomplete(
    :loading="$loadingCondition(mainTypesOfObjects)"
    :disabled="$disabledCondition(mainTypesOfObjects)"
    :items="$itemsCondition(mainTypesOfObjects)"
    :value="value"
    return-object
    label="Тип ресурса"
    placeholder="Выберите тип ресурса"
    item-text="name"
    item-value="id"
    color="primary"
    item-color="primary"
    required
    disabled
    :prepend-inner-icon="value === null ? '' : value.icon"
    :rules="[v => !!v || '']"
    @input="$emit('input', $event)"
  )
</template>

<script>
  export default {
    name: 'MainTypesOfObjects', // -- главные типы объектов
    props: {
      mainTypesOfObjects: { type: Array, default: null, required: true },
      value: { type: null, default: null, required: true },
    },
  }
</script>
