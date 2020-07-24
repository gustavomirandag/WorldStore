using System;
using System.Collections.Generic;
using System.Text;
using WorldStore.Common.Infra.DataAccess.Repositories;
using WorldStore.ProductMicroservice.Domain.AggregatesModel.ProductAggregate;
using WorldStore.ProductMicroservice.Infra.DataAccess;

namespace WorldStore.ProductMicroservice.Infra.Repositories
{
    public class AzureSqlServerProductsRepository : EntityFrameworkRepositoryBase<Guid,Product>, IProductRepository
    {
        public AzureSqlServerProductsRepository()
            :base(new ProductContext("Server=tcp:crossstore-db-server-gustavo.database.windows.net,1433;Initial Catalog=crossstore-db;Persist Security Info=False;User ID=daniel;Password=@dsInf123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
        {
        }
    }
}
