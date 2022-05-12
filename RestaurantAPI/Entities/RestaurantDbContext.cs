using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Entities
{
    public class RestaurantDbContext : DbContext // dziedziczy po DbContext z EntityFrameworkCore -> paczka
    {
        private string _connectionString = "Server=(localdb)\\mssqllocaldb;Database=RestaurantDb;Trusted_Connection=True;";
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Dish> Dishes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // nadpisanie OnModelCreating pozwala na dodatkowe sparametryzowanie danych w bazie
        {
            modelBuilder.Entity<Restaurant>()
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Address>()
                .Property(a => a.Street)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Address>()
                .Property(a => a.City)
                .IsRequired()
                .HasMaxLength(30);

            modelBuilder.Entity<Dish>()
               .Property(d => d.Name)
               .IsRequired()
               .HasMaxLength(50);
        }

        //EntityFrameworkCore.SqlServer
        //EntityFrameworkCore.Tools - migracje
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
        
    }
}
