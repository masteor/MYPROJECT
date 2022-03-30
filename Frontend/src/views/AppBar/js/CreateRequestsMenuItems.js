import {
  CreateMember,
  CreateMemberZLIVS,
  CreateProfile,
  CreateResource,
  CreateResourceZLIVS,
  CreateTripleRequest,
} from '@/constants/path-names'

export const CreateRequestsMenuItems = [
  {
    title: 'Создать ресурс',
    to: { name: CreateResource },
  },
  {
    title: 'Создать ресурс ЗЛИВС',
    to: { name: CreateResourceZLIVS },
  },
  /* {
    title: 'Создать имя профиля',
    to: { name: 'CreateProfileName' },
  }, */
  {
    title: 'Создать профиль',
    to: { name: CreateProfile },
  },
  {
    title: 'Предоставить субъектам доступ к ресурсу',
    to: { name: CreateMember },
  },
  {
    title: 'Предоставить субъектам доступ к ресурсу ЗЛИВС',
    to: { name: CreateMemberZLIVS },
  },
  {
    title: '[В РАЗРАБОТКЕ] Создать тройную заявку',
    to: { name: CreateTripleRequest },
  },
  /* {
    title: 'Создать ФИО пользователя',
    to: { name: 'CreateFIO' },
  },
  {
    title: 'Обновить ФИО пользователя',
    to: { name: 'UpdateFIO' },
  }, */
  /* {
    title: 'Создать пользователя',
    to: { name: 'CreateEmployee' },
  }, */
  /* {
    title: 'Создать логин',
    to: { name: 'CreateLogin' },
  }, */
]
