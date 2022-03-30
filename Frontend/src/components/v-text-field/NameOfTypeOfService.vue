<template lang="pug">
  //-- название типа сервиса
  v-text-field(
    type="text"
    label='Тип сервиса'
    dense
    color="primary"
    :value="value"
    required
    disabled
    :rules="[v => !!(v && v.length > 0) || '']"
  )
</template>

<script>
  export default {
    name: 'NameOfTypeOfService',

    props: {
      value: { type: null, default: null, required: true },
    },
  }
</script>
