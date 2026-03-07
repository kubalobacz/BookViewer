using BookViewerApp.Domain.Books.Models;

namespace BookViewerApp.Domain.Books.Contracts
{
    public interface IImageRepository
    {
        Task<ImageFile> GetImageAsync(int resizeRatio);
        Task<string> AddImage(byte[] imageByteArr, int resizeRatio, string imageType);
        Task<string> AddImage(Uri url, int resizeRatio);
    }
}
