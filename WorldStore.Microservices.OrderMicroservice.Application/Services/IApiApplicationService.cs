using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorldStore.Microservice.OrderMicroservice.Domain.AggregatesModel.OrderAggregate;

namespace WorldStore.Microservices.OrderMicroservice.Application.Services
{
    public interface IApiApplicationService
    {
        Task<Order> CreateOrderAsync(Guid customerId, IEnumerable<OrderItem> orderItems);
    }
}
