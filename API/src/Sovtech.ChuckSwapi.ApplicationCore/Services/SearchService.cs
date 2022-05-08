using Sovtech.ChuckSwapi.ApplicationCore.ApiClients;
using Sovtech.ChuckSwapi.ApplicationCore.Exceptions;
using Sovtech.ChuckSwapi.Contracts.Responses;

namespace Sovtech.ChuckSwapi.ApplicationCore.Services;

public class SearchService : ISearchService
{
    private readonly IChuckApiClient _chuckApiClient;
    private readonly ISwapiApiClient _swapiApiClient;

    public SearchService(IChuckApiClient chuckApiClient, ISwapiApiClient swapiApiClient)
    {
        _chuckApiClient=chuckApiClient;
        _swapiApiClient=swapiApiClient;
    }
    public async Task<ApiResponse<SearchResultResponse>> GetSearchQueries(string query)
    {
        if (string.IsNullOrEmpty(query)) throw new ArgumentNullException(nameof(query), "No search query provided");

        if (query.Length <= 3) throw new ApiException("Search paramter value size must be between 3 and 120");

        var jokeSearchResponse = await _chuckApiClient.GetJokesSearchResult(query); 

        var jokeSearchResult = new JokeSearchResult("Chuck Norris Api Client", jokeSearchResponse.Data.Result);

        var peopleSearchResponse = await _swapiApiClient.GetPeopleSearchResult(query);
        var peopleSearchResult = new PeopleSearchResult("Star Wars Api Client", peopleSearchResponse.Data.Results);

        var response = new SearchResultResponse(jokeSearchResult, peopleSearchResult);
        return new ApiResponse<SearchResultResponse>(response, "Search Result");


    }
}
