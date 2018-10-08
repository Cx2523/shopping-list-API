using Microsoft.AspNet.Identity;
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
    }
}