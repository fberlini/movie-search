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
        var movie = await movieSearchService.SearchMovies(movieTitle);
        return Ok(movie);
    }
}