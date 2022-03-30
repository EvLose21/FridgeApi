using FridgeProduct.BusinessLayer.Interfaces;
using FridgeProduct.BusinessLayer.Models;
using FridgeProduct.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeProduct.BusinessLayer.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        public ProductService(IRepositoryManager repository)
        {
            _repository = repository.Product;
        }

        public async Task<PaginatedList<ProductListItem>> GetProductListAsync(int? pageNumber)
        {
            var products = _repository.GetAllProductsQuery(trackChanges: false).
                Select(l => new ProductListItem
                {
                    Id = l.Id,
                    Name = l.Name,
                    DefaultQuantity = l.DefaultQuantity
                });

            return await PaginatedList<ProductListItem>.CreateAsync(products, pageNumber ?? 1, 3);
        }
    }
}
