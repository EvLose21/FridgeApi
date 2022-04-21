using FridgeProduct.Auditable.Data.Models;
using FridgeProduct.Auditable.Data.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FridgeProduct.Auditable.Data.Repositories
{
    public class RecieveMessageRepository : IRecieveMessageRepository
    {
        private readonly RecieveMessageContext _context;
        public RecieveMessageRepository(RecieveMessageContext context)
        {
            _context = context;
        }

        public void CreateMessage(RecieveMessage message)
        {
            _context.Messages.Add(message);
        }

        public async Task<List<RecieveMessage>> GetMessagesAsync()
            => await _context.Messages.ToListAsync();

        public async void Save() => await _context.SaveChangesAsync();
    }
}
