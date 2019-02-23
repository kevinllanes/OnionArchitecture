using Microsoft.AspNet.Identity;
using OnionArchitecture.Data.Identity;
using OnionArchitecture.Data.Identity.Models;

namespace OnionArchitecture.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Identity";
        }

        protected override void Seed(ApplicationDbContext context)
        {
            InitializeIdentityForEf(context);
            base.Seed(context);
        }

        public void InitializeIdentityForEf(ApplicationDbContext db)
        {
            // This is only for testing purpose
            const string name = "admin@admin.com";
            const string password = "Admin@123456";
            const string roleName = "Admin";
            var applicationRoleManager = IdentityFactory.CreateRoleManager(db);
            var applicationUserManager = IdentityFactory.CreateUserManager(db);
            //Create Role Admin if it does not exist
            var role = applicationRoleManager.FindByName(roleName);
            if (role == null)
            {
                role = new ApplicationIdentityRole{Name= roleName};
                applicationRoleManager.Create(role);
            }

            var user = applicationUserManager.FindByName(name);
            if (user == null)
            {
                user = new ApplicationIdentityUser { UserName = name, Email = name };
                applicationUserManager.Create(user, password);
                applicationUserManager.SetLockoutEnabled(user.Id, false);
            }

            // Add user admin to Role Admin if not already added
            var rolesForUser = applicationUserManager.GetRoles(user.Id);
            if (!rolesForUser.Contains(role.Name))
            {
                applicationUserManager.AddToRole(user.Id, role.Name);
            }
            db.SaveChanges();
        }
    }
}
