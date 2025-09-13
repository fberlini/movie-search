using MovieSearch.Api.Application.Dtos;
using MovieSearch.Api.Domain.Entities;

namespace MovieSearch.Api.Application.Contracts;

public interface IAdminService
{
    Task<MovieRequest> CreateRequest(CreateRequestDto request);
    Task<MovieRequest[]> GetRequests(DateTime? startDate, DateTime? endDate);
    Task<MovieRequest> GetRequest(Guid id);
    Task<MovieRequest[]> GetRequestsByIpAddress(string ipAddress);
    Task DeleteRequest(Guid id);
}