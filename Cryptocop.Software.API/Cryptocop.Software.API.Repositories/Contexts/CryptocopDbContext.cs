﻿using System.Reflection.Metadata.Ecma335;
using Cryptocop.Software.API.Models.Entities;
using Cryptocop.Software.API.Repositories.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Cryptocop.Software.API.Repositories.Contexts
{
    public class CryptocopDbContext : DbContext
    {
        public CryptocopDbContext(DbContextOptions<CryptocopDbContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            // User
            modelBuilder.Entity<PaymentCard>()
                .HasOne(p => p.User)
                .WithMany(u => u.PaymentCards);

            modelBuilder.Entity<Address>()
                .HasOne(a => a.User)
                .WithMany(u => u.Address);

            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasIndex(e => new
                {
                    e.StreetName,
                    e.HouseNumber,
                    e.City,
                    e.Country,
                    e.ZipCode,
                    e.UserId
                }).IsUnique();
            });
            
            modelBuilder.Entity<ShoppingCart>()
                .HasOne(s => s.User)
                .WithOne(u => u.ShoppingCart);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders);
            
            // Shopping Cart
            modelBuilder.Entity<ShoppingCartItem>()
                .HasOne(si => si.ShoppingCart)
                .WithMany(s => s.ShoppingCartItems);

            // Order
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems);
            
            

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<PaymentCard> PaymentCards { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<JwtToken> JwtTokens { get; set; }
    }
}