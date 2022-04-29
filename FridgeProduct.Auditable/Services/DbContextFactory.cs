using FridgeProduct.Auditable.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FridgeProduct.Auditable.Services
{
    public class DbContextFactory
        : IDbContextFactory
    {
        private readonly IConfiguration _configuration;
        public DbContextFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public RecieveMessageContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<RecieveMessageContext>();
            options.UseSqlServer(_configuration.GetConnectionString("sqlConnection"));
            return new RecieveMessageContext(options.Options);
        }
    }
}
