using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nextekk.MomPop.Core.Models.Entities;

namespace Nextekk.MomPop.Web.Models
{
    public class SaveProductViewModel
    {
        
        public string Name { get; set; }

        public string Description { get; set; }

        public int Stock { get; set; }

        public decimal Price { get; set; }

        public ProductEntity ToEntity(int? id = null)
        {
            return new ProductEntity
            {
                Id = id ?? default(int),
                Name = Name,
                Description = Description,
                Stock = Stock,
                Price = Price,
            };
        }
    }
}
