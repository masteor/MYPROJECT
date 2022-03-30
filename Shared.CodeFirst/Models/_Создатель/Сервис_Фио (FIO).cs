using System;
using DBPSA.Shared.Db.Services;
using DBPSA.Shared.Models.ФИО;

namespace DBPSA.Shared.Models._Создатель
{
    public partial class Создатель<T> where T : ДанныеИзФормы?
    {
        protected void ПроверитьНеСуществованиеФио(ICommonService commonService, ДанныеИзФормы_СозданияФИО_модель модель)
        {
            var fio = commonService.ПолучитьФИО(f => 
                string.Equals(f.family, модель.family, StringComparison.OrdinalIgnoreCase)
                && string.Equals(f.name, модель.name, StringComparison.OrdinalIgnoreCase)
                && string.Equals(f.patronymic, модель.patronymic, StringComparison.OrdinalIgnoreCase));
            
            if (fio != null)
            {
                throw new ArgumentException($"ФИО {модель.ПолучитьКороткоеФИО}, id={fio.id} уже существует");
            }
        }
        
        public Exception? УдалитьФиоЗаявка()
        {
            ЕслиДоЭтогоШагаВозниклаОшибкаБроситьИсключение();
            
            try
            {
                var f = CommonService?.ПолучитьФИО(fio => fio.id == Id) ?? throw new Exception($"ФИО с id={Id} не существует");
                
                Заявка = создатьЗаявку
                (
                    ТипыЗаявок.ЗаявкаНаУдалениеФио,
                    Модель,
                    РодительскаяЗаявка
                );
                
                if (Заявка.ПроизошлаОшибка) throw Заявка.Ошибка!;
                
                Result = JsonHelper.СоздатьJsonМодель(Ошибка, $"Заявка на удаление ФИО с id={Id} отправлена");
            }
            catch (Exception e)
            {
                Ошибка = e;
                Result = JsonHelper.СоздатьJsonМодель(Ошибка);
                throw;
            }

            return Ошибка;
        }
        
        public Exception? СоздатьФиоЗаявка()
        {
            try
            {
                ЕслиДоЭтогоШагаВозниклаОшибкаБроситьИсключение();
            
                ПроверитьНеСуществованиеФио(
                    CommonService,
                    (ДанныеИзФормы_СозданияФИО_модель) Модель
                );
                
                ПроверитьСуществованиеПользователя(
                    CommonService,
                    (int) ((ДанныеИзФормы_СозданияФИО_модель) Модель).id_user!
                );
                
                Заявка = создатьЗаявку
                (
                    ТипыЗаявок.ЗаявкаНаСозданиеФио,
                    Модель,
                    РодительскаяЗаявка
                );
                
                Фио = СоздатьФиоВ_БД
                (
                    CommonService,
                    Log,
                    (ДанныеИзФормы_СозданияФИО_модель) Модель,
                    Заявка
                );
                
                Result = JsonHelper.СоздатьJsonМодель(
                    new
                    {
                        requestId = Заявка?.Заявка?.id,
                        fioId = Фио?.id
                    }, 
                    Ошибка,
                    $"Заявка на создание ФИО [{Фио?.ПолучитьКороткоеФИО}] успешно создано");
            }
            catch (Exception e)
            {
                Ошибка = e;
                Result = JsonHelper.СоздатьJsonМодель(Ошибка);
                throw;
            }
            
            return Ошибка;
        }
        
        public FIO СоздатьФиоВ_БД
        (
            ICommonService commonService,
            ILog log,
            ДанныеИзФормы_СозданияФИО_модель модель,
            Репо_Заявку заявка
        )
        {
            var фио = commonService?.Создать(
                new FIO
                {
                    id_user = модель.id_user, 
                    family = модель.family!,
                    name = модель.name!,
                    patronymic = модель.patronymic!,
                    ид_заявки_на_создание = (int) заявка.Заявка?.id,
                    ид_заявки_на_удаление = null,
                    id_new = null
                });
            
            commonService.Коммитнуть(typeof(FIO));
            
            if (фио == null || фио.id < 1)
            {
                log.Error("ФИО не создано");
                throw new Exception("ФИО не создано");
            }

            return фио;
        }
    }
}