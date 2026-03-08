namespace BookViewerApp.MobileApplication.Common.Interfaces
{
    public interface IInitializable
    {
        public bool IsInitialized { get; set; }

        public Task<bool> CanInitializeSynchronously();
    }
}
