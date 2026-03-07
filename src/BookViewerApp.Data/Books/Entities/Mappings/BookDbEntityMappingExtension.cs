using BookViewerApp.Domain.Books.Models;

namespace BookViewerApp.Data.Books.Entities.Mappings
{
    static class BookDbEntityMappingExtension
    {
        public static Book ToBook(this BookDbEntity bookDbEntity)
        {
            return new Book
            {
                ID = bookDbEntity.ID,
                Title = bookDbEntity.Title,
                ReleaseYear = bookDbEntity.ReleaseYear,
                Publisher = bookDbEntity.Publisher,
                CoverFileName = bookDbEntity.CoverFileName,
            };
        }
    }
}
