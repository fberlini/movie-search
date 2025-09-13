using MovieSearch.Api.Application.Contracts;
using MovieSearch.Api.Application.Dtos;
using MovieSearch.Api.Domain.Entities;
using MovieSearch.Api.Shared.Exceptions.Repositories;
using MovieSearch.Api.Shared.Exceptions.Services;

namespace MovieSearch.Api.Application.Services;

public class AdminService(IRequestRepository requestRepository) : IAdminService
{
    private readonly IRequestRepository _requestRepository = requestRepository;

    public async Task<MovieRequest> CreateRequest(CreateRequestDto request)
    {
        try
        {
            var movieRequest = new MovieRequest
            {
                Id = Guid.NewGuid(),
                SearchToken = request.SearchToken ?? string.Empty,
                IpAddress = request.IpAddress ?? string.Empty,
                Timestamp = request.Timestamp,
                ImdbId = request.ImdbId,
                ProcessingTimeMs = request.ProcessingTimeMs
            };
            return await _requestRepository.CreateRequest(movieRequest);
        }
        catch (Exception exception)
        {
            throw HandleExceptions(exception);
        }
    }

    public async Task DeleteRequest(Guid id)
    {
        try
        {
            await _requestRepository.DeleteRequest(id);
        }
        catch (Exception exception)
        {
            throw HandleExceptions(exception);
        }
    }

    public async Task<MovieRequest> GetRequest(Guid id)
    {
        try
        {
            return await _requestRepository.GetRequestById(id);
        }
        catch (Exception exception)
        {
            throw HandleExceptions(exception);
        }
    }

    public async Task<MovieRequest[]> GetRequests(DateTime? startDate, DateTime? endDate)
    {
        try
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
        }
        catch (Exception exception)
        {
            throw HandleExceptions(exception);
        }
        throw new AdminServiceDateRangeInvalidException();
    }

    public async Task<MovieRequest[]> GetRequestsByIpAddress(string ipAddress)
    {
        try
        {
            return await _requestRepository.GetRequestsByIpAddress(ipAddress);
        }
        catch (Exception exception)
        {
            throw HandleExceptions(exception);
        }
    }

    private Exception HandleExceptions(Exception exception)
    {
        if (exception is MovieRequestNotFoundException)
        {
            return new AdminServiceMovieRequestNotFoundException();
        }
        if (exception is CreateRequestFailedException)
        {
            return new AdminServiceCreateRequestFailedException();
        }
        if (exception is DeleteRequestFailedException)
        {
            return new AdminServiceDeleteRequestFailedException();
        }
        if (exception is GetRequestFailedException)
        {
            return new AdminServiceGetRequestFailedException();
        }
        throw new AdminServiceUnknownError();
    }
}