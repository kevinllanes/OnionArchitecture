using Autofac;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using OnionArchitecture.Core.Data.Identity;
using OnionArchitecture.Data;
using OnionArchitecture.Data.Identity;
using OnionArchitecture.Data.Identity.Models;
using System.Data.Entity;
using System.Web;

namespace OnionArchitecture
{
    public class IdentityModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType(typeof(ApplicationUserManager)).As(typeof(IApplicationUserManager)).InstancePerRequest();
            builder.RegisterType(typeof(ApplicationRoleManager)).As(typeof(IApplicationRoleManager)).InstancePerRequest();
            builder.RegisterType(typeof(ApplicationIdentityUser)).As(typeof(IUser<int>)).InstancePerRequest();
            builder.Register(b => b.Resolve<IEntitiesContext>() as DbContext).InstancePerRequest();
            builder.Register(b =>
            {
                var manager = IdentityFactory.CreateUserManager(b.Resolve<DbContext>());
                if (Startup.DataProtectionProvider != null)
                {
                    manager.UserTokenProvider =
                        new DataProtectorTokenProvider<ApplicationIdentityUser, int>(
                            Startup.DataProtectionProvider.Create("ASP.NET Identity"));
                }
                return manager;
            }).InstancePerRequest();
            builder.Register(b => IdentityFactory.CreateRoleManager(b.Resolve<DbContext>())).InstancePerRequest();
            builder.Register(b => HttpContext.Current.GetOwinContext().Authentication).InstancePerRequest();
        }
    }
}
