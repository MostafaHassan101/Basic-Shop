using AutoMapper;
using AutoMapper.QueryableExtensions;
using BasicShop.Application.Carts.Queries;
using BasicShop.Application.Common.Exceptions;
using BasicShop.Application.Common.Interfaces;
using BasicShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BasicShop.Infrastructure.Services;

public class CartService : ICartService
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public CartService(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Cart> GetCartAsync(Guid customerId, CancellationToken cancellationToken)
    {
        var cart = await _context.Carts.FirstOrDefaultAsync(c => c.CustomerId == customerId, cancellationToken);

        if (cart == null)
        {
            cart = new Cart { CustomerId = customerId };
            await _context.Carts.AddAsync(cart, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        return cart;
    }

    public async Task AddCartItemAsync(Guid customerId, Guid productId, int quantity, CancellationToken cancellationToken)
    {
        var cart = await GetCartAsync(customerId, cancellationToken);

        var product = await _context.Products.FindAsync(productId, cancellationToken);
        if (product == null)
            throw new BadRequestException();


        var item = await TryGetCartItemAsync(productId, cart.Id, cancellationToken);

        if (item != null)
        {
            item.Quantity += quantity;
            await _context.SaveChangesAsync(cancellationToken);
            return;
        }

        CartItem cartItem = new()
        {
            CartId = cart.Id,
            ProductId = productId,
            Quantity = quantity,
        };
        await _context.CartItems.AddAsync(cartItem);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteCartItemAsync(Guid cartItemId, CancellationToken cancellationToken)
    {
        var Item =await _context.CartItems.SingleAsync(ci => ci.Id == cartItemId, cancellationToken);
        _context.CartItems.Remove(Item);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<CartItem?> TryGetCartItemAsync(Guid productId, Guid cartId, CancellationToken cancellationToken)
    {
        var cartItem = await _context.CartItems.FirstOrDefaultAsync(ci => ci.ProductId == productId && ci.CartId == cartId, cancellationToken);

        return cartItem;
    }

    public async Task UpdateCartItemAsync(Guid cartItemId, int quantity, CancellationToken cancellationToken)
    {
        var cartItem = await _context.CartItems.FirstOrDefaultAsync(ci => ci.Id == cartItemId);
        cartItem.Quantity = quantity;
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IQueryable<CartItemDto>> GetCartItemsAsync(Guid customerId, CancellationToken cancellationToken)
    {
        var cartItemsQuery = _context.CartItems.Include(p => p.Product)
            .AsNoTracking().Where(ci => ci.Cart.CustomerId == customerId && ci.Product.IsVisible)
            .ProjectTo<CartItemDto>(_mapper.ConfigurationProvider);

        return await Task.Run(() => cartItemsQuery, cancellationToken);
    }
}