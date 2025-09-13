using System.Net;
using System.Text.Json;
using Microsoft.Extensions.Options;
using MovieSearch.Api.Application.Contracts;
using MovieSearch.Api.Domain.Entities;
using MovieSearch.Api.Shared.Exceptions.Integrations;
using MovieSearch.Api.Shared.Options;

namespace MovieSearch.Api.Infrastructure.Integrations;

public class MovieApiClient(IOptions<MovieApiOptions> options) : IMovieApiClientContract
{
    private readonly string _baseUrl = options.Value.BaseUrl;
    private readonly string _apiKey = options.Value.ApiKey;

    public async Task<Movie> SearchMovies(string movieTitle)
    {
        using (var httpClient = new HttpClient())
        {
            var response = await httpClient.GetAsync($"{_baseUrl}?apikey={_apiKey}&t={movieTitle}");
            if (response.StatusCode != HttpStatusCode.OK)
            {
                HandleError(response);
            }

            var content = await response.Content.ReadAsStringAsync();

            try
            {
                var movie = JsonSerializer.Deserialize<Movie>(content);
                return movie ?? throw new MovieApiNotFoundException();
            }
            catch (JsonException)
            {
                throw new MovieApiResponseParseException();
            }
        }
    }

    private static void HandleError(HttpResponseMessage response)
    {
        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            throw new MovieApiNotFoundException();
        }
        else
        {
            throw new MovieApiUnknownErrorException();
        }
    }
}