using BookViewerApp.Domain.Books.Models;
using System.Text.Json;

namespace BookViewerApp.Data.Books.DTOs.Mappings
{
    public static class StephenKingApiBookDTOMappingExtension
    {
        public static Book ToBook(this StephenKingApiBookDTO dto)
        {
            var notesJson = JsonSerializer.Serialize(dto.Notes);
            return new Book
            {
                ID = dto.Id,
                Title = dto.Title,
                ReleaseYear = dto.PublishYear,
                Publisher = dto.Publisher,
                NotesJson = notesJson,
            };
        }
    }
}
