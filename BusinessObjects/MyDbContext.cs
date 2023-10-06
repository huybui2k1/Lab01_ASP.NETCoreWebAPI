using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot config = builder.Build();
            optionsBuilder.UseSqlServer(config.GetConnectionString("QLBHAPI"));

        }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder optionsBuilder)
        {
            optionsBuilder.Entity<Category>().HasData(

                new Category { CategoryId = 1, CategoryName = "Beverages" },
                new Category { CategoryId = 2, CategoryName = "Condiments" },
                new Category { CategoryId = 3, CategoryName = "Beverages" },
                new Category { CategoryId = 4, CategoryName = "Confections" },
                new Category { CategoryId = 5, CategoryName = "Dairy Products" },
                new Category { CategoryId = 6, CategoryName = "Meat/Poudly" },
                new Category { CategoryId = 7, CategoryName = "Produce" },
                new Category { CategoryId = 8, CategoryName = "SeaFood" }
                );
            optionsBuilder.Entity<Product>().HasData(

                new Product { ProductId = 1, ProductName = "Beverages" ,CategoryId=1,UnitsInStock=80,UnitPrice=5000},
                new Product { ProductId = 2, ProductName = "Honda", CategoryId = 2, UnitsInStock = 10, UnitPrice = 1000 },
               new Product { ProductId = 3, ProductName = "Yamaha", CategoryId = 3, UnitsInStock = 50, UnitPrice = 50000 },
                new Product { ProductId = 4, ProductName = "Suzuki", CategoryId = 7, UnitsInStock = 20, UnitPrice = 4000 },
                 new Product { ProductId = 5, ProductName = "Mecedez", CategoryId = 7, UnitsInStock = 70, UnitPrice = 2000 },
                  new Product { ProductId = 6, ProductName = "Vinfast", CategoryId = 5, UnitsInStock = 10, UnitPrice = 3300 },
                   new Product { ProductId = 7, ProductName = "Ford", CategoryId = 2, UnitsInStock = 60, UnitPrice = 7000 },
                   new Product { ProductId = 8, ProductName = "Toyota", CategoryId = 4, UnitsInStock = 55, UnitPrice = 8000 }
                );
        }
    }
}
