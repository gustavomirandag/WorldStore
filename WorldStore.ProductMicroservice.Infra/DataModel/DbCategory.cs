using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WorldStore.ProductMicroservice.Domain.AggregatesModel.ProductAggregate;

namespace WorldStore.ProductMicroservice.Infra.DataModel
{
    public class DbCategory
    {
        [Key]
        public string Name { get; set; }
    }
}
