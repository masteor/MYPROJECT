<template lang="pug">
    v-card.mx-auto
      v-card-title.headline {{ title }}
      v-divider
      v-card-text
        v-form(
          v-model="valid"
        )
          //-- текстовое поле ввода Названия ресурса
          v-text-field(
            type="text"
            label='Название ресурса'
            dense
            clearable
            counter
            color="primary"
            v-model="названиеРесурса"
            autofocus
            placeholder="Введите название ресурса"
            required
            :rules="[v => !!(v && v.length > 0 && v.length <= 255) || '']"
            @blur="blur"
          )

          //-- текстовое поле ввода Описания Ресурса
          v-text-field(
            type="text"
            label='Описание ресурса'
            dense
            clearable
            counter
            color="primary"
            v-model="описаниеРесурса"
            autofocus
            placeholder="Введите краткое описание ресурса"
            required
            :rules="[v => !!(v && v.length > 0 && v.length <= 255) || '']"
          )

          //-- текстовое поле названия Фрагмента - заполняется автоматически - не редактируется
          v-text-field(
            type="text"
            label='Фрагмент'
            dense
            color="primary"
            v-model="получитьФрагмент.fname"
            required
            disabled
            :rules="[v => !!(v && v.length > 0) || '']"
          )

          //-- выпадаюший список выбора Типа Ресурса (база данных, каталог и т.д.)
          v-autocomplete(
            :loading="$loadingCondition(получитьГлавныеТипыОбъектов)"
            :disabled="$disabledCondition(получитьГлавныеТипыОбъектов)"
            :items="$itemsCondition(получитьГлавныеТипыОбъектов)"
            v-model="идТипаОбъектаРесурса"
            value="идТипаОбъектаРесурса"
            label="Тип ресурса"
            placeholder="Выберите тип ресурса"
            item-text="name"
            item-value="id"
            color="primary"
            item-color="primary"
            required
            clearable
            :rules="[v => !!v || 'Выберите тип ресурса']"
          )

          //-- текстовое поле Типа Сервиса - заполняется автоматически - не редактируется
          v-text-field(
            type="text"
            label='Тип сервиса'
            dense
            color="primary"
            v-model="названиеТипаСервиса"
            required
            disabled
            :rules="[v => !!(v && v.length > 0) || '']"
          )

          //-- выпадаюший список выбора Типа Секретности ресурса
          v-autocomplete(
            :loading="$loadingCondition(получитьТипыСекретности)"
            :disabled="$disabledCondition(получитьТипыСекретности)"
            :items="$itemsCondition(получитьТипыСекретности)"
            v-model="идТипСекретности"
            label="Тип секретности"
            placeholder="Выберите тип секретности"
            item-text="name"
            item-value="id"
            color="primary"
            item-color="primary"
            required
            clearable
            :rules="[v => !!v || '']"
          )

          //-- выпадаюший список выбора Ответственного за ресурс
          v-autocomplete(
            :loading="$loadingCondition(получитьВсехСотрудников)"
            :disabled="$disabledCondition(получитьВсехСотрудников)"
            :items="$itemsCondition(получитьВсехСотрудников)"
            v-model="идОтветственный"
            label="Ответственный"
            placeholder="Выберите ответственного"
            item-text="fio_full"
            item-value="id_user"
            color="primary"
            item-color="primary"
            required
            clearable
            :rules="[v => !!v || '']"
          )

          //-- выпадаюший список выбора Владельца ресурса
          v-autocomplete(
            :loading="$loadingCondition(получитьВладельцевРесурсов)"
            :disabled="$disabledCondition(получитьВладельцевРесурсов)"
            :items="$itemsCondition(получитьВладельцевРесурсов)"
            v-model="идВладелецРесурса"
            label="Владелец ресурса"
            placeholder="Выберите владельца ресурса"
            item-text="name"
            item-value="id"
            color="primary"
            item-color="primary"
            required
            clearable
            :rules="[v => !!v || '']"
          )

          //-- выпадаюший список выбора Владельца ресурса
          v-autocomplete(
            :loading="$loadingCondition(получитьВсехСотрудников)"
            :disabled="$disabledCondition(получитьВсехСотрудников)"
            :items="$itemsCondition(получитьВсехСотрудников)"
            v-model="выбранныеСотрудники"
            label="Субъекты допуска (сотрудники)"
            placeholder="Выберите сотрудника"
            item-text="fio_full"
            item-value="id_user"
            color="primary"
            item-color="primary"
            multiple
            chips
            clearable
            deletable-chips
          )

          //-- выпадаюший список выбора Субъектов Допуска к ресурсу,
          //-- это те, кто потенциально могут получить к нему доступ
          v-autocomplete(
            :loading="$loadingCondition(получитьОргЕдиницы)"
            :disabled="$disabledCondition(получитьОргЕдиницы)"
            :items="$itemsCondition(получитьОргЕдиницы)"
            v-model="выбранныеОргЕдиницы"
            label="Субъекты допуска (орг.ед.)"
            placeholder="Выберите орг. единицу"
            item-text="name"
            item-value="id"
            color="primary"
            item-color="primary"
            multiple
            chips
            clearable
            deletable-chips
          )

      v-card-actions
        //-- кнопка отправления формы на сервер
        v-btn(
          :disabled="!valid || resourceExist"
          color="primary"
          shaped
          rounded
          @click="CreateResourceZlivs"
          :loading="loading"
        ) Создать ресурс
        //-- кнопки сохранения формы
        user-tools(
          @saveContent="saveContent"
          @clearContent="clearContent"
          @loadContent="loadContent"
        )
</template>

<script>
  import { формаЗаявкиНаСозданиеРесурсаЗЛИВС } from '@/constants/titles'
  import { vuexMixin } from './js/vuex-mixin'
  import UserTools from '@/components/UserTools'
  import Computed from './js/computed'
  import Watch from './js/watch'
  import Methods from './js/methods'

  export default {
    name: 'CreateResourceZlivs',
    components: { UserTools },
    mixins: [
      vuexMixin,
      Computed,
      Watch,
      Methods,
    ],

    data: () => ({
      title: формаЗаявкиНаСозданиеРесурсаЗЛИВС,
      valid: false,
      идТипаСервиса: 0,
      идТипаОбъектаРесурса: 0,
      идТипСекретности: 0,
      идОтветственный: 0,
      идВладелецРесурса: 0,
      идФрагмента: 0,
      описаниеРесурса: '',
      loading: false,
      resourceExist: false,
      действующиеРесурсы: [],
      названиеРесурса: '',

      выбранныеСотрудники: [],
      выбранныеОргЕдиницы: [],

    }),

    mounted () {
      this.ЗАПРОСИТЬ_ДАННЫЕ_ДЛЯ_ФОРМЫ_СОЗДАТЬ_РЕСУРС()
      this.идФрагмента = this.получитьФрагмент.id
    },

  }
</script>
