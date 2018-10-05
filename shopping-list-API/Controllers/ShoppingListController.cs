using shopping_list_API.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace shopping_list_API.Controllers
{
    public class ShoppingListController : ApiController
    {
        private Context _context = null;

        public ShoppingListController()
        {
            _context = new Context();
        }

        public IEnumerable<ShoppingList> Get()
        {
            var users = _context.ShoppingLists.ToList();
            return users;
        }

        public ShoppingList Get(int id)
        {
            // by default .net api gets simple types from uri
            var user = _context.ShoppingLists.Find(id);
            return user;
        }

        public void Post(ShoppingList user)
        {
            _context.ShoppingLists.Add(user);
            _context.SaveChanges();
        }

        public void Put(ShoppingList user)
        {
            var result = _context.ShoppingLists.Find(user.Id);
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
                var user = _context.ShoppingLists.Find(id);
                _context.ShoppingLists.Remove(user);
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