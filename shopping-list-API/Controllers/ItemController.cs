using shopping_list_API.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace shopping_list_API.Controllers
{
    public class ItemController : ApiController
    {
        private Context _context = null;

        public ItemController()
        {
            _context = new Context();
        }

        public IEnumerable<Item> Get()
        {
            var users = _context.Items.ToList();
            return users;
        }

        public Item Get(int id)
        {
            // by default .net api gets simple types from uri
            var user = _context.Items.Find(id);
            return user;
        }

        public void Post(Item user)
        {
            _context.Items.Add(user);
            _context.SaveChanges();
        }

        public void Put(Item user)
        {
            var result = _context.Items.Find(user.Id);
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
                var user = _context.Items.Find(id);
                _context.Items.Remove(user);
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