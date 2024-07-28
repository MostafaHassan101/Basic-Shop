using DevExtreme.AspNet.Data.ResponseModel;
using BasicShop.Application.Common.Exceptions;
using BasicShop.Application.Common.Interfaces;
using BasicShop.Application.Common.Models;
using BasicShop.Application.SearchCatalog;
using BasicShop.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BasicShop.Infrastructure.SearchCatalog;
class ProductSearch : IProductSearch
{
    private readonly IApplicationDbContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public ProductSearch(IApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<IQueryable<Product>> SearchByKeywordAsync(string keyword, CancellationToken cancellationToken)
    {
        keyword = keyword.ToLower();
        var result = await Task.Run(() => _context.Products.AsNoTracking().Where(pro => pro.Name.ToLower().Contains(keyword)), cancellationToken);
        return result;
    }

}