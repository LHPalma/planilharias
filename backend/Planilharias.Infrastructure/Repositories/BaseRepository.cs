using Microsoft.EntityFrameworkCore;
using Planilharias.Domain.Repositories;
using Planilharias.Infrastructure.Data;

namespace Planilharias.Infrastructure.Repositories;

public class BaseRepository<T>(PlanilhariasDbContext db) : IBaseRepository<T>
    where T : class
{
    protected readonly PlanilhariasDbContext Db = db;

    public Task<List<T>> GetAllAsync()
    {
        return db.Set<T>().ToListAsync();
    }


    public Task<T?> FindByIdAsync(Guid id)
    {
        return db.Set<T>().FindAsync(id).AsTask();
    }


    public async Task<T> GetByIdAsync(Guid id)
    {
        return await db.Set<T>().FindAsync(id) ?? throw new KeyNotFoundException($"{typeof(T).Name} {id} not found");
    }


    public async Task<T> AddAsync(T entity)
    {
        var entry = await db.Set<T>().AddAsync(entity);
        await db.SaveChangesAsync();
        return entry.Entity;
    }


    public async Task<T> UpdateAsync(T entity)
    {
        var entry = db.Set<T>().Update(entity);
        await db.SaveChangesAsync();
        return entry.Entity;
    }


    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        db.Set<T>().Remove(entity);
        await db.SaveChangesAsync();
    }
}