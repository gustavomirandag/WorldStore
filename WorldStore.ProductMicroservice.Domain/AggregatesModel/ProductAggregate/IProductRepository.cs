using System;
using System.Collections.Generic;
using System.Text;
using WorldStore.Common.Domain.Interfaces.Repositories;

namespace WorldStore.ProductMicroservice.Domain.AggregatesModel.ProductAggregate
{
    public interface IProductRepository : IRepository<Guid,Product>
    {
    }
}
