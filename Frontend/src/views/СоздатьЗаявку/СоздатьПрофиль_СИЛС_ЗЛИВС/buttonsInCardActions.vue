<template lang="pug">
  div
    template(v-if="typeOfObjectOfResource !== null && typeOfObjectOfResource.code === DATABASE")
      v-btn(
        color="primary"
        :disabled="!valid"
        shaped
        rounded
        small
        @click="$emit('addObjectToProfile')"
      ) Добавить объект к профилю

    template(v-else-if="typeOfObjectOfResource !== null && typeOfObjectOfResource.code === PARENTCATALOG")
      v-btn(
        color="primary"
        :disabled="!valid"
        shaped
        rounded
        small
        @click="$emit('addChildCatalog')"
      ) добавить дочерний

      v-btn(
        color="primary"
        :disabled="!valid"
        shaped
        rounded
        small
        @click="$emit('addParentCatalog')"
      ) добавить родительский

</template>

<script>
  import * as oti from '@/constants/object_type_icons'
  import UserTools from '@/components/UserTools'

  export default {
    name: 'ButtonsInCardActions',
    components: { UserTools },
    props: {
      /** ТипОбъектаРесурса */
      typeOfObjectOfResource: { type: null, default: null, required: true },
      valid: { type: Boolean, default: false, required: true },
    },

    created () {
      this.DATABASE = oti.DATABASE
      this.PARENTCATALOG = oti.PARENTCATALOG
    },
  }
</script>
