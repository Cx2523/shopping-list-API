using shopping_list_API.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;

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

        public User Get(int id)
        {
            return null;
        }

        public void Post(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public string[] Put()
        {
            var appConfig = ConfigurationManager.AppSettings;
            string dbname = appConfig["RDS_DB_NAME"];
            if (string.IsNullOrEmpty(dbname)) return null;

            string username = appConfig["RDS_USERNAME"];
            string password = appConfig["RDS_PASSWORD"];
            string hostname = appConfig["RDS_HOSTNAME"];
            string port = appConfig["RDS_PORT"];

            return new string[5] { dbname, username, password, hostname, port };
        }

        public string Delete()
        {
            return "this is a test";
        }

        //private bool _disposed = false;
        //protected override void Dispose(bool disposing)
        //{
        //    if (_disposed)
        //        return;

        //    if (disposing)
        //    {
        //        _context.Dispose();
        //    }

        //    _disposed = true;

        //    base.Dispose(disposing);
        //}
    }
}