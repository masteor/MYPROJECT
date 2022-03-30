using System.Web.Mvc;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Web.Models.Request.ADD_EMPLOYEE
{
    public class ВФормуСозданияПользователяМодель
    {
        // таб номер
        
        // должность
        public SelectList Должности { get; set; }
        // логин
        
        // емайл
        
        // в каком домене создан
        public SelectList Домены { get; set; }
        
        // форма допуска
        public SelectList ФормыДопуска { get; set; }
        
        // фио
        
        // дата создания пользователя в базе
        
        // отделы
        public SelectList Отделы { get; set; }
        
        // отделения
        public SelectList Отделения { get; set; }

        public ВФормуСозданияПользователяМодель(ITomThumb i)
        {
            var всеДолжности = i.CommonService.ПолучитьВсеДолжности();
            Должности = new SelectList(items: всеДолжности, dataValueField: nameof(JOB.id), dataTextField: nameof(JOB.name));

            var всеСервисы = i.CommonService.ПолучитьВсеСервисы();
            Домены = new SelectList(items: всеСервисы, dataValueField: nameof(SERVICE.id), dataTextField: nameof(SERVICE.net_name));

            var всеФормыДопуска = i.CommonService.ПолучитьВсеФормыДопуска();
            ФормыДопуска = new SelectList(items: всеФормыДопуска, dataValueField: nameof(FORM_PERM.id), dataTextField: nameof(FORM_PERM.name));

            var всеОтделы = i.CommonService.ПолучитьВсеОтделы();
            Отделы = new SelectList(items: всеОтделы, dataValueField: nameof(ORG.id), dataTextField: nameof(ORG.fname));
            
            var всеОтделения = i.CommonService.ПолучитьВсеОтделения();
            Отделения = new SelectList(items: всеОтделения, dataValueField: nameof(ORG.id), dataTextField: nameof(ORG.fname));
        }

        
    }
}