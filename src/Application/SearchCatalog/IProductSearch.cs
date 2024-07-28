using BasicShop.Domain.Entities;

namespace BasicShop.Application.SearchCatalog;

public interface IProductSearch//, IMapFrom<T>
{
    Task<IQueryable<Product>> SearchByKeywordAsync(string keyword, CancellationToken cancellationToken);

}
