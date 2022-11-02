using System;
using ArkTmStore.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace ArkTmStore.Api.BdContext
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<PriceHistory> PriceHistory { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Color> Color { get; set; }

        /*
         * dotnet ef migrations add initial --output-dir DatabaseContext/Migrations
         * dotnet ef migrations remove
         * dotnet ef database update
         */
    }
}