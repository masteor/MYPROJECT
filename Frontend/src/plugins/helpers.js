// различные методы-помощники, которые привязаны к this -
// легко и удобно можно доступиться из любого представления
import Vue from 'vue'

export default Vue.mixin({
  methods: {
    $loadingCondition (param) {
      return param === null
    },

    $disabledCondition (param) {
      return param?.length < 1
    },

    $existCondition (param) {
      return param?.length > 0
    },

    $itemsCondition (param) {
      return param === null ? [] : param
    },
  },
})
