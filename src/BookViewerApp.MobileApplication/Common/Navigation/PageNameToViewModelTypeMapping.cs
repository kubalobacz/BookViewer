using BookViewerApp.MobileApplication.Presentation.Books.ViewModel;

namespace BookViewerApp.MobileApplication.Common.Navigation
{
    static class PageNameToViewModelTypeMapping
    {
        public static Type MapStringNameToType(string pageName) => pageName switch
        {
            PageNamesConstants.BookCollectionBreakdownPage => typeof(BookCollectionBreakdownViewModel),
            _ => throw new ArgumentOutOfRangeException(nameof(pageName)),
        };
    }
}
