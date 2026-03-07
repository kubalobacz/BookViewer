using BookViewerApp.MobileApplication.Common.IoC;
using BookViewerApp.MobileApplication.Presentation.General.Views;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Extensions;

namespace BookViewerApp.MobileApplication.Common.Navigation.INavigationService
{
    public interface INavigationService
    {
        Task NavigateToAsync<TViewModel>() where TViewModel : BaseViewModel;
        Task<TResult?> NavigateForResult<TViewModel, TResult>(Dictionary<string, object>? navigationParameters = null) where TViewModel : BaseViewModel, IResultProvider<TResult>;
        Task GoBack(bool isAnimated);
        void DisplayLoadingPopup();
        Task ClosePopup();
    }

    public class NavigationService() : INavigationService
    {
        public Task NavigateToAsync<TViewModel>() where TViewModel : BaseViewModel
        {
            var navigationObjectsTuple = ResolveNavigationObjects(typeof(TViewModel));
            var destinationPage = navigationObjectsTuple.destinationPage;
            var destinationViewModel = navigationObjectsTuple.destinationViewModel;
            var currentWindow = navigationObjectsTuple.mainPage;

            if (destinationPage is ContentPage contentPage)
            {
                return currentWindow.Navigation.PushAsync(destinationPage);
            }

            return Task.CompletedTask;
        }

        public async Task<TResult?> NavigateForResult<TViewModel, TResult>(Dictionary<string, object>? navigationParameters) where TViewModel : BaseViewModel, IResultProvider<TResult>
        {
            var vmType = typeof(TViewModel);
            var navigationObjectsTuple = ResolveNavigationObjects(typeof(TViewModel));
            var destinationPage = navigationObjectsTuple.destinationPage;
            var destinationViewModel = navigationObjectsTuple.destinationViewModel;
            var currentWindow = navigationObjectsTuple.mainPage;

            if (destinationPage is ContentPage contentPage)
            {
                var taskCompletionSource = new TaskCompletionSource<TResult?>();
                ((IResultProvider<TResult>)destinationViewModel).SetResultTaskCompletionSource(taskCompletionSource!);
                contentPage.BindingContext = destinationViewModel;
                await currentWindow.Navigation.PushAsync(destinationPage);
                return await taskCompletionSource.Task;
            }

            return await Task.FromResult(default(TResult));
        }

        private (ContentPage destinationPage, BaseViewModel destinationViewModel, Page mainPage) ResolveNavigationObjects(Type viewModelType)
        {
            var currentWindow = ResolveCurrentPage();
            var destinationViewModel = (BaseViewModel)ServiceResolver.GetService(viewModelType)!;
            var pageType = ViewModelTypeToPageTypeMapping.MapViewModelTypeToPageType(destinationViewModel!.GetType());
            var destinationPage = (ContentPage)ServiceResolver.GetService(pageType)!;
            destinationPage.BindingContext = destinationViewModel;

            return new(destinationPage, destinationViewModel, currentWindow);
        }

        public Task GoBack(bool isAnimated)
        {
            //Implement viewmodel disposing when closing page
            var mainPage = ResolveCurrentPage();
            return mainPage.Navigation.PopAsync(isAnimated);
        }

        private Page ResolveCurrentPage()
        {

            return Microsoft.Maui.Controls.Application.Current!.MainPage!;
        }

        public void DisplayLoadingPopup()
        {
            var currentPage = ResolveCurrentPage();
            currentPage.ShowPopup(new LoadingPopupView(), new PopupOptions
            {
                CanBeDismissedByTappingOutsideOfPopup = false
            });
        }

        public Task ClosePopup()
        {
            var currentPage = ResolveCurrentPage();
            return currentPage.ClosePopupAsync();
        }
    }
}
