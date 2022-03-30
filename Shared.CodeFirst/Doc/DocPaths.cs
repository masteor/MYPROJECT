using System;
using QWERTY.Shared.Extensions;

namespace QWERTY.Shared.Doc
{
    public class DocPaths
    {
        public DocPaths()
        {
            
        }

        public DocPaths(string appDataPath, string templatePath, string documentPath)
        {
            AppDataPath = appDataPath.EndsWith("\\").Нет() ? appDataPath + "\\" : appDataPath;
            TemplatePath = AppDataPath + templatePath + "\\";
            DocumentPath = AppDataPath + documentPath + "\\";
        }

        public void CreateFullPaths(string? templateFileName, string? documentFileName)
        {
            TemplateFullPathName = TemplatePath + templateFileName;
            DocumentFullPathName = DocumentPath + documentFileName;
        }

        public string TemplateFullPathName = ""; 
        public string DocumentFullPathName = "";
        
        public readonly string? AppDataPath = string.Empty;
        public readonly string? TemplatePath = string.Empty;
        public readonly string? DocumentPath = string.Empty;

        public DocPaths(DocPaths _)
        {
            AppDataPath = _.AppDataPath;
            
            TemplatePath = _.TemplatePath;
            DocumentPath = _.DocumentPath;
            
            TemplateFullPathName = _.TemplateFullPathName;
            DocumentFullPathName = _.DocumentFullPathName;
        }
    }
}