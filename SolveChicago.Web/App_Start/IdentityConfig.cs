﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using SolveChicago.Web.Models;
using System.Net.Mail;
using System.IO;
using SolveChicago.Common;
using System.Diagnostics.CodeAnalysis;

namespace SolveChicago.Web
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            try
            {
                MailMessage mailMessage = new MailMessage(Settings.Mail.FromAddress, message.Destination)
                {
                    Subject = message.Subject,
                    Body = message.Body,
                    IsBodyHtml = true
                };
                List<MemoryStream> aMs = new List<MemoryStream>();
                List<System.Net.Mail.Attachment> att = new List<System.Net.Mail.Attachment>();
                //if (attachments != null)
                //{
                //    foreach (KeyValuePair<string, byte[]> a in attachments)
                //    {
                //        var ms = new MemoryStream(a.Value);
                //        aMs.Add(ms);
                //        var at = new System.Net.Mail.Attachment(ms, a.Key);
                //        att.Add(at);
                //        mailMessage.Attachments.Add(at);
                //    }
                //}
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Send(mailMessage);
                foreach (var a in att)
                {
                    a.Dispose();
                }
                foreach (var m in aMs)
                    m.Dispose();
            }
            catch
            {
                string errorMessage;
                if (!string.IsNullOrEmpty(message.Destination) && !string.IsNullOrEmpty(message.Subject))
                    errorMessage = string.Format("Could not send email to {0} with subject {1}", message.Destination, message.Subject);
                else
                    errorMessage = "Could not send email, but could not parse additional details as to why or to whom.";
            }
            return Task.FromResult(0);
        }
    }

    public class SmsService : IIdentityMessageService
    {
        [ExcludeFromCodeCoverage]
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }

    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        [ExcludeFromCodeCoverage]
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }

        [ExcludeFromCodeCoverage]
        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context) 
        {
            var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<ApplicationUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug it in here.
            manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<ApplicationUser>
            {
                MessageFormat = "Your security code is {0}"
            });
            manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<ApplicationUser>
            {
                Subject = "Security Code",
                BodyFormat = "Your security code is {0}"
            });
            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = 
                    new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }

    [ExcludeFromCodeCoverage]
    // Configure the application sign-in manager which is used in this application.
    public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
    {
        [ExcludeFromCodeCoverage]
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        [ExcludeFromCodeCoverage]
        public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
        }

        [ExcludeFromCodeCoverage]
        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }
    }
}
