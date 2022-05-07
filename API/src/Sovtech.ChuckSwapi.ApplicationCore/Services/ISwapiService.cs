using Sovtech.ChuckSwapi.Contracts.Responses;

namespace Sovtech.ChuckSwapi.ApplicationCore.Services;

public interface ISwapiService
{
    Task<ApiResponse<IReadOnlyList<PeopleResponse>>> PeopleList(int pageNumber); 
}
