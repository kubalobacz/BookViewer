using BookViewerApp.MobileApplication.Presentation.Books.ViewModel;
using System.Runtime.CompilerServices;

namespace BookViewerApp.MobileApplication.Presentation.Books.Page;

public partial class BookCollectionBreakdownPage : ContentPage
{
    public BookCollectionBreakdownPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        var viewModel = (BookCollectionBreakdownViewModel)BindingContext;
        if (viewModel is object)
        {
            if (viewModel.IsInitialized)
            {
                return;
            }
            //Fire and forget to initialize app data, and prevent app being killed during startup.
#pragma warning disable
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