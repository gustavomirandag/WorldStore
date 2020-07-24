using System;
using System.Collections.Generic;
using System.Text;
using WorldStore.Common.Domain.Entities;

namespace WorldStore.ProductMicroservice.Domain.AggregatesModel.ProductAggregate
{
    public class Product : EntityBase<Guid>
    {
        public string SKU { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public Category Category { get; set; }
        public Decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
