namespace BookViewerApp.Data.Books.DTOs
{
    public class StephenKingApiBookDTO
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string[]? Notes { get; set; }
        public int PublishYear { get; set; }
        public required string Publisher { get; set; }
    }
}
