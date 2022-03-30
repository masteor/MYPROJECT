using System;
using System.Threading.Tasks;
using QWERTY.Shared.Doc;
using QWERTY.Shared.Models.Заявки;
using QWERTY.Shared2.Tests.Обслуживание_Тестов;
using NSubstitute;
using NSubstitute.Core.Arguments;
using NUnit.Framework;
using static QWERTY.Shared.Enums.БуквенныеКодыТиповЗаявок;

namespace QWERTY.Shared2.Tests.Tests.Core.Models.Интеграционные_Тесты.Документы
{
    [TestFixture]
    public class Документ__ЗаявкаНаСозданиеЗащищаемогоРесурсаЗЛИВС__Тесты : Init
    {
        [Test]
        public void СоздаетсяИСохраняется_Документ_СозданиеЗащищаемогоРесурсаЗЛИВС_модель()
        {
            IDocument document = new Document(CommonService!, Log!, docPaths);
            
            // готовим модель создаваемого документа 
            var модельДокумента = new Документ_СозданиеЗащищаемогоРесурсаЗЛИВС_модель
                (CommonService, Log, 1223);
                
            string? doc = null;
            TestDelegate t1 = () =>
            {
                doc = document
                    .СоздатьИСохранитьВоХранилище(модельДокумента,
                        ЗаявкаНаСозданиеЗащищаемогоРесурсаЗЛИВС
                    );
            };
            
            Assert.DoesNotThrow(t1);
            Assert.NotNull(doc, "Документ_СозданиеЗащищаемогоРесурсаЗЛИВС_модель не создан");
        }

        [Test]
        public void СчитываемСуществующийФайл__ФайлСчитывается_ИсключенийНет()
        {
            IDocument document = new Document(CommonService!, Log!, docPaths);
            DocPaths paths = new DocPaths(docPaths);
            paths.CreateFullPaths("test1.docx", "test2.docx");

            byte[]? templateBytes = null;
            void T1() => templateBytes = document.ПолучитьДокументИзХранилища(paths.TemplateFullPathName);

            byte[]? documentBytes = null;
            void T2() => documentBytes = document.ПолучитьДокументИзХранилища(paths.DocumentFullPathName);

            Assert.DoesNotThrow(T1);
            Assert.DoesNotThrow(T2);
            
            Assert.AreNotEqual(null, templateBytes);
            Assert.AreNotEqual(null, documentBytes);
            
            Assert.IsFalse(templateBytes?.Length < 1);
            Assert.IsFalse(documentBytes?.Length < 1);
        }
        
        [Test]
        public void СчитываемНеСуществующийФайл__ДанныхНет_ИсключенияЕсть()
        {
            IDocument document = new Document(CommonService!, Log!, docPaths);
            DocPaths paths = new DocPaths(docPaths);
            paths.CreateFullPaths("test1фывапрол.docx", "test2ячсмитьбю.docx");

            byte[]? templateBytes = null;
            void T1() => templateBytes = document.ПолучитьДокументИзХранилища(paths.TemplateFullPathName);

            byte[]? documentBytes = null;
            void T2() => documentBytes = document.ПолучитьДокументИзХранилища(paths.DocumentFullPathName);

            Assert.Throws<Exception>(T1);
            Assert.Throws<Exception>(T2);
            
            Assert.AreEqual(null, templateBytes);
            Assert.AreEqual(null, documentBytes);
        }

        /*[Test]
        public void НастройкаФайлаШаблона()
        {
            /*var paths = new DocPaths(docPaths);
            paths.CreateFullPaths(CommonService?
                    .ПолучитьИмяШаблонаЗаявки(ЗаявкаНаСозданиеЗащищаемогоРесурсаЗЛИВС), 
                Guid.NewGuid().ToString()
            );
            
            var doc = new Doc<>(Log)
                .СоздатьИСохранитьВоХранилище(
                    paths,
                    null,
                    ЗаявкаНаСозданиеЗащищаемогоРесурсаЗЛИВС
                );
            
            Assert.Pass();#1#
        }*/
        
    }
}