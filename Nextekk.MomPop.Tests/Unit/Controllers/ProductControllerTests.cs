using Moq;
using Nextekk.MomPop.Core.Models;
using Nextekk.MomPop.Core.Services;
using Nextekk.MomPop.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static Nextekk.MomPop.Tests.Helpers.MockData;

namespace Nextekk.MomPop.Tests.Unit.Controllers
{
    public class ProductControllerTests
    {
        private Mock<IProductService> _productService;

        [Fact]
        public async Task ShouldBeAbleToGetAllProducts()
        {
            InitializeServiceMock();
            _productService.Setup(x => x.GetAll()).ReturnsAsync(_productDB.Select(x => new Product(x)));

            var products = await GetController().GetAll();

            Assert.Equal(3, products.Count());
        }

        private void InitializeServiceMock()
        {
            _productService = new Mock<IProductService>();
        }

        private ProductsController GetController()
        {
            return new ProductsController(_productService.Object);
        }
    }
}
