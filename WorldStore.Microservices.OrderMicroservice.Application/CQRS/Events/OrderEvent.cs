using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using WorldStore.Common.Application.Interfaces.CQRS.Events;
using WorldStore.Microservice.OrderMicroservice.Domain.AggregatesModel.OrderAggregate;

namespace WorldStore.Microservices.OrderMicroservice.Application.CQRS.Events
{
    public abstract class OrderEvent : Event
    {
        public Order Order { get; set; }
        public bool Success { get; set; }
    }
}
