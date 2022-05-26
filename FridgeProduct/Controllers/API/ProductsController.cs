using AutoMapper;
using FridgeProduct.BusinessLayer.MediatR.Products.Commands;
using FridgeProduct.BusinessLayer.MediatR.Products.Queries;
using FridgeProduct.Contracts;
using FridgeProduct.Entities.DataTransferObjects;
using FridgeProduct.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FridgeProduct.Controllers
{
    [Route("api/products")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    public class ProductsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProductsController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper, IMediator mediator)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            _mediator = mediator;
        }
        [HttpGet(Name = "GetProducts")]
        public async Task<IActionResult> GetProducts()
        {
            var result = await _mediator.Send(new GetProductsQuery());
            return Ok(result);
            //var products = await _repository.Product.GetAllProductsAsync(trackChanges: false);
            //var productsDto = _mapper.Map<IEnumerable<ProductDto>>(products);
            //return Ok(productsDto);
        }
        [HttpGet("{id}", Name = "ProductById")]
        public async Task<IActionResult> GetProduct(Guid id)
        {
            var product = await _repository.Product.GetProductAsync(id, trackChanges: false);
            if (product == null)
            {
                _logger.LogInfo($"Product with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var productDto = _mapper.Map<ProductDto>(product);
                return Ok(productDto);
            }
        }

        [HttpGet("products-count")]
        public IActionResult GetProductCount()
        {
            int productsCount = _repository.Product.GetAllProductsQuery(false).Count();

            return Ok(productsCount);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductForCreationDto product)
        {
            var productToReturn = await _mediator.Send(new CreateProductCommand(product));

            return CreatedAtRoute("GetProducts", new { id = productToReturn }, productToReturn);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductForFridge(Guid id)
        {
            var product = await _repository.Product.GetProductAsync(id, trackChanges: true);
            if (product == null)
            {
                _logger.LogInfo($"Product with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _repository.Product.Delete(product);
            await _repository.SaveAsync();

            return NoContent();
        }
    }
}
