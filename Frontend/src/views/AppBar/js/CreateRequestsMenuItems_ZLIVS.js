import {
  CreateMemberZLIVS,
  CreateProfile,
  CreateResourceZLIVS,
  /* CreateTripleRequest, */
} from '@/constants/path-names'

export default [
  {
    title: 'Создать ресурс ЗЛИВС',
    to: { name: CreateResourceZLIVS },
  },
  {
    title: 'Создать профиль',
    to: { name: CreateProfile },
  },
  {
    title: 'Предоставить субъектам доступ к ресурсу ЗЛИВС',
    to: { name: CreateMemberZLIVS },
  },
  /* {
    title: '[В РАЗРАБОТКЕ] Создать тройную заявку ЗЛИВС',
    to: { name: CreateTripleRequest },
  }, */
]
