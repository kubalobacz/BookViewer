using System.Windows.Input;

namespace BookViewerApp.MobileApplication.Presentation.General.Views;

public partial class GeneralButton : Border
{
	public GeneralButton()
	{
		InitializeComponent();
	}

    public ICommand Command
    {
        get => (ICommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(GeneralButton), null);
    public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(GeneralButton), null);

}