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
        private ApplicationContext _context = null;

        public ItemController()
        {
            _context = new ApplicationContext();
        }

        public IEnumerable<Item> Get(string userId)
        {
            var items = _context.Items.Where(i => i.UserId == userId).ToList();
            return items;
        }

        public Item GetById(string id)
        {
            // by default .net api gets simple types from uri
            var item = _context.Items.Find(id);
            return item;
        }

        public void Post(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
        }

        public void Put(Item item)
        {
            var result = _context.Items.Find(item.Id);
            if (result != null)
            {
                _context.Entry(result).CurrentValues.SetValues(item);
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            try
            {
                var item = _context.Items.Find(id);
                _context.Items.Remove(item);
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