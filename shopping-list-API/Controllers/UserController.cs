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
using System.Net;

namespace shopping_list_API.Controllers
{
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        private ApplicationContext _context = null;

        public UserController()
        {
            _context = new ApplicationContext();
        }

        //public IEnumerable<User> Get()
        //{
        //    var users = _context.Users.ToList();
        //    return users;
        //}

        //public IHttpActionResult Get(string id)
        //{
        //    // by default .net api gets simple types from uri

        //    try
        //    {
        //        var user = _context.Users
        //        .Include(u => u.Profile)
        //        .Where(u => u.Id == id)
        //        .FirstOrDefault();
        //        return Ok(user);
        //    }
        //    catch (Exception e)
        //    {

        //        throw e;
        //    }
        //}

        [HttpPost]
        [ActionName("Register")]
        public async Task<IHttpActionResult> Post(RegisterApiModel registerApiModel)
        {
            var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();

            User user = userManager.Find(registerApiModel.UserName, registerApiModel.Password);

            if (user == null)
            {
                user = new User { UserName = registerApiModel.UserName, Profile = new Profile { firstname = registerApiModel.firstname, lastname = registerApiModel.lastname, email = registerApiModel.email } };
                var result = await userManager.CreateAsync(user, registerApiModel.Password);

                if (result.Succeeded)
                {
                    return Ok(await userManager.FindAsync(registerApiModel.UserName, registerApiModel.Password));
                }
                else
                {
                    throw new HttpResponseException(HttpStatusCode.InternalServerError);
                }
            }
            else
            {
                return null;
            }
        }

        [HttpPost]
        [ActionName("Login")]
        public async Task<IHttpActionResult> Post(LoginApiModel loginApiModel)
        {
            var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            User user = await userManager.FindAsync(loginApiModel.UserName, loginApiModel.Password);
            if (user == null)
                return BadRequest("could not find user");

            return Ok(user); 
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