#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Autofac;
using Autofac.Features.OwnedInstances;
using QWERTY.Shared.Db.Infrastructure;
using QWERTY.Shared.Db.Repositories;
using QWERTY.Shared.Db.Services;
using QWERTY.Shared.Doc;
using log4net;
using log4net.Core;
using NSubstitute;
using NUnit.Framework;


// using IContainer = Autofac.IContainer;

namespace QWERTY.Shared2.Tests.Обслуживание_Тестов
{
    public abstract class Init
    {
        protected int _ID = 1855;
        
        protected static DbFactory DB_FACTORY => new DbFactory("QWERTY");

        protected ISYSRL_Repository? _sysrlRepository;
        protected IATTRI_Repository? _attriRepository;
        protected ICommonService? CommonService;
        protected IContainer? _container;
        protected readonly ILog? Log;
        private protected readonly DocPaths docPaths;
        private readonly string AppDataPath;
        internal Owned<T>? ScopedService<T>() => _container?.Resolve<Owned<T>>();
        
        protected Init()
        {
            AppDataPath = AppDomain.CurrentDomain.BaseDirectory;
            docPaths = new DocPaths(AppDataPath, @"templates", @"docs");
            
            Log = Substitute.For<ILog>() ?? throw new NullReferenceException(); // заглушка
            _container = Bootstrapper.SetAutofacContainer();
            
            CommonService = ScopedService<ICommonService>()?.Value ?? throw new NullReferenceException();
            _sysrlRepository = new SYSRL_Repository(DB_FACTORY);
            _attriRepository = new ATTRI_Repository(DB_FACTORY);
        }
    }
    
    
    internal class Bootstrapper
    {
        internal static IContainer SetAutofacContainer()
        {
            var builder = new ContainerBuilder();
            
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            
            builder.Register(context => new DbFactory("QWERTY"))
                .As<IDbFactory>();
            
            // Repositories
            builder.RegisterAssemblyTypes(typeof(EMPLOYEE_Repository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();
            
            builder.RegisterAssemblyTypes(typeof(Common_Service).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces();

            return builder.Build();
        }
    }
}