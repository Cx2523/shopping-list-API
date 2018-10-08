using shopping_list_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace shopping_list_API.Controllers
{
    public class AccountController
    {
        [HttpPost]
        public void Register(User user)
        {
            // the user coming into the method is already a User : IdentityUser ?
        }
    }
}