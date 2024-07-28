using BasicShop.Application.Common.Exceptions;
using BasicShop.Application.Common.Interfaces;
using BasicShop.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BasicShop.Application.Carts.Commands.DeleteItem;

public record DeleteItemCommand : IRequest
{
	public Guid Id { get; init; }
}

public class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommand>
{
	private readonly IApplicationDbContext _context;
    public DeleteItemCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task Handle(DeleteItemCommand request, CancellationToken cancellationToken)
	{
        var item = await _context.CartItems.FirstOrDefaultAsync(i => i.Id == request.Id, cancellationToken) ??
                        throw new NotFoundException(nameof(CartItem), request.Id);
        _context.CartItems.Remove(item);
        await _context.SaveChangesAsync(cancellationToken);
	}
}
