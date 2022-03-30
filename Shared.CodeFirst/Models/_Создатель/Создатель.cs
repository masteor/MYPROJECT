using System;
using QWERTY.Shared.Db;
using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Db.Services;
using QWERTY.Shared.Enums;
using QWERTY.Shared.Log;
using log4net;

namespace QWERTY.Shared.Models._Создатель
{
    public partial class Создатель<T> where T : ДанныеИзФормы
    {
        private protected int? Id;
        private protected readonly T Модель;
        private protected readonly string ЛогинПользователяСервиса;
        private protected readonly REQUEST? РодительскаяЗаявка;
        // protected internal REQUEST? Заявка { get; set; }

        public Exception? Ошибка
        {
            get => _ошибка;
            protected internal set
            {
                _ошибка = value;
                if (value != null)
                    _logger?.ОтправитьОшибкуВ_Лог(value);
                else
                    Log.Info($"Инициализация свойства Ошибка для {typeof(T)}");
            }
        }

        
        public bool ПроизошлаОшибка => Ошибка != null;
        

        public void СохранитьОшибку(Exception? exception)
        {
            Ошибка = exception;
        }

        private protected object? Result;
        // private object? _model;
        private ICommonService CommonService { get; }
        // private string _логинПользователяСервиса;
        protected readonly БуквенныеКодыТиповЗаявок БуквенныеКодыТиповЗаявок = new БуквенныеКодыТиповЗаявок();
        private protected EMPLOYEE? ПользовательСервиса;

        private ILogger? _logger;

        private Exception? _ошибка;
        // private protected T Модель { get; set; }
        
        private protected ILog Log { get; set; }

        public Создатель // тест +
        (
            ICommonService? commonService,
            ILog? log,
            string? логинПользователяСервиса,
            T? модель,
            REQUEST? родительскаяЗаявка
        ) 
            
            : this(commonService, log, логинПользователяСервиса, родительскаяЗаявка)
        {
            try
            {
                var unused = new ЧекнутьДанные<T>(модель);

                Модель = модель!;
                Id = Модель?.id;
            }
            catch (Exception e)
            {
                Ошибка = e;
                throw;
            }
        }

        public Создатель
        (
            ICommonService commonService,
            ILog log,
            int? id
        )
            : this(commonService, log)
        {
            
            // Проверить<int>(i => i < 1, id, new ArgumentOutOfRangeException(nameof(id)));
            try
            {
                throw new NotImplementedException();
                if (id == null || id < 1) throw new ArgumentOutOfRangeException(nameof(id));
                Id = (int) id;
            }
            catch (Exception e)
            {
                Ошибка = e;
                throw;
            }
        }

        public Создатель() // тест +
        {
            throw new NotImplementedException();
        }

        public Создатель // тест + 
        (
            ICommonService? commonService,
            ILog? log,
            REQUEST? родительскаяЗаявка
        )
            : this(commonService, log) => РодительскаяЗаявка = родительскаяЗаявка;

        public Создатель // тест +
        (
            ICommonService? commonService,
            ILog? log
        )
        {
            try
            {
                Log = log ?? throw new ArgumentNullException(nameof(log));
                _logger = new Logger(Log) ?? throw new ArgumentNullException(nameof(_logger));
                CommonService = commonService ?? throw new ArgumentNullException(nameof(commonService));
            }
            catch (Exception e)
            {
                Ошибка = e;
                throw;
            }
        }

        public Создатель // тест +
        (
            ICommonService? commonService,
            ILog? log,
            string? логинПользователяСервиса,
            REQUEST? родительскаяЗаявка
        )
            : this(commonService, log, родительскаяЗаявка)
        {
            try
            {
                ЛогинПользователяСервиса = логинПользователяСервиса ?? throw new ArgumentNullException(nameof(логинПользователяСервиса));;
                
                var получитьЛогин = commonService?
                    .ПолучитьЛогинПоИмениЛогина(ЛогинПользователяСервиса);

                if (получитьЛогин == null) throw new ArgumentNullException(nameof(получитьЛогин));

                ПользовательСервиса = commonService?
                                           .ПолучитьПользователяПоИд(получитьЛогин.id_user)
                                       ?? throw new ArgumentNullException(nameof(ПользовательСервиса));
            }
            catch (Exception e)
            {
                Ошибка = e;
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="типЗаявки"></param>
        /// <param name="entity"></param>
        /// <param name="requestParams"></param>
        /// <param name="родительскаяЗаявка"></param>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public TEntity СоздатьСущность<TEntity>(
            string типЗаявки,
            TEntity entity,
            RequestParams requestParams,
            REQUEST? родительскаяЗаявка
        ) 
            where TEntity : Id
        {
            
            var заявка = СоздатьЗаявкуПоИмениТипа
                (типЗаявки, requestParams, родительскаяЗаявка);

            entity.id_request_1 = заявка.id;
            var сущность = CommonService.Создать(entity);
            
            CommonService.Коммитнуть(typeof(TEntity));

            if (сущность == null || сущность.id < 1)
                throw new Exception($"{типЗаявки} не выполнена. Обратитесь к администратору сервиса. идЗаявка={заявка.id}");

            return сущность;
        }
        
        public TEntity СоздатьСущностьПоРодительскойЗаявке <TEntity>(
            string типЗаявки,
            TEntity entity,
            RequestParams requestParams,
            REQUEST заявка
        ) 
            where TEntity : Id
        {
            /*var заявка = СоздатьЗаявкуПоИмениТипа
                (типЗаявки, requestParams, родительскаяЗаявка);*/

            entity.id_request_1 = заявка.id;
            var сущность = CommonService.Создать(entity);
            
            CommonService.Коммитнуть(typeof(TEntity));

            if (сущность == null || сущность.id < 1)
                throw new Exception($"{типЗаявки} не выполнена. Обратитесь к администратору сервиса. идЗаявка={заявка.id}");

            return сущность;
        }
        
        public object ToObject<TClass>(TClass t) where TClass : class => new{t};


        public void ЕслиДоЭтогоШагаВозниклаОшибкаБроситьИсключение()
        {
            if (ПроизошлаОшибка) throw Ошибка!;
        } 

        public virtual object? ПолучитьJsonМодель() => Result; 
            // throw new NotImplementedException(message: "метод должен быть переопределен");
            
        private REQUEST ПолучитьЗаявкуПоИдИлиБроситьИсключение(int ид) 
            =>
            CommonService.ПолучитьЗаявкуПоИд(ид) 
            ?? throw new Exception($"Не могу получить заявку по ид=({ид})");
    }
}