using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WorldStore.Microservice.OrderMicroservice.Domain.AggregatesModel.ProductAggregate
{
    public interface IProductQueryService
    {
        Task<Product> GetProductAsync(Guid productId);
    }
}
