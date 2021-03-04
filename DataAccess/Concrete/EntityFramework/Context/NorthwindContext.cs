using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Context
{
    public class NorthwindContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: "Server=DESKTOP-9TUJNUE\\SQLEXPRESS;Database=Northwind;" +
                                                          "Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

    }

}
