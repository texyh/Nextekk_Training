using Nextekk.MomPop.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nextekk.MomPop.Core.Models;
using Nextekk.MomPop.Core.Models.Entities;
using System.Threading.Tasks;
using Nextekk.MomPop.Core.Repository;

namespace Nextekk.MomPop.Business
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        public async Task<int> Create(ProductEntity product)
        {
            product.CreatedAt = DateTime.UtcNow;
            product.UpdatedAt = DateTime.UtcNow;

            var id = await _productRepository.Create(product);
            return id;
        }

        public async Task Delete(int id)
        {
            await _productRepository.Delete(id);
        }

        public async Task<Product> Get(int id)
        {
            var Product = await _productRepository.Get(id);
            return new Product(Product);
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            var products = await _productRepository.GetAll();
            return products.Select(x => new Product(x)).ToList();
        }

        public async Task Update(ProductEntity product)
        {
            var entity = await _productRepository.Get(product.Id);

            entity.Description = product.Description;
            entity.Name = product.Name;
            entity.Stock = product.Stock;
            entity.Price = product.Price;
            entity.UpdatedAt = DateTime.UtcNow;

            await _productRepository.Update(new List<ProductEntity> { entity }); // This is a new list that takes just one member(the updated product)
            
        }
    }
}
