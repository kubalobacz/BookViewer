namespace BookViewerApp.MobileApplication.Common.Screen
{
    public static class ScreenMeasureCalculator
    {
        public static double GetScreenWidthInDIU()
        {
            var mainDisplay = DeviceDisplay.MainDisplayInfo;
            double widthDIU = mainDisplay.Width / mainDisplay.Density;
            return widthDIU;
        }

        public static double GetScreenHeightInDIU()
        {
            var mainDisplay = DeviceDisplay.MainDisplayInfo;
            double heightDIU = mainDisplay.Height / mainDisplay.Density;
            return heightDIU;
        }
    }
}
