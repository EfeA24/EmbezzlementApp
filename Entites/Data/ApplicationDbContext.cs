using embezzlement.Models;
using Entites.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Embezzlement> Embezzlements { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasKey(e => e.ItemId);

                entity.Property(e => e.ItemStockCode)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.ItemDescription)
                    .IsRequired(false);

                entity.Property(e => e.ItemCount)
                    .IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
