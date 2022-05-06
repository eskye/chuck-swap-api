using Microsoft.AspNetCore.Mvc;
using Sovtech.ChuckSwapi.ApplicationCore.Services;
using Sovtech.ChuckSwapi.Contracts.Responses;

namespace Sovtech.ChuckSwapi.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
           _searchService=searchService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiErrorResponse))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<ApiResponse<SearchResultResponse>>))]
        public async Task<ActionResult<ApiResponse<SearchResultResponse>>> Get(string query)
        {
            var response = await _searchService.GetSearchQueries(query);
            return Ok(response);
        }
    }

}