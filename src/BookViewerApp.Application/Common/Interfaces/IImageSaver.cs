namespace BookViewerApp.Application.Common.Interfaces
{
    public interface IImageSaver
    {
        Task<string> SaveImage(byte[] image, int resizeRatio, string imageType, string savePath);
    }
}
