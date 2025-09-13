namespace MovieSearch.Api.Shared.Exceptions.Services;

public class AdminServiceGetRequestFailedException : Exception
{
    public AdminServiceGetRequestFailedException() : base("Get request failed")
    {
    }
}