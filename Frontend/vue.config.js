/* const path = require('path')
const resolve = dir => path.join(__dirname, dir) */
const layoutPath = './Views/Shared/_Layout.cshtml'

module.exports = {
  indexPath: process.env.MODE_ENV === 'production'
    ? layoutPath
    : layoutPath,

  productionSourceMap: true,

  /* process.env.MODE_ENV !== 'production', */

  parallel: require('os').cpus().length > 1,

  devServer: {
    disableHostCheck: true,
  },

  transpileDependencies: ['vuetify'],
  runtimeCompiler: true,

  pluginOptions: {
    i18n: {
      locale: 'ru',
      fallbackLocale: 'ru',
      localeDir: 'locales',
      enableInSFC: false,
    },
  },

  /* chainWebpack: config => {
    config.resolve.alias
      .set('~', resolve('src/'))
      .set('store', resolve('src/store'))
  }, */
}
