import {
  CreateMember, CreateMemberZLIVS,
  CreateProfile,
  CreateResource,
  /* CreateTripleRequest, */
} from '@/constants/path-names'

export default [
  {
    title: 'Создать ресурс СИЛС',
    to: { name: CreateResource },
  },
  {
    title: 'Создать профиль',
    to: { name: CreateProfile },
  },
  {
    title: 'Предоставить субъектам доступ к ресурсу СИЛС',
    to: { name: CreateMember },
  },
  {
    title: 'Предоставить субъектам доступ к ресурсу ЗЛИВС',
    to: { name: CreateMemberZLIVS },
  },
  /* {
    title: '[В РАЗРАБОТКЕ] Создать тройную заявку СИЛС',
    to: { name: CreateTripleRequest },
  }, */
]
