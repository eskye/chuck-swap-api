using Sovtech.ChuckSwapi.ApplicationCore.Constants;
using Sovtech.ChuckSwapi.ApplicationCore.Helpers;
using Sovtech.ChuckSwapi.Contracts.Responses;

namespace Sovtech.ChuckSwapi.ApplicationCore.ApiClients;

public class ChuckApiClient : IChuckApiClient
{
    private readonly HttpClient _httpClient;
    public ChuckApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<ApplicationResponse<IReadOnlyList<string>>> GetAllChuckJokeCategories(CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.HttpGetAsync<IReadOnlyList<string>>(ApiUrlConstants.JokesCategories);
        return response;
    }

    public async Task<ApplicationResponse<JokeSearchListResponse>> GetJokesSearchResult(string query, CancellationToken cancellationToken = default)
    {
        var url = QueryHelper.AddQueryString(ApiUrlConstants.JokeSearch, "query", query);
        var response = await _httpClient.HttpGetAsync<JokeSearchListResponse>(url);
        return response;
    }

    public async Task<ApplicationResponse<JokeSearchResponse>> GetRandomJokes(string category, CancellationToken cancellationToken = default)
    {
        var url = QueryHelper.AddQueryString(ApiUrlConstants.GetRandomJoke, "category", category);
        var response = await _httpClient.HttpGetAsync<JokeSearchResponse>(url);
        return response;
    }
}
