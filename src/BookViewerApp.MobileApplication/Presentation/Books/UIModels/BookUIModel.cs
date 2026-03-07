using BookViewerApp.MobileApplication.Common.AppFileSystem;

namespace BookViewerApp.MobileApplication.Presentation.Books.UIModels
{
    public class BookUIModel
    {
        public int ID { get; init; }
        public string Title { get; init; }
        public int ReleaseYear { get; init; }
        public string Publisher { get; init; }
        public string? CoverFileName { get; init; }
        public char LetterSection { get; set; }
        public ImageSource? Image { get; }

        public BookUIModel(string title, string publisher, string? coverFileName = null)
        {
            Title = title;
            Publisher = publisher;
            CoverFileName = coverFileName;

            Image = !string.IsNullOrEmpty(CoverFileName)
                ? ImageSource.FromFile(Path.Combine(AppDirectoryPaths.ImagePath, CoverFileName)) : null;
        }
    }
}
