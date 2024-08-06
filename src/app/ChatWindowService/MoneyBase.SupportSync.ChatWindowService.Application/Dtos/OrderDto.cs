using MoneyBase.SupportSync.ChatWindowService.Domain.Enums;

namespace MoneyBase.SupportSync.ChatWindowService.Application.Dtos;

public record OrderDto(
    Guid Id,
    Guid CustomerId,
    string OrderName,
    AddressDto ShippingAddress,
    AddressDto BillingAddress,
    PaymentDto Payment,
    OrderStatus Status,
    List<OrderItemDto> OrderItems);
