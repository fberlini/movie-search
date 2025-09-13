using Microsoft.AspNetCore.Mvc;
using MovieSearch.Api.Application.Contracts;
using MovieSearch.Api.Filters;
using MovieSearch.Api.Shared.Exceptions.Services;

namespace MovieSearch.Api.Controllers;

[ApiController]
[Route("api/admin")]
[ServiceFilter(typeof(ApiKeyAuthFilter))]
public class AdminController(IAdminService adminService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> GetRequests([FromQuery] string? startDate, [FromQuery] string? endDate)
    {
        DateTime? startDateValue = null;
        DateTime? endDateValue = null;

        if (startDate != null)
        {
            if (!DateTime.TryParse(startDate, out var parsedStartDate))
            {
                return BadRequest("Invalid start date");
            }
            startDateValue = parsedStartDate;
        }

        if (endDate != null)
        {
            if (startDate == null || !DateTime.TryParse(endDate, out var parsedEndDate))
            {
                return BadRequest("Invalid end date");
            }
            endDateValue = parsedEndDate;
        }
        try
        {
            return Ok(await adminService.GetRequests(startDateValue, endDateValue));
        }
        catch (Exception exception)
        {
            return HandleExceptions(exception);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetRequest(Guid id)
    {
        try
        {
            return Ok(await adminService.GetRequest(id));
        }
        catch (Exception exception)
        {
            return HandleExceptions(exception);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteRequest(Guid id)
    {
        try
        {
            await adminService.DeleteRequest(id);
            return NoContent();
        }
        catch (Exception exception)
        {
            return HandleExceptions(exception);
        }
    }

    private ActionResult HandleExceptions(Exception exception)
    {
        if (exception is AdminServiceMovieRequestNotFoundException)
        {
            return NotFound(exception.Message);
        }

        return new StatusCodeResult(500);
    }
}