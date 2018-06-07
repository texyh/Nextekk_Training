using Nextekk.MomPop.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nextekk.MomPop.Core.Services
{
    public interface ITransactionService
    {
        Task ProcessCheckout(IEnumerable<OrderItemEntity> orderItems);

        Task<IEnumerable<OrderEntity>> GetOrders();

        Task<OrderEntity> GetOrder(Guid id);

    }
}
