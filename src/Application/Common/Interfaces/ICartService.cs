using BasicShop.Application.Carts.Queries;
using BasicShop.Domain.Entities;

namespace BasicShop.Application.Common.Interfaces;

public interface ICartService
{
    public Task<Cart> GetCartAsync(Guid customerId, CancellationToken cancellationToken);
    public Task<CartItem?> TryGetCartItemAsync(Guid productId, Guid cartId, CancellationToken cancellationToken);
    public Task<IQueryable<CartItemDto>> GetCartItemsAsync(Guid customerId, CancellationToken cancellationToken);
    public Task AddCartItemAsync(Guid customerId, Guid productId, int quantity, CancellationToken cancellationToken);
    public Task UpdateCartItemAsync(Guid cartItemId, int quantity, CancellationToken cancellationToken);
    public Task DeleteCartItemAsync(Guid cartItemId, CancellationToken cancellationToken);
}
