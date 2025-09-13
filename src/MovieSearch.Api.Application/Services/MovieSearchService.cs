using MovieSearch.Api.Application.Contracts;
using MovieSearch.Api.Application.Dtos;
using MovieSearch.Api.Domain.Entities;
using MovieSearch.Api.Shared.Exceptions.Integrations;
using MovieSearch.Api.Shared.Exceptions.Services;

namespace MovieSearch.Api.Application.Services;

public class MovieSearchService(IMovieApiClientContract movieApiClient, IAdminService adminService) : IMovieSearchService
{
    public async Task<Movie> SearchMovies(string movieTitle, string ipAddress)
    {
        try
        {
            var startTime = DateTime.UtcNow;
            var movie = await movieApiClient.SearchMovies(movieTitle);
            var endTime = DateTime.UtcNow;
            var processingTimeMs = (int)(endTime - startTime).TotalMilliseconds;

            await adminService.CreateRequest(new CreateRequestDto
            {
                SearchToken = movieTitle,
                IpAddress = ipAddress,
                Timestamp = DateTime.UtcNow,
                ImdbId = movie.ImdbId,
                ProcessingTimeMs = processingTimeMs
            });

            return movie;
        }
        catch (Exception exception)
        {
            throw HandleExceptions(exception);
        }
    }

    private Exception HandleExceptions(Exception exception)
    {
        if (exception is MovieApiNotFoundException)
        {
            return new MovieSearchServiceMovieApiNotFoundException();
        }
        throw new MovieSearchServiceUnknownErrorException();
    }
}