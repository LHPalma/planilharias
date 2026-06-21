using Microsoft.EntityFrameworkCore;
using Planilharias.Domain.Specifications;

namespace Planilharias.Infrastructure.Specifications;

public static class SpecificationEvaluator
{
    public static IQueryable<T> Apply<T>(IQueryable<T> query, ISpecification<T> spec)
        where T : class
        => spec.Includes.Aggregate(query.Where(spec.Criteria), (current, include) => current.Include(include));
}