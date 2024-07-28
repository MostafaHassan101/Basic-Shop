using AutoMapper;
using BasicShop.Application.Common.Interfaces;
using BasicShop.Application.Common.Mappings;
using BasicShop.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BasicShop.Application.Products.Commands.CreateProductCommand;

public record CreateProductCommand : IRequest, IMapFrom<CreateProductDto>
{
    public string Name { get; set; } = null!;
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public bool IsVisible { get; set; }

}

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CreateProductCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
	{
        var product = _mapper.Map<CreateProductDto>(request);
        var productEntity = _mapper.Map<Product>(product);
        await _context.Products.AddAsync(productEntity);
        await _context.SaveChangesAsync(cancellationToken);
	}
}