using shopping_list_API.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.Owin;
using shopping_list_API.Security;
using System.Threading.Tasks;

namespace shopping_list_API.Controllers
{
    public class UserController : ApiController
    {
        private ApplicationContext _context = null;

        public UserController()
        {
            _context = new ApplicationContext();
        }

        public IEnumerable<User> Get()
        {
            var users = _context.Users.ToList();
            return users;
        }

        public IHttpActionResult Get(string id)
        {
            // by default .net api gets simple types from uri

            try
            {
                var user = _context.Users
                .Include(u => u.Profile)
                .Where(u => u.Id == id)
                .FirstOrDefault();
                return Ok(user);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<string> Post(UserAPI userApi)
        {
            var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var authManager = HttpContext.Current.GetOwinContext().Authentication;

            User user = userManager.Find(userApi.UserName, userApi.Password);


            if (user == null)
            {
                user = new User { UserName = userApi.UserName, Profile = new Profile() };
                var result = await userManager.CreateAsync(user, userApi.Password);

                if (result.Succeeded)
                {
                    //await authManager.SignIn(user)
                    return "neato";
                }

                //authManager.SignIn(
                //    new AuthenticationProperties { IsPersistent = false }, ident);
                //return Redirect(user.ReturnUrl ?? Url.Action("Index", "Home"));
            }
            return "asdfaasfafsa";
        }

        public void Put(User user)
        {
            var result = _context.Users.Find(user.Id);
            if (result != null)
            {
                _context.Entry(result).CurrentValues.SetValues(user);
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            try
            {
                var user = _context.Users.Find(id);
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        private bool _disposed = false;
        protected override void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                _context.Dispose();
            }

            _disposed = true;

            base.Dispose(disposing);
        }
    }
}