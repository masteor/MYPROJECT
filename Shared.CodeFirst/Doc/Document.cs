using System;
using System.IO;
using System.Threading.Tasks;
using QWERTY.Shared.Db.Services;
using QWERTY.Shared.Enums;
using QWERTY.Shared.Helpers;
using QWERTY.Shared.Models;
using QWERTY.Shared.Models.Заявки;
using log4net;
using Xceed.Words.NET;
using static QWERTY.Shared.Enums.БуквенныеКодыТиповЗаявок;

namespace QWERTY.Shared.Doc
{
    public interface IDocument
    {
        string? СоздатьИСохранитьВоХранилище<T>(
            
            T? модель,
            string? типЗаявки
        ) where T : class;

        byte[] ПолучитьДокументИзХранилища(string fullPath);
    }
    
    public partial class Document : IDocument
    {
        private readonly ICommonService _commonService;
        private readonly ILog _log;
        private readonly DocPaths _docPaths;

        public Document(ICommonService? commonService, ILog? log, DocPaths? docPaths)
        {
            _commonService = commonService ?? throw new ArgumentNullException(nameof(log));
            _log = log ?? throw new ArgumentNullException(nameof(log));
            _docPaths = docPaths ?? throw new ArgumentNullException(nameof(docPaths));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="модель"></param>
        /// <param name="типЗаявки"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns>Полный путь до созданного документа, </returns>
        /// <returns>null - если возникла ошибка при создании</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public string? СоздатьИСохранитьВоХранилище<T>(T? модель,
            string? типЗаявки) where T : class
        {
            
            if (модель == null) throw new ArgumentNullException(nameof(модель));
            if (типЗаявки == null) throw new ArgumentNullException(nameof(типЗаявки));

            try
            {
                // готовим полные пути сохранения документа на основе путей, 
                // которые нам выдало приложение
                var paths = new DocPaths(_docPaths);
                paths.CreateFullPaths(_commonService?
                        .ПолучитьИмяШаблонаЗаявки(типЗаявки), 
                    Guid.NewGuid().ToString() + ".docx"
                );
                
                using var  doc = DocX.Create(paths.DocumentFullPathName);
                
                // создаем новый пустой файл по указанному пути
                
                doc.ApplyTemplate(paths.TemplateFullPathName);
                ОбработатьДокументПоМодели(doc, модель, типЗаявки);
                doc.Save();
                return paths.DocumentFullPathName;
            }
            catch (Exception e)
            {
                _log.Error($"Не удалось создать документ с шаблоном: {_docPaths.TemplateFullPathName} и " +
                            $"и типом модели {typeof(T)}", e);
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fullPath">Полный путь к открываемому файлу</param>
        /// <returns></returns>
        /// <exception cref="Exception">если файл пустой</exception>
        public byte[] ПолучитьДокументИзХранилища(string fullPath)
        {
            try
            {
                byte[] arr = new byte[] { };
                if (!File.Exists(fullPath)) 
                    throw new Exception($"По данному пути: {fullPath} файл не найден");
            
                using FileStream fs = File.OpenRead(fullPath);
                arr = new byte[fs.Length];
                fs.Read(arr, 0, arr.Length);
                if (arr.Length < 1)
                    throw new Exception($"Файл {fullPath} не может быть прочитан");
                return arr;
            }
            catch (Exception e)
            {
                _log.Error($"Ошибка в методе {nameof(ПолучитьДокументИзХранилища)}", e);
                throw;
            }
        }

        public void ОбработатьДокументПоМодели<T>(DocX doc, T модель, string типЗаявки) where T : class
        {
            switch (типЗаявки)
            {
                case ЗаявкаНаСозданиеЗащищаемогоРесурсаЗЛИВС:
                {
                    ОбработатьДокументЗаявкаНаСозданиеЗащищаемогоРесурсаЗЛИВС(doc, модель);
                    break;
                }
                default:
                    throw new NotImplementedException();
                    break;
            }    
        }

        
    }
}