using MoneyBase.SupportSync.ChatWindowService.Domain.Abstractions;
using MoneyBase.SupportSync.ChatWindowService.Domain.Models;

namespace MoneyBase.SupportSync.ChatWindowService.Domain.Events;

public record OrderCreatedEvent(Order order) : IDomainEvent;
