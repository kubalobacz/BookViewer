namespace BookViewerApp.MobileApplication.Common.IoC
{
    public static class ServiceResolver
    {
        public static object? GetService(Type serviceType)
        {
            var serviceCollection = IPlatformApplication.Current!.Services;
            return serviceCollection.GetService(serviceType);
        }
    }
}
