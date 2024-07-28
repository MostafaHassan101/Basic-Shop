using BasicShop.Application.Common.Exceptions;
using BasicShop.Application.Common.Interfaces;
using BasicShop.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BasicShop.Application.Products.Commands.DeleteProductCommand;

public record DeleteProductCommand : IRequest
{
	public Guid Id { get; init; }
}

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteProductCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
	{
		var product = await _context.Products.FirstOrDefaultAsync(pro => pro.Id == request.Id, cancellationToken)??
                        throw new NotFoundException(nameof(Product), request.Id);

        _context.Products.Remove(product);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
