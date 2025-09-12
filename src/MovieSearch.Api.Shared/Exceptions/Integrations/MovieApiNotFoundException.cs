namespace MovieSearch.Api.Shared.Exceptions.Integrations;

public class MovieApiNotFoundException: Exception
{
    public MovieApiNotFoundException(): base("Not Found"){}
}