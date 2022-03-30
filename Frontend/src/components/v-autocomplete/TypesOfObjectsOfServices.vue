<template lang="pug">
  v-autocomplete(
    :loading="$loadingCondition(typesOfObjectsOfServices) && idTypeOfService > 0"
    :disabled="($disabledCondition(typesOfObjectsOfServices) && idTypeOfService < 1) || disabled"
    :items="$itemsCondition(typesOfObjectsOfServices)"
    :value="value"
    return-object
    label="Тип добавляемого объекта"
    placeholder="Выберите тип добавляемого объекта"
    item-text="name"
    item-value="id"
    color="primary"
    item-color="primary"
    clearable
    auto-select-first
    required
    :prepend-inner-icon="value === null ? '' : value.icon"
    :rules="[v => !!v || '']"
    @input="$emit('input', $event)"
  )
    //-- можно менять внешний вид элемента списка, например, можно добавить иконку
    template(v-slot:item="{item}")
      v-icon {{ item.icon }}
      span {{ item.name }}
</template>

<script>
  export default {
    name: 'TypesOfObjectsOfServices', // типы объектов сервисов
    props: {
      typesOfObjectsOfServices: { type: Array, default: null, required: true },
      idTypeOfService: { type: Number, default: null, required: true },
      value: { type: Object, default: () => null, required: false },
      disabled: { type: Boolean, default: false, required: false },
    },
  }
</script>
