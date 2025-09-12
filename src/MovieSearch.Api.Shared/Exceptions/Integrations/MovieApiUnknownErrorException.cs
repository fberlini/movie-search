namespace MovieSearch.Api.Shared.Exceptions.Integrations;

public class MovieApiUnknownErrorException: Exception
{
    public MovieApiUnknownErrorException(): base("Unknown Error"){}
}