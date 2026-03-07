using BookViewerApp.MobileApplication.Common;
using BookViewerApp.MobileApplication.Common.Navigation;
using BookViewerApp.MobileApplication.Common.Navigation.INavigationService;
using BookViewerApp.MobileApplication.Common.Validation;
using BookViewerApp.MobileApplication.Presentation.Books.DTOs;
using CommunityToolkit.Mvvm.Input;

namespace BookViewerApp.MobileApplication.Presentation.Books.ViewModel
{
    public partial class AddBookViewModel : BaseViewModel, IResultProvider<AddBookDTO>
    {
        private TaskCompletionSource<AddBookDTO?>? _tcs;

        public AddBookViewModel(INavigationService navigationService) : base(navigationService)
        {
            var coverUrlProperty = new ValidatableProperty<string?>(ValidatorDelegateFactory.Required<string?>())
            {
                Value = "https://picsum.photos/200/300"
            };
            CoverUrl = coverUrlProperty;
        }

        public ValidatableProperty<string?> Title { get; } = new ValidatableProperty<string?>(ValidatorDelegateFactory.Required<string?>());
        public ValidatableProperty<int?> ReleaseYear { get; } = new ValidatableProperty<int?>(ValidatorDelegateFactory.Required<int?>());
        public ValidatableProperty<string?> Publisher { get; } = new ValidatableProperty<string?>(ValidatorDelegateFactory.Required<string?>());
        public ValidatableProperty<string?> CoverUrl { get; }

        public void SetResultTaskCompletionSource(TaskCompletionSource<AddBookDTO?> tcs)
        {
            _tcs = tcs;
        }

        [RelayCommand(CanExecute = nameof(Validate))]
        private void AddBook()
        {
            //For simplicity to avoid going too much out of assignment scope.
            Uri.TryCreate(CoverUrl.Value, UriKind.Absolute, out var uri);
            var addBootDTO = new AddBookDTO
            {
                Title = Title.Value!,
                ReleaseYear = ReleaseYear.Value!.Value,
                Publisher = Publisher.Value!,
                CoverURL = uri!
            };

            if (!_tcs.Task.IsCompleted)
            {
                _tcs.TrySetResult(addBootDTO);
            }
        }

        public override void OnDisappearing()
        {
            if (!_tcs.Task.IsCompleted)
            {
                _tcs.SetResult(null);
            }
        }

        public bool Validate()
        {
            return Title.IsValid && ReleaseYear.IsValid && Publisher.IsValid && CoverUrl.IsValid;
        }
    }
}
