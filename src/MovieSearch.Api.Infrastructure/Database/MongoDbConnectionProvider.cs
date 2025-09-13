using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MovieSearch.Api.Shared.Options;

namespace MovieSearch.Api.Infrastructure.Database;

public interface IMongoDbConnectionProvider
{
    IMongoDatabase GetDatabase();
    IMongoCollection<T> GetCollection<T>(string collectionName);
}

public class MongoDbConnectionProvider : IMongoDbConnectionProvider, IDisposable
{
    private readonly IMongoDatabase _database;
    private readonly MongoClient _client;
    private bool _disposed = false;

    public MongoDbConnectionProvider(IOptions<MongoOptions> options)
    {
        _client = new MongoClient(options.Value.ConnectionString);
        _database = _client.GetDatabase(options.Value.DatabaseName);
    }

    public IMongoDatabase GetDatabase()
    {
        return _database;
    }

    public IMongoCollection<T> GetCollection<T>(string collectionName)
    {
        return _database.GetCollection<T>(collectionName);
    }

    public void Dispose()
    {
        if (!_disposed)
        {
            _client?.Dispose();
            _disposed = true;
        }
    }
}