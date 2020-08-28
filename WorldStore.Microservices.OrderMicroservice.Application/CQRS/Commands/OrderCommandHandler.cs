using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorldStore.Microservice.OrderMicroservice.Domain.AggregatesModel.OrderAggregate;
using WorldStore.Microservices.OrderMicroservice.Application.CQRS.Interfaces;

namespace WorldStore.Microservices.OrderMicroservice.Application.CQRS.Commands
{
    public class OrderCommandHandler : IOrderCommandHandler
    {
        private IOrderService orderService;

        public OrderCommandHandler(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        public async Task<bool> HandleAsync(ProcessOrderCommand processOrderCommand)
        {
            return await orderService.ProcessOrderAsync(processOrderCommand.Order);
        }
    }
}
