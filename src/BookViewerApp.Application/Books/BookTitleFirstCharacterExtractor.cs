namespace BookViewerApp.Application.Books
{
    public class BookTitleFirstCharacterExtractor
    {
        public char DecideBookTitleFirstLetter(string title)
        {
            //Requirements specified only A-Z characters but wasn't sure what to do with other cases
            if (string.IsNullOrWhiteSpace(title))
                return '#';

            string[] prefixesToSkip = { "The ", "A ", "An " };

            foreach (var prefix in prefixesToSkip)
            {
                if (title.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                {
                    title = title.Substring(prefix.Length);
                    break;
                }
            }

            var firstChar = char.ToUpper(title.TrimStart()[0]);

            if (firstChar < 'A' || firstChar > 'Z')
                return '#';

            return firstChar;
        }
    }
}
