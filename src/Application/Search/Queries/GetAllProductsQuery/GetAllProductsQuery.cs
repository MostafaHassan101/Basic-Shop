using DevExtreme.AspNet.Data;
using MediatR;
using BasicShop.Application.Common.Interfaces;
using BasicShop.Application.Search.Queries.DTOs;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using BasicShop.Domain.Entities;
using System.Collections.Generic;

namespace BasicShop.Application.Search.Queries.GetAllProductsQuery;


public record GetAllProductsQuery : IRequest<IEnumerable<ProductResultDto>>
{
    public bool IsAdmin { get; set; } = false;
}

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductResultDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllProductsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductResultDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
	{
        IEnumerable<ProductResultDto> response;
        if(!request.IsAdmin)
            response = await _context.Products.Where(p => p.IsVisible).ProjectTo<ProductResultDto>(_mapper.ConfigurationProvider).ToListAsync();

        else
            response = await _context.Products.ProjectTo<ProductResultDto>(_mapper.ConfigurationProvider).ToListAsync();


        return response;
    }
}