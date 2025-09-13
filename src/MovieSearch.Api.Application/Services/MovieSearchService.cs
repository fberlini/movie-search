using MovieSearch.Api.Application.Contracts;
using MovieSearch.Api.Domain.Entities;

namespace MovieSearch.Api.Application.Services;

public class MovieSearchService(IMovieApiClientContract movieApiClient) : IMovieSearchService
{
    public Task<Movie> SearchMovies(string movieTitle)
    {
        return movieApiClient.SearchMovies(movieTitle);
    }
}