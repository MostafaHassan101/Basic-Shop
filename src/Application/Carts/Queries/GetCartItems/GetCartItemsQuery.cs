using BasicShop.Application.Common.Interfaces;
using BasicShop.Application.Search.Queries.DTOs;
using BasicShop.Domain.Common;
using BasicShop.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BasicShop.Application.Carts.Queries.GetCartItems;

public record GetCartItemsQuery : IRequest<CartResultDto>
{
}

public class GetCartItemsQueryHandler : IRequestHandler<GetCartItemsQuery, CartResultDto>
{
	private readonly ICartService _cartService;

    public GetCartItemsQueryHandler(ICartService cartService)
    {
        _cartService = cartService;
    }

    public async Task<CartResultDto> Handle(GetCartItemsQuery request, CancellationToken cancellationToken)
	{
		var userId = SysConstants.UserId;

		var cartItems = await _cartService.GetCartItemsAsync(userId, cancellationToken);

        var result = await cartItems.ToListAsync();

        decimal totalPrice = result.Sum(c => c.Price * c.Quantity);

        return new CartResultDto { Items = result, Total = totalPrice };
	}
}
