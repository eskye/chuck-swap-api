using Sovtech.ChuckSwapi.ApplicationCore.ApiClients;
using Sovtech.ChuckSwapi.Contracts.Responses;

namespace Sovtech.ChuckSwapi.ApplicationCore.Services;

public class ChuckService : IChuckService
{
    private readonly IChuckApiClient _chuckApiClient;

    public ChuckService(IChuckApiClient chuckApiClient)
    {
        _chuckApiClient=chuckApiClient;
    }
    public async Task<ApiResponse<IReadOnlyList<string>>> Categories()
    {
        var response = await _chuckApiClient.GetAllChuckJokeCategories();
        return new ApiResponse<IReadOnlyList<string>>(response.Data, "All the joke categories retrieved successfully");
    }

    public async Task<ApiResponse<JokeSearchResponse>> CategoryDetail(string category)
    {
        if (string.IsNullOrEmpty(category)) throw new ArgumentNullException("No category provided");
        var response = await _chuckApiClient.GetRandomJokes(category);
        return new ApiResponse<JokeSearchResponse>(response.Data, "Category detail retrieved successfully");
    }
}
