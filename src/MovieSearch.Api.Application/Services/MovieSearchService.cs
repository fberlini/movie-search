using MovieSearch.Api.Application.Contracts;
using MovieSearch.Api.Application.Dtos;
using MovieSearch.Api.Domain.Entities;

namespace MovieSearch.Api.Application.Services;

public class MovieSearchService(IMovieApiClientContract movieApiClient, IAdminService adminService) : IMovieSearchService
{
    public async Task<Movie> SearchMovies(string movieTitle, string ipAddress)
    {
        var startTime = DateTime.UtcNow;
        var movie = await movieApiClient.SearchMovies(movieTitle);
        var endTime = DateTime.UtcNow;
        var processingTimeMs = (int)(endTime - startTime).TotalMilliseconds;

        await adminService.CreateRequest(new CreateRequestDto {
            SearchToken = movieTitle,
            IpAddress = ipAddress,
            Timestamp = DateTime.UtcNow,
            ImdbId = movie.ImdbId,
            ProcessingTimeMs = processingTimeMs
        });
        
        return movie;
    }
}