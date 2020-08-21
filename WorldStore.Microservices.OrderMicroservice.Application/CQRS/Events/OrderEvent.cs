using System;
using System.Collections.Generic;
using System.Text;
using WorldStore.Microservice.OrderMicroservice.Domain.AggregatesModel.OrderAggregate;

namespace WorldStore.Microservices.OrderMicroservice.Application.CQRS.Events
{
    public class OrderEvent
    {
        public Order Order { get; set; }
    }
}
