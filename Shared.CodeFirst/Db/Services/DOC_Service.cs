using System;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Shared.Db.Services
{
    public partial interface ICommonService
    {
        DOC_TYPE? ПолучитьТипДокумента(string формуляр);
        DOC ПолучитьДокументПоИд(int идДокумента);
    }
    public partial class Common_Service // DOC_Service
    {
        public DOC_TYPE? ПолучитьТипДокумента(string формуляр) => 
            _docTypeRepository?.Найти(r => string.Equals(r.name, формуляр, StringComparison.OrdinalIgnoreCase));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="идДокумента"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">если документ с ид не найден в базе</exception>
        public DOC ПолучитьДокументПоИд(int идДокумента) => 
            _docRepository?.GetById(идДокумента) 
            ?? throw new ArgumentException($"документ с ид={идДокумента} не найден в базе");
    }
}