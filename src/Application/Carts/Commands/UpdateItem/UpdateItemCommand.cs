using AutoMapper;
using BasicShop.Application.Common.Exceptions;
using BasicShop.Application.Common.Interfaces;
using BasicShop.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BasicShop.Application.Carts.Commands.UpdateItem;

public record UpdateItemCommand : IRequest
{
	public Guid Id { get; init; }
	public int Quantity { get; init; }
}

public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand>
{
	private readonly IApplicationDbContext _context;
	private readonly IMapper _mapper;
	public UpdateItemCommandHandler(IApplicationDbContext context, IMapper mapper)
	{
        _context = context;
        _mapper = mapper;
    }
	public async Task Handle(UpdateItemCommand request, CancellationToken cancellationToken)
	{
		var cartItem = await _context.CartItems.FirstOrDefaultAsync(item => item.Id == request.Id, cancellationToken) ??
                        throw new NotFoundException(nameof(CartItem), request.Id);

		if (request.Quantity > 0 && request.Quantity <= 50)
			cartItem.Quantity = request.Quantity;
		else
			throw new BadRequestException("Invalid Quantity");

        await _context.SaveChangesAsync(cancellationToken);
	}
}