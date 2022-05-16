using FluentAssertions;
using FridgeProduct.BusinessLayer.Models;
using FridgeProduct.BusinessLayer.Services;
using FridgeProduct.Contracts;
using FridgeProduct.Entities;
using FridgeProduct.Entities.Models;
using FridgeProduct.Repository;
using FridgeProduct.Tests.Infrastructure.Helpers;
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
        public ProductServiceTests()
        {
            var contextHelper = new DbContextHelper();
            _dbContext = contextHelper.Context;
        }

        [Fact]
        public async Task ItShould_return_true_when_product_name_duplicate()
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
        public async Task ItShould_return_true_when_product_created()
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
        }
    }
}
