using FrameworkApp.Data.Configuration;
using FrameworkApp.Entities.Main.UsersObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkApp.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> context) : base(context) { }

        public DbSet<User> User { get; set; }
        public DbSet<UserPersonalInfo> UserPersonalInfo { get; set; }
        public DbSet<Role> Role { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserPersonalInfoConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }
    }
}
