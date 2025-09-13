namespace MovieSearch.Api.Shared.Exceptions.Services;

public class MovieSearchServiceMovieApiNotFoundException : Exception
{
    public MovieSearchServiceMovieApiNotFoundException() : base("Movie API not found")
    {
    }
}