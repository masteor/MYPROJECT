
/* eslint-disable no-unused-vars */

export const allServiceRoles = {
  /// <summary>
/// Администратор сервиса
/// </summary>
  Root: 'root',

  // алиас
  Admin: 'root',

  /// <summary>
/// Руководитель
/// </summary>
  Boss: 'boss',

  /// <summary>
/// Исполнитель
/// </summary>
  Executor: 'executor',

  /// <summary>
/// Оператор
/// </summary>
  Operator: 'operator',

  /// <summary>
/// Начальник РСО
/// </summary>
  RSO: 'rso-boss',

  /// <summary>
/// Пользователь
/// </summary>
  User: 'user',

  /// <summary>
/// Аноним, пользователь без логина, который вошёл в сервис вне домена
/// </summary>
  Anonim: 'anonim',
}

export const отчёты = [
  allServiceRoles.Operator,
  allServiceRoles.Admin,
  allServiceRoles.Root,
  allServiceRoles.RSO,
]

export const создатьЗаявки = [
  allServiceRoles.Admin,
  allServiceRoles.Root,
  allServiceRoles.User,
]

export const моиЗаявки = [
  allServiceRoles.User,
  allServiceRoles.Admin,
  allServiceRoles.Root,
  allServiceRoles.Executor,
]

export const исполнители = [
    allServiceRoles.Admin,
    allServiceRoles.Root,
    allServiceRoles.Executor,
]

export const Админы = [
  allServiceRoles.Admin,
  allServiceRoles.Root,
]
