using BookViewerApp.Domain.Books.Models;
namespace BookViewerApp.MobileApplication.Presentation.Books.UIModels.Mappings
{
    internal static class BookUIModelMappingExtension
    {
        internal static BookUIModel ToBookUIModel(this Book book, char sectionLetter, string[]? notes = null)
        {
            return new BookUIModel(book.Title, book.Publisher, book.CoverFileName)
            {
                ID = book.ID,
                Title = book.Title,
                ReleaseYear = book.ReleaseYear,
                Publisher = book.Publisher,
                LetterSection = sectionLetter,
                Notes = notes
            };
        }
    }
}
