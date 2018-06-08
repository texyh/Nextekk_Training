using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nextekk.MomPop.Core.Models.Entities;
using Nextekk.MomPop.Core.Repository;
using Nextekk.MomPop.Data.Context;
using System.Linq;

namespace Nextekk.MomPop.Data.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly NextekkMomPopDbContext _dbContext;

        public TransactionRepository(NextekkMomPopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateOrder(OrderEntity order, IEnumerable<OrderItemEntity> orderItems)
        {
            _dbContext.Orders.Add(order);
            _dbContext.OrderItems.AddRange(orderItems);
            await  _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<OrderEntity>> GetAllOrders()
        {
              return  await _dbContext.Orders.ToListAsync();
        }

        public async Task<OrderEntity> GetOrder(Guid id)
        {
            return await _dbContext.Orders
                .Include(x => x.OrderItems)
                .ThenInclude(x => x.Product)
                .FirstOrDefaultAsync(x => x.Id == id);

            //return await _dbContext
            //    .OrderItems
            //    .Include(x => x.Product)
            //    .Where(x => x.OrderId == id)
            //    .ToListAsync();
        }
    }
}

