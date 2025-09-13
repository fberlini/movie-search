namespace MovieSearch.Api.Shared.Exceptions.Services;

public class AdminServiceCreateRequestFailedException : Exception
{
    public AdminServiceCreateRequestFailedException() : base("Create request failed")
    {
    }
}