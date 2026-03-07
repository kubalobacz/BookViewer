namespace BookViewerApp.Application.Books.UseCases.DTO
{
    public class AddBookRequest
    {
        public required string Title { get; init; }
        public required int ReleaseYear { get; init; }
        public required string Publisher { get; init; }
        public required Uri CoverURL { get; init; }
    }
}
