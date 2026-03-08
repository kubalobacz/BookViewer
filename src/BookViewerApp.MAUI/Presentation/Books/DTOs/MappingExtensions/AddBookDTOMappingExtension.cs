
using BookViewerApp.Application.Books.UseCases.DTO;

namespace BookViewerApp.MobileApplication.Presentation.Books.DTOs.MappingExtensions
{
    public static class AddBookDTOMappingExtension
    {
        public static AddBookRequest ToAddBookRequest(this AddBookDTO addBookDTO)
        {
            return new AddBookRequest
            {
                Title = addBookDTO.Title,
                Publisher = addBookDTO.Publisher,
                ReleaseYear = addBookDTO.ReleaseYear,
                CoverURL = addBookDTO.CoverURL,
            };
        }
    }
}
