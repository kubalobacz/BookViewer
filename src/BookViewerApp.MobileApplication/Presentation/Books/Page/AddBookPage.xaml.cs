using BookViewerApp.MobileApplication.Presentation.Books.ViewModel;

namespace BookViewerApp.MobileApplication.Presentation.Books.Page;

public partial class AddBookPage : ContentPage
{
	public AddBookPage()
	{
		InitializeComponent();
	}

    protected override void OnDisappearing()
    {
        ((AddBookViewModel)BindingContext).OnDisappearing();
        base.OnDisappearing();
    }
}