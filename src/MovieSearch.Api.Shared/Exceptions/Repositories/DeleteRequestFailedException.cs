namespace MovieSearch.Api.Shared.Exceptions.Repositories;

public class DeleteRequestFailedException : Exception
{
    public DeleteRequestFailedException() : base("Delete request failed")
    {
    }
}