using BookViewerApp.Domain.Books.Models;

namespace BookViewerApp.Data.Books.DTOs.Mappings
{
    public static class StephenKingApiBookDTOMappingExtension
    {
        public static Book ToBook(this StephenKingApiBookDTO dto)
        {
            return new Book
            {
                ID = dto.Id,
                Title = dto.Title,
                ReleaseYear = dto.PublishYear,
                Publisher = dto.Publisher
            };
        }
    }
}
