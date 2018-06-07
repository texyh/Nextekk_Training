using System;
using System.Collections.Generic;
using System.Text;

namespace Nextekk.MomPop.Core.Models.Entities
{
    public class OrderEntity
    {
        public OrderEntity()
        {
            OrderItems = new List<OrderItemEntity>();
        }

        public Guid Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual ICollection<OrderItemEntity> OrderItems { get; set; }
    }
}
