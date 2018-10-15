using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace shopping_list_API.Models
{
    public class User : IdentityUser
    {
        //public int ProfileId { get; set; }
        public Profile Profile { get; set; }
    }
}