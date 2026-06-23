using Planilharias.Domain.Specifications;

namespace Planilharias.Domain.Repositories;

public interface IBaseRepository<T>
    where T : class
{
    Task<List<T>> GetAllAsync(CancellationToken ct);

    Task<T> GetByIdAsync(Guid id, CancellationToken ct);

    Task<T?> FindByIdAsync(Guid id, CancellationToken ct);

    Task<T> AddAsync(T entity, CancellationToken ct);

    Task<T> UpdateAsync(T entity, CancellationToken ct);

    Task DeleteAsync(Guid id, CancellationToken ct);

    Task<T?> FirstOrDefaultAsync(ISpecification<T> spec, CancellationToken ct);
}
