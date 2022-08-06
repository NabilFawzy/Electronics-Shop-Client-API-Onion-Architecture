using Microsoft.EntityFrameworkCore;
using OnionArch.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnionArch.Repository.Data
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions options) : base(options)
        {
        }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductType> ProductTypes { get; set; }
        public virtual DbSet<AnnonymsUser> AnnonymsUsers { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasOne(p => p.ProductType)
            .WithMany()
            .HasForeignKey(p => p.ProductTypeId);
        }

    }
}
