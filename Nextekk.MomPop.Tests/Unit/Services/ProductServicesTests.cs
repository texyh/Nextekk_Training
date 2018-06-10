using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Nextekk.MomPop.Core.Repository;
using Nextekk.MomPop.Core.Services;
using Xunit;
using Nextekk.MomPop.Business;
using Nextekk.MomPop.Core.Models;
using Nextekk.MomPop.Core.Models.Entities;
using static Nextekk.MomPop.Tests.Helpers.MockData;

namespace Nextekk.MomPop.Tests.Services
{
    public class ProductServicesTests
    {
        private Mock<IProductRepository> _productRepository;

        [Fact]
        public async Task ShouldBeAbleToGetAllProducts()
        {
            InitializeRepositoryMock();
            var service = GetService();
            _productRepository.Setup(x => x.GetAll()).ReturnsAsync(_productDB);

            var products = await service.GetAll();

            Assert.Equal(3, products.Count());
            Assert.IsAssignableFrom<IEnumerable<Product>>(products);
            _productRepository.Verify(x => x.GetAll(), Times.Once);
        }

        [Fact]
        public async Task ShouldBeAbleToGetAProduct()
        {
            var _id = 1;
            InitializeRepositoryMock();
            SetUpRepositoryGet();

            var product = await  GetService().Get(_id);

            Assert.IsType<Product>(product);
            Assert.Equal("Samsung", product.Name);
            Assert.Equal(1, product.Id);
            _productRepository.Verify(x => x.Get(_id), Times.Once);
        }

        [Fact]
        public async Task ShouldBeAbleToUpdateProduct()
        {
            InitializeRepositoryMock();
            SetUpRepositoryGet();

            var product = new ProductEntity
            {
                Id = 1,
                Name = "Samsung",
                Description = "This is a flashy laptop",
                Stock = 10,
                Price = 250000
            };

            await GetService().Update(product);
            _productRepository.Verify(x => x.Update(It.Is<IEnumerable<ProductEntity>>(y => y.First().Stock == 10)), Times.Once);
            _productRepository.Verify(x => x.Update(It.Is<IEnumerable<ProductEntity>>(y => y.First().Price == 250000)), Times.Once);
            // you can add more verify;

        }

        [Fact]
        public async Task ShouldBeAbleToCreateProduct()
        {
            InitializeRepositoryMock();
            var product = new ProductEntity
            {
                Name = "hp",
                Stock = 50,
                Price = 250000,
            };

            await GetService().Create(product);
            _productRepository.Verify(x => x.Create(It.Is<ProductEntity>(y => y.Stock == 50)), Times.Once);
        }

        private void SetUpRepositoryGet()
        {
            _productRepository.Setup(x => x.Get(It.IsAny<int>()))
                .Returns((int id) => Task.FromResult(_productDB.FirstOrDefault(x => x.Id == id)));
        }

        private ProductService GetService()
        {
            return new ProductService(_productRepository.Object);
        }

        private void InitializeRepositoryMock()
        {
            _productRepository = new Mock<IProductRepository>();
        }
    }
}
