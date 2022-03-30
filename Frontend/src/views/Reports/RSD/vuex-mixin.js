import { mapActions, mapGetters } from 'vuex'
import { получитьРазрешительнаяСистемаДоступаКРесурсам } from '@/store/getter-types'
import { ПОЛУЧИТЬ_РАЗРЕШИТЕЛЬНАЯ_СИСТЕМА_ДОСТУПА_К_РЕСУРСАМ_С_СЕРВЕРА } from '@/store/action-types'

export const vuexMixin = {
  computed: {
    ...mapGetters([
      получитьРазрешительнаяСистемаДоступаКРесурсам,
    ]),

    items () {
      return this.получитьРазрешительнаяСистемаДоступаКРесурсам
    },
  },

  methods: {
    ...mapActions([
      ПОЛУЧИТЬ_РАЗРЕШИТЕЛЬНАЯ_СИСТЕМА_ДОСТУПА_К_РЕСУРСАМ_С_СЕРВЕРА,
    ]),
  },
}
