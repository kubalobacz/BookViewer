using BookViewerApp.Application.Books.UseCases.DTO;
using BookViewerApp.Application.Books.UseCases.DTO.MappingExtensions;
using BookViewerApp.Application.Books.UseCases.Interfaces;
using BookViewerApp.Domain.Books.Contracts;
using BookViewerApp.Domain.Books.Models;

namespace BookViewerApp.Application.Books.UseCases
{
    public class AddBookUseCase : IAddBookUseCase
    {

        private readonly IBooksRepository _booksRepository;
        private readonly IImageRepository _imageRepository;

        public AddBookUseCase(IBooksRepository booksRepository, IImageRepository imageRepository)
        {
            _booksRepository = booksRepository;
            _imageRepository = imageRepository;
        }

        public async Task<Book> ExecuteAsync(AddBookRequest addBookRequest, int resizeRatio)
        {
            var imageName = await _imageRepository.AddImage(addBookRequest.CoverURL, resizeRatio);
            var book = addBookRequest.ToBook();
            book.CoverFileName = imageName;
            await _booksRepository.Add(book);
            return book;
        }
    }
}
