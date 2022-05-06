using Sovtech.ChuckSwapi.ApplicationCore.Constants;
using Sovtech.ChuckSwapi.ApplicationCore.Helpers;
using Sovtech.ChuckSwapi.Contracts.Responses;

namespace Sovtech.ChuckSwapi.ApplicationCore.ApiClients;

public class SwapiApiClient : ISwapiApiClient
{
    private readonly HttpClient _httpClient;
    public SwapiApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ApplicationResponse<PeopleListResponse>> GetAllStarWarsPeople(int pageNumber)
    {
        var url = QueryHelper.AddQueryString(ApiUrlConstants.People, "page", pageNumber.ToString());
        var response = await _httpClient.HttpGetAsync<PeopleListResponse>(url);
        return response;
    }

    public async Task<ApplicationResponse<PeopleListResponse>> GetPeopleSearchResult(string query)
    {
        var url = QueryHelper.AddQueryString(ApiUrlConstants.People, "search", query);
        var response = await _httpClient.HttpGetAsync<PeopleListResponse>(url);
        return response;
    }
}
