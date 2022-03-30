<template lang="pug">
  div
    v-text-field(
      type="text"
      label='Поиск'
      outlined
      dense
      clearable
      color="blue"
      v-model="строкаПоиска"
      autofocus
    )
    v-progress-linear(
      v-if="loading"
      :size="20"
      :width="2"
      color="primary"
      indeterminate
    )
    v-treeview(
      :search="строкаПоиска"
      :activatable="activatable"
      :selectable="selectable"
      :selection-type="selectionType"
      :multiple-active="multipleActive"
      :active="active"
      return-object
      dense
      rounded
      :items="items"
      item-key="id"
      item-text="name"
      @update:active="$emit('updateActive', $event)"
      @update:open="$emit('updateOpen')"
    )
</template>

<script>
  export default {
    name: 'ResourceProfileTree',

    props: {
      loading: { type: Boolean, default: false, required: true },
      items: { type: Array, default: () => new Array([]), required: true },
      active: { type: Array, default: () => new Array([]), required: false },
      itemKey: { type: String, default: 'id', required: false },
      itemText: { type: String, default: 'name', required: false },
      activatable: { type: Boolean, default: false, required: false },
      selectable: { type: Boolean, default: false, required: false },
      selectionType: { type: String, default: 'leaf', required: false },
      multipleActive: { type: Boolean, default: false, required: false },
    },

    data () {
      return {
        строкаПоиска: '',
        openAll: false,
      }
    },
  }
</script>
