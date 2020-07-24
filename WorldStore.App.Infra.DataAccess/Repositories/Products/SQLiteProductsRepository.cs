using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WorldStore.App.Domain.Entities;
using WorldStore.App.Domain.Interfaces.Repositories;
using WorldStore.App.Infra.DataAccess.Contexts;
using WorldStore.Common.Infra.DataAccess.Repositories;

namespace WorldStore.App.Infra.DataAccess.Repositories.Products
{
    public class SQLiteProductsRepository : EntityFrameworkRepositoryBase<Guid, Product>, IProductRepository
    {
        public SQLiteProductsRepository(string devicePlatform)
        {
            string dbPath = "Filename=";
            const string dbFileName = "crossstore.sqlite";

            switch (devicePlatform)
            {
                case "UWP":
                    dbPath += Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), dbFileName);
                    break;
                case "iOS":
                    dbPath += Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", "data", dbFileName);
                    break;
                case "Android":
                    dbPath += Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), dbFileName);
                    break;
            }

            db = new WorldStoreLocalContext(dbPath);
        }
    }
}
