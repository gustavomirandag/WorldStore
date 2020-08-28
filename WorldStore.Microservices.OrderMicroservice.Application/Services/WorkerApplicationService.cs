using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using WorldStore.Common.Domain.Application.CQRS.Messaging;
using WorldStore.Microservices.OrderMicroservice.Application.CQRS.Commands;
using WorldStore.Microservices.OrderMicroservice.Application.CQRS.Events;
using WorldStore.Microservices.OrderMicroservice.Application.CQRS.Interfaces;

namespace WorldStore.Microservices.OrderMicroservice.Application.Services
{
    public class WorkerApplicationService : IWorkerApplicationService
    {
        private IOrderCommandHandler orderCommandHandler;
        private IMediatorHandler bus;

        public WorkerApplicationService(IOrderCommandHandler orderCommandHandler, IMediatorHandler bus)
        {
            this.orderCommandHandler = orderCommandHandler;
            this.bus = bus;
        }

        public async Task ProcessOrderAsync(ProcessOrderCommand processOrderCommand)
        {
            var commandHandlerSuccess = await orderCommandHandler.HandleAsync(processOrderCommand);
            var orderProcessedEvent = new OrderProcessedEvent(processOrderCommand.Order);
            orderProcessedEvent.Success = true;

            if (!commandHandlerSuccess)
                orderProcessedEvent.Success = false;

            await bus.EnqueueAsync(orderProcessedEvent, OrderProcessedEvent.EventQueueName);
        }
    }
}
