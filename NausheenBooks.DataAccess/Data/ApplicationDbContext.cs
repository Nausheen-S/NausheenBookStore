using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using NausheenBooks.Models; //added using statement

//changed the namespace to properly reflect project
namespace NausheenBookStore.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //adding new dbcontext for categories
        public DbSet<Category> Categories { get; set; }

        //adding new dbcontext for cover types
        public DbSet<CoverType> CoverTypes { get; set; }

        //adding new dbcontext for products
        public DbSet<Product> Products { get; set; }
    }
}
