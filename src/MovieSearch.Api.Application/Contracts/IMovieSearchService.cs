using MovieSearch.Api.Domain.Entities;

namespace MovieSearch.Api.Application.Contracts;

public interface IMovieSearchService
{
    Task<Movie> SearchMovies(string movieTitle, string ipAddress);
}