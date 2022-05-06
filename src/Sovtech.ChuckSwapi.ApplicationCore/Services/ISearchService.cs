using Sovtech.ChuckSwapi.Contracts.Responses;

namespace Sovtech.ChuckSwapi.ApplicationCore.Services;

public interface ISearchService
{
    Task<ApiResponse<SearchResultResponse>> GetSearchQueries(string query);
}
