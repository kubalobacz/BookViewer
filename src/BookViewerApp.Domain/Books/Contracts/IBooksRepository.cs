using BookViewerApp.Domain.Books.Models;
using BookViewerApp.Domain.Common;

namespace BookViewerApp.Domain.Books.Contracts
{
    public interface IBooksRepository : ICachableRepositoryBase<Book>
    {
    }
}
