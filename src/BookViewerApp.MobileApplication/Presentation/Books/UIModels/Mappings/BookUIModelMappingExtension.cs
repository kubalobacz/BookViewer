using BookViewerApp.Domain.Books.Models;
namespace BookViewerApp.MobileApplication.Presentation.Books.UIModels.Mappings
{
    internal static class BookUIModelMappingExtension
    {
        internal static BookUIModel ToBookUIModel(this Book book)
        {
            return new BookUIModel(book.Title, book.Publisher, book.CoverFileName)
            {
                ID = book.ID,
                Title = book.Title,
                ReleaseYear = book.ReleaseYear,
                Publisher = book.Publisher,
            };
        }
    }
}
