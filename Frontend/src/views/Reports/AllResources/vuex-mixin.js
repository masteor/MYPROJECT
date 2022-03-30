import { mapActions, mapGetters } from 'vuex'
import { получитьПереченьРесурсовВАс } from '@/store/getter-types'
import { ПОЛУЧИТЬ_ПЕРЕЧЕНЬ_РЕСУРСОВ_В_АС_С_СЕРВЕРА } from '@/store/action-types'

export const vuexMixin = {
  computed: {
    ...mapGetters([
      получитьПереченьРесурсовВАс,
    ]),

    items () {
      return this.получитьПереченьРесурсовВАс
    },
  },

  methods: {
    ...mapActions([
      ПОЛУЧИТЬ_ПЕРЕЧЕНЬ_РЕСУРСОВ_В_АС_С_СЕРВЕРА,
    ]),
  },
}
