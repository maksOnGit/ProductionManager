using Microsoft.AspNetCore.Identity;
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

            client.Property(c => c.ClientId)
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

            prod.HasIndex(p => p.ProductionName)
                .IsUnique();
            prod.Property(p => p.ProductionName)
                .HasMaxLength(50)
                .IsRequired();
            prod.Property(p => p.City)
                .HasMaxLength(50)
                .IsRequired();
            prod.Property(p => p.Street)
                .HasMaxLength(100)
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
            var room = builder.Entity<Room>();
            room.Property(r => r.RoomName)
                .HasMaxLength(50)
                .IsRequired();
            room.HasIndex(p => p.RoomName)
                .IsUnique();
            room.HasMany(r => r.Lots)
                .WithOne(l => l.Room)
                .HasForeignKey(r => r.RoomId)
                .OnDelete(DeleteBehavior.ClientCascade);


            //ProductOrder
            builder.Entity<ProductOrder>()
                .HasOne(l => l.Product)
                .WithMany(p => p.ProductOrders)
                .HasForeignKey(l => l.ProductId)
                .OnDelete(DeleteBehavior.NoAction);



            PasswordHasher<User> hasher = new PasswordHasher<User>();
            string hashedPassword = hasher.HashPassword(new User(), "Test-1");
            
            //UserSeed

            var users = new User[]
            {
                new User { Id = "1",
                    FirstName="Maximilian",
                    LastName="Poniatowski",
                    UserName = "max",
                    NormalizedUserName = "MAX",
                    Email = "max@intec.be",
                    NormalizedEmail = "MAX@INTEC.BE",
                    EmailConfirmed = true,
                    PasswordHash = hashedPassword,
                    BirthDay = DateTime.Now,
                    Country = "Belgium",
                    City = "Bruxelles",
                    Number = 5,
                    Street = "Nieuwe Straat",
                    ZIP = 1000,
                    PhoneNumber = "02/789.321"
                    },


                new User { Id = "2",
                    UserName = "admin",
                    FirstName="Admin",
                    LastName="The first one",
                    NormalizedUserName = "ADMIN",
                    Email = "admin@intec.be",
                    NormalizedEmail = "ADMIN@INTEC.BE",
                    EmailConfirmed = true,
                    PasswordHash = hashedPassword,
                    BirthDay = DateTime.Now,
                    Country = "Belgium",
                    City = "Bruxelles",
                    Number = 5,
                    Street = "Nieuwe Straat",
                    ZIP = 1000,
                    PhoneNumber = "02/189.181"
                    }
            };

            //ProductionSeed

            var productions = new Production[]
            {
                new Production { Id = 1,
                    City = "Bruxelles",
                    Country = "Belgium",
                    ZIP = 1000,
                    Street = "High Street",
                    Number= 10,
                    PhoneNumber = "02/153.154",
                    Email = "SmartFood@smartfood.com",
                    ProductionName = "SmartFood-Brusels",
                }
            };

            //RoomSeed

            var rooms = new Room[]
            {
                new Room { Id = 1,
                        ProductionId = 1,
                        RoomName = "Room 1"
                },
                new Room { Id = 2,
                        ProductionId = 1,
                        RoomName = "Room 2"
                },
                new Room { Id = 3,
                        ProductionId = 1,
                        RoomName = "Room 3"
                }
            };

            //ProdcutSeed

            var products = new Product[]
            {
                new Product { Id = 1,
                            ProductName = "Shitake",
                            Price = 18,
                            PriceFor = "kilogram",
                            NotOrderedStock = 45,
                            OrderedStock = 15,
                            RealStock = 60,
                            },
                new Product { Id = 2,
                            ProductName = "Maitake",
                            Price = 26,
                            PriceFor = "kilogram",
                            NotOrderedStock = 6,
                            OrderedStock = 56,
                            RealStock = 62,
                            
                            }
            };

            //LotsSeed

            var lots = new Lot[]
            {
                new Lot { Id = 1,
                        ProductName = "Shitake",
                        Description = "DanishTrolley 12, 13, 14",
                        IsGrowing = true,
                        StartDate = DateTime.Now.AddDays(-5),
                        EstimatedQuantitie = 50,
                        RecoltedQuantitie = 24.5,
                        RoomId = 1,
                        ProductId = 1
                        },
                new Lot { Id = 2,
                        ProductName = "Shitake",
                        Description = "DanishTrolley 15, 16, 17",
                        IsGrowing = true,
                        StartDate = DateTime.Now,
                        EstimatedQuantitie = 50,
                        RecoltedQuantitie = 0,
                        RoomId = 1,
                        ProductId = 1

                        },
                new Lot { Id = 3,
                        ProductName = "Maitake",
                        Description = "In the middle of the central column",
                        IsGrowing = true,
                        StartDate = DateTime.Now,
                        EstimatedQuantitie = 15,
                        RecoltedQuantitie = 0,
                        RoomId = 3,
                        ProductId = 2
                        }


            };

            //ClientsSeed

            var clients = new Client[]
            {
                new Client
                {
                    ClientId = "Luxus Restaurant",
                    Email = "LuxusRest@outlook.be",
                    PhoneNumber = "02/458.124",
                    Country = "Belgium",
                    City = "Bruxelles",
                    Number = 5,
                    Street = "Food Straat",
                    ZIP = 1000
                },
                new Client
                {
                    ClientId = "SmartKitchens-Anderlecht",
                    Email = "SmartKitchens1000@outlook.be",
                    PhoneNumber = "02/358.424",
                    Country = "Belgium",
                    City = "Bruxelles",
                    Number = 152,
                    Street = "Food Straat",
                    ZIP = 1000
                },
                new Client
                {
                    ClientId = "RoyVeggies",
                    Email = "RoyBalzac@outlook.be",
                    PhoneNumber = "02/124.124",
                    Country = "Belgium",
                    City = "Bruxelles",
                    Number = 5,
                    Street = "Butcher's Street",
                    ZIP = 1000
                },
            };


            builder.Entity<User>().HasData(users);
            builder.Entity<Production>().HasData(productions);
            builder.Entity<Product>().HasData(products);
            builder.Entity<Lot>().HasData(lots);
            builder.Entity<Client>().HasData(clients);
            builder.Entity<Room>().HasData(rooms);


            base.OnModelCreating(builder);  
        }
    }
}
