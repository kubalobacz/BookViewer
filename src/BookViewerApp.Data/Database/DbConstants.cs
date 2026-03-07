namespace BookViewerApp.Data.Database
{
    static class DbConstants
    {
        public const string DatabaseFilename = "BookViewerLocalDB.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            SQLite.SQLiteOpenFlags.ReadWrite |
            SQLite.SQLiteOpenFlags.Create |
            SQLite.SQLiteOpenFlags.SharedCache;
    }
}
