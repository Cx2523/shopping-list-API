using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace shopping_list_API.Models
{
    public class Profile
    {
        
        public int Id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        //[ForeignKey("User")]
        //public string UserId { get; set; }
        public User User { get; set; }
        public ICollection<Item> Items { get; set; }
        public ICollection<ShoppingList> ShoppingLists { get; set; }

    }
}