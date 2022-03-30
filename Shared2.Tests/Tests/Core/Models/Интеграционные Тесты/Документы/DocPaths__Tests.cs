using System;
using QWERTY.Shared.Doc;
using QWERTY.Shared2.Tests.Tests.Core.Models.Модульные_Тесты;
using NSubstitute;
using NUnit.Framework;
using Init = QWERTY.Shared2.Tests.Обслуживание_Тестов.Init;
using static QWERTY.Shared.Enums.БуквенныеКодыТиповЗаявок;

namespace QWERTY.Shared2.Tests.Tests.Core.Models.Интеграционные_Тесты.Документы
{
    [TestFixture]
    public class DocPaths__Tests : Init
    {
        [Test]
        public void ПроверяемГенерациюПутей()
        {
            const string буквенныйКодТипаЗаявки = "буквенныйКодТипаЗаявки";
            const string полученноеИмяШаблона = "ИмяШаблонаЗаявкаНаСозданиеЗащищаемогоРесурсаЗЛИВС";
                        
            const string AppDataPath = "C:\\App";
            var dp = new DocPaths(AppDataPath, "templates", "docs");
            
            const string documentFileName = "documentFileName.txt";
            const string? templateFileName = "templateFileName.txt";
            
            dp.CreateFullPaths(templateFileName, documentFileName);

            Assert.AreEqual(
                dp.DocumentFullPathName,
                "C:\\App\\docs\\documentFileName.txt"
            );
            
            Assert.AreEqual(
                dp.TemplateFullPathName,
                "C:\\App\\templates\\templateFileName.txt"
            );
        }
    }
}