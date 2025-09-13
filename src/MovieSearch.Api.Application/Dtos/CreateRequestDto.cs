namespace MovieSearch.Api.Application.Dtos;

public class CreateRequestDto
{
    public string? SearchToken { get; set; }
    public string? IpAddress { get; set; }
    public DateTime Timestamp { get; set; }
    public string? ImdbId { get; set; }
    public int ProcessingTimeMs { get; set; }
}