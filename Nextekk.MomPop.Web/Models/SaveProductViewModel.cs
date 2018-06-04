using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nextekk.MomPop.Web.Models
{
    public class SaveProductViewModel
    {
        
        public string Name { get; set; }

        public string Description { get; set; }

        public int Stock { get; set; }

        public decimal Price { get; set; }
    }
}
