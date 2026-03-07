using BookViewerApp.MobileApplication.Common.IoC;
using BookViewerApp.MobileApplication.Common.Navigation;
using BookViewerApp.MobileApplication.Presentation.Books.ViewModel;


namespace BookViewerApp.MobileApplication
{
    public partial class App : Microsoft.Maui.Controls.Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var viewModelType = typeof(BookCollectionBreakdownViewModel);
            var viewModel = ServiceResolver.GetService(viewModelType);
            var pageType = ViewModelTypeToPageTypeMapping.MapViewModelTypeToPageType(viewModelType);
            var page = ServiceResolver.GetService(pageType) as ContentPage;
            page!.BindingContext = viewModel;
            var navigationPage = new NavigationPage(page);

            return new Window(navigationPage);
        }
    }
}
