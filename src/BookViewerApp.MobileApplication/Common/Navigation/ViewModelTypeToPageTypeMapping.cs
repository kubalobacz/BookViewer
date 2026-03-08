using BookViewerApp.MobileApplication.Presentation.Books.Page;
using BookViewerApp.MobileApplication.Presentation.Books.ViewModel;

namespace BookViewerApp.MobileApplication.Common.Navigation
{
    static class ViewModelTypeToPageTypeMapping
    {

        private static readonly Dictionary<Type, Type> _map = new()
        {
            {typeof(BookCollectionBreakdownViewModel), typeof(BookCollectionBreakdownPage) },
            {typeof(AddBookViewModel), typeof(AddBookPage) },
            {typeof(BookDetailsViewModel), typeof(BookDetailsPage) },
        };

        public static Type MapViewModelTypeToPageType(Type viewModelType)
        {
            if (_map.TryGetValue(viewModelType, out var pageType))
            {
                return pageType;
            }

            throw new ArgumentOutOfRangeException(nameof(viewModelType));
        }
    }
}
