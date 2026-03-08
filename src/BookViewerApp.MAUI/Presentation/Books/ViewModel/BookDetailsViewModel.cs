using BookViewerApp.MobileApplication.Common;
using BookViewerApp.MobileApplication.Common.Navigation;
using BookViewerApp.MobileApplication.Common.Navigation.INavigationService;
using BookViewerApp.MobileApplication.Common.Navigation.Interfaces;
using BookViewerApp.MobileApplication.Presentation.Books.UIModels;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BookViewerApp.MobileApplication.Presentation.Books.ViewModel
{
    public partial class BookDetailsViewModel : BaseViewModel, INavigationAware
    {
        private readonly INavigationService _navigationService;

        [ObservableProperty]
        private BookUIModel book;

        public BookDetailsViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
        }

        public void OnNavigatedTo(IDictionary<string, object> parameters)
        {
            if (parameters.TryGetValue(NavigationParametersConstants.BOOK_DETAILS, out var bookObj) &&
                bookObj is BookUIModel book)
            {
                Book = book;
            }
        }
    }
}
