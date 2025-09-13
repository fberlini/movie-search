namespace MovieSearch.Api.Shared.Exceptions.Services;

public class AdminServiceUnknownError : Exception
{
    public AdminServiceUnknownError() : base("Unknown error")
    {
    }
}