import { arrayToTree } from 'performant-array-to-tree'
import { config } from '@/constants/treeConfig'

export default {
  computed: {
    //= ===========================================================================
    // ОБЪЕКТЫ ФОРМЫ
    //= ===========================================================================
    имяПрофиля: {
      get: function () { return this.v?.имяПрофиля },
      set: function (value) { this.v.имяПрофиля = value },
    },

    идПрофиля: {
      get: function () { return this.v?.идПрофиля },
      set: function (value) { this.v.идПрофиля = value },
    },

    выбранныеСотрудники: {
      get: function () { return this.v?.выбранныеСотрудники },
      set: function (value) { this.v.выбранныеСотрудники = [...value] },
    },

    выбранныеОргЕдиницы: {
      get: function () { return this.v?.выбранныеОргЕдиницы },
      set: function (value) { this.v.выбранныеОргЕдиницы = [...value] },
    },

    //= =============================================================================
    // ГЕТТЕРЫ
    //= =============================================================================
    получитьДействующиеПрофилиПользователя () {
      return this.$store.getters.получитьДействующиеПрофилиПользователя
    },

    получитьВсехСотрудников () {
      return this.$store.getters.получитьВсехСотрудников
    },

    получитьОргЕдиницы () {
      return this.$store.getters.получитьОргЕдиницы
    },
    // ----------------------------------------------------------------------
    отправлятьНеРазрешено () {
      return !(this.valid && (this.выбранныеОргЕдиницыВыбраны || this.выбранныеСотрудникиВыбраны))
    },
    выбранныеОргЕдиницыВыбраны () {
      return this.выбранныеОргЕдиницы?.length > 0
    },
    выбранныеСотрудникиВыбраны () {
      return this.выбранныеСотрудники?.length > 0
    },

    // построитель дерева
    treeFromArray () {
      const result = arrayToTree(this.treeItems, config)
      return result ?? []
    },
  },
}
