using FridgeProduct.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeProduct.Tests.Infrastructure.Helpers
{
    public static class ProductHelper
    {
        public static Product GetOne(string id = "37c7455e-8842-4889-9553-b49b67aad9bd")
        {
            return new Product
            {
                Id = Guid.Parse(id),
                Name = "Product Name",
                DefaultQuantity = 2
            };
        }

        public static IEnumerable<Product> Getmany()
        {
            yield return GetOne();
        }
    }
}
