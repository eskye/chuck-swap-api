using Microsoft.AspNetCore.Mvc;
using Sovtech.ChuckSwapi.ApplicationCore.ApiClients;
using Sovtech.ChuckSwapi.ApplicationCore.Services;
using Sovtech.ChuckSwapi.Contracts.Responses;

namespace Sovtech.ChuckSwapi.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChuckController : ControllerBase
    {
       
        private readonly ILogger<ChuckController> _logger;
        private readonly IChuckService _chuckService;

        public ChuckController(ILogger<ChuckController> logger, IChuckService chuckService)
        {
            _logger = logger;
            _chuckService = chuckService;
        }

        [HttpGet("categories")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiErrorResponse))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<IReadOnlyList<string>>))]
        public async Task<ActionResult<IReadOnlyList<string>>> GetCategories()
        {
            var response = await _chuckService.Categories();
            return Ok(response);
        }

        [HttpGet("category/{category}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiErrorResponse))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<JokeSearchResponse>))]
        public async Task<ActionResult<ApiResponse<JokeSearchResponse>>> GetCategoryDetail(string category)
        {
            var response = await _chuckService.CategoryDetail(category);
            return Ok(response);
        }
    }
}