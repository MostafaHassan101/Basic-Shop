using AutoMapper;
using AutoMapper.QueryableExtensions;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using BasicShop.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BasicShop.Application.Products.Queries.GetProductsQuery;

public record GetProductsQuery : IRequest<LoadResult>
{
    public DataSourceLoadOptionsBase LoadOptions { get; init; } = new DataSourceLoadOptionsBase();
}

public class QueryHandler : IRequestHandler<GetProductsQuery, LoadResult>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public QueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<LoadResult> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Products.AsNoTracking().ProjectTo<GetProductsDto>(_mapper.ConfigurationProvider);

        return await DataSourceLoader.LoadAsync(query, request.LoadOptions);
    }
}
