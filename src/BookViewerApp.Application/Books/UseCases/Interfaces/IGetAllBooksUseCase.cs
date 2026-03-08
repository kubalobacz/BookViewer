using BookViewerApp.Domain.Books.Models;

namespace BookViewerApp.Application.Books.UseCases.Interfaces
{
    public interface IGetAllBooksUseCase
    {
        public Task<IReadOnlyList<Book>> ExecuteAsync(int resizeRatio);
        public Task<bool> HasCachedBooks();
    }
}
