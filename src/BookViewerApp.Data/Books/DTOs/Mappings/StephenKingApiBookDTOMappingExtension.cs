using BookViewerApp.Data.Books.Entities;
using BookViewerApp.Domain.Books.Models;

namespace BookViewerApp.Data.Books.DTOs.Mappings
{
    public static class StephenKingApiBookDTOMappingExtension
    {
        public static BookDbEntity ToBookDbEntity(this StephenKingApiBookDTO dto)
        {
            return new BookDbEntity
            {
                ID = dto.Id,
                Title = dto.Title,
                ReleaseYear = dto.PublishYear,
                Publisher = dto.Publisher
            };
        }

    }
}
