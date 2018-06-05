using System;
using System.Collections.Generic;
using System.Text;
using Nextekk.MomPop.Core.Models;
using System.Threading.Tasks;
using Nextekk.MomPop.Core.Models.Entities;

namespace Nextekk.MomPop.Core.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAll();

        Task<Product> Get(int id);

        Task<int> Create(ProductEntity product);

        Task Update(ProductEntity product);

        Task Delete(int id);
        
    }
}
