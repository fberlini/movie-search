namespace MovieSearch.Api.Shared.Exceptions.Services;

public class AdminServiceDeleteRequestFailedException : Exception
{
    public AdminServiceDeleteRequestFailedException() : base("Delete request failed")
    {
    }
}