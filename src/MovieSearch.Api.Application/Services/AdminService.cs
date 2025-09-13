using MovieSearch.Api.Application.Contracts;
using MovieSearch.Api.Application.Dtos;
using MovieSearch.Api.Domain.Entities;
using MovieSearch.Api.Shared.Exceptions.Services;

namespace MovieSearch.Api.Application.Services;

public class AdminService(IRequestRepository requestRepository) : IAdminService
{
    private readonly IRequestRepository _requestRepository = requestRepository;

    public async Task<MovieRequest> CreateRequest(CreateRequestDto request)
    {
        var movieRequest = new MovieRequest {
            Id = Guid.NewGuid(),
            SearchToken = request.SearchToken ?? string.Empty,
            IpAddress = request.IpAddress ?? string.Empty,
            Timestamp = request.Timestamp,
            ImdbId = request.ImdbId,
            ProcessingTimeMs = request.ProcessingTimeMs
        };
        return await _requestRepository.CreateRequest(movieRequest);
    }

    public async Task DeleteRequest(Guid id)
    {
        await _requestRepository.DeleteRequest(id);
    }

    public async Task<MovieRequest> GetRequest(Guid id)
    {
        return await _requestRepository.GetRequestById(id);
    }

    public async Task<MovieRequest[]> GetRequests(DateTime? startDate, DateTime? endDate)
    {
        if (startDate == null && endDate == null)
        {
            return await _requestRepository.GetRequests();
        }
        else if (startDate != null && endDate == null)
        {
            return await _requestRepository.GetRequestsByDay(startDate.Value);
        }
        else if (startDate != null && endDate != null)
        {
            return await _requestRepository.GetRequestsRange(startDate.Value, endDate.Value);
        }
        throw new AdminServiceDateRangeInvalidException();
    }

    public async Task<MovieRequest[]> GetRequestsByIpAddress(string ipAddress)
    {
        return await _requestRepository.GetRequestsByIpAddress(ipAddress);
    }
}