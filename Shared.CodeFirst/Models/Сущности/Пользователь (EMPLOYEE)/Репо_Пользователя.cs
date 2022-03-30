using System;
using DBPSA.Shared.Db.Entities.Таблицы;
using DBPSA.Shared.Db.Services;
using DBPSA.Shared.Extensions;
using DBPSA.Shared.Helpers;
using DBPSA.Shared.Models._Создатель;
using DBPSA.Shared.Models.ФИО;
using DBPSA.Shared.Properties;
using log4net;
using static DBPSA.Shared.Enums.ТипыЗаявок;

namespace DBPSA.Shared.Models.Пользователь
{
    public class Репо_Пользователя : Создатель<ДанныеИзФормы_СозданияПользователя_модель?>
    {
        private readonly FIO _fio;
        private readonly EMPLOYEE _employee;
        private readonly Репо_Заявку _заявка;

        public Репо_Пользователя
        (
            ICommonService commonService,
            ILog log,
            string? логинПользователяСервиса,
            ДанныеИзФормы_СозданияПользователя_модель? модель,
            Репо_Заявку? родительскаяЗаявка
        ) 
            : base(
                commonService,
                log,
                логинПользователяСервиса,
                модель,
                родительскаяЗаявка
            )
        {
            try
            {
                if (Ошибка != null) return;

                _заявка = создатьЗаявку(ЗаявкаНаСозданиеПользователя, модель, родительскаяЗаявка);

                if (_заявка.Ошибка.IsNotNull())
                {
                    Ошибка = _заявка.Ошибка;
                    return;
                }

                try
                {
                    _employee = СоздатьПользователяВ_БД(commonService, log, модель!, _заявка);
                    _fio = new Репо_ФИО
                        (
                            commonService,
                            log,
                            логинПользователяСервиса,
                            new ДанныеИзФормы_СозданияФИО_модель(модель!, _employee!),
                            _заявка
                        )
                        .Фио;
                }
                catch (Exception e)
                {
                    Ошибка = e;
                }
            }
            catch (Exception e)
            {
                Ошибка = e;
            }
            finally
            {
                if (Ошибка.IsNotNull()) log.Error(nameof(Репо_Заявку), Ошибка);
            }
        }

        public override object? ПолучитьJsonМодель() =>
            JsonHelper.СоздатьJsonМодель(new
                {
                    RequestId = _заявка.Заявка?.id,
                    EmployeeId = _employee?.id
                }, 
                Ошибка,
                $"Пользователь [{_fio?.ПолучитьКороткоеФИО}, таб.номер: {_employee?.tnum.ToString()}] успешно создан"
            );

        private EMPLOYEE СоздатьПользователяВ_БД(ICommonService commonService, ILog log, ДанныеИзФормы_СозданияПользователя_модель модель, Репо_Заявку заявка)
        {
            var employee = commonService?.Создать(new EMPLOYEE
            {
                tnum = (int) модель.tnum!,
                id_job = модель?.id_job,
                id_form_perm = модель?.id_form_perm,
                job_begin_date = модель?.job_begin_date, 
                job_end_date = null,
                ид_актуальной_записи = null,
                ид_заявки_создания = заявка.Заявка?.id,
                ид_заявки_удаления = null,
            });
            
            commonService?.Коммитнуть(typeof(EMPLOYEE));
            
            if (employee == null || employee.id < 1)
            {
                log.Error(Resources.Пользователь_не_создан);
                throw new Exception(Resources.Пользователь_не_создан);
            }
            
            return employee;
        }

        
    }
}