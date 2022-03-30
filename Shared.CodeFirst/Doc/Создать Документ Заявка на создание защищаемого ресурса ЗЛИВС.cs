using System;
using QWERTY.Shared.Models.Заявки;
using Xceed.Words.NET;

namespace QWERTY.Shared.Doc
{
    public partial class Document
    {
        public void ОбработатьДокументЗаявкаНаСозданиеЗащищаемогоРесурсаЗЛИВС<T>
            (DocX doc, T модельДокумента) where T : class
        {
            var модель = модельДокумента as Документ_СозданиеЗащищаемогоРесурсаЗЛИВС_модель;
            if (модель == null) throw new ArgumentNullException(nameof(модель));

            var tn = 1;
            {
                // главная таблица
                var mainTable = doc.Tables[tn++];
                mainTable.Rows[2].Cells[1].Paragraphs[0].ReplaceText("<OBJECT.NAME>", модель.ObjectName);
                mainTable.Rows[3].Cells[1].Paragraphs[0]
                    .ReplaceText("<OBJECT_TYPE.NAME>", модель.ObjectTypeName);
                mainTable.Rows[5].Cells[1].Paragraphs[0].ReplaceText("<SECRET_TYPE>", модель.SecretTypeName);
                
                // todo: пункты перечней не реализованы
                mainTable.Rows[6].Cells[1].Paragraphs[0].ReplaceText("<RESOURCE_UCA>", string.Empty);
            }

            {
                // таблица описания
                var descrTable = doc.Tables[tn++];
                descrTable.Rows[0].Cells[0].Paragraphs[0]
                    .ReplaceText("<RESOURCE.DESCRIPTION>", модель.ResourceDescription);
            }

            {
                // таблица "Ответственный за ресурс:"
                var responsibleTable = doc.Tables[tn++];
                // ФИО
                responsibleTable.Rows[1].Cells[0].Paragraphs[0].ReplaceText("<RESOURCE.RESPONSIBLE.FULLNAME>",
                    модель.ResourceResponsibleFullName);
                // Должность
                responsibleTable.Rows[1].Cells[1].Paragraphs[0]
                    .ReplaceText("<RESPONSIBLE.JOB.NAME>",модель.ResponsibleJobName);
                // Место работы
                responsibleTable.Rows[1].Cells[2].Paragraphs[0]
                    .ReplaceText("<RESPONSIBLE.ORG.FNAME>", модель.ResponsibleOrgFname);
            }

            {
                // таблица "Перечень субъектов доступа (сотрудники):"
                var resourceMemberEmployeeTable = doc.Tables[tn++];
                // удаляем первую строку,
                // потому что в шаблоне она используется для описания структуры данных данной таблицы
                resourceMemberEmployeeTable.RemoveRow(1);

                // заполняем таблицу допущенных сотрудников 
                var rme = модель.ResourceMemberEmployees;
                if (rme != null)
                    for (var i = 0; i < rme.Count; i++)
                    {
                        var row = resourceMemberEmployeeTable.InsertRow();
                        var _ = rme[i];
                        
                        // №
                        row.Cells[0].Paragraphs[0].InsertText((i+1).ToString());
                        
                        // ФИО
                        row.Cells[1].Paragraphs[0]
                            .InsertText(_.Fullname);
                        
                        // Должность
                        row.Cells[2].Paragraphs[0].InsertText(_.JobName);
                        
                        // Место работы
                        row.Cells[3].Paragraphs[0].InsertText(_.OrgFname);
                    }
            }

            {
                // Перечень субъектов доступа (орг.структуры):
                var resourceMemberOrgsTable = doc.Tables[tn++];
                // удаляем первую строку,
                // потому что в шаблоне она используется для описания структуры данных данной таблицы
                resourceMemberOrgsTable.RemoveRow(1);
                
                // заполняем таблицу допущенных оргз 
                var rmo = модель.ResourceMemberOrgs;
                if (rmo != null)
                    for (var i = 0; i < rmo.Count; i++)
                    {
                        var row = resourceMemberOrgsTable.InsertRow();
                        var _ = rmo[i];
                        
                        // №
                        row.Cells[0].Paragraphs[0].InsertText((i+1).ToString());
                        // название орг.структуры
                        row.Cells[1].Paragraphs[0].InsertText(_);
                    }
            }

            {
                // таблица-подпись "Ответственный за ресурс"
                var responsibleSignatureTable = doc.Tables[tn++];
                // расшифровка подписи
                responsibleSignatureTable.Rows[0].Cells[2].Paragraphs[0]
                    .ReplaceText("<RESOURCE.RESPONSIBLE.SHORTNAME>", модель.ResourceResponsibleShortName);
            }

            {
                // таблица-подпись "Начальник подразделения"
                var ownerSignatureTable = doc.Tables[tn];
                // расшифровка подписи
                ownerSignatureTable.Rows[0].Cells[0].Paragraphs[0]
                    .ReplaceText("<OWNER.ORG.FNAME>", модель.OwnerOrgFname);
                
                ownerSignatureTable.Rows[0].Cells[2].Paragraphs[0].ReplaceText("<OWNER.SHORTNAME>",
                    модель.OwnerShortName);
            }
        }
    }
}