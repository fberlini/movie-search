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
        if (startDate == null && endDate == null)
        {
            return Ok(await adminService.GetRequests());
        }

        if (startDate != null && endDate != null)
        {
            if (
                !DateTime.TryParse(startDate, out var parsedStartDate) ||
                !DateTime.TryParse(endDate, out var parsedEndDate) ||
                parsedStartDate > parsedEndDate
            )
            {
                return BadRequest("Invalid date range");
            }

            try
            {
                return Ok(await adminService.GetRequestsByDateRange(parsedStartDate, parsedEndDate));
            }
            catch (Exception exception)
            {
                return HandleExceptions(exception);
            }
        }

        return BadRequest("Invalid date range");
    }

    [HttpGet("summary")]
    public async Task<ActionResult> GetSummary([FromQuery] string date)
    {
        if (string.IsNullOrEmpty(date) || !DateTime.TryParse(date, out var parsedDate))
        {
            return BadRequest("Invalid date");
        }

        try
        {
            return Ok(await adminService.GetSummaryOfDay(parsedDate));
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