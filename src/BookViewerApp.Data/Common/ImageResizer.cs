using BookViewerApp.Data.Common.Interfaces;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Processing;

namespace BookViewerApp.Data.Common
{
    public class ImageResizer : IImageResizer
    {
        public byte[] ResizeImage(byte[] originalImage, int resizeRatio)
        {
            using var image = Image.Load(originalImage);
            var newHeight = image.Height / resizeRatio;
            var newWidth = image.Width / resizeRatio;

            image.Mutate(i => i.Resize(newWidth, newHeight));
            using var memoryStream = new MemoryStream();
            image.Save(memoryStream, new PngEncoder());
            return memoryStream.ToArray();
        }
    }
}
