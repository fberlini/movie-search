using System.Text.Json.Serialization;

namespace MovieSearch.Api.Infrastructure.Integrations.Dtos;

public class RatingDto
{
    [JsonPropertyName("Source")]
    public required string Source { get; set; }

    [JsonPropertyName("Value")]
    public required string Value { get; set; }
}