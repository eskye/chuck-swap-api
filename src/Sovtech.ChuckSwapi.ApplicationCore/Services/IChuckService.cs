using Sovtech.ChuckSwapi.Contracts.Responses;

namespace Sovtech.ChuckSwapi.ApplicationCore.Services;

public interface IChuckService
{
    Task<ApiResponse<IReadOnlyList<string>>> Categories();

    Task<ApiResponse<JokeSearchResponse>> CategoryDetail(string category);
     

}
