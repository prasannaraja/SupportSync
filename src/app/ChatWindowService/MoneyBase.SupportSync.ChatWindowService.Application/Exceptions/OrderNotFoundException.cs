using MoneyBase.SupportSync.Core.Exceptions;

namespace MoneyBase.SupportSync.ChatWindowService.Application.Exceptions;
public class OrderNotFoundException : NotFoundException
{
    public OrderNotFoundException(Guid id) : base("Order", id)
    {
    }
}
