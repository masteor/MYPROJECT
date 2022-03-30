<template lang="pug">
  div
    v-tooltip(bottom)
      template(v-slot:activator="{ on, attrs }")
        v-icon(
          color="primary"
          x-large
          @click="$emit('saveContent')"
          v-bind="attrs"
          v-on="on"
        ) mdi-content-save-outline
      span Сохранить форму

    v-tooltip(bottom)
      template(v-slot:activator="{ on, attrs }")
        v-icon(
          color="primary"
          x-large
          @click="$emit('clearContent')"
          v-bind="attrs"
          v-on="on"
        ) mdi-text-box-remove-outline
      span Очистить форму

    v-tooltip(bottom)
      template(v-slot:activator="{ on, attrs }")
        v-icon(
          color="primary"
          x-large
          @click="$emit('loadContent')"
          v-bind="attrs"
          v-on="on"
        ) mdi-archive-arrow-up-outline
      span Восстановить сохраненную форму
</template>

<script>
  export default {
    name: 'UserTools',
  }
</script>

<style scoped>

</style>
