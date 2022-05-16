using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProductionLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductionManager_EndProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Lot> Lots { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProdTask> ProdTasks { get; set; }
        public DbSet<ProdTaskStatus> ProdTaskStatuses { get; set; }
        public DbSet<ProdTaskUser> ProdTasksUsers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Production> Productions { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //FluentApi

            builder.Entity<Order>()
                .HasOne(o => o.Production)
                .WithMany(p => p.Orders)
                .HasForeignKey(o => o.ProductionId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Lot>()
                .HasOne(l => l.Room)
                .WithMany(p => p.Lots)
                .HasForeignKey(l => l.RoomId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<ProductOrder>()
                .HasOne(l => l.Product)
                .WithMany(p => p.ProductOrders)
                .HasForeignKey(l => l.ProductId)
                .OnDelete(DeleteBehavior.NoAction);


            base.OnModelCreating(builder);  
        }
    }
}
