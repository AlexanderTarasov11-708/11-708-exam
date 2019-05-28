using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MealService.Models;
using Microsoft.EntityFrameworkCore;

namespace MealService
{
    public class MyDbContext : DbContext
    {
        public DbSet<Meal> Meals { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
