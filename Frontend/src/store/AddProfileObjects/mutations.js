import { SET_ADDEDPROFILEOBJECTS } from './mutation-types'

export default {
    /**
    *
    * @param { AddProfileObjectsState } state
    * @param { [] } addedProfileObjects
    */
    [SET_ADDEDPROFILEOBJECTS] (state, { addedProfileObjects }) {
        state.addedProfileObjects = addedProfileObjects
    },
}
