namespace MovieSearch.Api.Shared.Exceptions.Integrations;

public class MovieApiResponseParseException: Exception
{
    public MovieApiResponseParseException(): base("Response Parse Error"){}
}