namespace BookViewerApp.MobileApplication.Presentation.General.Views;

public partial class GeneralEntry : VerticalStackLayout
{
    public GeneralEntry()
    {
        InitializeComponent();
    }

    public object EntryText
    {
        get => (object)GetValue(EntryTextProperty);
        set => SetValue(EntryTextProperty, value);
    }

    public string HeaderText
    {
        get => (string)GetValue(HeaderTextProperty);
        set => SetValue(HeaderTextProperty, value);
    }

    public bool IsValid
    {
        get => (bool)GetValue(IsValidProperty);
        set => SetValue(IsValidProperty, value);
    }

    public static readonly BindableProperty EntryTextProperty = BindableProperty.Create(nameof(EntryText), typeof(object), typeof(GeneralButton), null, BindingMode.TwoWay);
    public static readonly BindableProperty HeaderTextProperty = BindableProperty.Create(nameof(HeaderText), typeof(string), typeof(GeneralEntry), string.Empty);
    public static readonly BindableProperty IsValidProperty = BindableProperty.Create(nameof(IsValid), typeof(bool), typeof(GeneralEntry), false);

}