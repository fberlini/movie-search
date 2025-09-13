using Microsoft.AspNetCore.Mvc;
using MovieSearch.Api.Application.Contracts;
using MovieSearch.Api.Domain.Entities;

namespace MovieSearch.Api.Controllers;

[ApiController]
[Route("api/movies")]
public class MovieSearchController(IMovieSearchService movieSearchService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<Movie>> Search([FromQuery] string movieTitle)
    {
        var ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString() ?? string.Empty;
        var movie = await movieSearchService.SearchMovies(movieTitle, ipAddress);
        return Ok(movie);
    }
}