using MovieSearch.Api.Domain.Entities;

namespace MovieSearch.Api.Application.Contracts;

public interface IMovieApiClientContract
{
    Task<Movie> SearchMovies(string movieTitle);
}