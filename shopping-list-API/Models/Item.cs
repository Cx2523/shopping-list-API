using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace shopping_list_API.Models
{
    public class Item
    {
        public int Id { get; set; }
        [Required]
        public string name { get; set; }
        public string description { get; set; }
        public float costPerUnit { get; set; }
        [Required]
        public int UserId { get; set; }
        //public User User { get; set; }
        public int? ShoppingListId { get; set; }
        //public ShoppingList ShoppingList { get; set; }
    }
}   