using BookViewerApp.MobileApplication.Common.Screen;

namespace BookViewerApp.MobileApplication.Presentation.General.Views;

public partial class LoadingPopupView : ContentView
{
    public LoadingPopupView()
    {
        InitializeComponent();
        HeightRequest = ScreenMeasureCalculator.GetScreenHeightInDIU();
        WidthRequest = ScreenMeasureCalculator.GetScreenWidthInDIU();
    }
}