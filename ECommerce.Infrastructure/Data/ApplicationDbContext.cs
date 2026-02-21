using System;
using System.Collections.Generic;
using System.Text;
using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Data
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // SQL Server connection string
                optionsBuilder.UseSqlServer("Data Source =.; Initial Catalog = ECommerceSystem; Integrated Security = True; Encrypt = False;").EnableDetailedErrors(true);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // =========================
            // Fluent API Configurations
            // =========================

            // User
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(100);

           

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Email)
                 .IsRequired()
                  .HasMaxLength(100);

                entity.HasMany(e => e.Orders)
                    .WithOne(o => o.User)
                    .HasForeignKey(o => o.UserId);

                entity.HasMany(e => e.CartItems)
                    .WithOne(c => c.User)
                    .HasForeignKey(c => c.UserId);
            });

            // Category
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasMany(e => e.Products)
                    .WithOne(p => p.Category)
                    .HasForeignKey(p => p.CategoryId);
            });

            // Product
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18,2)");

                entity.Property(e => e.Stock)
                    .IsRequired();

                entity.HasMany(e => e.OrderItems)
                    .WithOne(oi => oi.Product)
                    .HasForeignKey(oi => oi.ProductId);

                entity.HasMany(e => e.CartItems)
                    .WithOne(ci => ci.Product)
                    .HasForeignKey(ci => ci.ProductId);
            });

            // Order
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.TotalPrice)
                    .HasColumnType("decimal(18,2)");

                entity.HasMany(e => e.OrderItems)
                    .WithOne(oi => oi.Order)
                    .HasForeignKey(oi => oi.OrderId);
            });

            // OrderItem
            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.UnitPrice)
                    .HasColumnType("decimal(18,2)");

                entity.Property(e => e.Quantity)
                    .IsRequired();
            });

            // CartItem
            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Quantity)
                    .IsRequired();
            });

            // =========================
            // Seed Data
            // =========================
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FullName = "Admin User",
                   
                    Email = "admin@example.com",
                    Password = "admin123",
                    Role = Domain.Enums.UserRole.Admin,
                    createdAt = new DateTime(2026, 1, 1)
                },
                new User
                {
                    Id = 2,
                    FullName = "Customer User",
                   
                    Email = "customer@example.com",
                    Password = "customer123",
                    Role = Domain.Enums.UserRole.Customer,
                    createdAt = new DateTime(2026, 1, 1)
                });

            modelBuilder.Entity<Category>().HasData(
               new Category { Id = 1, Name = "Electronics", createdAt = new DateTime(2026, 1, 1)},
               new Category { Id = 2, Name = "Books", createdAt = new DateTime(2026, 1, 1) },
               new Category { Id = 3, Name = "Clothing", createdAt = new DateTime(2026, 1, 1) }
           );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Laptop", Price = 1500, Stock = 10, CategoryId = 1, createdAt = new DateTime(2026, 1, 1) },
                new Product { Id = 2, Name = "Smartphone", Price = 800, Stock = 20, CategoryId = 1, createdAt = new DateTime(2026, 1, 1) },
                new Product { Id = 3, Name = "Book A", Price = 20, Stock = 100, CategoryId = 2, createdAt = new DateTime(2026, 1, 1) }
            );

        }
    }
}
