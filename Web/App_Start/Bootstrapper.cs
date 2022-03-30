using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using QWERTY.Shared.Db.Infrastructure;
using QWERTY.Shared.Db.Repositories;
using QWERTY.Shared.Db.Services;
using QWERTY.Web.Core.Authentication;
using QWERTY.Web.Properties;

namespace QWERTY.Web
{
    internal class Bootstrapper
    {
        internal static void Run(Settings settings)
        {
            SetAutofacContainer(settings: settings);
        }

        internal static void SetAutofacContainer(Settings settings)
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();

            // configuration access
            /*builder.Register(context => new ConfigHelper(settings))
                .As<IConfigHelper>()
                .SingleInstance();*/

            // Properties.Settings.Default.DbConnectionString

            // datasource
            builder.Register(@delegate: context => new DbFactory("QWERTY"))
                .As<IDbFactory>()
                .InstancePerRequest();

            /*builder.Register(myStruct => new MyStruct()).As<IMyStruct>().InstancePerRequest();*/
            /* messaging support
            builder.Register(context => new MqHelper(settings.MqPath))
                .As<IMqHelper>()
                .SingleInstance();*/

            // Repositories
            builder.RegisterAssemblyTypes(typeof(EMPLOYEE_Repository).Assembly)
                   .Where(predicate: t => t.Name.EndsWith(value: "Repository"))
                   .AsImplementedInterfaces()
                   .InstancePerRequest();

            // Services
            /*builder.RegisterAssemblyTypes(typeof (EMPLOYEE_Service).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerRequest();*/

            builder.RegisterAssemblyTypes(typeof (Common_Service).Assembly)
                .Where(predicate: t => t.Name.EndsWith(value: "Service"))
                .AsImplementedInterfaces()
                .InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof (UserAccount).Assembly)
                .AsImplementedInterfaces()
                .InstancePerRequest();

            /*// configure message sender dependency
            if (!String.IsNullOrEmpty(settings.MailHost))
            {
                builder.RegisterType<MailSender>()
                    .As<IMessageSender>()
                    .InstancePerRequest();
            }
            else if (!String.IsNullOrEmpty(settings.JabberServer))
            {
                builder.RegisterType<JabberMessageSender>()
                    .As<IMessageSender>()
                    .InstancePerRequest();
            }
            else
            {
                builder.RegisterType<LogFileSender>()
                    .As<IMessageSender>()
                    .InstancePerRequest();
            }*/

            // configure Autofac to be used as default dependecy source in application

            DependencyResolver.SetResolver(resolver: new AutofacDependencyResolver(container: builder.Build()));
        }
    }
}
