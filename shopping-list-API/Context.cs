using Microsoft.AspNet.Identity.EntityFramework;
using shopping_list_API.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace shopping_list_API
{
    public class Context : IdentityDbContext<User>
    {
     
        public Context() : base(rdsHelper.GetRDSConnectionString() ?? "DefaultConnection")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Context>());
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ShoppingList> ShoppingLists { get; set; }
    }
}