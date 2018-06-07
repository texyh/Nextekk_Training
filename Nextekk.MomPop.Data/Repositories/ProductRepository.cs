using Nextekk.MomPop.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Nextekk.MomPop.Core.Models.Entities;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nextekk.MomPop.Data.Context;

namespace Nextekk.MomPop.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly NextekkMomPopDbContext _dbContext;

        public ProductRepository(NextekkMomPopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Create(ProductEntity product)
        {
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();
            return product.Id;
        }

        public async Task Delete(int id)
        {
            var product = new ProductEntity {Id = id};
            _dbContext.Attach(product); // Explain Tommorow
            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ProductEntity> Get(int id)
        {
           
            return await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<ProductEntity>> GetAll()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<IEnumerable<ProductEntity>> GetProductsInIds(IEnumerable<int> ids)
        {
            return await _dbContext.Products.Where(x => ids.Contains(x.Id)).ToListAsync();
        }

        public async Task Update(IEnumerable<ProductEntity> products)
        {
            _dbContext.UpdateRange(products);
            await _dbContext.SaveChangesAsync();
        }
    }
}
