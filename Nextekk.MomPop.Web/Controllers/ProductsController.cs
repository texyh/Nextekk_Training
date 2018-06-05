using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nextekk.MomPop.Web.Models;
using Nextekk.MomPop.Core.Models;
using Nextekk.MomPop.Business;
using Nextekk.MomPop.Core.Services;

namespace Nextekk.MomPop.Web.Controllers
{
    /// <summary>
    /// This is the controller for managing products
    /// </summary>
    [Produces("application/json")]
    [Route("api/Products")]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        /// <summary>
        /// The constructor for the product constroller
        /// </summary>
        public ProductsController(IProductService service)
        {
            _productService = service;
        }


        /// <summary>
        /// This gets the list of products in the system
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public Task<IEnumerable<Product>> GetAll()
        {
            return _productService.GetAll();

        }

        /// <summary>
        /// this returns the product of the given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("{id:min(1)}")]
        public Task<Product> Get(int id)
        {
            return _productService.Get(id);
        }
        
        /// <summary>
        /// Creates a new Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<int> Create([FromBody]SaveProductViewModel product)
        {
            var entity = product.ToEntity();
            return _productService.Create(entity);
        }


        [HttpPut, Route("{id:min(1)}")]
        public Task Update(int id, [FromBody]SaveProductViewModel product)
        {
            return _productService.Update(product.ToEntity(id));
        }


        [HttpDelete]
        public Task Delete(int id)
        {
            return _productService.Delete(id);
        }
    }
}