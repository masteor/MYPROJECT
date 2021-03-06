import { mapActions, mapGetters } from 'vuex'
import { получитьПереченьРесурсовККоторымПредоставленДоступСубъектам } from '@/store/getter-types'
import { ПОЛУЧИТЬ_ПЕРЕЧЕНЬ_РЕСУРСОВ_К_КОТОРЫМ_ПРЕДОСТАВЛЕН_ДОСТУП_СУБЪЕКТАМ_С_СЕРВЕРА } from '@/store/action-types'

export const vuexMixin = {
  computed: {
    ...mapGetters([
      получитьПереченьРесурсовККоторымПредоставленДоступСубъектам,
    ]),

    items () {
      return this.получитьПереченьРесурсовККоторымПредоставленДоступСубъектам
    },
  },

  methods: {
    ...mapActions([
      ПОЛУЧИТЬ_ПЕРЕЧЕНЬ_РЕСУРСОВ_К_КОТОРЫМ_ПРЕДОСТАВЛЕН_ДОСТУП_СУБЪЕКТАМ_С_СЕРВЕРА,
    ]),
  },
}
