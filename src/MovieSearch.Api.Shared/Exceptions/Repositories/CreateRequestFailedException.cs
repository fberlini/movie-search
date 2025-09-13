namespace MovieSearch.Api.Shared.Exceptions.Repositories;

public class CreateRequestFailedException : Exception
{
    public CreateRequestFailedException() : base("Create request failed")
    {
    }
}