using Microsoft.AspNetCore.Mvc;

namespace MovieSearch.Api.Controller;

[ApiController]
[Route("api/admin")]
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