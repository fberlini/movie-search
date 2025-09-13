namespace MovieSearch.Api.Shared.Exceptions.Services;

public class AdminServiceMovieRequestNotFoundException : Exception
{
    public AdminServiceMovieRequestNotFoundException() : base("Movie request not found")
    {
    }
}