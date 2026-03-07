using BookViewerApp.Application.Common.Interfaces;
using BookViewerApp.Data.Common.Interfaces;

namespace BookViewerApp.Data.Common
{
    public class ImageSaver : IImageSaver
    {
        private readonly IImageResizer _imageResizer;

        public ImageSaver(IImageResizer imageResize)
        {
            _imageResizer = imageResize;
        }

        public async Task<string> SaveImage(byte[] image, int resizeRatio, string imageType, string savePath)
        {
            var imageByteArr = image;
            var resizedByteArr = _imageResizer.ResizeImage(imageByteArr, resizeRatio);

            var fileName = Guid.NewGuid().ToString();
            var fileNameWithExtension = String.Concat(fileName, imageType);
            var combinedImageSavePath = Path.Combine(savePath, fileNameWithExtension);
            await File.WriteAllBytesAsync(combinedImageSavePath, resizedByteArr);
            return fileNameWithExtension;
        }
    }
}
