using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WorldStore.Microservice.OrderMicroservice.Domain.AggregatesModel.OrderAggregate
{
    public interface IOrderService
    {
        Order CreateOrder(Guid customerId, IReadOnlyCollection<OrderItem> orderItems);
        Task<bool> ProcessOrderAsync(Order order);
    }
}
