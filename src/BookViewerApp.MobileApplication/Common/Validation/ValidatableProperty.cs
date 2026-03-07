using CommunityToolkit.Mvvm.ComponentModel;

namespace BookViewerApp.MobileApplication.Common.Validation
{
    public partial class ValidatableProperty<T> : ObservableObject
    {
        private T _value;
        private bool _isValid;
        private readonly Func<T, bool> _validationDelegate;
        private readonly Lock _lock = new();

        public ValidatableProperty(Func<T, bool> validationDelegate)
        {
            _validationDelegate = validationDelegate;
        }

        public T Value
        {
            get => _value;
            set
            {
                lock (_lock)
                {
                    SetProperty(ref _value, value);
                    IsValid = _validationDelegate(value);
                }
            }               
        }

        public bool IsValid
        {
            get => _isValid;
            set => SetProperty(ref _isValid, value);
        }
    }
}
