using BookViewerApp.Application.Books;
using BookViewerApp.Application.Books.UseCases;
using BookViewerApp.MobileApplication.Common;
using BookViewerApp.MobileApplication.Common.Navigation.INavigationService;
using BookViewerApp.MobileApplication.Presentation.Books.DTOs;
using BookViewerApp.MobileApplication.Presentation.Books.DTOs.MappingExtensions;
using BookViewerApp.MobileApplication.Presentation.Books.UIModels;
using BookViewerApp.MobileApplication.Presentation.Books.UIModels.Mappings;
using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BookViewerApp.MobileApplication.Presentation.Books.ViewModel
{
    public partial class BookCollectionBreakdownViewModel : BaseViewModel
    {
        private readonly GetAllBooksUseCase _getAllBooksUseCase;
        private readonly AddBookUseCase _addBookUseCase;
        //In real app select this based on device info
        private int _imageResizeRatio = 1;

        public BookCollectionBreakdownViewModel(INavigationService navigationService, GetAllBooksUseCase getAllBooksUseCase, AddBookUseCase addBookUseCase) : base(navigationService)
        {
            _getAllBooksUseCase = getAllBooksUseCase;
            _addBookUseCase = addBookUseCase;
        }

        [ObservableProperty]
        public List<BookCollectionElementUIModel> books;

        public override async void Initialize()
        {
            try
            {
                await SetBooks();
            }
            catch (Exception)
            {
                //TODO: Log and perform mobile specific error handling.
                throw;
            }
        }

        public override async Task InitializeAsync()
        {
            try
            {
                _navigationService.DisplayLoadingPopup();
                await SetBooks();
                await _navigationService.ClosePopup();
            }
            catch (Exception)
            {
                //TODO: Log and perform mobile specific error handling.
                throw;
            }
        }

        [RelayCommand]
        private async Task NavigateToAddBookPage(object sectionLetter)
        {
            try
            {
                var addBookDTO = await _navigationService.NavigateForResult<AddBookViewModel, AddBookDTO>();
                if (addBookDTO is null)
                {
                    return;
                }
                var book = await _addBookUseCase.ExecuteAsync(addBookDTO.ToAddBookRequest(), _imageResizeRatio);
                var characterExtractor = new BookTitleFirstCharacterExtractor();
                var titleFirstLetter = characterExtractor.DecideBookTitleFirstLetter(book.Title);
                var booksCollection = Books.FirstOrDefault(b => b.StartingLetter == (char)sectionLetter);
                booksCollection!.Books.Add(book.ToBookUIModel());
            }
            catch (Exception e)
            {
                //TODO: Log and perform mobile specific error handling.
                throw;
            }
            finally
            {
                await _navigationService.GoBack(true);
            }
        }

        public override Task<bool> CanInitializeSynchronously()
        {
            return _getAllBooksUseCase.HasCachedBooks();
        }

        private async Task SetBooks()
        {
            {
                var bookUIModels = new List<BookUIModel>();
                var domainBookModels = await _getAllBooksUseCase.ExecuteAsync(_imageResizeRatio);
                foreach (var book in domainBookModels)
                {
                    bookUIModels.Add(book.ToBookUIModel());
                }

                var characterExtractor = new BookTitleFirstCharacterExtractor();
                Books = bookUIModels.GroupBy(b => characterExtractor.DecideBookTitleFirstLetter(b.Title))
                    .Select(b => new BookCollectionElementUIModel(b.ToObservableCollection(), b.Key, NavigateToAddBookPageCommand))
                    .OrderBy(b => b.StartingLetter)
                    .ToList();

                IsInitialized = true;
            }
        }
    }
}
