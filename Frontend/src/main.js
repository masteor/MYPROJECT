import { router } from './router/router.js'
import Vue from 'vue'
import App from './views/App.vue'
import { store } from './store/store.js'
/* import './plugins/base' */
import './plugins/vee-validate'
import vuetify from './plugins/vuetify'
/* import i18n from './i18n' */
// import Telegraf from './plugins/telegraf' // больше не используется, оставлен для примера как делать плагины
import Get from './plugins/axios/get'
import Helpers from './plugins/helpers'
import Moment from './plugins/Moment'
// import Vlf from 'vlf'

// Vue.use(Vlf, localForage)
Vue.use(Moment)
// Vue.use(Telegraf)
Vue.use(Get)
Vue.mixin(Helpers)

Vue.config.productionTip = false

export default new Vue({
  // указываем, какие компоненты будем использовать в public/index.html
  components: {
    App,
  },
  router,
  store,
  vuetify,
  /* i18n, */
  /* render: h => h(App), */
}).$mount('#rootapp')
