using MediatR;

namespace MoneyBase.SupportSync.Core.CQRS;
public interface IQuery<out TResponse> : IRequest<TResponse>
    where TResponse : notnull
{
}
