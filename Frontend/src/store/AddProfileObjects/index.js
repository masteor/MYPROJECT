import * as actions from './actions'
import mutations from './mutations'
import * as getters from './getters'
import state from './state'

export const AddProfileObjects = {
    namespaced: true,
    mutations,
    actions,
    state,
    getters,
}
