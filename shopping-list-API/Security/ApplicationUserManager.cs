using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using shopping_list_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shopping_list_API.Security
{
    public class ApplicationUserManager : UserManager<User>
    {
        public ApplicationUserManager(IUserStore<User> userStore) : base(userStore)
        {
        }

        public static ApplicationUserManager Create(
        IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var manager = new ApplicationUserManager(
                new UserStore<User>(context.Get<ApplicationContext>()));

            // optionally configure your manager
            // ...

            return manager;
        }
    }
}