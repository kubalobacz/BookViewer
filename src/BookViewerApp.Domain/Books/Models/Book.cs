using SQLite;
using System.Diagnostics.CodeAnalysis;

namespace BookViewerApp.Domain.Books.Models
{
    public class Book
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public required string Title { get; set; }
        public int ReleaseYear { get; set; }
        public required string Publisher { get; set; }

        //String instead of char for SQL support
        public string? PreferedSectionLetter { get; set; }
        public string? CoverFileName { get; set; }
        public string? NotesJson { get; set; }

        [SetsRequiredMembers]
        public Book()
        {

        }
    }
}
