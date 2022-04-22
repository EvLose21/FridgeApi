using FridgeProduct.Auditable.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FridgeProduct.Auditable.Data
{
    public class RecieveMessageContext : DbContext
    {
        public RecieveMessageContext(DbContextOptions<RecieveMessageContext> options)
            : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<RecieveMessage> Messages { get; set; }
    }
}
