using Application.Repositories;
using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System.Linq.Expressions;

namespace Persistence.Repositories;

public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity, new()
{
    private readonly DbSet<T> _entity;

    public ReadRepository(RentalDbContext dbContext)
    {
        _entity = dbContext.Set<T>();
    }

    public IQueryable<T> Get(Expression<Func<T, bool>> filter, bool tracking = true)
    {
        IQueryable<T> query = _entity.Where(filter).AsQueryable();
        if (!tracking) query.AsNoTracking();
        return query;
    }

    public async Task<T> GetByIdAsync(int id, bool tracking = true, params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _entity.AsQueryable();

        if (includes.Any())
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }

        if (!tracking) query = query.AsNoTracking();

        return await query.FirstAsync(p => p.Id == id);
    }
}