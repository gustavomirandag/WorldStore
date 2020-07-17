﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WorldStore.ProductMicroservice.Domain.AggregatesModel.ProductAggregate;
using WorldStore.ProductMicroservice.Infra.DataModel;

namespace WorldStore.ProductMicroservice.Infra.DataAccess
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<DbCategory> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<Product>()
                .Property(product => product.Category)
                .HasConversion(
                    category => category.ToString(),
                    category => Category.Parse(category))
                .HasColumnName("Category");

            modelBuilder
                .Entity<DbCategory>()
                .Property(dbCategory => dbCategory.Name)
                .HasConversion(
                    category => category.ToString(),
                    category => new Category(category))
                .HasColumnName("Category");
        }
    }
}
