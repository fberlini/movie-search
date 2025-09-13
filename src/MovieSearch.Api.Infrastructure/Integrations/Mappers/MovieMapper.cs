using MovieSearch.Api.Domain.Entities;
using MovieSearch.Api.Infrastructure.Integrations.Dtos;

namespace MovieSearch.Api.Infrastructure.Integrations.Mappers;

public static class MovieMapper
{
    public static Movie ToDomain(this MovieDto dto)
    {
        return new Movie
        {
            Title = dto.Title,
            Year = dto.Year,
            Rated = dto.Rated,
            Released = dto.Released,
            Runtime = dto.Runtime,
            Genre = dto.Genre,
            Director = dto.Director,
            Writer = dto.Writer,
            Actors = dto.Actors,
            Plot = dto.Plot,
            Language = dto.Language,
            Country = dto.Country,
            Awards = dto.Awards,
            Poster = dto.Poster,
            ImdbRating = dto.ImdbRating,
            ImbdVotes = dto.ImdbVotes,
            ImdbId = dto.ImdbId,
        };
    }
}