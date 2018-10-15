using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using shopping_list_API.Models;
using shopping_list_API.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace shopping_list_API.Controllers
{
    public class AccountController : ApiController
    {
        private ApplicationUserManager _applicationUserManager;

        public AccountController()
        {

            _applicationUserManager = new ApplicationUserManager(new UserStore<User>());
        }

        [HttpPost]
        public async Task<string> Register(User user)
        {

            var result = await _applicationUserManager.CreateAsync(user, user.Id);
            // the user coming into the method is already a User : IdentityUser ?
            //return result.Succeeded.ToString(); 
            return "string";
        }
    }
}