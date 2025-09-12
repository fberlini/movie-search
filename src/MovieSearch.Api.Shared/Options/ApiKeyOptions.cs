namespace MovieSearch.Api.Shared.Options;

public class ApiKeyOptions
{
    public const string AuthenticationApiKey = "Authentication:ApiKey";

    public required string HeaderName { get; set; }
    public required string Key { get; set; }
}