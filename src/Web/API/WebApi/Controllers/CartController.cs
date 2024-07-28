using BasicShop.Application.Carts.Commands.AddItem;
using BasicShop.Application.Carts.Commands.DeleteItem;
using BasicShop.Application.Carts.Commands.UpdateItem;
using BasicShop.Application.Carts.Queries.GetCartItems;
using Microsoft.AspNetCore.Mvc;
using WebApi.ModelBinders;

namespace WebApi.Controllers
{
    [Route("api/cart")]
    public class CartController : ApiControllerBase
    {

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetItems()
        {
            var command = new GetCartItemsQuery { };
            return Ok(await Mediator.Send(command));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> AddItemToCart(AddItemCommand addItemCommand)
        {
            await Mediator.Send(addItemCommand);
            return Ok();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> UpdateCartItem(UpdateItemCommand updateItem)
        {
            await Mediator.Send(updateItem);
            return Ok();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> RemoveItemFromCart([FromForm] Guid key)
        {
            var command = new DeleteItemCommand { Id = key };
            await Mediator.Send(command);
            return Ok();
        }

    }
}
