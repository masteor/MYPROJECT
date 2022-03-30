import { mapActions, mapGetters } from 'vuex'
import { получитьПереченьАрмВАс } from '@/store/getter-types'
import { ПОЛУЧИТЬ_ПЕРЕЧЕНЬ_АРМ_В_АС_С_СЕРВЕРА } from '@/store/action-types'

export const vuexMixin = {
  computed: {
    ...mapGetters([
      получитьПереченьАрмВАс,
    ]),

    items () {
      return this.получитьПереченьАрмВАс
    },
  },

  methods: {
    ...mapActions([
      ПОЛУЧИТЬ_ПЕРЕЧЕНЬ_АРМ_В_АС_С_СЕРВЕРА,
    ]),
  },
}
