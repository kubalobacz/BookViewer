namespace BookViewerApp.MobileApplication.Common.Screen
{
    class ScreenMeasureCalculator
    {
        public double GetScreenWidthInDIU()
        {
            var mainDisplay = DeviceDisplay.MainDisplayInfo;
            double widthDIU = mainDisplay.Width / mainDisplay.Density;
            return widthDIU;
        }

        public double GetScreenHeightInDIU()
        {
            var mainDisplay = DeviceDisplay.MainDisplayInfo;
            double heightDIU = mainDisplay.Height / mainDisplay.Density;
            return heightDIU;
        }
    }
}
