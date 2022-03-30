import {
  отфильтроватьПрофили, получитьдействующиеИНаЭтапеРегистрацииПрофили,
  получитьПраваПредоставляемыеПрофилем,
  получитьТипСервисаПоТипуОбъекту,
  получитьТипыОбъектовСервисов,
} from '@/store/getter-types'

import { arrayToTree } from 'performant-array-to-tree'
import { config } from '@/constants/treeConfig'
import * as oti from '@/constants/object_type_icons'

export default {
  computed: {
    DATABASE () {
      return oti.DATABASE
    },

    PARENTCATALOG () {
      return oti.PARENTCATALOG
    },

    // --------------------------------------------------------------------------------
    можноЛиДобавитьОбъектКоПрофилю () {
      return (
        this.названиеДобавляемогоОбъекта?.length > 0 &&
        this.праваПредоставляемыеПрофилем?.length > 0 &&
        this.ТипДобавляемогоОбъекта?.id > 0
      )
    },

    еслиНазначаемПраваНаРесурс () {
      return this.объектыПрофиля.length < 1
    },

    получитьТипыОбъектовСервисов () {
      return this.еслиНазначаемПраваНаРесурс

        ? this.$store.getters[получитьТипыОбъектовСервисов]
          .filter(v => v.id_service_type === this.идТипаСервиса && v.main_object === 1)

        : this.$store.getters[получитьТипыОбъектовСервисов]
          .filter(v => v.id_service_type === this.идТипаСервиса && v.main_object === 0)
    },

    /** @return {paramsTypes.ТипСервисов.название} */
    названиеТипаСервиса () {
      return this.$store.getters[получитьТипСервисаПоТипуОбъекту](
        this.идТипаОбъектаРесурса,
      )?.название ?? null
    },

    получитьПраваПредоставляемыеПрофилем () {
      return this.$store.getters[получитьПраваПредоставляемыеПрофилем]
    },

    отфильтрованныеПраваПредоставляемыеПрофилем () {
      const t = this.$store.getters[получитьПраваПредоставляемыеПрофилем]
      if (t?.length < 1 || this.идТипаСервиса < 1 || this.идТипДобавляемогоОбъекта < 1) return []

      console.log('отфильтрованныеПраваПредоставляемыеПрофилем')
      console.log(`this.идТипаСервиса: ${this.идТипаСервиса}`)
      console.log(`this.идТипДобавляемогоОбъекта: ${this.идТипДобавляемогоОбъекта}`)

      return t.filter(v =>
        v.id_service_type === this.идТипаСервиса &&
        v.id_object_type === this.идТипДобавляемогоОбъекта, /* && v.main_object === 0, */
      )
    },

    зарезервированныеИменаПрофилей () {
      return this.$store.getters[отфильтроватьПрофили](
        this.$store.getters[получитьдействующиеИНаЭтапеРегистрацииПрофили],
        this.получитьФрагмент?.id,
      )
    },

    profileExist () {
      return this.зарезервированныеИменаПрофилей.some(
        value => value.profile_name === this.имяПрофиля,
      )
    },

    идТипаОбъектаРесурса () {
      return this.ТипОбъектаРесурса === null ? 0 : this.ТипОбъектаРесурса?.id
    },

    идТипДобавляемогоОбъекта () {
      return this.ТипДобавляемогоОбъекта === null ? 0 : this.ТипДобавляемогоОбъекта?.id
    },

    treeFromArray () {
      return arrayToTree(this.объектыПрофиля, config)
    },
  },
}
