using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WorldStore.App.Domain.Entities;

namespace WorldStore.App.Infra.DataAccess.Contexts
{
    public class WorldStoreLocalContext : DbContext
    {
        private readonly string dbConnectionString;
        public DbSet<Product> Products { get; set; }


        public WorldStoreLocalContext(string dbConnectionString)
        {
            this.dbConnectionString = dbConnectionString;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseSqlServer(dbConnectionString);
            optionsBuilder.UseSqlite(dbConnectionString);
        }
    }
}
