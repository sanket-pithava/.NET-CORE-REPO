using BulkyWeb.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bulky.DataAccess.Data
{
    public class ApplicationDBContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) 
        {
            
        }
        public DbSet<Catogery> catogeries { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<ApplicationUsers> applicationUsers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Catogery>().HasData(
                new Catogery { Id=1,Name="Action",DisplayOrder=1},
                new Catogery { Id = 2, Name = "SciFi", DisplayOrder = 2 },
                new Catogery { Id = 3, Name = "History", DisplayOrder = 3 }
                );
            //For A Product Table
            modelBuilder.Entity<Product>().HasData(
               new Product
               {
                   Id = 1,
                   Title = "The Great Gatsby",
                   Description = "A classic novel by F. Scott Fitzgerald exploring themes of wealth, love, and the American dream.",
                   ISBN = "9780743273565",
                   Author = "F. Scott Fitzgerald",
                   ListPrice = 199,
                   Price = 189,
                   Price50 = 179,
                   Price100 = 169,
                   CategoryId =1,
                   ImageURL = ""
               },
               new Product
               {
                  Id = 2,
                  Title = "Atomic Habits",
                  Description = "A guide to building good habits and breaking bad ones with small incremental changes.",
                  ISBN = "9780735211292",
                  Author = "James Clear",
                  ListPrice = 499,
                  Price = 479,
                  Price50 = 459,
                  Price100 = 439,
                  CategoryId = 1,
                   ImageURL = ""

               },
               new Product
               {
            Id = 3,
            Title = "Clean Code",
            Description = "A handbook of agile software craftsmanship with practical advice for writing cleaner code.",
            ISBN = "9780132350884",
            Author = "Robert C. Martin",
            ListPrice = 799,
            Price = 769,
            Price50 = 729,
            Price100 = 699,
            CategoryId = 1,
                   ImageURL = ""
               },
              new Product
        {
            Id = 4,
            Title = "The Pragmatic Programmer",
            Description = "Classic guide to software engineering best practices and mindset for developers.",
            ISBN = "9780201616224",
            Author = "Andrew Hunt and David Thomas",
            ListPrice = 699,
            Price = 669,
            Price50 = 639,
            Price100 = 599,
            CategoryId = 1,
                  ImageURL = ""
              },
        new Product
        {
            Id = 5,
            Title = "Deep Work",
            Description = "A book on focused success in a distracted world, emphasizing deep concentration and productivity.",
            ISBN = "9781455586691",
            Author = "Cal Newport",
            ListPrice = 399,
            Price = 379,
            Price50 = 359,
            Price100 = 339,
            CategoryId = 2,
            ImageURL = ""
        }
               );
        }
    }
}
