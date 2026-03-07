using BookViewerApp.Application.Books;
using BookViewerApp.Data.Books.API;
using BookViewerApp.Data.Books.DTOs.Mappings;
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
            var booksToReturn = await _database!.Table<Book>().ToListAsync();
            if (booksToReturn.Count == 0)
            {
                var booksFromApiResult = await _stephenKingApi.GetAllBooks();
                var characterExtractor = new BookTitleFirstCharacterExtractor();
                booksFromApiResult.Data.ForEach(b =>
                {
                    var book = b.ToBook();
                    book.PreferedSectionLetter = characterExtractor.DecideBookTitleFirstLetter(book.Title).ToString();
                    booksToReturn.Add(book);
                });
                await _database.InsertAllAsync(booksToReturn);
            }

            return booksToReturn;
        }

        public async Task<int> Update(Book entity)
        {
            await InitializeAsync();
            return await _database!.UpdateAsync(entity);
        }

        public async Task InitializeAsync()
        {
            if (_database is null)
            {
                var combinedPath = Path.Combine(_localDbPath, DbConstants.DatabaseFilename);
                _database = new SQLiteAsyncConnection(combinedPath, DbConstants.Flags);
                await _database.CreateTableAsync<Book>();
            }
        }

        public async Task<int> Add(Book entity)
        {
            await InitializeAsync();
            return await _database!.InsertAsync(entity);
        }

        public async Task<bool> HasCachedData()
        {
            await InitializeAsync();
            var book = await _database!.Table<Book>().FirstOrDefaultAsync();
            return book != null;
        }
    }
}
