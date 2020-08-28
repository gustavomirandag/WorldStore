using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WorldStore.App.Domain.Entities;
using WorldStore.App.Domain.Interfaces.Repositories;
using WorldStore.Common.Domain.Interfaces.Services;

namespace WorldStore.App.Infra.DataAccess.Repositories.Orders
{
    public class OrderMicroserviceRepository : IOrderRepository
    {
        private readonly string token;
        private readonly ISerializerService serializerService;

        public OrderMicroserviceRepository(string token, ISerializerService serializerService)
        {
            this.token = token;
            this.serializerService = serializerService;
        }

        public async Task CreateAsync(Order entity)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
            var orderSerialized = serializerService.Serialize(entity);
            var httpContent = new StringContent(orderSerialized, Encoding.UTF8, "application/json");
            await client.PostAsync("https://worldstore-gustavo-order-microservice-api.azurewebsites.net/api/orders",httpContent);
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> ReadAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Order> ReadAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
