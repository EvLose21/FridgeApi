using FridgeProduct.BusinessLayer.MediatR.Products.Commands;
using FridgeProduct.BusinessLayer.MediatR.Products.Queries;
using FridgeProduct.Entities.DataTransferObjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FridgeProduct.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet(Name = "GetProducts")]
        public async Task<IActionResult> GetProducts()
        {
            var result = await _mediator.Send(new GetProductsQuery());
            return Ok(result);
        }
        [HttpGet("{id}", Name = "ProductById")]
        public async Task<IActionResult> GetProduct(Guid id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(id));
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductForCreationDto product)
        {
            var productToReturn = await _mediator.Send(new CreateProductCommand(product));

            return CreatedAtRoute(nameof(GetProducts), new { id = productToReturn }, productToReturn);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductForFridge(Guid id)
        {
            var product = await _mediator.Send(new DeleteProductCommand(id));
            return NoContent();
        }
    }
}
