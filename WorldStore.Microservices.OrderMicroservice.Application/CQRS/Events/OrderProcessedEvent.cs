using System;
using System.Collections.Generic;
using System.Text;
using WorldStore.Microservice.OrderMicroservice.Domain.AggregatesModel.OrderAggregate;

namespace WorldStore.Microservices.OrderMicroservice.Application.CQRS.Events
{
    public class OrderProcessedEvent : OrderEvent
    {
        public const string EventQueueName = "order-processed-event-queue";
        public override string QueueName => EventQueueName;

        public OrderProcessedEvent()
        {
        }

        public OrderProcessedEvent(Order order)
        {
            Order = order;
        }
    }
}
