using AutoMapper;
using FridgeProduct.Contracts;
using FridgeProduct.Entities.DataTransferObjects;
using FridgeProduct.Entities.Models;
using FridgeProduct.Entities.RequestFeatures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using FridgeProduct.BusinessLayer.MediatR.Fridges.Queries;

namespace FridgeProduct.Controllers
{
    [Route("api/fridges")]
    [ApiController]
    public class FridgesController : ControllerBase
    {
        private readonly IRepositoryManager _repostitory;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public FridgesController(IRepositoryManager repostitory, ILoggerManager logger, IMapper mapper, IMediator mediator)
        {
            _repostitory = repostitory;
            _logger = logger;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet, Authorize]
        public async Task<IActionResult> GetFridges()
        {
            var fridges = await _mediator.Send(new GetFridgesQuery());
            return Ok(fridges);
        }

        [HttpGet("{fridgeId}")]
        public async Task<IActionResult> GetProductsForFridge(Guid fridgeId, [FromQuery] ProductParameters productParameters)
        {
            var fridge = await _repostitory.Fridge.GetFridgeAsync(fridgeId, trackChanges: false);
            if (fridge == null)
            {
                _logger.LogInfo($"Fridge with id: {fridgeId} doesn't exist in the database.");
                return NotFound();
            }

            var productsFromDb = _repostitory.Product.GetProducts(fridgeId, productParameters, trackChanges: false);
            return Ok(productsFromDb);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] FridgeToProductForCreationDto fproduct)
        {
            if (fproduct == null)
            {
                _logger.LogError("FridgeToProductDto object sent from client is null.");
                return BadRequest("FridgeToProductDto object is null");
            }

            var fproductEntity = _mapper.Map<FridgeToProduct>(fproduct);
            _repostitory.FridgeToProduct.AddProductForFridge(fproductEntity);
            await _repostitory.SaveAsync();

            var fproductToReturn = _mapper.Map<FridgeToProductDto>(fproductEntity);

            return CreatedAtRoute("", new { id = fproductToReturn.FridgeId }, fproductToReturn);
        }

        [HttpGet("{fridgeId}/addmissingproducts")]
        public async Task<IActionResult> MissProduct(Guid fridgeId)
        {
            var products = await _repostitory.FridgeToProduct.GetMissingProductAsync(fridgeId, trackChanges: false);
            var productsDto = _mapper.Map<IEnumerable<FridgeToProductDto>>(products);
            return Ok(productsDto);
        }

        [HttpDelete("{fridgeId}/{id}")]
        public async Task<IActionResult> DeleteProductForFridge(Guid fridgeId, Guid id)
        {
            var fproduct = _repostitory.FridgeToProduct.GetFProduct(fridgeId, id, trackChanges: false);
            if (fproduct == null)
            {
                _logger.LogInfo($"Product with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _repostitory.FridgeToProduct.DeleteProductForFridge(fproduct);
            await _repostitory.SaveAsync();

            return NoContent();
        }

        [HttpPut("{id}")] 
        public async Task<IActionResult> UpdateFridge(Guid id, [FromBody] FridgeForUpdateDto fridge) 
        { 
            if (fridge == null) 
            { 
                _logger.LogError("FridgeForUpdateDto object sent from client is null."); 
                return BadRequest("FridgeForUpdateDto object is null"); 
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the FridgeForUpdateDto object");
                return UnprocessableEntity(ModelState);
            }

            var fridgeEntity = await _repostitory.Fridge.GetFridgeAsync(id, trackChanges: true);
            if (fridgeEntity == null) 
            {
                _logger.LogInfo($"Fridge with id: {id} doesn't exist in the database."); 
                return NotFound(); 
            } 
            _mapper.Map(fridge, fridgeEntity); 
            await _repostitory.SaveAsync();
            return NoContent(); 
        }
    }
}
