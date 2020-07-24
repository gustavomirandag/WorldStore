using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WorldStore.App.Domain.Entities;
using WorldStore.App.Domain.Interfaces.Repositories;

namespace WorldStore.App.Domain.Services
{
    //Use Cases related to product
    public class ProductLocalService
    {
        private readonly IProductRepository repository;

        public ProductLocalService(IProductRepository repository)
        {
            this.repository = repository;
        }

        public async Task AddProductAsync(Product product)
        {
            product.Id = Guid.NewGuid();
            await repository.CreateAsync(product);
            await repository.SaveChangesAsync();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return repository.ReadAll();
        }

        public async Task UpdateProductAsync(Product product)
        {
            repository.Update(product);
            await repository.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(Guid productId)
        {
            await repository.DeleteAsync(productId);
            await repository.SaveChangesAsync();
        }
    }
}
