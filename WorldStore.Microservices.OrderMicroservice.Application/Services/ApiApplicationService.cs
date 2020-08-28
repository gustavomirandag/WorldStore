using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorldStore.Common.Domain.Application.CQRS.Messaging;
using WorldStore.Microservice.OrderMicroservice.Domain.AggregatesModel.OrderAggregate;
using WorldStore.Microservices.OrderMicroservice.Application.CQRS.Commands;

namespace WorldStore.Microservices.OrderMicroservice.Application.Services
{
    public class ApiApplicationService : IApiApplicationService
    {
        private IOrderService orderService;
        private IMediatorHandler bus;

        public ApiApplicationService(IOrderService orderService, IMediatorHandler mediatorHandler)
        {
            this.orderService = orderService;
            bus = mediatorHandler;
        }

        public async Task<Order> CreateOrderAsync(Guid customerId, IEnumerable<OrderItem> orderItems)
        {
            var order = orderService.CreateOrder(customerId, orderItems);
            var processOrderCommand = new ProcessOrderCommand(order);
            await bus.EnqueueAsync(processOrderCommand, ProcessOrderCommand.CommandQueueName);

            return order;
        }
    }
}
