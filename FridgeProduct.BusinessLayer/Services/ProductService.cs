using AutoMapper;
using FridgeProduct.BusinessLayer.Interfaces;
using FridgeProduct.BusinessLayer.Models;
using FridgeProduct.Contracts;
using FridgeProduct.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeProduct.BusinessLayer.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepositoryManager _repositoryManager;
        public ProductService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<PaginatedList<ProductListItem>> GetProductListAsync(int? pageNumber)
        {
            var products = _repositoryManager.Product.GetAllProductsQuery(trackChanges: false).
                Select(l => new ProductListItem
                {
                    Id = l.Id,
                    Name = l.Name,
                    DefaultQuantity = l.DefaultQuantity
                });

            return await PaginatedList<ProductListItem>.CreateAsync(products, pageNumber ?? 1, 3);
        }

        public async Task<PaginatedList<ProductListItem>> ProductsByFridgeAsync(Guid? id, int? pageNumber)
        {
            if (id != null)
            {
                var products = _repositoryManager.FridgeToProduct.FindAll(trackChanges: false)
                .Where(fp => fp.FridgeId == id)
                .Select(fp => new ProductListItem
                {
                    Id = fp.ProductId,
                    Name = fp.Product.Name,
                    DefaultQuantity = fp.Quantity
                });

                return await PaginatedList<ProductListItem>.CreateAsync(products, pageNumber ?? 1, 3);
            }
            else throw new ArgumentNullException("id");

        }

        public async Task<ReturnProduct> CreateProductAsync(CreateProductModel model)
        {
            var addedProduct = new Product
            {
                Name = model.Name,
                DefaultQuantity = model.DefaultQuantity
            };

            

            if (_repositoryManager.Product.GetAllProductsQuery(trackChanges: false).Any(p => p.Name == addedProduct.Name))
            {
                return new ReturnProduct
                {
                    Status = EnumProductValidation.exist
                };
            }

            if (_repositoryManager.Product.GetAllProductsQuery(trackChanges: false).Count() >= 10)
            {
                return new ReturnProduct
                {
                    Status = EnumProductValidation.over
                };
            }

            _repositoryManager.Product.Create(addedProduct);
            await _repositoryManager.SaveAsync();
            return new ReturnProduct { Id = addedProduct.Id, Status = EnumProductValidation.created };
        }
    }
}
