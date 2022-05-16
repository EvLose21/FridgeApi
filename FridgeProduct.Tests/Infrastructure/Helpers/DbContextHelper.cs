using FridgeProduct.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace FridgeProduct.Tests.Infrastructure.Helpers
{
    public class DbContextHelper
    {
        public RepositoryContext Context { get; set; }
        public DbContextHelper()
        {
            
            var builder = new DbContextOptionsBuilder<RepositoryContext>();
            builder.UseInMemoryDatabase("Unit_Testing")
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));

            var options = builder.Options;
            Context = new RepositoryContext(options, false);
            Context.Database.EnsureDeleted();
            Context.AddRange(ProductHelper.Getmany());

            Context.SaveChanges();
        }
    }
}
