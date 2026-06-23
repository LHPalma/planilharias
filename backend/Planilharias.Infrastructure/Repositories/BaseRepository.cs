using Microsoft.EntityFrameworkCore;
using Planilharias.Domain.Repositories;
using Planilharias.Domain.Specifications;
using Planilharias.Infrastructure.Data;
using Planilharias.Infrastructure.Specifications;

namespace Planilharias.Infrastructure.Repositories;

public class BaseRepository<T>(PlanilhariasDbContext db) : IBaseRepository<T>
    where T : class
{
    protected readonly PlanilhariasDbContext Db = db;

    public Task<List<T>> GetAllAsync(CancellationToken ct)
    {
        return db.Set<T>().ToListAsync(ct);
    }


    public Task<T?> FindByIdAsync(Guid id, CancellationToken ct)
    {
        return db.Set<T>().FindAsync([id], ct).AsTask();
    }

    public async Task<T> GetByIdAsync(Guid id, CancellationToken ct)
    {
        return await db.Set<T>().FindAsync([id], ct) ?? throw new KeyNotFoundException($"{typeof(T).Name} {id} not found");
    }


    public async Task<T> AddAsync(T entity, CancellationToken ct)
    {
        var entry = await db.Set<T>().AddAsync(entity, ct);
        await db.SaveChangesAsync(ct);
        return entry.Entity;
    }


    public async Task<T> UpdateAsync(T entity, CancellationToken ct)
    {
        var entry = db.Set<T>().Update(entity);
        await db.SaveChangesAsync(ct);
        return entry.Entity;
    }


    public async Task DeleteAsync(Guid id, CancellationToken ct)
    {
        var entity = await GetByIdAsync(id, ct);
        db.Set<T>().Remove(entity);
        await db.SaveChangesAsync(ct);
    }

    public Task<T?> FirstOrDefaultAsync(ISpecification<T> spec, CancellationToken ct)
    {
        return SpecificationEvaluator.Apply(db.Set<T>(), spec).FirstOrDefaultAsync(ct);
    }
}
