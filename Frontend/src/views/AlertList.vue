<template lang="pug">
  v-card.mx-auto
    v-card-text
      v-list
          v-list-item(
            v-for="item in this.$store.state.алерты"
            :key="item.id"
          )
            v-list-item-content {{`${item.datetime} | ${item.alert.сообщение}`}}
</template>

<script>
  export default {
    name: 'AlertList',

    data: () => ({
    }),
  }

</script>
