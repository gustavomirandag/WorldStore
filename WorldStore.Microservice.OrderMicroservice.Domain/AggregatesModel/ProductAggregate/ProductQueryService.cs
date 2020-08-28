using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WorldStore.Microservice.OrderMicroservice.Domain.AggregatesModel.ProductAggregate
{
    public class ProductQueryService : IProductQueryService
    {
        private IProductQueryRepository productQueryRepository;

        public ProductQueryService(IProductQueryRepository productQueryRepository)
        {
            this.productQueryRepository = productQueryRepository;
        }

        public async Task<Product> GetProductAsync(Guid productId)
        {
            return await productQueryRepository.ReadAsync(productId);
        }
    }
}
