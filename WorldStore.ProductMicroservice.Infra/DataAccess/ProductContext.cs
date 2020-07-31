using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WorldStore.ProductMicroservice.Domain.AggregatesModel.ProductAggregate;
using WorldStore.ProductMicroservice.Infra.DataModel;

namespace WorldStore.ProductMicroservice.Infra.DataAccess
{
    public class ProductContext : DbContext
    {
        private readonly string dbConnectionString;
        public DbSet<Product> Products { get; set; }
        //public DbSet<DbCategory> Categories { get; set; }

        public ProductContext()
        {
            this.dbConnectionString = "Server=tcp:world-store-db-server-gustavo.database.windows.net,1433;Initial Catalog=worldstore-db-gustavo;Persist Security Info=False;User ID=pivotto;Password=@dsInf123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            Database.EnsureCreated();
        }

        public ProductContext(string dbConnectionString)
        {
            this.dbConnectionString = dbConnectionString;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(dbConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder
            //    .Entity<Product>()
            //    .Property(product => product.Category)
            //    .HasConversion(
            //        category => category.ToString(),
            //        category => Category.Parse(category))
            //    .HasColumnName("Category");

            //modelBuilder
            //    .Entity<DbCategory>()
            //    .Property(dbCategory => dbCategory.Name)
            //    .HasConversion(
            //        category => category.ToString(),
            //        category => new Category(category))
            //    .HasColumnName("Category");
        }
    }
}
