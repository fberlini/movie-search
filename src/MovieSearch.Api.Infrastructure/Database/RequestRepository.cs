using MongoDB.Driver;
using MovieSearch.Api.Application.Contracts;
using MovieSearch.Api.Domain.Entities;
using MovieSearch.Api.Infrastructure.Database.Dtos;
using MovieSearch.Api.Infrastructure.Database.Mappers;
using MovieSearch.Api.Shared.Exceptions.Repositories;

namespace MovieSearch.Api.Infrastructure.Database;

public class RequestRepository(IMongoDbConnectionProvider mongoDbConnectionProvider) : IRequestRepository
{
    private readonly IMongoCollection<MovieRequestDto> _collection = mongoDbConnectionProvider.GetCollection<MovieRequestDto>("movieRequests");

    public async Task<MovieRequest> CreateRequest(MovieRequest request)
    {
        try
        {
            var dto = request.ToDto();
            await _collection.InsertOneAsync(dto);
            return request;
        }
        catch (Exception)
        {
            throw new CreateRequestFailedException();
        }
    }

    public async Task DeleteRequest(Guid id)
    {
        try
        {
            var filter = Builders<MovieRequestDto>.Filter.Eq(x => x.Id, id);
            await _collection.FindOneAndDeleteAsync(filter);
        }
        catch (Exception)
        {
            throw new DeleteRequestFailedException();
        }
    }

    public async Task<MovieRequest> GetRequestById(Guid id)
    {
        try
        {
            var filter = Builders<MovieRequestDto>.Filter.Eq(x => x.Id, id);
            var request = await _collection.Find(filter).FirstOrDefaultAsync() ?? throw new MovieRequestNotFoundException();
            return request.ToDomain();
        }
        catch (Exception exception)
        {
            if (exception is MovieRequestNotFoundException)
            {
                throw;
            }

            throw new GetRequestFailedException();
        }
    }

    public async Task<MovieRequest[]> GetRequests()
    {
        try
        {
            var requests = await _collection.Find(_ => true).ToListAsync();
            return requests.ToArray().ToDomainArray();
        }
        catch (Exception)
        {
            throw new GetRequestFailedException();
        }
    }

    public async Task<long> GetRequestsByDay(DateTime date)
    {
        try
        {
            var startOfDay = date.Date;
            var endOfDay = startOfDay.AddDays(1);
            var filter = Builders<MovieRequestDto>.Filter.And(
                Builders<MovieRequestDto>.Filter.Gte(x => x.Timestamp, startOfDay),
                Builders<MovieRequestDto>.Filter.Lt(x => x.Timestamp, endOfDay)
            );
            var requests = await _collection.CountDocumentsAsync(filter);
            return requests;
        }
        catch (Exception)
        {
            throw new GetRequestFailedException();
        }
    }

    public async Task<MovieRequest[]> GetRequestsByIpAddress(string ipAddress)
    {
        try
        {
            var filter = Builders<MovieRequestDto>.Filter.Eq(x => x.IpAddress, ipAddress);
            var requests = await _collection.Find(filter).ToListAsync();
            return requests.ToArray().ToDomainArray();
        }
        catch (Exception)
        {
            throw new GetRequestFailedException();
        }
    }

    public async Task<MovieRequest[]> GetRequestsRange(DateTime startDate, DateTime endDate)
    {
        try
        {
            var filter = Builders<MovieRequestDto>.Filter.And(
                Builders<MovieRequestDto>.Filter.Gte(x => x.Timestamp, startDate),
                Builders<MovieRequestDto>.Filter.Lte(x => x.Timestamp, endDate)
            );
            var requests = await _collection.Find(filter).ToListAsync();
            return requests.ToArray().ToDomainArray();
        }
        catch (Exception)
        {
            throw new GetRequestFailedException();
        }
    }
}