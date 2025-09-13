namespace MovieSearch.Api.Shared.Exceptions.Services;

public class MovieSearchServiceCreateRequestFailedException : Exception
{
    public MovieSearchServiceCreateRequestFailedException() : base("Create request failed")
    {
    }
}