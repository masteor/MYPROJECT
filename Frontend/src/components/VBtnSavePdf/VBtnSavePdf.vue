<template lang="pug">
  v-btn(
    color="primary"
    shaped
    rounded
    @click="SaveExcel()"
  ) Excel

</template>

<script>
  import ExcelJS from 'exceljs'
  import FileSaver from 'file-saver'
  import _ from 'lodash'

  export default {
    name: 'VBtnSavePdf',
    components: { },

    props: {
      title: {
        type: String,
        default: '',
      },
      headers: {
        type: Array,
        default: () => [],
      },
      filteredItems: {
        type: Array,
        default: () => [],
      },
    },

    methods: {
      async SaveExcel () {
        // выдергиваем из массива заголовков имена свойств
        const headerKeys = this.headers.map(v => v.value)

        // проходим по каждому объекту массива и получаем только значения тех свойств, которые есть в массиве заголовков
        const filteredItems = this.filteredItems.map((value) => Object.values(_.pick(value, headerKeys)))

        const workbook = new ExcelJS.Workbook()

        workbook.creator = 'Me'
        workbook.lastModifiedBy = 'Her'
        workbook.created = new Date(1985, 8, 30)
        workbook.modified = new Date()
        workbook.lastPrinted = new Date(2016, 9, 27)
        workbook.properties.date1904 = true
        workbook.calcProperties.fullCalcOnLoad = false

        workbook.views = [
          {
            x: 0,
            y: 0,
            width: 10000,
            height: 20000,
            firstSheet: 0,
            activeTab: 1,
            visibility: 'visible',
          },
        ]

        const sheet = workbook.addWorksheet('My Sheet', {
          pageSetup: { paperSize: 9, orientation: 'landscape' },
        })

        sheet.pageSetup.margins = {
          left: 0.7,
          right: 0.7,
          top: 0.75,
          bottom: 0.75,
          header: 0.3,
          footer: 0.3,
        }

        sheet.addRow([`${this.title}`])
        sheet.addRow(this.headers.map(v => `${v.text}`))
        sheet.addRows(filteredItems)

        const buf = await workbook.xlsx.writeBuffer()
        FileSaver(new Blob([buf]), 'kdushfkjhdf.xlsx')
      },
    },
  }
</script>
