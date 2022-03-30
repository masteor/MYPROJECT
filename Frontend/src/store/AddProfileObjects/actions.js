import { SET_ADDEDPROFILEOBJECTS } from './mutation-types'
/* import * as actionTypes from '../action-types'
import { PostPayload } from '../store'
import { ДОБАВИТЬ_ОБЪЕКТЫ_В_ПРОФИЛЬ_НА_СЕРВЕРЕ } from '../url-types' */

/**
*
* @param { function } commit
* @param { [] } addedProfileObjects
*/
export function setAddedProfileObjects ({ commit }, { addedProfileObjects }) {
    commit(SET_ADDEDPROFILEOBJECTS, { addedProfileObjects })
}

/*
export function AddProfileObjects ({ dispatch }, { addedProfileObjects }) {
    dispatch(
      actionTypes.ВЫПОЛНИТЬ_ЗАПРОС_POST,
      new PostPayload(
        ДОБАВИТЬ_ОБЪЕКТЫ_В_ПРОФИЛЬ_НА_СЕРВЕРЕ,
        { addedProfileObjects },
        actionTypes.ВЫПОЛНИТЬ_ЗАПРОС_POST,
      ),
      { root: true },
    )
    /!* commit(SET_ADDEDPROFILEOBJECTS, { addedProfileObjects }) *!/
}
*/
