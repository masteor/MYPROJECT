import moment from 'moment'

export default {
  install (Vue) {
    // eslint-disable-next-line camelcase
    Vue.prototype.$_moment = $_moment
  },
}

// eslint-disable-next-line camelcase
var $_moment = (value) => moment(value)

// eslint-disable-next-line camelcase
export { $_moment }
