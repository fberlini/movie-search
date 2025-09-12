using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using MovieSearch.Api.Shared.Options;

namespace MovieSearch.Api.Filters;

public class ApiKeyAuthFilter(IOptions<ApiKeyOptions> options) : IAuthorizationFilter
{
    private readonly ApiKeyOptions _options = options.Value;

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        if (!context.HttpContext.Request.Headers.TryGetValue(_options.HeaderName, out var extractedApiKey) || extractedApiKey != _options.Key)
        {
            context.Result = new UnauthorizedObjectResult("API Key is not valid");
        }
    }
}