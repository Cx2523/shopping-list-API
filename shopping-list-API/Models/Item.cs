using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shopping_list_API.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public float costPerUnit { get; set; }
    }
}