using AutoMapper;
using FridgeProduct.Contracts;
using FridgeProduct.Entities.DataTransferObjects;
using FridgeProduct.Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;

namespace FridgeProduct.Controllers
{
    [Route("api/fridges/{fridgeId}/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ProductsController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetProductsForFridge(Guid fridgeId)
        {
            var fridge = _repository.Fridge.GetFridge(fridgeId, trackChanges: false);
            if (fridge == null)
            {
                _logger.LogInfo($"Fridge with id: {fridgeId} doesn't exist in the database.");
                return NotFound();
            }

            var productsFromDb = _repository.Product.GetProducts(fridgeId, trackChanges: false);

            //var productsDto = _mapper.Map<IEnumerable<ProductDto>>(productsFromDb);
            return Ok(productsFromDb);
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductForCreationDto product)
        {
            if (product == null)
            {
                _logger.LogError("FridgeForCreationDto object sent from client is null.");
                return BadRequest("FridgeForCreationDto object is null");
            }

            var productEntity = _mapper.Map<Product>(product);
            _repository.Product.CreateProdcut(productEntity);
            _repository.Save();

            var productToReturn = _mapper.Map<ProductDto>(productEntity);

            return CreatedAtRoute("FridgeById", new { id = productToReturn.Id },
                productToReturn);
        }
        //[HttpDelete("id")]
        /*public IActionResult DeleteProductForFridge(Guid fridgeId, Guid id)
        {
            var fridge = _repository.Fridge.GetFridge(fridgeId, trackChanges: false);
            if(fridge == null)
            {
                _logger.LogInfo($"Fridge with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            var productForFridge = _repository.Product.GetProduct(fridgeId, id, trackChanges: false);
            if(productForFridge == null)
            {
                _logger.LogInfo($"Product with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            _repository.Product.DeleteProduct(product)
        }*/
        [HttpPut("{id}")] 
        public IActionResult UpdateProductForFridge(Guid fridgeId, Guid id, [FromBody] ProductForUpdateDto product) 
        { 
            if (product == null) 
            { 
                _logger.LogError("ProductForUpdateDto object sent from client is null."); 
                return BadRequest("ProductForUpdateDto object is null"); 
            } 
            var company = _repository.Fridge.GetFridge(fridgeId, trackChanges: false); 
            if (company == null) 
            { 
                _logger.LogInfo($"Fridge with id: {fridgeId} doesn't exist in the database."); 
                return NotFound(); 
            } 
            var productEntity = _repository.Product.GetProduct(fridgeId, id, trackChanges: true); 
            if (productEntity == null) 
            { 
                _logger.LogInfo($"Product with id: {id} doesn't exist in the database."); 
                return NotFound(); 
            } 
            _mapper.Map(product, productEntity); 
            _repository.Save();
            return NoContent();
        }
    }
}
