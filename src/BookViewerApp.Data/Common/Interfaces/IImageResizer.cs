namespace BookViewerApp.Data.Common.Interfaces
{
    public interface IImageResizer
    {
        byte[] ResizeImage(byte[] image, int resizeRatio);
    }
}
