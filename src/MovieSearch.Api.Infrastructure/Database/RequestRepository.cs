using MongoDB.Driver;
using MovieSearch.Api.Application.Contracts;
using MovieSearch.Api.Domain.Entities;
using MovieSearch.Api.Infrastructure.Database.Dtos;
using MovieSearch.Api.Infrastructure.Database.Mappers;

namespace MovieSearch.Api.Infrastructure.Database;

public class RequestRepository(IMongoDbConnectionProvider mongoDbConnectionProvider) : IRequestRepository
{
    private readonly IMongoCollection<MovieRequestDto> _collection = mongoDbConnectionProvider.GetCollection<MovieRequestDto>("movieRequests");

    public async Task<MovieRequest> CreateRequest(MovieRequest request)
    {
        var dto = request.ToDto();
        await _collection.InsertOneAsync(dto);
        return request;
    }

    public async Task DeleteRequest(string id)
    {
        var filter = Builders<MovieRequestDto>.Filter.Eq(x => x.Id, Guid.Parse(id));
        await _collection.FindOneAndDeleteAsync(filter);
    }

    public async Task<MovieRequest> GetRequestById(string id)
    {
        var filter = Builders<MovieRequestDto>.Filter.Eq(x => x.Id, Guid.Parse(id));
        var request = await _collection.Find(filter).FirstOrDefaultAsync();
        return request.ToDomain();
    }

    public async Task<MovieRequest[]> GetRequests()
    {
        var requests = await _collection.Find(_ => true).ToListAsync();
        return requests.ToArray().ToDomainArray();
    }

    public async Task<MovieRequest[]> GetRequestsByDay(DateTime date)
    {
        var startOfDay = date.Date;
        var endOfDay = startOfDay.AddDays(1);
        var filter = Builders<MovieRequestDto>.Filter.And(
            Builders<MovieRequestDto>.Filter.Gte(x => x.Timestamp, startOfDay),
            Builders<MovieRequestDto>.Filter.Lt(x => x.Timestamp, endOfDay)
        );
        var requests = await _collection.Find(filter).ToListAsync();
        return requests.ToArray().ToDomainArray();
    }

    public async Task<MovieRequest[]> GetRequestsByIpAddress(string ipAddress)
    {
        var filter = Builders<MovieRequestDto>.Filter.Eq(x => x.IpAddress, ipAddress);
        var requests = await _collection.Find(filter).ToListAsync();
        return requests.ToArray().ToDomainArray();
    }

    public async Task<MovieRequest[]> GetRequestsRange(DateTime startDate, DateTime endDate)
    {
        var filter = Builders<MovieRequestDto>.Filter.And(
            Builders<MovieRequestDto>.Filter.Gte(x => x.Timestamp, startDate),
            Builders<MovieRequestDto>.Filter.Lte(x => x.Timestamp, endDate)
        );
        var requests = await _collection.Find(filter).ToListAsync();
        return requests.ToArray().ToDomainArray();
    }
}