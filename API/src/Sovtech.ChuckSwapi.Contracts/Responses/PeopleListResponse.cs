using Newtonsoft.Json;

namespace Sovtech.ChuckSwapi.Contracts.Responses;
public class PeopleListResponse
{
    [JsonProperty("count")]
    public int Count { get; set; }

    [JsonProperty("next")]
    public string Next { get; set; }

    [JsonProperty("previous")]
    public string Previous { get; set; }

    [JsonProperty("results")]
    public List<PeopleResponse> Results { get; set; }
}


