using Microsoft.EntityFrameworkCore;
using MoneyBase.SupportSync.ChatWindowService.Domain.Models;

namespace MoneyBase.SupportSync.ChatWindowService.Application.Data;
public interface IApplicationDbContext
{
    DbSet<Customer> Customers { get; }
    DbSet<Product> Products { get; }
    DbSet<Order> Orders { get; }
    DbSet<OrderItem> OrderItems { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
