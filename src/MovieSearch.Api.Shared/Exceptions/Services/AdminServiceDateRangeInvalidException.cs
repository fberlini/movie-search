namespace MovieSearch.Api.Shared.Exceptions.Services;

public class AdminServiceDateRangeInvalidException : Exception
{
    public AdminServiceDateRangeInvalidException() : base("Invalid date range")
    {
    }
}