using Newtonsoft.Json;

namespace Sovtech.ChuckSwapi.Contracts.Responses;

public class JokeSearchListResponse
{
    [JsonProperty("total")]
    public int Total { get; set; }

    [JsonProperty("result")]
    public List<JokeSearchResponse> Result { get; set; }
}

