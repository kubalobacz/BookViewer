using BookViewerApp.Domain.Books.Contracts;
using BookViewerApp.Domain.Books.Models;
namespace BookViewerApp.Application.Books.UseCases
{
    public class GetAllBooksUseCase
    {
        private readonly IBooksRepository _booksRepository;
        private readonly IImageRepository _imageRepository;

        public GetAllBooksUseCase(IBooksRepository booksRepository, IImageRepository imageRepository)
        {
            _booksRepository = booksRepository;
            _imageRepository = imageRepository;
        }

        public async Task<IReadOnlyList<Book>> ExecuteAsync(int resizeRatio)
        {
            var books = await _booksRepository.FindAll();
            var booksCount = books.Count();

            var tasks = books
                .Where(book => string.IsNullOrEmpty(book.CoverFileName))
                .Select(async book =>
                {
                    var imageFile = await _imageRepository.GetImageAsync(resizeRatio);
                    book.CoverFileName = imageFile.Name;
                    await _booksRepository.Update(book);
                })
                .ToList();

            await Task.WhenAll(tasks);
            return books;
        }

        public Task<bool> HasCachedBooks()
        {
            return _booksRepository.HasCachedData();
        }
    }
}
