using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WorldStore.ProductMicroservice.Domain.AggregatesModel.ProductAggregate
{
    public interface IProductService
    {
        Task<bool> AddProductAsync(Product product);
        Task<Product> GetProductAsync(Guid productId);
        IEnumerable<Product> GetAllProducts();
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<bool> UpdateProductAsync(Product product);
        Task<bool> DeleteProductAsync(Guid productId);
    }
}
