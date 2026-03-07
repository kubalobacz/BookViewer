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
using CommunityToolkit.Maui;
using FFImageLoading.Maui;
using Microsoft.Extensions.Logging;
using Refit;

namespace BookViewerApp.MobileApplication
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseFFImageLoading()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddRefitClient<IStephenKingApi>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://stephen-king-api.onrender.com/api"));
            builder.Services.AddRefitClient<IPicsumApi>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://picsum.photos"));

            builder.Services.AddSingleton<INavigationService, NavigationService>();
            builder.Services.AddScoped<IImageResizer, ImageResizer>();

            builder.Services.AddTransient<BookCollectionBreakdownViewModel>();
            builder.Services.AddTransient<AddBookViewModel>();
            builder.Services.AddTransient<BookCollectionBreakdownPage>();
            builder.Services.AddTransient<AddBookPage>();
            builder.Services.AddScoped<IImageSaver, ImageSaver>();

            builder.Services.AddSingleton<IBooksRepository>(sp =>
            {
                var stephenKingApiService = sp.GetRequiredService<IStephenKingApi>();
                var directory = FileSystem.Current.AppDataDirectory;
                return new BooksRepository(stephenKingApiService, directory);
            });
            builder.Services.AddSingleton<IImageRepository>(sp =>
            {
                var picsumApi = sp.GetRequiredService<IPicsumApi>();
                var imageResizer = sp.GetRequiredService<IImageResizer>();
                var imageSaver = sp.GetRequiredService<IImageSaver>();
                var directory = AppDirectoryPaths.ImagePath;
                return new ImageRepository(picsumApi, imageResizer, imageSaver, directory);
            });
            builder.Services.AddScoped<GetAllBooksUseCase>();
            builder.Services.AddScoped<AddBookUseCase>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
