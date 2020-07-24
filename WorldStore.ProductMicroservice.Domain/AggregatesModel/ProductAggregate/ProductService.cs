using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WorldStore.ProductMicroservice.Domain.AggregatesModel.ProductAggregate
{
    //Use Cases related to product
    public class ProductService : IProductService
    {
        private readonly IProductRepository repository;

        public ProductService(IProductRepository repository)
        {
            this.repository = repository;
        }

        public async Task<bool> AddProductAsync(Product product)
        {
            product.Id = Guid.NewGuid();
            await repository.CreateAsync(product);
            return await repository.SaveChangesAsync() > 0;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return repository.ReadAll();
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await repository.ReadAllAsync();
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            repository.Update(product);
            return await repository.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteProductAsync(Guid productId)
        {
            await repository.DeleteAsync(productId);
            return await repository.SaveChangesAsync() > 0;
        }

        public async Task<Product> GetProductAsync(Guid productId)
        {
            return await repository.ReadAsync(productId);
        }
    }
}
