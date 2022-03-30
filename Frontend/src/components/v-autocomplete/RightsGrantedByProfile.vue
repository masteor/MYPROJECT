<template lang="pug">
  v-autocomplete(
    :loading="$loadingCondition(rightsGrantedByProfile)"
    :disabled="$disabledCondition(rightsGrantedByProfile)"
    :items="$itemsCondition(rightsGrantedByProfile)"
    :value="value"
    label="Права, предоставляемые объекту, профилем"
    placeholder="Выберите права для объекта"
    item-text="description"
    item-value="id"
    color="primary"
    item-color="primary"
    multiple
    chips
    deletable-chips
    clearable
    @input="$emit('input', $event)"
  )
    //-- :rules="[v => !!(v.length) || '']"
    template(v-slot:prepend-item)
      v-btn(
        color="primary"
        shaped
        rounded
        x-small
        @click="$emit('selectDeselectRights')"
      ) Выбрать/убрать все
</template>

<script>
  export default {
    name: 'RightsGrantedByProfile', // праваПредоставляемыеПрофилем
    props: {
      rightsGrantedByProfile: { type: Array, default: null, required: true },
      value: { type: Array, default: null, required: true },
    },
  }
</script>

<style scoped>

</style>
