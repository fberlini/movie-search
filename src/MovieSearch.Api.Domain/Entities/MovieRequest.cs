namespace MovieSearch.Api.Domain.Entities
{
    public class MovieRequest
    {
        public Guid Id { get; set; }
        public required string SearchToken { get; set; }
        public string? ImdbId { get; set; }
        public int ProcessingTimeMs { get; set; }
        public DateTime Timestamp { get; set; }
        public required string IpAddress { get; set; }
    }
}