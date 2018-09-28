using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shopping_list_API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public IEnumerable<Item> Items { get; set; }
        public IEnumerable<ShoppingList> ShoppingLists{ get; set; }
    }
}