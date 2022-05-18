using FluentAssertions;
using FridgeProduct.BusinessLayer.Models;
using FridgeProduct.BusinessLayer.Services;
using FridgeProduct.Contracts;
using FridgeProduct.Entities;
using FridgeProduct.Entities.Models;
using FridgeProduct.Repository;
using FridgeProduct.Tests.Infrastructure.Helpers;
using MockQueryable.Moq;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FridgeProduct.Tests
{
    public class ProductServiceTests
    {
        private readonly RepositoryContext _dbContext;
        private readonly Mock<IRepositoryManager> _repositoryManager;
        private readonly Mock<IProductRepository> _productRepository;
        public ProductServiceTests()
        {
            _repositoryManager = new Mock<IRepositoryManager>();
            _productRepository = new Mock<IProductRepository>();
            var contextHelper = new DbContextHelper();
            _dbContext = contextHelper.Context;
        }
        [Fact]
        public async Task ItShould_return_true_when_product_name_duplicate()
        {
            // Arrange
            var products = CreateProduct(1);

            var productListMock = products.BuildMock();
            _repositoryManager.Setup(rp=>rp.Product).Returns(_productRepository.Object);
            _productRepository.Setup(pr=>pr.GetAllProductsQuery(false)).Returns(productListMock);

            var service = new ProductService(_repositoryManager.Object);

            var createProduct = new CreateProductModel
            {
                DefaultQuantity = 2,
                Name = products[0].Name
            };

            // Act
            var result = await service.CreateProductAsync(createProduct);

            // Assert
            Assert.Equal(EnumProductValidation.exist, result.Status);
        }

        [Fact]
        public async Task ItShould_return_true_when_product_created()
        {
            // Arrange
            var productList = CreateProduct(12);

            var productListMock = productList.BuildMock();
            _repositoryManager.Setup(rp => rp.Product).Returns(_productRepository.Object);
            _productRepository.Setup(pr => pr.GetAllProductsQuery(false)).Returns(productListMock);

            var service = new ProductService(_repositoryManager.Object);

            var createProduct = new CreateProductModel
            {
                DefaultQuantity = 2,
                Name = "Orange"
            };

            // Act
            var result = await service.CreateProductAsync(createProduct);

            // Assert
            Assert.Equal(EnumProductValidation.over, result.Status);
        }

        [Fact]
        public async Task ItShould_return_true_when_product_created_successfull()
        {
            // Arrange
            var products = CreateProduct(1);

            var productListMock = products.BuildMock();
            _repositoryManager.Setup(rp => rp.Product).Returns(_productRepository.Object);
            _productRepository.Setup(pr => pr.GetAllProductsQuery(false)).Returns(productListMock);

            var service = new ProductService(_repositoryManager.Object);

            var createProduct = new CreateProductModel
            {
                DefaultQuantity = 2,
                Name = "Correct Name"
            };

            // Act
            var result = await service.CreateProductAsync(createProduct);

            // Assert
            Assert.Equal(EnumProductValidation.created, result.Status);
        }
        /*[Fact]
        public async Task ItShould_return_true_when_product_name_duplicate_Integration()
        {
            //Arrange
            var repositoryManager = new RepositoryManager(_dbContext);
            var model = new CreateProductModel
            {
                Name = "Product Name",
                DefaultQuantity = 3
            };
            var service = new ProductService(repositoryManager);
            //Act
            var result = await service.CreateProductAsync(model);
            //Assert
            Assert.True(result.Status.Equals(EnumProductValidation.exist));
        }

        [Fact]
        public async Task ItShould_return_true_when_product_Integration()
        {
            //Arrange
            var repositoryManager = new RepositoryManager(_dbContext);
            var model = new CreateProductModel
            {
                Name = "Product name",
                DefaultQuantity = 3
            };
            var service = new ProductService(repositoryManager);
            //Act
            var result = await service.CreateProductAsync(model);
            //Assert
            Assert.False(result.Id == Guid.Empty);
            //result.Should().
        }*/

        private List<Product> CreateProduct(int count)
        {
            var products = new List<Product>();
            for (int i = 0; i < count; i++)
            {
                var prod = new Product
                {
                    Id = Guid.NewGuid(),
                    Name = $"Name {i}",
                    DefaultQuantity = i
                };
                products.Add(prod);
            }

            return products;
        }
    }

}
