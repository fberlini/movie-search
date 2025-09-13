namespace MovieSearch.Api.Shared.Exceptions.Repositories;

public class GetRequestFailedException : Exception
{
    public GetRequestFailedException() : base("Get request failed")
    {
    }
}