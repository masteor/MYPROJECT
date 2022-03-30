// eslint-disable-next-line no-unused-vars
import { ТипОбъектовСервисов, ОБЪЕКТ_ПРОФИЛЯ } from '@/store/param-types'

export class ОбъектФормы {
  // выбранный объект в дереве
  active = null
  идТипаСервиса = 0

  имяПрофиля = ''
  названиеДобавляемогоОбъекта = ''
  праваПредоставляемыеПрофилем = []
  treeItems = []
  treeCounter = 0
  имяРесурса = ''

  /** @type {{}} */
  ДействующийОбъектРесурса = null

  /** @type {ТипОбъектовСервисов} */
  ТипОбъектаРесурса = null

  /** @type {ТипОбъектовСервисов} */
  ТипДобавляемогоОбъекта = null

  /** @type {ОБЪЕКТ_ПРОФИЛЯ[]} */
  объектыПрофиля = []
}

export default {
  computed: {
    // -------------------- ОбъектФормы -------------------------------------
    идТипаСервиса: {
      get: function () { return this.v?.идТипаСервиса },
      set: function (value) { this.v.идТипаСервиса = value },
    },

    ДействующийОбъектРесурса: {
      get: function () { return this.v?.ДействующийОбъектРесурса ?? null },
      set: function (value) { this.v.ДействующийОбъектРесурса = value },
    },

    идДействующегоОбъектаРесурса: {
      // eslint-disable-next-line camelcase
      get: function () { return this.v?.ДействующийОбъектРесурса?.id_object ?? null },
    },

    имяПрофиля: {
      get: function () { return this.v?.имяПрофиля },
      set: function (value) { this.v.имяПрофиля = value },
    },

    названиеДобавляемогоОбъекта: {
      get: function () { return this.v?.названиеДобавляемогоОбъекта },
      set: function (value) { this.v.названиеДобавляемогоОбъекта = value },
    },

    праваПредоставляемыеПрофилем: {
      get: function () { return this.v?.праваПредоставляемыеПрофилем },
      set: function (value) { this.v.праваПредоставляемыеПрофилем = [...value] },
    },

    treeItems: {
      get: /** @return {[]|null} */ function () { return this.v?.treeItems },
      set: function (value) { this.v.treeItems = value },
    },

    treeCounter: {
      get: function () { return this.v?.treeCounter },
      set: function (value) { this.v.treeCounter = value },
    },

    имяРесурса: {
      get: function () { return this.v?.ДействующийОбъектРесурса?.name ?? null },
      set: function (value) { this.v.имяРесурса = value },
    },

    /** @type {ТипОбъектовСервисов} */
    ТипОбъектаРесурса: {
      get: function () { return this.v?.ТипОбъектаРесурса },
      set: function (value) { this.v.ТипОбъектаРесурса = { ...value } },
    },

    /** @type {ТипОбъектовСервисов} */
    ТипДобавляемогоОбъекта: {
      get: function () { return this.v?.ТипДобавляемогоОбъекта },
      set: function (value) { this.v.ТипДобавляемогоОбъекта = { ...value } },
    },

    /** @type {ОБЪЕКТ_ПРОФИЛЯ[]} */
    объектыПрофиля: {
      get: function () { return this.v?.объектыПрофиля },
      set: function (value) { this.v.объектыПрофиля = [...value] },
    },

    active: {
      get: function () { return this.v?.active },
      set: function (value) { this.v.active = value },
    },
  },
}
