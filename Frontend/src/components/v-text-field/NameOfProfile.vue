<template lang="pug">
  //-- название профиля
  v-text-field(
    type="text"
    label='Название профиля'
    dense
    clearable
    counter
    color="primary"
    :value="value"
    @input="$emit('input', $event)"
    autofocus
    placeholder="Введите название профиля"
    required
    :rules="[v => !!(v && v.length > 0) || '']"
    @blur="$emit('blurProfile')"
  )
</template>

<script>
  export default {
    name: 'NameOfProfile',

    props: {
      value: { type: String, default: null, required: true },
    },
  }
</script>
