using Domain.Entities.Common;

namespace Application.Repositories;

public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity, new()
{
    Task<bool> AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);
    bool Update(T entity);
    void UpdateRange(IEnumerable<T> entities);
    bool Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);
    Task<int> SaveAsync();
}