using Microsoft.AspNetCore.Mvc;
using MovieSearch.Api.Application.Contracts;

namespace MovieSearch.Api.Controllers;

[ApiController]
[Route("api/movies")]
public class MovieSearchController(IMovieSearchService movieSearchService) : ControllerBase
{
    [HttpGet]
    public ActionResult Search([FromQuery] string movieTitle)
    {
        return Ok(movieSearchService.SearchMovies(movieTitle));
    }
}