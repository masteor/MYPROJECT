<template lang="pug">
  div
</template>

<script>
  export default {
    name: 'CoolReloadPage',

    beforeMount () {
      this.$router.push({ name: this.$store.state.lastPageName })
    },
  }
</script>
