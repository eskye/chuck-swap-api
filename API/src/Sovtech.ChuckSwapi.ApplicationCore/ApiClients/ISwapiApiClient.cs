using Sovtech.ChuckSwapi.ApplicationCore.Helpers;
using Sovtech.ChuckSwapi.Contracts.Responses;

namespace Sovtech.ChuckSwapi.ApplicationCore.ApiClients;

public interface ISwapiApiClient
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<ApplicationResponse<PeopleListResponse>> GetAllStarWarsPeople(int pageNumber);
    Task<ApplicationResponse<PeopleListResponse>> GetPeopleSearchResult(string query);

}

