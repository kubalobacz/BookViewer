using BookViewerApp.MobileApplication.Common.Navigation.INavigationService;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BookViewerApp.MobileApplication.Common
{
    public abstract partial class BaseViewModel : ObservableObject
    {
        protected INavigationService _navigationService;

        public BaseViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public virtual Task InitializeAsync()
        {
            return Task.CompletedTask;
        }

        public virtual void Initialize()
        {

        }

        public virtual void OnDisappearing()
        {

        }
    }
}
