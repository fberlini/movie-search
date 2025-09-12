using Microsoft.AspNetCore.Mvc;
using MovieSearch.Api.Filters;

namespace MovieSearch.Api.Controllers;

[ApiController]
[Route("api/admin")]
[ServiceFilter(typeof(ApiKeyAuthFilter))]
public class AdminController : ControllerBase
{
    [HttpGet]
    public ActionResult GetRequests([FromQuery] DateTime startDate, [FromQuery] DateTime? endDate)
    {
        throw new Exception("Not implemented");
    }

    [HttpGet("{id}")]
    public ActionResult GetRequest(Guid id)
    {
        throw new Exception("Not implemented");
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteRequest(Guid id)
    {
        throw new Exception("Not implemented");
    }
}