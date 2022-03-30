import * as _ from '@/constants/titles'
import * as pathNames from '@/constants/path-names'

export const ReportsMenuItems = [
  {
    title: _.переченьРесурсовВАсPRD,
    to: { name: pathNames.AllResourcesFromPrd },
  },
  {
    title: _.разрешительнаяСистемаДоступаКРесурсамPRD,
    to: { name: pathNames.RsdToPrd },
  },
  {
    title: _.переченьСубъектовДоступаДопущенногоКРаботеВАс,
    to: { name: pathNames.AcAccess },
  },
  /* {
    title: _.переченьРесурсовВАс,
    to: { name: pathNames.AllResources },
  }, */

  {
    title: _.переченьАрмВАс,
    to: { name: pathNames.AllArms },
  },
  {
    title: _.переченьСубъектовДоступаДопущенныхКРаботеНаАрм,
    to: { name: pathNames.AllArmUsers },
  },

  /* {
    title: _.переченьРесурсовККоторымПредоставленДоступСубъектам,
    to: { name: pathNames.AllResourcesWithMembers },
  }, */

  /* {
    title: _.разрешительнаяСистемаДоступаКРесурсам,
    to: { name: pathNames.RSD },
  }, */

  // @LABEL:VIEWS-OPERATOR-REPORTS@
]
