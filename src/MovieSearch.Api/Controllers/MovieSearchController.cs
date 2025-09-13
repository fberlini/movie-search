using Microsoft.AspNetCore.Mvc;
using MovieSearch.Api.Application.Contracts;
using MovieSearch.Api.Domain.Entities;
using MovieSearch.Api.Shared.Exceptions.Services;

namespace MovieSearch.Api.Controllers;

[ApiController]
[Route("api/movies")]
public class MovieSearchController(IMovieSearchService movieSearchService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<Movie>> Search([FromQuery] string movieTitle)
    {
        var ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString() ?? string.Empty;
        try
        {
            var movie = await movieSearchService.SearchMovies(movieTitle, ipAddress);
            return Ok(movie);
        }
        catch (Exception exception)
        {
            return HandleExceptions(exception);
        }
    }

    private ActionResult HandleExceptions(Exception exception)
    {
        if (exception is MovieSearchServiceMovieApiNotFoundException)
        {
            return NotFound(exception.Message);
        }
        return new StatusCodeResult(500);
    }
}