<template lang="pug">
  v-menu(
    top
    offset-y
  )
    template(
      v-slot:activator="{ on, attrs }"
    )
      v-btn(
        color="errors"
        dark
        rounded
        text
        v-bind="attrs"
        v-on="on"
      ) {{ name }}
    v-list(
      rounded
    )
      v-list-item(
        v-for="item in items"
        :key="item.title"
        :to="item.to"
      )
        v-list-item-content
          v-list-item-title {{ item.title }}
</template>

<script>
  export default {
    name: 'DropDownMenu',
    props: {
      name: {
        type: String,
        default: '',
      },
      items: {
        type: Array,
        default: () => [''],
      },
    },
  }
</script>
