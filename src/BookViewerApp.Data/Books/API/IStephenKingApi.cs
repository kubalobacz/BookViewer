using BookViewerApp.Data.Books.DTOs;
using Refit;

namespace BookViewerApp.Data.Books.API
{
    public interface IStephenKingApi
    {
        [Get("/books")]
        public Task<GetBooksApiResult> GetAllBooks();
    }
}
