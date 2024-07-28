using AutoMapper;
using BasicShop.Application.Common.Exceptions;
using BasicShop.Application.Common.Interfaces;
using BasicShop.Domain.Common;
using BasicShop.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BasicShop.Application.Carts.Commands.AddItem;

public record AddItemCommand : IRequest
{
	public Guid CustomerId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}

public class AddItemCommandHandler : IRequestHandler<AddItemCommand>
{
	private readonly IApplicationDbContext _context;
	private readonly IMapper _mapper;
    private readonly ICartService _cartService;
    public AddItemCommandHandler(IApplicationDbContext context, IMapper mapper, ICartService cartService)
    {
        _context = context;
        _mapper = mapper;
        _cartService = cartService;
    }

    public async Task Handle(AddItemCommand request, CancellationToken cancellationToken)
    {
        request.CustomerId = SysConstants.UserId;

        await _cartService.AddCartItemAsync(request.CustomerId, request.ProductId, request.Quantity, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);
    }
}