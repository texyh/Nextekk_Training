using System;
using System.Collections.Generic;
using System.Text;

namespace Nextekk.MomPop.Core.Models.Entities
{
    public class OrderItemEntity
    {
        public Guid Id { get; set; }

        public int ProductId { get; set; }

        public int  Quantity { get; set; }

        public Guid OrderId { get; set; }

        public virtual ProductEntity Product { get; set; }
    }
}
