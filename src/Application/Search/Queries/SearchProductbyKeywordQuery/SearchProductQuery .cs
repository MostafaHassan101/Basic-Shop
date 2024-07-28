using AutoMapper;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using BasicShop.Application.Common.Interfaces;
using BasicShop.Application.Common.Security;
using BasicShop.Application.SearchCatalog;
using BasicShop.Domain.Entities;
using MediatR;
using Microsoft.Win32;
using System.Linq.Expressions;
using BasicShop.Application.Search.Queries.DTOs;

namespace BasicShop.Application.Search.Queries.SearchProductQuery;

public record SearchProductQuery : IRequest<IEnumerable<ProductResultDto>>
{
    public string SearchKeyword { get; init; } = null!;
    public bool IsAdmin { get; init; } = false;
}

public class SearchProductQueryHandler : IRequestHandler<SearchProductQuery, IEnumerable<ProductResultDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IProductSearch _productSearch;
    private readonly IMapper _mapper;
    public SearchProductQueryHandler(IApplicationDbContext context, IMapper mapper, IProductSearch productSearch)
    {
        _context = context;
        _mapper = mapper;
        _productSearch = productSearch;
    }
    public async Task<IEnumerable<ProductResultDto>> Handle(SearchProductQuery request, CancellationToken cancellationToken)
    {
       var products = await _productSearch.SearchByKeywordAsync(request.SearchKeyword, cancellationToken);

        if(!request.IsAdmin)
            products = products.Where(p => p.IsVisible);

        return _mapper.Map<IEnumerable<ProductResultDto>>(products);
    }
}