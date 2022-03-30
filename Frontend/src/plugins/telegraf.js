// инициализируем телеграф - канал для общения между компонентами
import Vue from 'vue'
import { DEBUG } from '@/globals'

const bus = new Vue({
    created: function () {
        if (DEBUG) {
            console.log('let bus = new Vue({})')
        }
    },
})

// eslint-disable-next-line camelcase
const $_on_ = function (event, fn) {
    bus.$on(event, fn)
}

// eslint-disable-next-line camelcase
const $_emit_ = function (event, value) {
    bus.$emit(event, value)
    if (DEBUG) {
        console.log(`Vue.prototype.$_emit_ отработал: [event: ${event} | value: ${value}]`)
    }
}

export default {
    install (Vue) {
        // eslint-disable-next-line camelcase
        Vue.prototype.$_on_ = $_on_
        // eslint-disable-next-line camelcase
        Vue.prototype.$_emit_ = $_emit_
    },
}

// eslint-disable-next-line camelcase
export { DEBUG, $_emit_, $_on_, bus }
