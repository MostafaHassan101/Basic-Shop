using DevExtreme.AspNet.Data.ResponseModel;
using BasicShop.Application.Search.Queries.GetAllProductsQuery;
using BasicShop.Application.Search.Queries.SearchProductQuery;
using Microsoft.AspNetCore.Mvc;
using WebApi.ModelBinders;


namespace WebApi.Controllers
{
    [Route("api/search")]
    public class SearchController : ApiControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> SearchByKeyword(string q = "")
        {
            var command = new SearchProductQuery { SearchKeyword = q };
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> SearchByKeywordByAmdin(string q = "")
        {
            var command = new SearchProductQuery { SearchKeyword = q, IsAdmin = true };
            return Ok(await Mediator.Send(command));
        }
    }
}
