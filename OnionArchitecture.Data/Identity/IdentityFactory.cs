using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OnionArchitecture.Data.Identity.Models;
using System;
using System.Data.Entity;

namespace OnionArchitecture.Data.Identity
{
    public class IdentityFactory
    {
        public static UserManager<ApplicationIdentityUser, int> CreateUserManager(DbContext context)
        {
            var manager = new UserManager<ApplicationIdentityUser, int>(new UserStore<ApplicationIdentityUser, ApplicationIdentityRole, int, ApplicationIdentityUserLogin, ApplicationIdentityUserRole, ApplicationIdentityUserClaim>(context));
            // Configure validation logic for usernames
            manager.UserValidator = new  UserValidator<ApplicationIdentityUser, int>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };
            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };
            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;
            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug in here.
            manager.RegisterTwoFactorProvider("PhoneCode", new PhoneNumberTokenProvider<ApplicationIdentityUser, int>
            {
                MessageFormat = "Your security code is: {0}"
            });
            manager.RegisterTwoFactorProvider("EmailCode", new EmailTokenProvider<ApplicationIdentityUser, int>
            {
                Subject = "SecurityCode",
                BodyFormat = "Your security code is {0}"
            });
            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();
            return manager;
        }

        public static RoleManager<ApplicationIdentityRole, int> CreateRoleManager(DbContext context)
        {
            return new RoleManager<ApplicationIdentityRole, int>(new RoleStore<ApplicationIdentityRole, int, ApplicationIdentityUserRole>(context));
        }
    }
}
