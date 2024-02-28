using RpgGame.Domain.Entities;

namespace RpgGame.Repository
{
    public interface IEFCoreRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(string id);
        Task<bool> SaveChangeAsync();
    }
}
