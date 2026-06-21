using System.Linq.Expressions;

namespace Planilharias.Domain.Specifications;

public abstract class Specification<T>(
    Expression<Func<T, bool>> criteria
) : ISpecification<T>
{
    public Expression<Func<T, bool>> Criteria { get; } = criteria;

    public List<Expression<Func<T, object>>> Includes { get; } = [];

    protected void AddInclude(Expression<Func<T, object>> include)
        => Includes.Add(include);
}