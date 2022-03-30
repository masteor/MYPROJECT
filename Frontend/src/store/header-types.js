import * as _ from './словарь'
// --------------------------------------------------------------------------------------------------------------------
export class ПРИМЕР_ЗАГОЛОВКА_ОТЧЕТА {
  constructor () {
    return [
      {
        text: 'id',
        align: 'start',
        value: 'id',
      },
      {
        text: '',
        value: '',
      },
    ]
  }
}

// --------------------------------------------------------------------------------------------------------------------
export class ПЕРЕЧЕНЬ_СУБЬЕКТОВ_ДОСТУПА_ДОПУЩЕННОГО_К_РАБОТЕ_В_АС {
  constructor () {
    return [
      {
        text: _.id,
        align: 'start',
         value: 'id',
      },
      {
        text: _.ТабельныйНомер,
        value: 'tnum',
      },
      {
        text: _.Логин,
        value: 'login',
      },
      {
        text: _.Фио,
        value: 'fio',
      },
      {
        text: _.НазваниеОргструктуры,
        value: 'org_fname',
      },
      {
        text: _.ДатаСоздания,
        value: 'create_date_2',
      },
      {
        text: _.ДатаЗавершения,
        value: 'end_date_2',
      },
      {
        text: _.Активен,
        value: 'is_active_string',
      },
      {
        text: _.РегистрационныйНомер,
        value: 'reg_num',
      },
    ]
  }
}

// --------------------------------------------------------------------------------------------------------------------
export class ПЕРЕЧЕНЬ_РЕСУРСОВ_В_АС {
  constructor () {
    return [
      {
        text: _.id,
        align: 'start',
        value: 'id',
      },
      {
        text: _.НазваниеРесурса,
        value: 'resource_name',
      },
      {
        text: _.ТипСервиса,
        value: 'service_type_name',
      },
      /* {
        text: _.НазваниеСервиса,
        value: 'service_name',
      }, */
      {
        text: _.Фрагмент,
        value: 'frag_name',
      },
      {
        text: _.ПолныйПуть,
        value: 'path',
      },
      /* {
        text: _.Описание,
        value: 'description',
      }, */
      {
        text: _.ТипСекретности,
        value: 'secret_type_name',
      },
      {
        text: _.Ответственный,
        value: 'responsible',
      },
      {
        text: _.Владелец,
        value: 'owner',
      },
      {
        text: _.ДатаСоздания,
        value: 'create_date_2',
      },
      {
        text: _.СтатусПроверки,
        value: 'create_date_state_name',
      },
      {
        text: _.ДатаЗавершения,
        value: 'end_date_2',
      },
      /* {
        text: _.РегистрационныйНомер,
        value: 'reg_num',
      }, */
    ]
  }
}

// --------------------------------------------------------------------------------------------------------------------
export class РЕСУРСЫ_ГДЕ_ПОЛЬЗОВАТЕЛЬ_ОТВЕТСТВЕННЫЙ_ИЛИ_ВЛАДЕЛЕЦ {
  constructor () {
    return [
      {
        text: _.id,
        align: 'start',
        value: 'id_resource',
      },
      {
        text: _.НазваниеРесурса,
        value: 'resource_name',
      },
      {
        text: _.ТипОбъекта,
        value: 'object_type_name',
      },
      /* {
        text: _.ТипСервиса,
        value: 'service_type_name',
      }, */
       /* {
        text: _.НазваниеСервиса,
        value: 'service_name',
      }, */
      /* {
        text: _.Фрагмент,
        value: 'frag_name',
      }, */
      {
        text: _.ПолныйПуть,
        value: 'path',
      },
       {
        text: _.Описание,
        value: 'description',
      },
      {
        text: _.ТипСекретности,
        value: 'secret_type_name',
      },
      {
        text: _.Ответственный,
        value: 'fio_responsible',
      },
      {
        text: _.Владелец,
        value: 'fio_owner',
      },
      /* {
        text: _.ДатаСоздания,
        value: 'create_date_2',
      }, */
      {
        text: _.ДатаСоздания,
        value: 'create_date_2_str',
      },
      {
        text: _.СтатусПроверки,
        value: 'create_request_state_name',
      },
      {
        text: _.ДатаЗавершения,
        value: 'end_date_2',
      },
      {
        text: _.РегистрационныйНомер,
        value: 'reg_num',
      },
    ]
  }
}

export class ПЕРЕЧЕНЬ_АРМ_В_АС {
  constructor () {
    return [
      {
        text: _.id,
        align: 'start',
        value: 'id',
      },
      {
        text: _.РегНомерАрМа,
        value: 'reg_num_arm',
      },
      /* {
        text: _.IdНовогоАрМа,
        value: 'arm_id_new',
      }, */
      {
        text: _.РегНомерФормуляра,
        value: 'reg_num_logbook',
      },
      {
        text: _.НомерПомещения,
        value: 'room',
      },
      {
        text: _.Здание,
        value: 'building',
      },
      {
        text: _.Площадка,
        value: 'prom_area_name',
      },
      /* {
        text: 'id заявки постановки на учёт',
        value: 'arm_id_request_1',
      },
      {
        text: 'id заявки снятия с учёта',
        value: 'arm_id_request_2',
      }, */
      {
        text: _.ДатаПостановкиНаУчёт,
        value: 'create_date_2',
      },
      {
        text: _.ДатаСнятияСУчёта,
        value: 'end_date_2',
      },
      /* {
        text: 'arm_user_id_user',
        value: 'arm_user_id_user',
      },
      {
        text: 'user_room_id_user',
        value: 'user_room_id_user',
      }, */
    ]
  }
}

export class ПЕРЕЧЕНЬ_СУБЪЕКТОВ_ДОСТУПА_ДОПУЩЕННЫХ_К_РАБОТЕ_НА_АРМ {
  constructor () {
    return [
      {
        text: _.id,
        align: 'start',
        value: 'id',
      },
      {
        text: _.Фио,
        value: 'sfio',
      },
      {
        text: _.ТабельныйНомер,
        value: 'tnum',
      },
      {
        text: _.РегНомерАрМа,
        value: 'arm_reg_num',
      },
      {
        text: _.РольПерсонала,
        value: 'arm_user_role_name',
      },
      {
        text: _.ДатаРазрешенияДопуска,
        value: 'create_date_2',
      },
      {
        text: _.ДатаПрекращенияДопуска,
        value: 'end_date_2',
      },
    ]
  }
}
export class ПЕРЕЧЕНЬ_РЕСУРСОВ_К_КОТОРЫМ_ПРЕДОСТАВЛЕН_ДОСТУП_СУБЪЕКТАМ {
  constructor () {
    return [
      {
        text: _.Ин,
        align: 'start',
        value: 'id',
      },
      {
        text: _.Имя,
        value: 'resource_name',
      },
      {
        text: _.ТипСервиса,
        value: 'service_type_name',
      },
      {
        text: _.НазваниеСервиса,
        value: 'service_name',
      },
      {
        text: _.Фрагмент,
        value: 'frag_name',
      },
      {
        text: _.ПолныйПуть,
        value: 'path',
      },
      {
        text: _.Описание,
        value: 'description',
      },
      {
        text: _.ТипСекретности,
        value: 'secret_type_name',
      },
      {
        text: _.Владелец,
        value: 'string owner',
      },
      {
        text: _.Ответственный,
        value: 'responsible',
      },
      {
        text: _.ДатаСоздания,
        value: 'create_date',
      },
      {
        text: _.РегНомерЗаявки,
        value: 'reg_num',
      },
    ]
  }
}

export class РАЗРЕШИТЕЛЬНАЯ_СИСТЕМА_ДОСТУПА_К_РЕСУРСАМ {
  constructor () {
    return [
      {
        text: _.Ин,
        align: 'start',
        value: 'id',
      },
      {
        text: _.ИмяОбъектаРесурса,
        value: 'resource_name',
      },
      {
        text: _.ИмяПрофиля,
        value: 'profile_name',
      },
      {
        text: _.СтруктурнаяЕдиница,
        value: 'org_name',
      },
      {
        text: _.Фио,
        value: 'fio_full',
      },
      {
        text: _.ТабельныйНомер,
        value: 'tnum',
      },
      {
        text: _.Должность,
        value: 'job_name',
      },
      {
        text: _.Логин,
        value: 'login',
      },
      {
        text: _.ФормаДопуска,
        value: 'form_perm',
      },
      {
        text: _.ДатаПредоставленияДоступа,
        value: 'create_date_2',
      },
      {
        text: _.ДатаПрекращенияДоступа,
        value: 'end_date_2',
      },
    ]
  }
}

export class СПИСОК_ЗАЯВОК_БЕЗ_РАЗБИВКИ_ПО_ТИПАМ {
  constructor () {
    return [
      {
        text: _.id,
        align: 'start',
        value: 'id',
      },
      {
        text: _.ИдЗаявки,
        value: 'id_request',
      },
      {
        text: _.ДатаПодачиЗаявки,
        value: 'datestr_1',
      },
      /* {
        text: _.ДатаПодачиЗаявки,
        value: 'date_1',
      }, */
      {
        text: _.ТипЗаявки,
        value: 'request_type_name',
      },
      {
        text: _.ОтправительЗаявки,
        value: 'sender',
      },
      {
        text: _.ПолучательЗаявки,
        value: 'recipient',
      },
      {
        text: _.СтатусПроверки,
        value: 'request_state_name',
      },
      {
        text: _.Документ,
        value: 'id_doc',
      },
    ]
  }
}

// это заголовки для информационной формы, а не для таблицы
export class КАРТОЧКА_СОТРУДНИКА {
  constructor () {
    return [
      {
        text: _.id,
        value: 'id',
      },
      {
        text: _.ТабНомер,
        value: 'tnum',
      },
      {
        text: _.Фио,
        value: 'employee_fio_full',
      },
      {
        text: _.Логин,
        value: 'login',
      },
      {
        text: _.ФормаДопуска,
        value: 'form_perm',
      },
      {
        text: _.Активен,
        value: 'is_active_descr',
      },
      {
        text: _.Должность,
        value: 'job_descr',
      },
      {
        text: _.РабочийТелефон,
        value: 'wphone',
      },
      {
        text: _.ДомашнийТелефон,
        value: 'wphone',
      },
      {
        text: _.Здание,
        value: 'build',
      },
      {
        text: _.Площадка,
        value: 'prom_area',
      },
      {
        text: _.Комната,
        value: 'room',
      },
      {
        text: _.Отдел,
        value: 'dep_descr',
      },
      {
        text: _.Рук,
        comment: 'Руководитель отдела',
        value: 'dep_boss_fio_full',
      },
      {
        text: _.Отделение,
        value: 'div_descr',
      },
      {
        text: _.Рук,
        comment: 'Руководитель отделения',
        value: 'div_boss_fio_full',
      },
      {
        text: _.Лаборатория,
        value: 'lab_descr',
      },
      {
        text: _.Рук,
        comment: 'Руководитель лаборатории',
        value: 'lab_boss_fio_full',
      },
    ]
  }
}

export class ЗАЯВКА_НА_СОЗДАНИЕ_ЗАЩИЩАЕМОГО_РЕСУРСА {
  constructor () {
    return [
      {
        text: _.id,
        align: 'start',
        value: 'id',
      },
      {
        text: _.НазваниеРесурса,
        value: 'resource_name',
      },
      {
        text: _.ТипОбъекта,
        value: 'object_type_name',
      },
      {
        text: _.ТипСервиса,
        value: 'service_type_name',
      },
       /* {
        text: _.НазваниеСервиса,
        value: 'service_name',
      }, */
      {
        text: _.Фрагмент,
        value: 'frag_name',
      },
      /* {
        text: _.ПолныйПуть,
        value: 'path',
      }, */
       /* {
        text: _.Описание,
        value: 'description',
      }, */
      {
        text: _.ТипСекретности,
        value: 'secret_type_name',
      },
      /* {
        text: _.Владелец,
        value: 'owner',
      }, */
      {
        text: _.Ответственный,
        value: 'responsible',
      },
      {
        text: _.ПодразделениеОтдел,
        value: 'org_fname',
      },
      {
        text: _.ДатаСоздания,
        value: 'create_date_1',
      },
      /* {
        text: _.ДатаЗавершения,
        value: 'end_date_2',
      }, */
      /* {
        text: _.РегистрационныйНомер,
        value: 'reg_num',
      }, */
      {
        text: _.СтатусПроверки,
        value: 'status',
      },
      {
        text: _.Документ,
        value: 'doc',
      },
    ]
  }
}

export class ЗАЯВКИ_НА_СОЗДАНИЕ_ЗАЩИЩАЕМОГО_РЕСУРСА {
  constructor () {
    return [
      {
        text: _.ДатаПодачиЗаявки,
        align: 'start',
        value: 'create_date_1',
      },
      {
        text: _.НазваниеРесурса,
        value: 'resource_name',
      },
      {
        text: _.ТипСервиса,
        value: 'service_type_name',
      },
      {
        text: _.НазваниеСервиса,
        value: 'service_name',
      },
      {
        text: _.ТипСекретности,
        value: 'secret_type_name',
      },
      {
        text: _.Ответственный,
        value: 'responsible',
      },
      {
        text: _.НазваниеПодразделения,
        value: 'division',
      },
      {
        text: _.НазваниеОтдела,
        value: 'department',
      },
      {
        text: _.СтатусПроверки,
        value: 'status',
      },
      {
        text: _.Документ,
        value: 'doc',
      },
    ]
  }
}

export class ЗАЯВКА_НА_СОЗДАНИЕ_ПРОФИЛЯ_ДОСТУПА {
  constructor () {
    return [
      {
        text: _.ДатаПодачиЗаявки,
        align: 'start',
        value: 'create_date_1',
      },
    ]
  }
}

export class ОБЪЕКТЫ_ПРОФИЛЯ {
  constructor () {
    return [
      {
        text: _.НазваниеОбъектаРесурса,
        align: 'start',
        value: 'object_name',
      },
      {
        text: _.Права,
        value: '',
      },
      {
        text: _.ТипОбъектаРесурса,
        value: '',
      },
    ]
  }
}

// @LABEL:HEADER@
