
using System.Text.Json.Serialization;

namespace BookViewerApp.Data.Books.DTOs
{
    public class StephenKingApiBookDTO
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        [JsonPropertyName("Notes")]
        public string[]? Description { get; set; }
        [JsonPropertyName("Year")]
        public int PublishYear { get; set; }
        public required string Publisher { get; set; }
    }
}
