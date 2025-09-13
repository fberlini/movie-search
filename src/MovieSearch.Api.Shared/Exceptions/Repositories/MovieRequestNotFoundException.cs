namespace MovieSearch.Api.Shared.Exceptions.Repositories;

public class MovieRequestNotFoundException : Exception
{
    public MovieRequestNotFoundException() : base("Movie request not found")
    {
    }
}