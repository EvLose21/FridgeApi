using FridgeProduct.Auditable.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FridgeProduct.Auditable.Data.Repositories.Abstracts
{
    public interface IRecieveMessageRepository
    {
        Task<List<RecieveMessage>> GetMessagesAsync();
        void CreateMessage(RecieveMessage message);
        void Save();
    }
}
