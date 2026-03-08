using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
namespace BookViewerApp.MobileApplication.Presentation.Books.UIModels
{
    public partial class BookCollectionElementUIModel : ObservableObject
    {
        [ObservableProperty]
        private char _startingLetter;

        [ObservableProperty]
        private ObservableCollection<BookUIModel> _books;

        public ICommand AddBookCommand { get; }

        public ICommand DisplayBookDetailsCommand { get; }

        public BookCollectionElementUIModel(ObservableCollection<BookUIModel> books, char startingLetter,
                                            ICommand addBookCommand, ICommand displayBookDetailsCommand)
        {
            Books = books;
            StartingLetter = startingLetter;
            AddBookCommand = addBookCommand;
            DisplayBookDetailsCommand = displayBookDetailsCommand;
        }
    }
}
