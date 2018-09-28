﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shopping_list_API.Models
{
    public class ShoppingList
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime dateCreated { get; set; }
        public IEnumerable<Item> Items { get; set; }
    }
}