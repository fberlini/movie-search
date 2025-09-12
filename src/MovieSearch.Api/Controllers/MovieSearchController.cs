using Microsoft.AspNetCore.Mvc;

namespace MovieSearch.Api.Controller;

[ApiController]
[Route("api/movies")]
public class MovieSearchController : ControllerBase
{
    [HttpGet]
    public ActionResult Search()
    {
        throw new Exception("Not implemented");
    }
}