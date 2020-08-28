using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using WorldStore.Common.Domain.Entities;

namespace WorldStore.Microservice.OrderMicroservice.Domain.AggregatesModel.OrderAggregate
{
    public class Order : EntityBase<Guid>
    {
        public Guid CustomerId { get; set; }
        public DateTime DateTime { get; set; }
        public IEnumerable<OrderItem> OrderItems { get; set; }

        public Order()
        {
            OrderItems = new List<OrderItem>();
        }
    }
}
