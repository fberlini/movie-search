namespace MovieSearch.Api.Shared.Exceptions.Services;

public class MovieSearchServiceUnknownErrorException : Exception
{
    public MovieSearchServiceUnknownErrorException() : base("Unknown error")
    {
    }
}