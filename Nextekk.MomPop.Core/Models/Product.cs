using System;
using System.Collections.Generic;
using System.Text;
using Nextekk.MomPop.Core.Models.Entities;

namespace Nextekk.MomPop.Core.Models
{
    public class Product
    {
        public Product(ProductEntity entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Description = entity.Description;
            Stock = entity.Stock;
            Price = entity.Price;
        }

        public Product()
        {
            
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Stock { get; set; }

        public decimal Price { get; set; }
    }
}
