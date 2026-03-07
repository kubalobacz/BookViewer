using BookViewerApp.Domain.Books.Models;

namespace BookViewerApp.Application.Books.UseCases.DTO.MappingExtensions
{
    public static class AddBookRequestMappingExtension
    {
        public static Book ToBook(this AddBookRequest addBookRequest)
        {
            return new Book
            {
                Title = addBookRequest.Title,
                Publisher = addBookRequest.Publisher,
                ReleaseYear = addBookRequest.ReleaseYear,
            };
        }
    }
}
