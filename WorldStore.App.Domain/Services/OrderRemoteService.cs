using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorldStore.App.Domain.Entities;
using WorldStore.App.Domain.Interfaces.Repositories;
using WorldStore.App.Domain.Interfaces.Services;

namespace WorldStore.App.Domain.Services
{
    public class OrderRemoteService : IOrderService
    {
        private IOrderRepository orderRepository;

        public OrderRemoteService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public async Task CreateOrderAsync(Order order)
        {
            await orderRepository.CreateAsync(order);
        }
    }
}
