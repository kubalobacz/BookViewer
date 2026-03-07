using BookViewerApp.Application.Common.Interfaces;
using BookViewerApp.Data.Books.API;
using BookViewerApp.Data.Common.Interfaces;
using BookViewerApp.Domain.Books.Contracts;
using BookViewerApp.Domain.Books.Models;

namespace BookViewerApp.Data.Books.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly IPicsumApi _picsumApi;
        private readonly IImageSaver _imageSaver;
        private string _imageSavePath;

        public ImageRepository(IPicsumApi picsumApi, IImageResizer imageResizer, IImageSaver imageSaver, string imageSavePath)
        {
            _picsumApi = picsumApi;
            _imageSaver = imageSaver;
            _imageSavePath = imageSavePath;
        }

        public async Task<ImageFile> GetImageAsync(int resizeRatio)
        {
            var downloadedImage = await DownloadImage();

            var fileName = await AddImage(downloadedImage.Item1, resizeRatio, downloadedImage.Item2);

            return new ImageFile
            {
                Name = fileName
            };
        }

        public Task<string> AddImage(byte[] imageByteArr, int resizeRatio, string imageType)
        {
            return _imageSaver.SaveImage(imageByteArr, resizeRatio, imageType, _imageSavePath);
        }

        public async Task<string> AddImage(Uri url, int resizeRatio)
        {
            //Change implementation and use URI if we use actual images, and not random ones.
            var downloadedImage = await DownloadImage();
            return await _imageSaver.SaveImage(downloadedImage.Item1, resizeRatio, downloadedImage.Item2, _imageSavePath);
        }

        private async Task<(byte[], string)> DownloadImage()
        {
            var imageApiResponse = await _picsumApi.GetRandomImage();
            var responseUri = imageApiResponse.RequestMessage!.RequestUri;
            var imageType = Path.GetExtension(responseUri!.AbsolutePath);
            var imageByteArr = await imageApiResponse.Content.ReadAsByteArrayAsync();
            return (imageByteArr, imageType);
        }
    }
}

