namespace BookViewerApp.MobileApplication.Common.Validation;

public static class ValidatorDelegateFactory
{
    public static Func<T, bool> Required<T>()
    {
        return input =>
        {
            if (input == null) return false;

            if (input is string s)
                return !string.IsNullOrWhiteSpace(s);

            return !input.Equals(default(T));
        };
    }

    public static Func<string?, bool> IsDigit<T>()
    {
        return input => double.TryParse(input, out _);
    }
}

