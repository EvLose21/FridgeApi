using FridgeProduct.Auditable.Data;

namespace FridgeProduct.Auditable.Services
{
    public interface IDbContextFactory
    {
        RecieveMessageContext CreateDbContext();
    }
}
