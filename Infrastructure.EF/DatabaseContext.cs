using Domain.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Infrastructure.EF
{
    /// <summary>
    /// Контекст.
    /// </summary>
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        /// <summary>
        /// продукты.
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// магазины.
        /// </summary>
        public DbSet<Shop> Shops { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Shop>()
                .HasMany(u => u.Products)
                .WithOne(c => c.Shop)
                .IsRequired();

            //modelBuilder.Entity<Course>().tp
            //modelBuilder.Entity<Shop>().Property(c => c.Name).HasMaxLength(100);
            //modelBuilder.Entity<Product>().Property(c => c.Subject).HasMaxLength(100);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
        }
    }
}
