using Sovtech.ChuckSwapi.ApplicationCore.Helpers;
using Sovtech.ChuckSwapi.Contracts.Responses;

namespace Sovtech.ChuckSwapi.ApplicationCore.ApiClients;

public interface IChuckApiClient
{
    /// <summary>
    /// Get all the joke categories from the provided URL
    /// https://api.chucknorris.io/jokes/categories 
    /// </summary>
    /// <returns>All the joke categories</returns>
    Task<ApplicationResponse<IReadOnlyList<string>>> GetAllChuckJokeCategories(CancellationToken cancellationToken = default);

    Task<ApplicationResponse<JokeSearchListResponse>> GetJokesSearchResult(string query, CancellationToken cancellationToken = default);

    Task<ApplicationResponse<JokeSearchResponse>> GetRandomJokes(string category, CancellationToken cancellationToken = default);

}

