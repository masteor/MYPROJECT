import * as _ from '@/constants/titles'
import * as __ from '@/constants/path-names'

export const ExecuteMenuItems = [
  {
    title: _.новыеЗаявки,
    to: { name: __.ExecuteRequests },
  },
  {
    title: _.выполненныеЗаявки,
    to: { name: __.FinishedRequests },
  },
  /* {
    title: _.заявкиНаСозданиеПрофиляНовые,
    to: { name: __.RequestCreatedProfileNew },
  },
  {
    title: _.заявкиНаСозданиеПрофиляВыполненные,
    to: { name: __.RequestCreatedProfileFinished },
  }, */
]
