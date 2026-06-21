using Planilharias.Domain.Specifications;

namespace Planilharias.Domain.Repositories;

public interface IBaseRepository<T>
    where T : class
{
    Task<List<T>> GetAllAsync();

    Task<T> GetByIdAsync(Guid id);

    Task<T?> FindByIdAsync(Guid id);

    Task<T> AddAsync(T entity);

    Task<T> UpdateAsync(T entity);

    Task DeleteAsync(Guid id);

    Task<T?> FirstOrDefaultAsync(ISpecification<T> spec);
}