namespace MoneyBase.SupportSync.ChatWindowService.Application.Dtos;

public record OrderItemDto(Guid OrderId, Guid ProductId, int Quantity, decimal Price);
