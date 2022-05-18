using FridgeProduct.Entities;
using FridgeProduct.Entities.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace FridgeProduct.Tests
{
    public class IntegrationTest
    {
        /*protected readonly HttpClient TestClient;
        protected IntegrationTest()
        {
            var appFactory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        services.RemoveAll(typeof(RepositoryContext));
                        services.AddDbContext<RepositoryContext>(options => { options.UseInMemoryDatabase("TestDb"); });
                    });
                });
            TestClient = appFactory.CreateClient();
        }
        protected async Task<Product> CreateProductAsync(Product product)
        {
            var response = await TestClient.PostAsJsonAsync("api/products", product);
            return await response.Content.ReadAsAsync<Product>();
        }*/
    }
}
