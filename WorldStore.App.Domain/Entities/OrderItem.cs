using System;
using System.Collections.Generic;
using System.Text;
using WorldStore.Common.Domain.Entities;

namespace WorldStore.App.Domain.Entities
{
    public class OrderItem : EntityBase<Guid>
    {
        public Guid ProductId { get; set; }
        public string SKU { get; set; }
        public string Name { get; set; }
        public Decimal Price { get; set; }
        public int Quantity { get; set; } //Bought Quantity
    }
}
