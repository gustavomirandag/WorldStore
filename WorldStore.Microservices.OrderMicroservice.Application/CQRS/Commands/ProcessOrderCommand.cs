using System;
using System.Collections.Generic;
using System.Text;
using WorldStore.Microservice.OrderMicroservice.Domain.AggregatesModel.OrderAggregate;

namespace WorldStore.Microservices.OrderMicroservice.Application.CQRS.Commands
{
    public class ProcessOrderCommand : OrderCommand
    {
        public const string CommandQueueName = "process-order-command-queue";
        public override string QueueName => CommandQueueName;

        public ProcessOrderCommand()
        {   
        }

        public ProcessOrderCommand(Order order)
        {
            Order = order;
        }
    }
}
