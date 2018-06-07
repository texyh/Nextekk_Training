using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nextekk.MomPop.Core.Models.Entities;
using Nextekk.MomPop.Core.Repository;
using Nextekk.MomPop.Data.Context;

namespace Nextekk.MomPop.Data.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly NextekkMomPopDbContext _dbContext;

        public TransactionRepository(NextekkMomPopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateOrderItems(IEnumerable<OrderItemEntity> orderItems)
        {
            _dbContext.AddRange(orderItems);
            await  _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<OrderItemEntity>> GetAllOrderItems()
        {
              return  await _dbContext.OrderItems.Include(x => x.Product).ToListAsync();
        }
    }
}
