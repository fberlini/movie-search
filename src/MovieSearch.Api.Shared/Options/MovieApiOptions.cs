namespace MovieSearch.Api.Shared.Options;

public class MovieApiOptions
{
    public const string MovieApiSettings = "ExternalServices:MovieApiSettings";

    public required string BaseUrl { get; set; }
    public required string ApiKey { get; set; }
}