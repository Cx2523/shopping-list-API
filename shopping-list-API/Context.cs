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
    public class ApplicationContext : IdentityDbContext<User>
    {

        public ApplicationContext() : base(rdsHelper.GetRDSConnectionString() ?? "DefaultConnection")
        {
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ApplicationContext>());
            Database.SetInitializer(new CreateDatabaseIfNotExists<ApplicationContext>());
        }


        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }

        //public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ShoppingList> ShoppingLists { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Profile>()
               .HasRequired(p => p.User)
               .WithRequiredDependent(u => u.Profile);

            base.OnModelCreating(modelBuilder);

        }
    }
}