using MovieSearch.Api.Domain.Entities;

namespace MovieSearch.Api.Application.Contracts;

public interface IRequestRepository
{
    Task<MovieRequest[]> GetRequests();
    Task<MovieRequest[]> GetRequestsRange(DateTime startDate, DateTime endDate);
    Task<MovieRequest[]> GetRequestsByDay(DateTime date);
    Task<MovieRequest[]> GetRequestsByIpAddress(string ipAddress);
    Task<MovieRequest> GetRequestById(string id);
    Task<MovieRequest> CreateRequest(MovieRequest request);
    Task DeleteRequest(string id);
}