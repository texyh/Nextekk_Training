using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Nextekk.MomPop.Core.Models.Entities;


namespace Nextekk.MomPop.Core.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductEntity>> GetAll();

        Task<ProductEntity> Get(int id);

        Task<int> Create(ProductEntity product);

        Task Update(IEnumerable<ProductEntity> products);

        Task Delete(int id);
    }
}
