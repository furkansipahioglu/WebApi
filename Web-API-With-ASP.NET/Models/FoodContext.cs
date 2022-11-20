using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodAPI.Models
{
    public class FoodContext : DbContext
    {
        public FoodContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlite("Data source = foods.db");
        }

        public FoodContext(DbContextOptions<FoodContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Food> Foods { get; set; }
        public DbSet<AdminUser> Admin { get; set; }
    }
}
