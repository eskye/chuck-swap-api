using Sovtech.ChuckSwapi.ApplicationCore.ApiClients;
using Sovtech.ChuckSwapi.Contracts.Responses;

namespace Sovtech.ChuckSwapi.ApplicationCore.Services;

public class SwapiService : ISwapiService
{
    private readonly ISwapiApiClient _swapiApiClient;

    public SwapiService(ISwapiApiClient swapiApiClient)
    {
        _swapiApiClient = swapiApiClient;
    }  
    public async Task<ApiResponse<IReadOnlyList<PeopleResponse>>> PeopleList(int pageNumber = 1)
    {
        var response = await _swapiApiClient.GetAllStarWarsPeople(pageNumber);
        return new ApiResponse<IReadOnlyList<PeopleResponse>>(response.Data.Results, "List of all the Star Wars people");
    }
}
