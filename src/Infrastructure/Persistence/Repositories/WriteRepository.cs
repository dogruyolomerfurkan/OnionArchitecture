using Application.Repositories;
using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity, new()
{
    private readonly DbSet<T> _entity;
    private readonly RentalDbContext _dbContext;

    public DbSet<T> Entity => _entity;

    public WriteRepository(RentalDbContext dbContext)
    {
        _dbContext = dbContext;
        _entity = dbContext.Set<T>();
    }
    public async Task<bool> AddAsync(T entity)
    {
        var entityEntry = await _entity.AddAsync(entity);
        return entityEntry.State == EntityState.Added;
    }

    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await _entity.AddRangeAsync(entities);
    }

    public bool Update(T entity)
    {
        var entityEntry = _entity.Attach(entity);
        //todo this might change
        return entityEntry.State == EntityState.Modified;

    }

    public void UpdateRange(IEnumerable<T> entities)
    {
        _entity.AttachRange(entities);
    }

    public bool Remove(T entity)
    {
        var entityEntry = _entity.Remove(entity);
        return entityEntry.State == EntityState.Deleted;
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        _entity.RemoveRange(entities);
    }

    public async Task<int> SaveAsync()
    {

        return await _dbContext.SaveChangesAsync();
    }
}