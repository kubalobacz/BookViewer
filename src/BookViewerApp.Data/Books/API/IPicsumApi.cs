using Refit;

namespace BookViewerApp.Data.Books.API
{
    public interface IPicsumApi
    {
        [Get("/200/300")]
        public Task<HttpResponseMessage> GetRandomImage();
    }
}
