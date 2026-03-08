namespace BookViewerApp.MobileApplication.Common.Navigation
{
    public interface IResultProvider<T>
    {
        void SetResultTaskCompletionSource(TaskCompletionSource<T?> tcs);
    }
}
