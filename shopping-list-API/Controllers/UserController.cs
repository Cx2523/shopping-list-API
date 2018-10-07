using shopping_list_API.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Data.Entity;

namespace shopping_list_API.Controllers
{
    public class UserController : ApiController
    {
        private Context _context = null;

        public UserController()
        {
            _context = new Context();
        }

        public IEnumerable<User> Get()
        {
            var users = _context.Users.ToList();
            return users;
        }

        public IHttpActionResult Get(int id)
        {
            // by default .net api gets simple types from uri

            try
            {
                var user = _context.Users
                .Include(u => u.Items)
                .Include(u => u.ShoppingLists)
                .Where(u => u.Id == id)
                .FirstOrDefault();
                return Ok(user);
            }
            catch (Exception e)
            {

                throw e;
            }

            
        }

        public void Post(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
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