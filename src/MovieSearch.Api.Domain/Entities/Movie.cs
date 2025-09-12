namespace MovieSearch.Api.Domain.Entities
{
    public class Movie
    {
        public required string Title { get; set; }
        public int Year { get; set; }
        public required string Rated { get; set; }
        public DateTime Released { get; set; }
        public required string Runtime { get; set; }
        public required string Genre { get; set; }
        public required string Director { get; set; }
        public required string Writer { get; set; }
        public required string Actors { get; set; }
        public required string Plot { get; set; }
        public required string Language { get; set; }
        public required string Country { get; set; }
        public string? Awards { get; set; }
        public string? Poster { get; set; }
        public int ImdbRating { get; set; }
        public int ImbdVotes { get; set; }
        public string? ImdbId { get; set; }

    }
}
