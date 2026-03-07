using SQLite;
using System.Diagnostics.CodeAnalysis;
namespace BookViewerApp.Data.Books.Entities
{
    public class BookDbEntity
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public required string Title { get; set; }
        public int ReleaseYear { get; set; }
        public required string Publisher { get; set; }
        public string? CoverFileName { get; set; }

        [SetsRequiredMembers]
        public BookDbEntity()
        {

        }
    }
}
