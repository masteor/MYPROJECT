using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AutoFixture;
using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Db.Services;
using QWERTY.Shared.Enums;
using QWERTY.Shared.Models;
using QWERTY.Shared.Models._Создатель;
using QWERTY.Shared.Models.Заявки;
using QWERTY.Shared.Models.Заявки.Заявка_на_предоставление_доступа_к_защищаемым_ресурсам;
using QWERTY.Shared.Models.Заявки.Заявка_на_создание_защищаемого_ресурса;
using QWERTY.Shared.Models.Заявки.Заявка_на_создание_профиля_доступа_на_ресурс;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using log4net;
using NUnit.Framework;
using static QWERTY.Shared2.Tests.Обслуживание_Тестов.TestHelper;

namespace QWERTY.Shared2.Tests.Tests.Core.Models.Модульные_Тесты
{
    public abstract class InitModule
    {
        private protected readonly ICommonService _commonService;
        private protected readonly ILog log;

        private protected int идПользователяСервиса;
        private protected int идДругогоПользователяСервиса;
        // private protected int идТипаЗаявки;
        private protected string буквенныйКодСтатусаЗаявки;

        private protected readonly REQUEST? РодительскаяЗаявка;

        private protected readonly LOGIN ЛогинПользователяСервиса;
        private protected const string логинПользователяСервиса = "kirillovanm";
        private protected static string? емайлПользователяСервиса;
        
        private protected readonly EMPLOYEE ПользовательСервиса;
        private protected IEnumerable<REQUEST_TYPE> типыЗаявок;
        private protected static Fixture? _fixture;

        /*private protected ДанныеИзФормы_ПредоставлениеПравСубъектам_модель? данныеИзФормыПредоставлениеПравСубъектамМодель;
        private protected  ДанныеИзФормы данныеИзФормы;
        private protected  ДанныеИзФормы_СозданиеЗащищаемогоРесурса_модель данныеИзФормыСозданиеЗащищаемогоРесурсаМодель;
        private protected  ДанныеИзФормы_СозданиеПрофиляДоступа_модель данныеИзФормыСозданиеПрофиляДоступаМодель;*/
        
        private protected InitModule()
        {
            _fixture = new Fixture();
            
            типыЗаявок = new List<REQUEST_TYPE>
            {
                new REQUEST_TYPE
                {
                    id = 17,
                    code = БуквенныеКодыТиповЗаявок.ЗаявкаНаПредоставлениеДоступаСубъектам,
                },
            };
            
            
            log = Substitute.For<ILog>();
            _commonService = Substitute.For<ICommonService>();
            
            
            емайлПользователяСервиса = ПолучитьЕмайлИзЛогина(логинПользователяСервиса);
            
            идПользователяСервиса = 2222;
            идДругогоПользователяСервиса = 2233;
            буквенныйКодСтатусаЗаявки = БуквенныеКодыСтатусовЗаявок.Зарегистрирована;
            
            РодительскаяЗаявка = new REQUEST
            {
                id = (int) ПолучитьФикстуру<uint>(),
                id_request_type = 0,
                date_1 = default,
                date_2 = null,
                id_user_1 = 0,
                id_user_2 = 0,
                id_request_state = 0,
                id_doc = null,
                reg_num = null,
                parent = null,
            };
            
            ПользовательСервиса = new EMPLOYEE
            {
                id = идПользователяСервиса,
                tnum = null,
                id_job = null,
                id_form_perm = null,
                id_fio = null,
                job_begin_date = null,
                job_end_date = null,
                ид_актуальной_записи = null,
                ид_заявки_создания = null,
                ид_заявки_удаления = null,
            };
            
            ЛогинПользователяСервиса = new LOGIN
            {
                id = 1111,
                name = логинПользователяСервиса,
                email = емайлПользователяСервиса,
                id_user = идПользователяСервиса,
                id_domen = 0,
                id_request_0 = null,
                id_request_1 = null,
                id_request_2 = null,
                is_active = true
            };

            _commonService
                .ПолучитьЛогинПоИмениЛогина(ЛогинПользователяСервиса.name)
                .Returns(ЛогинПользователяСервиса);
            
            _commonService
                .ПолучитьПользователяПоИд(идПользователяСервиса)
                .Returns(ПользовательСервиса);

            foreach (var rt in типыЗаявок)
                _commonService
                    .ПолучитьТипЗаявкиПоИмениТипа(rt.code ?? throw new ArgumentNullException(nameof(rt.code)))
                    .Returns(new REQUEST_TYPE
                    {
                        id = rt.id
                    });

            _commonService
                .ПолучитьСтатусЗаявкиПоКоду(Arg.Any<string>())
                .Returns(arg =>
                {
                    
                    return new REQUEST_STATE
                    {
                        id = ПолучитьФикстуру<int>(),
                        name = ПолучитьФикстуру<string>(),
                        code = (string) arg[0]
                    };
                });

            /*_commonService
                .НайтиСтатусЗаявкиПоКоду(
                    Arg.Is<string>(s => !string.Equals(s, буквенныйКодСтатусаЗаявки,
                        StringComparison.OrdinalIgnoreCase)))
                .Throws(new InvalidOperationException($"код статуса заявки не найден"));*/

            #region Создать
            
            _commonService
                .Создать(Arg.Any<REQUEST>()).Returns(arg =>
                {
                    var request = (REQUEST) arg[0];
                    request.id = (int) ПолучитьФикстуру<uint>();
                    return request;
                });
            
            _commonService
                .Создать(Arg.Any<MEMBER>()).Returns(arg =>
                {
                    var member = (MEMBER) arg[0];
                    member.id = (int) ПолучитьФикстуру<uint>();
                    return member;
                });
            
            _commonService
                .Создать(Arg.Any<PROFILE>()).Returns(arg =>
                {
                    var profile = (PROFILE) arg[0];
                    profile.id = (int) ПолучитьФикстуру<uint>();
                    return profile;
                });
            
            _commonService
                .Создать(Arg.Any<OBJECT>()).Returns(arg =>
                {
                    var o = (OBJECT) arg[0];
                    o.id = (int) ПолучитьФикстуру<uint>();
                    return o;
                });
            
            _commonService
                .Создать(Arg.Any<RESOURCE>()).Returns(arg =>
                {
                    var o = (RESOURCE) arg[0];
                    o.id = (int) ПолучитьФикстуру<uint>();
                    return o;
                });
            
            _commonService
                .Создать(Arg.Any<RIGHT>()).Returns(arg =>
                {
                    var o = (RIGHT) arg[0];
                    o.id = (int) ПолучитьФикстуру<uint>();
                    return o;
                });
            
            _commonService
                .Создать(Arg.Any<RESOURCE_MEMBER>()).Returns(arg =>
                {
                    var o = (RESOURCE_MEMBER) arg[0];
                    o.id = ПолучитьФикстуру<int>();
                    return o;
                });
            
            _commonService
                .Создать(Arg.Any<DOC>()).Returns(arg =>
                {
                    var o = (DOC) arg[0];
                    o.id = ПолучитьФикстуру<int>();
                    return o;
                });
            
            #endregion


            #region ПолучитьТипЗаявкиПоИмениТипа

            _commonService
                .ПолучитьТипЗаявкиПоИмениТипа("CREATE_OBJECT")
                .Returns(new REQUEST_TYPE
                {
                    id = ПолучитьФикстуру<int>(),
                    name = "Cоздание сущности объект ресурса",
                    sdescription = string.Empty,
                    id_parent = null,
                    maintenance = null,
                    code = "CREATE_OBJECT",
                });
            
            _commonService
                .ПолучитьТипЗаявкиПоИмениТипа("CREATE_RIGHT")
                .Returns(new REQUEST_TYPE
                {
                    id = ПолучитьФикстуру<int>(),
                    name = "Создание сущности RIGHT",
                    sdescription = string.Empty,
                    id_parent = null,
                    maintenance = null,
                    code = "CREATE_RIGHT",
                });

            _commonService
                .ПолучитьТипЗаявкиПоИмениТипа("CREATE_DOC")
                .Returns(new REQUEST_TYPE
                {
                    id = ПолучитьФикстуру<int>(),
                    name = "Создание сущности DOC",
                    sdescription = string.Empty,
                    id_parent = null,
                    maintenance = null,
                    code = "CREATE_DOC",
                });
                

            #endregion

            #region ПолучитьЗаявкуПоИд

            _commonService
                .ПолучитьЗаявкуПоИд(Arg.Any<int>())
                .Returns(arg =>
                {
                    var id = (int) arg[0];
                    var requestNoParent = ПолучитьФикстуру_REQUEST_NoParent();
                    requestNoParent.id = id;
                    return requestNoParent;
                });

            #endregion

            _commonService
                .ПолучитьСтатусЗаявкиПоИд(Arg.Any<int>())
                .Returns(ПолучитьФикстуру<REQUEST_STATE>());
        }

        protected ДанныеИзФормы ПолучитьВалиднуюМодель_ДанныеИзФормы() 
            =>
            new ДанныеИзФормы()
            {
                id = null,
                request_params = ПолучитьВалиднуюМодель_RequestParams()
            };

        private protected RequestParams ПолучитьВалиднуюМодель_RequestParams()
            =>
                ПолучитьВалиднуюМодель_RequestParams(логинПользователяСервиса);
        
        private protected RequestParams ПолучитьВалиднуюМодель_RequestParams(string? senderLogin) 
            => 
                new RequestParams
                {
                    create_date_time = null,
                    end_date_time = null,
                    sender_login = senderLogin,
                    recipient_login = null,
                    request_state_id = 1,
                    doc = new byte?[]
                    {
                    },
                    reg_number = null,
                    parent = null
                };

        private protected Создатель<T> ПолучитьВалиднуюМодель_Создатель_ДанныеИзФормы_N5<T>(T модель, REQUEST? родительскаяЗаявка) where T : ДанныеИзФормы
            =>
            new Создатель<T>(
                _commonService,
                log,
                модель.request_params?.sender_login,
                модель,
                родительскаяЗаявка
            );

        private protected T ПолучитьВалиднуюМодель_ДанныеИзФормы_Fixture<T>() where T : ДанныеИзФормы
            =>
            ДобавитьВоМодельКорректный_request_params_sender_login(
                ПолучитьФикстуру<T>());

        protected internal static T ПолучитьФикстуру<T>()
        {
            _fixture ??= new Fixture();
            return _fixture.Create<T>();
        }

        protected static PROFILE ПолучитьФикстуру_PROFILE() =>
            new PROFILE
            {
                id = ПолучитьФикстуру<int>(),
                name = ПолучитьФикстуру<string>(),
                id_request_1 = ПолучитьФикстуру<int>(),
                ид_заявки_на_удаление = null
            };
        
        protected static RequestParams ПолучитьФикстуру_RequestParams()
        {
            try
            {
                var requestParams = new RequestParams
                {
                    create_date_time = ПолучитьФикстуру<DateTime>(),
                    end_date_time = null,
                    sender_login = ПолучитьФикстуру<string>(),
                    recipient_login = ПолучитьФикстуру<string>(),
                    request_state_id = ПолучитьФикстуру<int>(),
                    doc = new byte?[] { },
                    reg_number = ПолучитьФикстуру<string>(),
                    parent = null
                };
            
                return requestParams;
            }
            catch (Exception e)
            {
                PrintTestContext(e.Message);
                throw;
            }
        }

        protected static REQUEST ПолучитьФикстуру_REQUEST_NoParent()
        {
            var _дата_создания = ПолучитьФикстуру<DateTime>();
            var _ид_пользователя_подавшего_заявку = ПолучитьФикстуру<int>();

            return new REQUEST
            {
                id = ПолучитьФикстуру<int>(),
                id_request_type = ПолучитьФикстуру<int>(),
                date_1 = _дата_создания,
                date_2 = _дата_создания,
                id_user_1 = _ид_пользователя_подавшего_заявку,
                id_user_2 = _ид_пользователя_подавшего_заявку,
                id_request_state = ПолучитьФикстуру<int>(),
                id_doc = ПолучитьФикстуру<int>(),
                reg_num = ПолучитьФикстуру<string>(),
                parent = null,
            };
        }

        private protected T ДобавитьВоМодельКорректный_request_params_sender_login<T>(T модель) where T : ДанныеИзФормы
        {
            if (модель.request_params == null)
                throw new ArgumentNullException(nameof(модель.request_params));

            модель.request_params.sender_login = логинПользователяСервиса;
            return модель;
        }

        protected string ПолучитьЕмайлИзЛогина(string логин) 
            => 
                логин + "@sils.local";
        
        
        public struct Сообщения
        {
            public struct Модели
            {
                public const string МодельДолжнаВернутьОшибки = "модель должна вернуть ошибки, а их нет";
                public const string МодельНеДолжнаВернутьОшибки = "модель не должна вернуть ошибки, а они есть";
            }
        }
        
        protected static List<REQUEST> СоздатьНовыйСписок_REQUEST(int[] идЗаявок, int идТекущегоСтатусаЗаявки)
        {
            REQUEST[] requests = new REQUEST[идЗаявок.Length];
            for (var i = 0; i < идЗаявок.Length; i++)
                requests[i] = new REQUEST
                {
                    id = идЗаявок[i],
                    id_request_state = идТекущегоСтатусаЗаявки
                };
            return requests.ToList();
        }
    }
}