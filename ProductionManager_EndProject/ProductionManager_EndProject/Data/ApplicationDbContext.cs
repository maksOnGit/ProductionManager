using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProductionLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductionManager_EndProject.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
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

            //Order
            var order = builder.Entity<Order>();

            order.HasOne(o => o.Production)
                .WithMany(p => p.Orders)
                .HasForeignKey(o => o.ProductionId)
                .OnDelete(DeleteBehavior.NoAction);
            order.HasKey(o => o.Id);
            order.Property(o => o.UserId)
                .IsRequired();
            order.Property(o => o.Reference)
                .HasMaxLength(50);
            order.Property(o => o.Price)
                .HasMaxLength(6);
            

            //User
            var user = builder.Entity<User>();

            user.Property(u => u.FirstName)
                .HasMaxLength(50)
                .IsRequired();
            user.Property(u => u.LastName)
                .HasMaxLength(50)
                .IsRequired();
            user.Property(u => u.Street)
                .HasMaxLength(100)
                .IsRequired();
            user.Property(u => u.City)
                .HasMaxLength(50)
                .IsRequired();
            user.Property(u => u.BirthDay)
                .HasMaxLength(50)
                .IsRequired();
            user.Property(u => u.Country)
                .HasMaxLength(50)
                .IsRequired();
            user.Property(u => u.ZIP)
                .HasMaxLength(50)
                .IsRequired();

            //Client
            var client = builder.Entity<Client>();

            client.Property(c => c.ClientName)
                .HasMaxLength(50)
                .IsRequired();
            client.Property(c => c.Email)
                .HasMaxLength(50)
                .IsRequired();
            client.Property(c => c.PhoneNumber)
                .HasMaxLength(50)
                .IsRequired();
            client.Property(c => c.Country)
                .HasMaxLength(50)
                .IsRequired();
            client.Property(c => c.City)
                .HasMaxLength(50)
                .IsRequired();
            client.Property(c => c.Street)
                .HasMaxLength(100)
                .IsRequired();

            //Lot
            builder.Entity<Lot>()
                .HasOne(l => l.Room)
                .WithMany(p => p.Lots)
                .HasForeignKey(l => l.RoomId)
                .OnDelete(DeleteBehavior.NoAction);


            //ProdTask
            var prodTask = builder.Entity<ProdTask>();

            prodTask.Property(p => p.TaskName)
                .HasMaxLength(50)
                .IsRequired();
            prodTask.Property(p => p.TaskDescription)
                .HasMaxLength(500)
                .IsRequired();

            //ProdTaskStatuses
            builder.Entity<ProdTaskStatus>()
                .Property(p => p.StatusName)
                .HasMaxLength(50)
                .IsRequired();

            //ProdTaskUser
            builder.Entity<ProdTaskUser>()
                .Property(p => p.UserId)
                .IsRequired();

            //Production  
            var prod = builder.Entity<Production>();

            prod.Property(p => p.ProductionName)
                .HasMaxLength(50)
                .IsRequired();
            prod.Property(p => p.City)
                .HasMaxLength(50)
                .IsRequired();
            prod.Property(p => p.Street)
                .HasMaxLength(50)
                .IsRequired();
            prod.Property(p => p.Country)
                .HasMaxLength(50)
                .IsRequired();
            prod.Property(p => p.PhoneNumber)
                .HasMaxLength(50)
                .IsRequired();
            prod.Property(p => p.Email)
                .HasMaxLength(50)
                .IsRequired();

            //Products
            var product = builder.Entity<Product>();

            product.Property(p => p.PriceFor)
                .HasMaxLength(50)
                .IsRequired();
            product.Property(p => p.ProductName)
                .HasMaxLength(50)
                .IsRequired();

            //Room
            builder.Entity<Room>()
                .Property(r => r.RoomName)
                .HasMaxLength(50)
                .IsRequired();
            
            //ProductOrder
            builder.Entity<ProductOrder>()
                .HasOne(l => l.Product)
                .WithMany(p => p.ProductOrders)
                .HasForeignKey(l => l.ProductId)
                .OnDelete(DeleteBehavior.NoAction);


            base.OnModelCreating(builder);  
        }
    }
}
