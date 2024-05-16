

namespace FormBuilder.Modules.Core.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetSingleAsync(string id, string partitionkey);
        Task AddAsync(T item);
        Task UpdateAsync(string partitionkey, T item);
        Task DeleteAsync(string id, string partitionkey);

    }
}
