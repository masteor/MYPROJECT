import { АЛЕРТНУТЬ } from '@/store/action-types'
import * as paramsTypes from '@/store/param-types'
import ТипАлерта from '@/constants/типАлерта'

export default {
  methods: {
    // сразу после ввода имени профиля
    blurProfile () {
      if (this.имяПрофиля.length < 1) return
      this.проверитьСуществованиеПрофиля()
    },

    async проверитьСуществованиеПрофиля () {
      console.log('проверитьСуществованиеПрофиля()')
      if (this.получитьФрагмент.id < 1) return

      if (this.profileExist) {
        await this.$store.dispatch(
          АЛЕРТНУТЬ,
          new paramsTypes.ПАРАМЕТРЫ_АЛЕРТА(
            `Профиль с именем: '${this.имяПрофиля}' уже существует в БД`,
            ТипАлерта.error,
          ),
        )
      }
    },
  },
}
