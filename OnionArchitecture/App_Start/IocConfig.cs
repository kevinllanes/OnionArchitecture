using System.Reflection;
using Autofac;
using Autofac.Integration.Mvc;
using OnionArchitecture;
using OnionArchitecture.Core.Data;
using OnionArchitecture.Core.Services;
using OnionArchitecture.Data.Data;
using OnionArchitecture.Infrastructure.Logging;
using OnionArchitecture.Services;
using System.Web.Mvc;
using OnionArchitecture.Core.Logging;
using OnionArchitecture.Data;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(IocConfig), "RegisterDependencies")]

namespace OnionArchitecture
{
    public class IocConfig
    {
        public static void Run()
        {
            RegisterDependencies();
        }

        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();
            const string nameOrConnectionString = "name=OnionArchitectureConnection";


            //builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterModule<AutofacWebTypesModule>();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerRequest();
            builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>)).InstancePerRequest();
            builder.RegisterType(typeof(UnitOfWork)).As(typeof(IUnitOfWork)).InstancePerRequest();
            builder.Register<IEntitiesContext>(b =>
            {
                var logger = b.Resolve<ILogger>();
                var context = new ApplicationDbContext(nameOrConnectionString, logger);
                return context;
            }).InstancePerRequest();

            builder.Register(b => NLogLogger.Instance).SingleInstance();
            builder.RegisterModule(new IdentityModule());

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
