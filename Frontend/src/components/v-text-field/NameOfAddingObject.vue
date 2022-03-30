<template lang="pug">
  //-- название добавляемого объекта
  v-text-field(
    type="text"
    label="Название добавляемого объекта"
    dense
    clearable
    counter
    color="primary"
    :value="value"
    :disabled="disabled"
    @input="$emit('input', $event)"
    autofocus
    placeholder="Введите название добавляемого объекта"
  )
  //-- :rules="[v => !!(v.length > 0) || '']"
</template>

<script>
  export default {
    name: 'NameOfAddingObject',
    props: {
      value: { type: String, default: '', required: true },
      disabled: { type: Boolean, default: false, required: false },
    },
  }
</script>
