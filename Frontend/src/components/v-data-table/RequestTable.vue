 <template lang="pug">
  v-card.mx-auto
    v-card-title.headline {{ title }}
      v-spacer
      v-text-field(
        v-model="строкаПоиска"
        label="Поиск"
        single-line
        hide-details
        prepend-inner-icon="mdi-table-search"
        clearable
      )
    v-divider
    v-card-text
      //- таблица с данными
      v-data-table.elevation-1(
        :headers="headers"
        :items="this.items"
        :loading="loading"
        loading-text="Ожидайте, данные загружаются"
        :search="строкаПоиска"
        single-expand
        :show-expand="showExpand"
        :expanded.sync="expanded"
        :item-key="itemKey"
        :footer-props="{showFirstLastPage: true}"
      )
        //- слот для раскрытия строк таблицы
        template(v-slot:expanded-item="{ item, headers }")
          td(:colspan="headers.length")
            v-progress-circular(
              v-if="expandedLoading"
              :size="20"
              :width="2"
              color="primary"
              indeterminate
            )
            preview-profile(
              v-if="showPreviewProfile && !expandedLoading"
              :model="результатЗапроса"
            )
            preview-resource(
              v-if="showPreviewResource && !expandedLoading"
              :model="результатЗапроса"
            )
            preview-resource-zlivs(
              v-if="showPreviewResourceZlivs && !expandedLoading"
              :model="результатЗапроса"
            )

        //- слот для показа документов при нажатии на иконку глаза
        template(v-slot:item.id_doc="{ item }")
          table
            tr
              td
                div(v-if="item.id_doc > 1")
                  v-progress-circular(
                    v-if="item.id_doc === docId"
                    :size="20"
                    :width="2"
                    color="primary"
                    indeterminate
                  )
                  v-icon(
                    v-else
                    color="primary"
                    @click="showDoc(item.id_doc)"
                  ) mdi-eye
                div(v-else)
                  v-icon mdi-eye-off

              //-
                кнопка отклонения подтверждения, показывается только если есть соответствующее разрешение
                разрешение спускается от родительского компонента
              template(
                v-if="allowedExecute"
              )
                td
                  v-progress-circular(
                    v-if="executePushed && (item.id_request === requestId)"
                    :size="20"
                    :width="2"
                    color="primary"
                    indeterminate
                  )
                  v-icon(
                    v-else
                    color="primary"
                    @click="executeRequest(item.id_request, Выполнена)"
                  ) mdi-check-bold

                //-
                  кнопка отклонения заявки, показывается только если есть соответствующее разрешение
                  разрешение спускается от родительского компонента
                td
                  v-progress-circular(
                    v-if="declinePushed && (item.id_request === requestId)"
                    :size="20"
                    :width="2"
                    color="secondary"
                    indeterminate
                  )
                  v-icon(
                    v-else
                    color="secondary"
                    @click="executeRequest(item.id_request, Отклонена)"
                  ) mdi-close-thick
</template>

<script>
  import { $host } from '@/globals'
  import { ПОЛУЧИТЬ_СОДЕРЖИМОЕ_ДОКУМЕНТА_ПО_ИД } from '@/store/url-types'

  import {
    ДОПОЛНИТЕЛЬНЫЕ_ПАРАМЕТРЫ_ЗАЯВКИ,
    ПАРАМЕТРЫ_ЗАПРОСА_ВЫПОЛНИТЬ_ЗАЯВКУ,
    ПАРАМЕТРЫ_ЗАПРОСА_ПОЛУЧИТЬ_СОДЕРЖИМОЕ_ЗАЯВКИ,
  } from '@/store/param-types'

  import {
    ВЫПОЛНИТЬ_ЗАЯВКУ_С_ОПРЕДЕЛЕННЫМ_СТАТУСОМ,
    ПОЛУЧИТЬ_СОДЕРЖИМОЕ_ЗАЯВКИ_ПО_ТИПУ_ЗАЯВКИ_И_НОМЕРУ_ЗАЯВКИ,
  } from '@/store/action-types'

  import { Выполнена, Отклонена } from '@/constants/идСтатусаЗаявки'
  import * as БуквенныеКодыТиповЗаявок from '@/constants/БуквенныеКодыТиповЗаявок'

  import {
    domainAccount,
    запросУспешен,
    получитьЛогинПользователяСервиса,
  } from '@/store/getter-types'

  import PreviewProfile from '@/views/Preview/Profile'
  import PreviewResource from '@/views/Preview/Resource'
  import PreviewResourceZlivs from '@/views/Preview/ResourceZlivs'

  export default {
    name: 'RequestTable',
    components: { PreviewResourceZlivs, PreviewProfile, PreviewResource },
    props: {

      allowedExecute: {
        type: Boolean,
        default: () => false,
      },

      headers: {
        type: Array,
        default: () => [],
      },

      itemKey: {
        type: String,
        default: () => 'id',
      },

      items: {
        type: Array,
        default: () => [],
      },

      loading: {
        type: Boolean,
        default: () => false,
      },

      title: {
        type: String,
        default: '',
      },

      showExpand: {
        type: Boolean,
        default: false,
      },
    },

    data: () => ({
      строкаПоиска: '',
      expanded: [],
      expandedLoading: false,
      payload: '',
      docLoading: false,
      docId: '',
      requestId: 0,
      requestTypeCode: '',
      executePushed: false,
      declinePushed: false,
      результатЗапроса: '',
      БуквенныеКодыТиповЗаявок: {},
    }),

    computed: {
      showPreviewProfile () {
        return this.requestTypeCode === БуквенныеКодыТиповЗаявок.ЗаявкаНаСозданиеПрофиляДоступа
      },

      showPreviewResource () {
        return this.requestTypeCode === БуквенныеКодыТиповЗаявок.ЗаявкаНаСозданиеЗащищаемогоРесурса
      },

      showPreviewResourceZlivs () {
        return this.requestTypeCode === БуквенныеКодыТиповЗаявок.ЗаявкаНаСозданиеЗащищаемогоРесурсаЗЛИВС
      },
    },

    watch: {
      expanded (array) {
        this.результатЗапроса = {}

        if (array.length < 1) {
          this.requestTypeCode = ''
          this.expandedLoading = false

          return
        }

        this.getExpanded(array)
      },
    },

    beforeCreate () {
      this.Выполнена = Выполнена
      this.Отклонена = Отклонена
      this.БуквенныеКодыТиповЗаявок = БуквенныеКодыТиповЗаявок
    },

    methods: {
      async getExpanded (array) {
        // если предыдущий запрос не завершился - до свидания
        if (this.expandedLoading) return

        this.expandedLoading = true

        // если раскрыта строка - загружаем данные соответствующие типу заявки
        this.результатЗапроса = await this.$store.dispatch(
          ПОЛУЧИТЬ_СОДЕРЖИМОЕ_ЗАЯВКИ_ПО_ТИПУ_ЗАЯВКИ_И_НОМЕРУ_ЗАЯВКИ,
          new ПАРАМЕТРЫ_ЗАПРОСА_ПОЛУЧИТЬ_СОДЕРЖИМОЕ_ЗАЯВКИ(
            array[0].id_request,
            array[0].request_type_code,
            this.$store.getters.domainAccount,
          ),
        )

        this.requestTypeCode = array[0].request_type_code
        this.expandedLoading = false
      },

      async executeRequest (value, идСтатусаЗаявки) {
        console.log(`executeRequest(value, идСтатусаЗаявки)=${value}, ${идСтатусаЗаявки}`)

        // отклоняем новые нажатия если предыдущий запрос не отработал
        if (this.requestId > 0 && (this.executePushed || this.declinePushed)) return

        // включаем круг прогресса
        if (идСтатусаЗаявки === Выполнена) this.executePushed = true
        if (идСтатусаЗаявки === Отклонена) this.declinePushed = true
        this.requestId = value

        this.результатЗапроса = await this.$store.dispatch(
          ВЫПОЛНИТЬ_ЗАЯВКУ_С_ОПРЕДЕЛЕННЫМ_СТАТУСОМ,
          new ПАРАМЕТРЫ_ЗАПРОСА_ВЫПОЛНИТЬ_ЗАЯВКУ(
            value,
            new ДОПОЛНИТЕЛЬНЫЕ_ПАРАМЕТРЫ_ЗАЯВКИ(
              null,
              null,
              this.$store.getters[получитьЛогинПользователяСервиса],
              this.$store.getters[получитьЛогинПользователяСервиса],
              идСтатусаЗаявки,
              null,
              null,
            ),
          ))

        // если запрос успешен - удаляем заявку из таблицы
        if (this.$store.getters[запросУспешен]) {
          this.$emit('delete-item-with-id', value)
        }

        // выключаем круг прогресса
        if (идСтатусаЗаявки === Выполнена) this.executePushed = false
        if (идСтатусаЗаявки === Отклонена) this.declinePushed = false
        this.requestId = 0
      },

      showDoc (value) {
        const _this = this
        this.docId = value
        this.docLoading = true
        // запоминаем какая заявка смотрится сейчас
        // this.overlooked = this.payload.id_request
        const xhr = new XMLHttpRequest()
        xhr.open('GET',
                 `${$host}${ПОЛУЧИТЬ_СОДЕРЖИМОЕ_ДОКУМЕНТА_ПО_ИД}?id=${value}&domainAccount=${this.$store.getters[domainAccount]}`,
        )
        xhr.responseType = 'blob'
        xhr.onload = function () {
          if (this.status === 200) {
            const objUrl = URL.createObjectURL(xhr.response)
            window.open(objUrl)
            _this.docLoading = false
            _this.docId = ''
          }
        }
        xhr.send()
      },
    },
  }
</script>
