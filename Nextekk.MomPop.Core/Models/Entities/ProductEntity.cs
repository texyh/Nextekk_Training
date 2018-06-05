using System;
using System.Collections.Generic;
using System.Text;

namespace Nextekk.MomPop.Core.Models.Entities
{
    public class ProductEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Stock { get; set; }

        public decimal Price { get; set; }
        
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
        
    }
}
