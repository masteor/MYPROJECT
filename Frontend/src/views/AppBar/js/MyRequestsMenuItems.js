import * as _ from '@/constants/titles'
import * as pathNames from '@/constants/path-names'

export const MyRequestsMenuItems = [
  /* {
    title: _.моиЗаявкиНаРассмотрении,
    to: { name: pathNames.MyUnConsRequests },
  }, */
  /* {
    title: _.моиВыполненныеЗаявки,
    to: { name: pathNames.MyExecutedRequests },
  }, */
  {
    title: _.всеМоиЗаявки,
    to: { name: pathNames.AllMyRequests },
  },
  {
    title: _.яОтветственныйЗаРесурс,
    to: { name: pathNames.IamResponsible },
  },
  {
    title: _.яВладелецРесурса,
    to: { name: pathNames.IamOwner },
  },
  {
    title: _.моиПрофили,
    to: { name: pathNames.MyProfiles },
  },
]
