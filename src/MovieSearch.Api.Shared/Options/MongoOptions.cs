namespace MovieSearch.Api.Shared.Options;

public class MongoOptions
{
    public const string MongoSettings = "MongoDbSettings";

    public required string ConnectionString { get; set; }
    public required string DatabaseName { get; set; }
}