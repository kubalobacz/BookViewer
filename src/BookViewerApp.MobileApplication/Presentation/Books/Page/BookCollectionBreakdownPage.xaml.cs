using BookViewerApp.MobileApplication.Presentation.Books.ViewModel;
using System.Runtime.CompilerServices;

namespace BookViewerApp.MobileApplication.Presentation.Books.Page;

public partial class BookCollectionBreakdownPage : ContentPage
{
    bool _firstRenderCompleted;

    public BookCollectionBreakdownPage()
    {
        InitializeComponent();
    }

    //Move this logic to BasePage
    protected override async void OnAppearing()
    {
        var viewModel = (BookCollectionBreakdownViewModel)BindingContext;
        if (viewModel is object)
        {
            if (viewModel.IsInitialized || _firstRenderCompleted)
            {
                return;
            }
            //Fire and forget to initialize app data, and prevent app being killed during startup.
#pragma warning disable
            if (await viewModel.CanInitializeSynchronously())
            {
                viewModel.Initialize();
                base.OnAppearing();
                return;
            }
            Task.Run(async () =>
            {
                await viewModel.InitializeAsync();
            });
#pragma warning restore
        }
        base.OnAppearing();
    }

    protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        base.OnPropertyChanged(propertyName);
    }
}