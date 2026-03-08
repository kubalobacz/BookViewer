using CommunityToolkit.Mvvm.ComponentModel;

namespace BookViewerApp.MobileApplication.Common.Validation
{
    public partial class ValidatableProperty<T> : ObservableObject
    {
        private T _value;
        private bool _isValid;
        private readonly Func<T, bool>[] _validationDelegateArr;
        private readonly Lock _lock = new();



        public ValidatableProperty(params Func<T, bool>[] validationDelegateArr)
        {
            _validationDelegateArr = validationDelegateArr;
        }

        public T Value
        {
            get => _value;
            set
            {
                lock (_lock)
                {
                    SetProperty(ref _value, value);
                    IsValid = _validationDelegateArr.All(validator => validator(value));
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
