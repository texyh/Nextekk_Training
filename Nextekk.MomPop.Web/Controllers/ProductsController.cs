using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nextekk.MomPop.Web.Models;

namespace Nextekk.MomPop.Web.Controllers
{
    /// <summary>
    /// This is the controller for managing products
    /// </summary>
    [Produces("application/json")]
    [Route("api/Products")]
    public class ProductsController : Controller
    {
        IEnumerable<ProductViewModel> productDB = new List<ProductViewModel>
        {
               new ProductViewModel { Name = "Hp Pavallion", Description ="cool laptop", Id = 1, Price = 100000, Stock = 10 },
               new ProductViewModel { Name = "samsung", Description ="cool laptop", Id = 2, Price = 105000, Stock = 20 },
        };
        /// <summary>
        /// This gets the list of products in the system
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<ProductViewModel> GetAll()
        {
            return productDB.ToList();
                
        }

        /// <summary>
        /// this returns the product of the given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("{id:min(1)}")]
        public ProductViewModel Get(int id)
        {
            return productDB.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost]
        public int Create(SaveProductViewModel product)
        {
            return 1; // Todo
        }

        [HttpPut]
        public void Update(SaveProductViewModel product)
        {
            //Todo
        }

        [HttpDelete]
        public void Delete(int id)
        {
            //Todo
        }
    }
}