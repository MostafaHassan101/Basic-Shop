using BasicShop.Application.Products.Commands.CreateProductCommand;
using BasicShop.Application.Products.Commands.DeleteProductCommand;
using BasicShop.Application.Products.Commands.UpdateProductCommand;
using BasicShop.Application.Search.Queries.GetAllProductsQuery;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/product")]
    public class ProductController : ApiControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetAllProductsForUser()
        {
            var command = new GetAllProductsQuery { };
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetAllProductsForAdmin()
        {
            var command = new GetAllProductsQuery { IsAdmin = true };
            return Ok(await Mediator.Send(command));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> CreateProduct(CreateProductCommand createProductCommand)
        {
            await Mediator.Send(createProductCommand);
            return Ok();
        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommand updateProductCommand)
        {
            await Mediator.Send(updateProductCommand);
            return Ok();
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            await Mediator.Send(new DeleteProductCommand { Id = id });
            return Ok();
        }
    }
}
