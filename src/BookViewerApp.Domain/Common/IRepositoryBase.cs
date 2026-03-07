namespace BookViewerApp.Domain.Common
{
    public interface IRepositoryBase<T>
    {
        Task<IReadOnlyList<T>> FindAll();
        Task<int> Update(T entity);
        Task<int> Add(T entity);
    }
}
