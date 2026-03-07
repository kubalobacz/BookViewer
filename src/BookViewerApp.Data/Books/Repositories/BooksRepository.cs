using BookViewerApp.Data.Books.API;
using BookViewerApp.Data.Books.DTOs.Mappings;
using BookViewerApp.Data.Books.Entities;
using BookViewerApp.Data.Books.Entities.Mappings;
using BookViewerApp.Data.Database;
using BookViewerApp.Domain.Books.Contracts;
using BookViewerApp.Domain.Books.Models;
using SQLite;

namespace BookViewerApp.Data.Books.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        private ISQLiteAsyncConnection? _database;
        private IStephenKingApi _stephenKingApi;
        private string _localDbPath;

        public BooksRepository(IStephenKingApi stephenKingApi, string localDbPath, ISQLiteAsyncConnection? database = null)
        {
            _database = database;
            _stephenKingApi = stephenKingApi;
            _localDbPath = localDbPath;
        }

        public async Task<IReadOnlyList<Book>> FindAll()
        {
            await InitializeAsync();
            var booksToReturn = await _database!.Table<BookDbEntity>().ToListAsync();
            if (booksToReturn.Count == 0)
            {
                var booksFromApiResult = await _stephenKingApi.GetAllBooks();
                var bookDbEntities = new List<BookDbEntity>();
                booksFromApiResult.Data.ForEach(b => bookDbEntities.Add(b.ToBookDbEntity()));
                await _database.InsertAllAsync(bookDbEntities);
                booksToReturn = bookDbEntities;
            }


            var book = new BookDbEntity
            {
                Title = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA",
                Publisher = "BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB",
                Description = "CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC",
                CoverFileName = booksToReturn[0].CoverFileName,
            };
            booksToReturn.Add(book);


            return booksToReturn.Select(b => b.ToBook())
                .ToList()
                .AsReadOnly();
        }

        public async Task<int> Update(Book entity)
        {
            await InitializeAsync();
            var mappedBook = entity.ToDbEntity();
            return await _database!.UpdateAsync(mappedBook);
        }

        public async Task InitializeAsync()
        {
            if (_database is null)
            {
                var combinedPath = Path.Combine(_localDbPath, DbConstants.DatabaseFilename);
                _database = new SQLiteAsyncConnection(combinedPath, DbConstants.Flags);
                await _database.CreateTableAsync<BookDbEntity>();
            }
        }

        public async Task<int> Add(Book entity)
        {
            await InitializeAsync();
            var mappedBook = entity.ToDbEntity();
            return await _database!.InsertAsync(mappedBook);
        }
    }
}
