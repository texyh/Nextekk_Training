using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Nextekk.MomPop.Core.Models.Entities;

namespace Nextekk.MomPop.Core.Repository
{
    public interface ITransactionRepository
    {
        Task CreateOrder(OrderEntity order, IEnumerable<OrderItemEntity> orderItems);

        Task<IEnumerable<OrderEntity>> GetAllOrders();

        Task<OrderEntity> GetOrder(Guid id);
    }
}
