using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nextekk.MomPop.Core.Models.Entities;

namespace Nextekk.MomPop.Web.Models
{
    public class OrderItemViewModel
    {
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public OrderItemEntity ToEntity()
        {
            return new OrderItemEntity
            {
                ProductId = ProductId,
                Quantity = Quantity
            };
        }
    }
}
