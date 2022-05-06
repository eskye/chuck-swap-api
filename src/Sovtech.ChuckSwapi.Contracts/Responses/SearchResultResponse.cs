namespace Sovtech.ChuckSwapi.Contracts.Responses;

public record SearchResultResponse(JokeSearchResult JokeSearchResult, PeopleSearchResult PeopleSearchResult);
public record BaseSearchResultMetadata(string DownStreamApiName);


public record JokeSearchResult : BaseSearchResultMetadata
{
    public JokeSearchResult(string DownStreamApiName, IReadOnlyList<JokeSearchResponse> jokes) : base(DownStreamApiName)
    {
        Jokes=jokes;
    }
    public IReadOnlyList<JokeSearchResponse> Jokes { get; }
}


public record PeopleSearchResult : BaseSearchResultMetadata
{
    public PeopleSearchResult(string DownStreamApiName, IReadOnlyList<PeopleResponse> peoples) : base(DownStreamApiName)
    {
        Peoples = peoples;
    }

    public IReadOnlyList<PeopleResponse> Peoples { get; }
}

