using SleekCart.Application.Abstractions.Queries;

namespace SleekCart.Shared.Abstractions.Queries;
public interface IQueryHandler<TQuery, TResult>
    where TQuery: IQuery<TResult> where TResult: new()
{
    Task<TResult> HandleAsync(TQuery query, CancellationToken ct);
}