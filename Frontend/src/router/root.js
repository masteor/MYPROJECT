import * as _ from '@/constants/path-names'
import * as lazy from '@/router/LazyImport'

export const Menu = {
  // в корне делать нечего - отправляем куда подальше
  path: '/',
  name: _.Menu,
  component: lazy.Menu,
}

// если пользователь ломится куда не следует - отправляем его на начальный путь в зависимости от его роли
export const UnAuthorized = {
  path: _.НеИзвестен,
  name: _.UnAuthorized,
  component: lazy.Login,
}
