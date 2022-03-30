import Vue from 'vue'
import Router from 'vue-router'

// eslint-disable-next-line no-unused-vars
import * as mainContent from '@/router/mainContent'

// import * as navDrawer from '@/router/navDrawer'
import * as root from '@/router/root'
// import * as _ from '@/constants/path-names'
// import * as _ from '@/constants/path-names'

Vue.use(Router)

// можно сгруппировать компоненты, находящиеся по одному пути в чанк используя нижеуказанную конструкцию
/* const Login = () =>
  import(/!* webpackChunkName: "user" *!/ '../src/views/Login.vue') */

console.log(`process.env.BASE_URL: ${process.env.BASE_URL}`)

const router = new Router({
  mode: 'hash',
  // warn: base на локалхост не работает
  // base: process.env.BASE_URL,
  routes: [
     // root.Menu,
    {
      path: '/',
    },

    // App
    mainContent.App,

    // Reports (Отчёты)
    mainContent.AcAccess,
    mainContent.AllResources,
    mainContent.AllResourcesFromPrd,
    mainContent.AllArmUsers,
    mainContent.AllArms,
    mainContent.AllResourcesWithMembers,
    mainContent.RSD,
    mainContent.RsdToPrd,

    // Requests (Заявки)
    // Создание
    mainContent.CreateResource,
    mainContent.CreateResourceZLIVS,
    mainContent.CreateProfileName,
    mainContent.CreateProfile,
    mainContent.CreateMember,
    mainContent.CreateMemberZLIVS,
    mainContent.CreateTripleRequest,
    mainContent.CreateFIO,
    mainContent.UpdateFIO,
    mainContent.CreateEmployee,
    mainContent.CreateLogin,

    // Исполнение
    mainContent.ExecuteRequests,
    mainContent.FinishedRequests,
    mainContent.RequestCreatedProfileNew,
    mainContent.RequestCreatedProfileFinished,

    // Справочники
    mainContent.CreatedProfiles,
    mainContent.CreatedResources,

    // Мои заявки
    mainContent.MyUnConsRequests,
    mainContent.AllMyRequests,
    mainContent.MyExecutedRequests,
    mainContent.IamResponsible,
    mainContent.IamOwner,
    mainContent.MyProfiles,

    // FakeUser
    mainContent.FakeUser,
    mainContent.CoolReloadPage,

    // Settings
    mainContent.Settings,
    mainContent.Alerts,

    /* {
      ...root.Root,
      children: [
        // Reports
        navDrawer.Reports,

        mainContent.AcAccess,
        mainContent.AllResources,
        mainContent.AllResourcesFromPrd,
        mainContent.AllArmUsers,
        mainContent.AllArms,
        mainContent.AllResourcesWithMembers,
        mainContent.RSD,
        mainContent.RsdToPrd,
// @LABEL:ROUTER-OPERATOR-REPORTS@

        // Requests
        navDrawer.Requests,

        mainContent.CreateResource,
        mainContent.CreateProfileName,
        mainContent.AddProfileObjects,
        mainContent.CreateMember,
        mainContent.CreateTripleRequest,
        mainContent.CreateFIO,
        mainContent.UpdateFIO,
        mainContent.CreateEmployee,
        mainContent.CreateLogin,
        mainContent.ExecuteRequests,
        // @LABEL:ROUTER-OPERATOR-REQUESTS@
      ],
    }, */

    // root.User,
    // navDrawer.Reports,

    /* {
      ...root.Operator,
      children: [
        // Reports
        navDrawer.Reports,

        mainContent.AcAccess,
        mainContent.AllResources,
        mainContent.AllResourcesFromPrd,
        mainContent.AllArmUsers,
        mainContent.AllArms,
        mainContent.AllResourcesWithMembers,
        mainContent.RSD,
        mainContent.RsdToPrd,
// @LABEL:ROUTER-OPERATOR-REPORTS@

        // Requests
        navDrawer.Requests,

        mainContent.CreateResource,
        mainContent.CreateProfileName,
        mainContent.AddProfileObjects,
        mainContent.CreateMember,
        mainContent.CreateTripleRequest,
        mainContent.CreateFIO,
        mainContent.UpdateFIO,
        mainContent.CreateEmployee,
        mainContent.CreateLogin,
        mainContent.ExecuteRequests,
        // @LABEL:ROUTER-OPERATOR-REQUESTS@
      ],
    }, */
    /* root.Login, */

    root.UnAuthorized,
  ],
})

 // глобальный навигационный хук, вызывается до любого перехода
 router.beforeEach((to, from, next) => {
    console.log(`router.beforeEach.to: ${to.fullPath}`)
    console.log(`router.beforeEach.from: ${from.fullPath}`)
    console.log(`router.beforeEach.next: ${next.name}`)

   next()

   /* if (to.matched.some(r => r.meta.requiredAuth)) {
    const authed = Store.getters.authed
    console.log(`auth: ${authed}`)

    const userRoles = Store.state['service-role']

    console.log(`userRoles: ${userRoles}`)
    console.log(`toPath: ${to.path}`)

    if (!authed) {
      console.log('не авторизован')
      next({
        path: 'login',
      })
    } else {
      console.log('авторизован ролью')
      if (to.path !== Store.getters.authedPathName) {
        next({
          path: Store.getters.authedPathName,
        })
      } else {
        next()
      }
    }
  } else {
    console.log('нет меты')
    next()
  } */
})

export { router }
