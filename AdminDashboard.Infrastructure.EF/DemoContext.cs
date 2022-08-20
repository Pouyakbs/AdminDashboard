using AdminDashboard.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

namespace AdminDashboard.Infrastructure.EF
{
    public class DemoContext : DbContext
    {
        public DemoContext(DbContextOptions<DemoContext> dbContextOptions) : base(dbContextOptions)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<Products> Products { get; set; }
        public DbSet<SellManagement> SellManagement { get; set; }
        public DbSet<SellManagementStore> SellManagementStore { get; set; }
        public DbSet<Store> Store { get; set; }
    }
}
