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

        public async Task CreateOrder(OrderEntity order)
        {
            _dbContext.Orders.Add(order);
            _dbContext.OrderItems.AddRange(order.OrderItems);
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
                .Include(x => x.OrderItems.Select(y => y.Product))
                
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
