using Microsoft.AspNetCore.Mvc;
using Sovtech.ChuckSwapi.ApplicationCore.Services;
using Sovtech.ChuckSwapi.Contracts.Responses;

namespace Sovtech.ChuckSwapi.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SwapiController : ControllerBase
{
    private readonly ILogger<SwapiController> _logger;
    private readonly ISwapiService _swapiService;

    public SwapiController(ILogger<SwapiController> logger, ISwapiService swapiService)
    {
        _logger = logger;
        _swapiService = swapiService;
    }

    [HttpGet("people")]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiErrorResponse))]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<IReadOnlyList<PeopleResponse>>))]
    public async Task<ActionResult<IReadOnlyList<PeopleResponse>>> GetPeople()
    {
        var response = await _swapiService.PeopleList();
        return Ok(response);
    }
}