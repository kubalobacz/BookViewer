using BookViewerApp.Application.Books.UseCases;
using BookViewerApp.Application.Common.Interfaces;
using BookViewerApp.Data.Books.API;
using BookViewerApp.Data.Books.Repositories;
using BookViewerApp.Data.Common;
using BookViewerApp.Data.Common.Interfaces;
using BookViewerApp.Domain.Books.Contracts;
using BookViewerApp.MobileApplication.Common.AppFileSystem;
using BookViewerApp.MobileApplication.Common.Navigation.INavigationService;
using BookViewerApp.MobileApplication.Presentation.Books.Page;
using BookViewerApp.MobileApplication.Presentation.Books.ViewModel;
using Refit;

namespace BookViewerApp.MobileApplication.Common.IoC
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterViewModelsAndPages(this IServiceCollection services)
        {
            services.AddTransient<BookCollectionBreakdownViewModel>();
            services.AddTransient<AddBookViewModel>();
            services.AddTransient<BookCollectionBreakdownPage>();
            services.AddTransient<AddBookPage>();
        }

        public static void RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddRefitClient<IStephenKingApi>()
               .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://stephen-king-api.onrender.com/api"));
            services.AddRefitClient<IPicsumApi>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://picsum.photos"));

            services.AddSingleton<INavigationService, NavigationService>();
            services.AddScoped<IImageResizer, ImageResizer>();
            services.AddScoped<IImageSaver, ImageSaver>();
        }

        public static void RegisterUseCases(this IServiceCollection services)
        {
            services.AddScoped<GetAllBooksUseCase>();
            services.AddScoped<AddBookUseCase>();
        }

        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IBooksRepository>(sp =>
            {
                var stephenKingApiService = sp.GetRequiredService<IStephenKingApi>();
                var directory = FileSystem.Current.AppDataDirectory;
                return new BooksRepository(stephenKingApiService, directory);
            });
            services.AddSingleton<IImageRepository>(sp =>
            {
                var picsumApi = sp.GetRequiredService<IPicsumApi>();
                var imageResizer = sp.GetRequiredService<IImageResizer>();
                var imageSaver = sp.GetRequiredService<IImageSaver>();
                var directory = AppDirectoryPaths.ImagePath;
                return new ImageRepository(picsumApi, imageResizer, imageSaver, directory);
            });
        }
    }
}
