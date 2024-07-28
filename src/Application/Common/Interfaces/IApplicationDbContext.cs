namespace BasicShop.Application.Common.Interfaces;

using BasicShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

public interface IApplicationDbContext
{
    DbSet<Product> Products { get; }
    DbSet<Cart> Carts { get; }
    DbSet<CartItem> CartItems { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
