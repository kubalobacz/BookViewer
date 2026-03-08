using BookViewerApp.Application.Books.UseCases.DTO;
using BookViewerApp.Domain.Books.Models;

namespace BookViewerApp.Application.Books.UseCases.Interfaces
{
    public interface IAddBookUseCase
    {
        public Task<Book> ExecuteAsync(AddBookRequest addBookRequest, int resizeRatio);
    }
}
