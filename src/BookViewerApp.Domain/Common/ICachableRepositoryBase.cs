namespace BookViewerApp.Domain.Common
{
    public interface ICachableRepositoryBase<T>
    {
        Task<IReadOnlyList<T>> FindAll();
        Task<int> Update(T entity);
        Task<int> Add(T entity);
        Task<bool> HasCachedData();
    }
}
