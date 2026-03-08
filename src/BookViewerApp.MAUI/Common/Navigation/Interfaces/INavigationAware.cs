namespace BookViewerApp.MobileApplication.Common.Navigation.Interfaces
{
    public interface INavigationAware
    {
        void OnNavigatedTo(IDictionary<string, object> parameters);
    }
}
