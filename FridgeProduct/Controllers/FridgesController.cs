using AutoMapper;
using FridgeProduct.Contracts;
using FridgeProduct.Entities.DataTransferObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FridgeProduct.Controllers
{
    [Route("api/fridges")]
    [ApiController]
    public class FridgesController : ControllerBase
    {
        private readonly IRepositoryManager _repostitory;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public FridgesController(IRepositoryManager repostitory, ILoggerManager logger, IMapper mapper)
        {
            _repostitory = repostitory;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetFridges()
        {
            var fridges = _repostitory.Fridge.GetAllFridges(trackChanges: false);
            var fridgesDto = _mapper.Map<IEnumerable<FridgeDto>>(fridges);
            return Ok(fridgesDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetFridge(Guid id)
        {
            var fridge = _repostitory.Fridge.GetFridge(id, trackChanges: false);
            if(fridge == null)
            {
                _logger.LogInfo($"Fridge with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var fridgeDto = _mapper.Map<FridgeDto>(fridge);
                return Ok(fridgeDto);
            }
        }
    }
}
