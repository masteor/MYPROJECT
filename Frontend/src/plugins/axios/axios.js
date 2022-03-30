import ax from 'axios'
import { $host } from '@/globals'

// eslint-disable-next-line camelcase
/* const $post = function (url, params, $then_func, $catch_func) {
    url = $host + url

    ax
        .post(url, params)
        .then(function (response) {
            $then_func(response)
        })
        .catch(function (error) {
            $catch_func(error)
        })
} */

// eslint-disable-next-line camelcase
/* const $get = function (url, params, $then_func, $catch_func) {
    url = $host + url
    console.log($host)
    console.log(url)
    ax
        .get(url, params)
        .then(function (response) {
            $then_func(response)
        })
        .catch(function (error) {
            $catch_func(error)
        })
} */

 /* export default {
    install (Vue) {
        Vue.prototype.$post = axPost
        Vue.prototype.$get = axGet
    },
} */

console.log(`baseURL: ${$host}`)
const apiClient = ax.create({
    baseURL: $host,
    withCredentials: false,
    headers: {
        Accept: 'application/json',
        'Content-Type': 'application/json',
    },
})

/**
 * @param {string} url
 * @param {{}} params
 * @return {Promise<AxiosResponse<any>>}
 */
var axGet = (url, params) => apiClient.get(url, { params: params })

/**
 * @param {string} url
 * @param {{}} params
 * @return {Promise}
 */
var axPost = (url, params) => apiClient.post(url, params)

export { /* $get, $post,ax,  */ axGet, axPost }
