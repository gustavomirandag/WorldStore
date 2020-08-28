using System;
using System.Collections.Generic;
using System.Text;
using WorldStore.Common.Domain.Entities;

namespace WorldStore.App.Domain.Entities
{
    public class Order : EntityBase<Guid>
    {
        public Guid CustomerId { get; set; }
        public DateTime DateTime { get; set; }
        public IReadOnlyCollection<OrderItem> OrderItems { get; set; }
    }
}
