<template lang="pug">
  v-card
    v-card-text
      v-treeview(
        :activatable="!(typeOfObjectOfResource.code === DATABASE)"
        :hoverable="!(typeOfObjectOfResource.code === DATABASE)"
        :items="items"
        item-key="id"
        @update:active="active = $event[0] === undefined ? null : $event[0]"
      )
        template(v-slot:label="{item}")
          v-container
            v-row
              v-col(
                style="min-width: 100px; max-width: 100%"
              ).ma-0.pa-1
                //-- ставим иконку перед элементом дерева
                v-icon {{ item.ObjectType.icon }}
                //-- тип объекта
                span {{item.ObjectType.name}}
                //-- имя объекта
                span {{` [${item.ObjectName}]`}}
            v-row
              v-col(
                style="min-width: 100px; max-width: auto"
              ).ma-0.pa-1
                //-- выводим права
                v-autocomplete(
                  :items="$itemsCondition(showingRights)"
                  label="Права"
                  :value="item.RightDescriptions"
                  item-text="description"
                  item-value="id"
                  color="primary"
                  item-color="primary"
                  multiple
                  disabled
                  dense
                  small-chips
                )
                //-- span {{`item.id=${item.id} | leaf=${leaf} | ` + `indeterminate=${indeterminate} | ` + `active=${active} | ` + `open=${open}`}}
              v-col(
                style="max-width: 20px;"
              ).ma-0.pa-1
                //-- кнопка удаления объекта из профиля
                v-tooltip(
                  v-if="item.parent === null"
                  bottom
                )
                  template(v-slot:activator="{ on, attrs }")
                    v-icon(
                      @click="$emit('removeObject', item.id)"
                      v-bind="attrs"
                      v-on="on"
                    ) mdi-close
                  span Удалить, выделенный и все подчиненные, объекты

    //-- кнопки добавления объектов в профиль и для работы с деревом
    v-card-actions

      // если объекты еще не были добавлены, а первый объект должен быть ресурс
      // тогда отображаем кнопку добавления ресурса
      template(v-if="itemsLength < 1")
        v-btn(
          color="primary"
          :disabled="!valid"
          shaped
          rounded
          small
          @click="$emit('addObjectToProfile', null)"
        ) Добавить объект к профилю

      //-- кнопка для типов объектов БАЗА ДАННЫХ
      template(v-else-if="typeOfObjectOfResource !== null && typeOfObjectOfResource.code === DATABASE")
        v-btn(
          color="primary"
          :disabled="!valid"
          shaped
          rounded
          small
          @click="$emit('addObjectToProfile', {active: active, direction: 'child'})"
        ) Добавить объект к профилю

      //-- кнопка для типов объектов КАТАЛОГ
      template(v-else-if="typeOfObjectOfResource !== null && typeOfObjectOfResource.code === PARENTCATALOG")
        v-btn(
          color="primary"
          :disabled="!valid || !activated"
          shaped
          rounded
          small
          @click="$emit('addObjectToProfile', {active: active, direction: 'child'})"
        ) Добавить дочерний каталог

</template>

<script>
  import * as oti from '@/constants/object_type_icons'

  export default {
    name: 'ProfileTree',

    props: {
      items: { type: Array, default: null, required: true },
      showingRights: { type: Array, default: () => [], required: true },
      /** ТипОбъектаРесурса */ typeOfObjectOfResource: { type: Object, default: () => {}, required: true },
      valid: { type: Boolean, default: false, required: true },
    },

    data () {
      return {
        // eslint-disable-next-line vue/no-reserved-keys
        /* private */_active: null, // выделенный объект в дереве
      }
    },

    computed: {
      DATABASE () {
        return oti.DATABASE
      },

      PARENTCATALOG () {
        return oti.PARENTCATALOG
      },

      itemsLength () {
        return this.items?.length
      },

      activated () {
        return this.active !== null && this.active !== undefined
      },

      active: {
        // для ресурса БАЗА ДАННЫХ активный объект всегда будет сам ресурс, т.е. вложенность 1-го уровня
        get: function () { return this.typeOfObjectOfResource.code === this.DATABASE ? 1 : this._active },
        set: function (value) { this._active = value },
      },
    },
  }
</script>
