namespace BookViewerApp.MobileApplication.Presentation.Books.Views;

public partial class BookCollectionElementView : Grid
{
    public BookCollectionElementView()
    {
        InitializeComponent();
        //Code equivalent in XAML with control property binding seems to not work.
        LetterLabel.SizeChanged += (s, e) =>
        {
            IconImage.HeightRequest = LetterLabel.Height;
            IconImage.WidthRequest = LetterLabel.Height;
        };
    }
}