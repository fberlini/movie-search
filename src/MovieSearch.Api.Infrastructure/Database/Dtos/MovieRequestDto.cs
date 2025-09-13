using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace MovieSearch.Api.Infrastructure.Database.Dtos;

public class MovieRequestDto
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public Guid Id { get; set; }
    
    [BsonElement("searchToken")]
    public required string SearchToken { get; set; }
    
    [BsonElement("imdbId")]
    public string? ImdbId { get; set; }
    
    [BsonElement("processingTimeMs")]
    public int ProcessingTimeMs { get; set; }
    
    [BsonElement("timestamp")]
    public DateTime Timestamp { get; set; }
    
    [BsonElement("ipAddress")]
    public required string IpAddress { get; set; }
}