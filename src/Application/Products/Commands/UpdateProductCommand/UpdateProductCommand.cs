using AutoMapper;
using BasicShop.Application.Common.Exceptions;
using BasicShop.Application.Common.Interfaces;
using BasicShop.Application.Common.Mappings;
using BasicShop.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BasicShop.Application.Products.Commands.UpdateProductCommand;

public record UpdateProductCommand : IRequest, IMapFrom<UpdateProductDto>
{
	public Guid Id { get; init; }
    public string Name { get; set; } = null!;
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public bool IsVisible { get; set; }

}

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
{
	private readonly IApplicationDbContext _context;
	private readonly IMapper _mapper;
    public UpdateProductCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
	{
		var product = await _context.Products.FirstOrDefaultAsync(pro => pro.Id == request.Id) ??
                        throw new NotFoundException(nameof(Product), request.Id);

        var mappedRequest = _mapper.Map<UpdateProductDto>(request);

        _mapper.Map(mappedRequest, product);
        await _context.SaveChangesAsync(cancellationToken);
	}
}
