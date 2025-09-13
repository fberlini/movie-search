using MovieSearch.Api.Domain.Entities;
using MovieSearch.Api.Infrastructure.Database.Dtos;


namespace MovieSearch.Api.Infrastructure.Database.Mappers;

public static class MovieRequestMapper
{
    public static MovieRequestDto ToDto(this MovieRequest domain)
    {
        return new MovieRequestDto
        {
            Id = domain.Id,
            SearchToken = domain.SearchToken,
            ImdbId = domain.ImdbId,
            ProcessingTimeMs = domain.ProcessingTimeMs,
            Timestamp = domain.Timestamp,
            IpAddress = domain.IpAddress
        };
    }

    public static MovieRequest ToDomain(this MovieRequestDto dto)
    {
        return new MovieRequest
        {
            Id = dto.Id,
            SearchToken = dto.SearchToken,
            ImdbId = dto.ImdbId,
            ProcessingTimeMs = dto.ProcessingTimeMs,
            Timestamp = dto.Timestamp,
            IpAddress = dto.IpAddress
        };
    }

    public static MovieRequestDto[] ToDtoArray(this MovieRequest[] domainArray)
    {
        return domainArray.Select(ToDto).ToArray();
    }

    public static MovieRequest[] ToDomainArray(this MovieRequestDto[] dtoArray)
    {
        return dtoArray.Select(ToDomain).ToArray();
    }
}