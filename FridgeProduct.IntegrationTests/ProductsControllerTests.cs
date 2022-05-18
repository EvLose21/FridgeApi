using FridgeProduct.Entities;
using FridgeProduct.Entities.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FridgeProduct.IntegrationTests
{
    [TestFixture]
    public class ProductsControllerTests
    {
        [Test]
        public async Task CheckStatus_SendRequest_ShouldReturnOk()
        {
            // Arrange

            WebApplicationFactory<Startup> webHost = new WebApplicationFactory<Startup>().WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    var dbContextDescriptor = services.SingleOrDefault(d =>
                        d.ServiceType == typeof(DbContextOptions<RepositoryContext>));

                    services.Remove(dbContextDescriptor);

                    services.AddDbContext<RepositoryContext>(options =>
                    {
                        options.UseInMemoryDatabase("test_db");
                    });
                });
            });

            HttpClient httpClient = webHost.CreateClient();

            // Act

            HttpResponseMessage response = await httpClient.GetAsync("api/products/");

            // Assert

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public async Task GetProductsCount_SendRequest_ShouldReturnActualProductsCount()
        {
            // Arrange

            WebApplicationFactory<Startup> webHost = new WebApplicationFactory<Startup>().WithWebHostBuilder(builer =>
            {
                builer.ConfigureTestServices(services =>
                {
                    var dbContextDescriptor = services.SingleOrDefault(d =>
                        d.ServiceType == typeof(DbContextOptions<RepositoryContext>));

                    services.Remove(dbContextDescriptor);

                    services.AddDbContext<RepositoryContext>(options =>
                    {
                        options.UseInMemoryDatabase("test_db");
                    });
                });
            });

            RepositoryContext dbContext =
                webHost.Services.CreateScope().ServiceProvider.GetService<RepositoryContext>();

            List<Product> products = new() { new Product(), new Product(), new Product() };

            await dbContext.Products.AddRangeAsync(products);

            await dbContext.SaveChangesAsync();

            HttpClient httpClient = webHost.CreateClient();

            // Act

            HttpResponseMessage response = await httpClient.GetAsync("api/delivery/products-count");

            // Assert

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            int productsCount = int.Parse(await response.Content.ReadAsStringAsync());

            Assert.AreEqual(products.Count, productsCount);
        }
    }
}
