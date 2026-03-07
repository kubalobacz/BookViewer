namespace BookViewerApp.Domain.Books.Models
{
    public class Book
    {
        public int ID { get; set; }
        public required string Title { get; set; }
        public int ReleaseYear { get; set; }
        public required string Publisher { get; set; }
        public char? PreferedSectionLetter { get; set; }
        public string? CoverFileName { get; set; }
    }
}
