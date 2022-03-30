import { mapActions, mapGetters } from 'vuex'
import { получитьПереченьСубъектовДоступаДопущенныхКРаботеНаАрм } from '@/store/getter-types'
import { ПОЛУЧИТЬ_ПЕРЕЧЕНЬ_СУБЪЕКТОВ_ДОСТУПА_ДОПУЩЕННЫХ_К_РАБОТЕ_НА_АРМ_С_СЕРВЕРА } from '@/store/action-types'

export const vuexMixin = {
  computed: {
    ...mapGetters([
      получитьПереченьСубъектовДоступаДопущенныхКРаботеНаАрм,
    ]),

    items () {
      return this.получитьПереченьСубъектовДоступаДопущенныхКРаботеНаАрм
    },
  },

  methods: {
    ...mapActions([
      ПОЛУЧИТЬ_ПЕРЕЧЕНЬ_СУБЪЕКТОВ_ДОСТУПА_ДОПУЩЕННЫХ_К_РАБОТЕ_НА_АРМ_С_СЕРВЕРА,
    ]),
  },
}
