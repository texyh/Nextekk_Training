using System;
using System.Collections.Generic;
using System.Text;
using Nextekk.MomPop.Core.Models.Entities;

namespace Nextekk.MomPop.Tests.Helpers
{
    public static class MockData
    {
        public static Guid _id = Guid.Parse("9C39E685-D8B7-4AA5-8BDC-6052DBBAA05D");

        public static Guid _id2 = Guid.Parse("8997731B-5A73-4749-BEDD-842EF18D1A22");

        public static IEnumerable<ProductEntity> _productDB
        {
            get
            {
                return new List<ProductEntity>
                {
                    new ProductEntity { Id = 1, Name  = "Samsung", Description = "This is a flashy laptop", Stock = 50, Price = 200000},
                    new ProductEntity { Id = 2, Name  = "Dell", Description = "This is a strong laptop", Stock = 20, Price = 250000},
                    new ProductEntity { Id = 3, Name  = "Mac", Description = "This is a strong and flashy laptop", Stock = 20, Price = 800000}
                };
            }
        }
        
    }
}
