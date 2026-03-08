namespace BookViewerApp.MobileApplication.Common.AppFileSystem;

public static class AppDirectoryPaths
{
    public static string AppData { get; } = FileSystem.Current.AppDataDirectory;

    public static string ImagePath { get; } = InitializeImagePath();

    private static string InitializeImagePath()
    {
        var path = Path.Combine(AppData, "Images");

        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);

        return path;
    }
}
