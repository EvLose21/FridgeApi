using FridgeProduct.Auditable.Data.Repositories.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FridgeProduct.Auditable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IRecieveMessageRepository _repository;
        public MessagesController(IRecieveMessageRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetMessages()
        {
            var messages = await _repository.GetMessagesAsync();
            return Ok(messages);
        }
    }
}
