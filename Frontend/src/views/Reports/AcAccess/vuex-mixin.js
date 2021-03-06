import { mapActions, mapGetters } from 'vuex'

import {
  получитьКарточкуСотрудника,
  получитьПереченьСубьектовДоступаДопущенногоКРаботеВАс,
} from '@/store/getter-types'

import {
  ПОЛУЧИТЬ_КАРТОЧКУ_СОТРУДНИКА_С_СЕРВЕРА,
  ПОЛУЧИТЬ_ПЕРЕЧЕНЬ_СУБЬЕКТОВ_ДОСТУПА_ДОПУЩЕННОГО_К_РАБОТЕ_В_АС_С_СЕРВЕРА,
} from '@/store/action-types'

export const vuexMixin = {
  computed: {
    ...mapGetters([
      получитьПереченьСубьектовДоступаДопущенногоКРаботеВАс,
      получитьКарточкуСотрудника,
    ]),

    items () {
      return this.получитьПереченьСубьектовДоступаДопущенногоКРаботеВАс
    },
  },

  methods: {
    ...mapActions([
      ПОЛУЧИТЬ_ПЕРЕЧЕНЬ_СУБЬЕКТОВ_ДОСТУПА_ДОПУЩЕННОГО_К_РАБОТЕ_В_АС_С_СЕРВЕРА,
      ПОЛУЧИТЬ_КАРТОЧКУ_СОТРУДНИКА_С_СЕРВЕРА,
    ]),
  },
}
