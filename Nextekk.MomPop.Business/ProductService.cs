using Nextekk.MomPop.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nextekk.MomPop.Core.Models;
using Nextekk.MomPop.Core.Models.Entities;
using System.Threading.Tasks;

namespace Nextekk.MomPop.Business
{
    public class ProductService : IProductService
    {
        IEnumerable<ProductEntity> productDB = new List<ProductEntity>
        {
            new ProductEntity { Name = "Hp Pavallion", Description ="cool laptop", Id = 1, Price = 100000, Stock = 10, CreatedAt = DateTime.UtcNow},
            new ProductEntity { Name = "samsung", Description ="cool laptop", Id = 2, Price = 105000, Stock = 20, CreatedAt = DateTime.UtcNow },
        };

        public async Task<int> Create(ProductEntity product)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> Get(int id)
        {
            var product = productDB.FirstOrDefault(x => x.Id == id);
            return await Task.FromResult(new Product(product));
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            var products = productDB.Select(x => new Product(x)).ToList();
            return await Task.FromResult(products);
        }

        public Task Update(ProductEntity product)
        {
            throw new NotImplementedException();
        }
    }
}
