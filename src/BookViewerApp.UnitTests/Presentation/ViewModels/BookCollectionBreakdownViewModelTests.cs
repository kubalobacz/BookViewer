using BookViewerApp.Application.Books.UseCases.Interfaces;
using BookViewerApp.Domain.Books.Models;
using BookViewerApp.MobileApplication.Common.Navigation.INavigationService;
using BookViewerApp.MobileApplication.Presentation.Books.ViewModel;
using FluentAssertions;
using Moq;

namespace BookViewerApp.UnitTests;

public class BookCollectionBreakdownViewModelTests
{
    private readonly Mock<INavigationService> _navigationServiceMock;
    private readonly Mock<IGetAllBooksUseCase> _getAllBooksUseCaseMock;
    private readonly Mock<IAddBookUseCase> _addBookUseCaseMock;

    private readonly BookCollectionBreakdownViewModel _vm;

    public BookCollectionBreakdownViewModelTests()
    {
        _navigationServiceMock = new Mock<INavigationService>();
        _getAllBooksUseCaseMock = new Mock<IGetAllBooksUseCase>();
        _addBookUseCaseMock = new Mock<IAddBookUseCase>();

        _vm = new BookCollectionBreakdownViewModel(
            _navigationServiceMock.Object,
            _getAllBooksUseCaseMock.Object,
            _addBookUseCaseMock.Object);
    }

    [Fact]
    public async Task InitializeAsync_ShouldGroupBooksByFirstLetter()
    {
        var books = new List<Book>
    {
        CreateBook("QWER"),
        CreateBook("ASDF"),
        CreateBook("ZXCV")
    };

        _getAllBooksUseCaseMock
            .Setup(x => x.ExecuteAsync(It.IsAny<int>()))
            .ReturnsAsync(books);

        await _vm.InitializeAsync();

        _vm.Books.Should().HaveCount(3);
        _vm.Books.Select(x => x.StartingLetter)
            .Should().Contain(new[] { 'Q', 'A', 'Z' });
    }

    [Fact]
    public async Task InitializeAsync_ShouldSetNotEmptyBooks()
    {
        var books = new List<Book>
    {
        CreateBook("QWER"),
        CreateBook("ASDF"),
        CreateBook("ZXCV")
    };

        _getAllBooksUseCaseMock
            .Setup(x => x.ExecuteAsync(It.IsAny<int>()))
            .ReturnsAsync(books);

        await _vm.InitializeAsync();

        _vm.Books.Should().NotBeNull();
        _vm.Books.Should().NotBeEmpty();
    }

    [Fact]
    public async Task CanInitializeSynchronously_ShouldReturnTrue_WhenCacheExists()
    {
        _getAllBooksUseCaseMock
            .Setup(x => x.HasCachedBooks())
            .ReturnsAsync(true);

        var result = await _vm.CanInitializeSynchronously();

        result.Should().BeTrue();
    }

    //Move to some helper/factory unit test class
    private Book CreateBook(string title = "Foo Book", int releaseYear = 1234, string publisher = "Foo Publisher", string? sectionLetter = null, string? notesJson = null)
    {
        return new Book
        {
            Title = title,
            ReleaseYear = releaseYear,
            Publisher = publisher,
            PreferedSectionLetter = sectionLetter,
            NotesJson = notesJson
        };
    }

}
